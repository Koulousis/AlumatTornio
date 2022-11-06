using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Actions;
using DXF.Elements;
using DXF.Lathe;
using DXF.Properties;

namespace DXF
{
	public partial class MainApp : Form
	{
		public static List<string> DxfText { get; set; }
		public static List<Line> Lines { get; set; }
		public static List<Arc> Arcs { get; set; }
		public static float ZoomFactor = 1f;
		public static List<GCodePoint> GCodePoints { get; set; }
		
		public static string DxfFileName = "Default";

		public MainApp()
		{
			InitializeComponent();
		}

		private void MainApp_Load(object sender, EventArgs e)
		{
			statusLabel.Text = "Not selected";
			statusLabel.ForeColor = Color.Red;

			depthOfCutInput.Value = Convert.ToDecimal(Settings.Default["G71DepthOfCut"]);
			retractValueInput.Value = Convert.ToDecimal(Settings.Default["G71RetractValue"]);
			xAllowanceInput.Value = Convert.ToDecimal(Settings.Default["G71XAllowance"]);
			zAllowanceInput.Value = Convert.ToDecimal(Settings.Default["G71ZAllowance"]);
			feedRateInput.Value = Convert.ToDecimal(Settings.Default["G71FeedRate"]);
		}

		private void fileDxfMenuItem_Click(object sender, EventArgs e)
		{
			//Prompt the user to select dxf and if selected continue
			exportProgressBar.Value = 0;
			gCodeTextBox.Lines = new[] { "" };
			Lines = new List<Line>();
			Arcs = new List<Arc>();
			GCodePoints = new List<GCodePoint>();
			if (!Read.DxfFile()) return;

			Read.DxfLines();
			Remove.DuplicateLines();
			Read.DxfArcs();
			Remove.DuplicateArcs();

			//Modify the data
			float gap = Get.Gap();
			Edit.OffsetLines(gap);
			//Get.OffsetArcs(gap);

			Edit.AddIndexesAndMakeCorrections();
			//Re-visualize the data
			statusLabel.Text = "Opened";
			statusLabel.ForeColor = Color.Orange;
			View.Refresh();
		}

		private void View_Paint(object sender, PaintEventArgs e)
		{
			//Setup Graphics and modify origin point and coordinates to cartesian system
			Graphics preview = e.Graphics;
			preview.SmoothingMode = SmoothingMode.AntiAlias;
			Matrix cartesian = new Matrix(1, 0, 0, -1, 0, 0);
			preview.Transform = cartesian;
			preview.TranslateTransform(Get.TransformWidth(View.Width), Get.TransformWidth(View.Height), MatrixOrder.Append);
			
			if (axesVisualizeCheckBox.Checked) { Visualize.Axes(preview, (float)View.Width / ZoomFactor, (float)View.Height / ZoomFactor); }

			if (MainApp.DxfText != null) {
				ZoomFactor = Get.Scale(View.Width, View.Height);
				preview.ScaleTransform(ZoomFactor, ZoomFactor);
				//Create die path
				//GraphicsPath diePath = Create.Path();
				GraphicsPath diePath = Create.FullPath();
				GraphicsPath g71Profile = Create.G71Profile();

				//Visualize
				if (dieVisualizeCheckBox.Checked) { Visualize.Die(preview, diePath); }
				if (profileVisualizeCheckBox.Checked) { Visualize.G71Profile(preview, g71Profile); }

				GCode.G71(preview);
			}
		}

		private void exportGCode_Click(object sender, EventArgs e)
		{
			exportProgressBar.Value = 0;
			for (int i = 0; i < 100; i++) { for (int j = 0; j < 10000; j++) { } exportProgressBar.Value++; }

			//Set G71 Attributes
			G71Attributes g71Attributes = new G71Attributes(depthOfCutInput.Value, retractValueInput.Value, xAllowanceInput.Value, zAllowanceInput.Value, feedRateInput.Value);

			//Fill G-Code Text
			GCode.Text.AddRange(CodeBlock.LatheInitialization());
			GCode.Text.AddRange(CodeBlock.StartPosition());
			GCode.Text.AddRange(CodeBlock.G71Roughing(g71Attributes));
			GCode.Text.AddRange(CodeBlock.G71Profile());
			GCode.Text.AddRange(CodeBlock.G70Finishing());
			GCode.Text.AddRange(CodeBlock.LatheEnd());

			//G-Code Text Export
			GCode.Export();

			//Update Status
			statusLabel.Text = "Exported";
			statusLabel.ForeColor = Color.Green;
			gCodeTextBox.Lines = GCode.Text.ToArray();
		}
		
		private void View_MouseMove(object sender, MouseEventArgs e)
		{
			//Pixels to millimeters
			//Graphics object to retrieve data
			Graphics screen = CreateGraphics();

			//Move X and Y origin location
			double cursorPositionX = Get.TransformWidth(View.Width) - e.Location.X;
			double cursorPositionY = Get.TransformHeight(View.Height) - e.Location.Y;
			//Transform pixels to millimeters
			cursorPositionX += 25.4f / screen.DpiX;
			cursorPositionY += 25.4f / screen.DpiY;

			//Set Labels text to X and Y mouse position
			coordinatesLabel.Text = $@"{cursorPositionX / ZoomFactor,0:F3}, {(cursorPositionY / ZoomFactor) * 2,0:F3}";
		}

		private void axesVisualizeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			View.Refresh();
		}

		private void dieVisualizeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			View.Refresh();
		}

		private void profileVisualizeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			View.Refresh();
		}

		private void changeDXFFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var folderBrowserDialog = new FolderBrowserDialog();
			DialogResult result = folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				Settings.Default["DxfFolderPath"] = folderBrowserDialog.SelectedPath;
				Settings.Default.Save();
			}
		}
		private void changeExportFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var folderBrowserDialog = new FolderBrowserDialog();
			DialogResult result = folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				Settings.Default["ExportFolderPath"] = folderBrowserDialog.SelectedPath;
				Settings.Default.Save();
			}
		}

		private void g71RoughingCycleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (Form form = new Form())
			{
				Bitmap img = Resources.g71_roughing_cycle;

				form.StartPosition = FormStartPosition.CenterScreen;
				Size size = new Size(img.Width / 2, img.Height / 2);
				form.Size = size;
				form.ShowIcon = false;

				PictureBox pb = new PictureBox();
				pb.SizeMode = PictureBoxSizeMode.StretchImage;
				pb.Dock = DockStyle.Fill;
				pb.Image = img;

				form.Controls.Add(pb);
				form.ShowDialog();
			}
		}

		private void g72FacingCycleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (Form form = new Form())
			{
				Bitmap img = Resources.g72_facing_cycle;

				form.StartPosition = FormStartPosition.CenterScreen;
				Size size = new Size(img.Width / 2, img.Height / 2);
				form.Size = size;
				form.ShowIcon = false;

				PictureBox pb = new PictureBox();
				pb.SizeMode = PictureBoxSizeMode.StretchImage;
				pb.Dock = DockStyle.Fill;
				pb.Image = img;

				form.Controls.Add(pb);
				form.ShowDialog();
			}
		}

		private void depthOfCutInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71DepthOfCut"] = depthOfCutInput.Value;
			Settings.Default.Save();
		}

		private void retractValueInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71RetractValue"] = retractValueInput.Value;
			Settings.Default.Save();
		}

		private void xAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71XAllowance"] = xAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void zAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71ZAllowance"] = zAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void feedRateInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71FeedRate"] = feedRateInput.Value;
			Settings.Default.Save();
		}
	}
}
