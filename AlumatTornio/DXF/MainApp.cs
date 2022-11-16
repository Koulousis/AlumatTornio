using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Actions;
using DXF.Organizer;
using DXF.Elements;
using DXF.Lathe;
using DXF.Properties;
using DXF.Tools;

namespace DXF
{
	public partial class MainApp : Form
	{
		public MainApp()
		{
			InitializeComponent();
		}

		#region Application Load
		private void MainApp_Load(object sender, EventArgs e)
		{
			statusLabel.Text = "Not selected";
			statusLabel.ForeColor = Color.Red;

			g71DepthOfCutInput.Value = Convert.ToDecimal(Settings.Default["G71DepthOfCut"]);
			g71RetractInput.Value = Convert.ToDecimal(Settings.Default["G71Retract"]);
			g71XAllowanceInput.Value = Convert.ToDecimal(Settings.Default["G71XAllowance"]);
			g71ZAllowanceInput.Value = Convert.ToDecimal(Settings.Default["G71ZAllowance"]);
			g71FeedRateInput.Value = Convert.ToDecimal(Settings.Default["G71FeedRate"]);

			g72DepthOfCutInput.Value = Convert.ToDecimal(Settings.Default["G72DepthOfCut"]);
			g72RetractInput.Value = Convert.ToDecimal(Settings.Default["G72Retract"]);
			g72XAllowanceInput.Value = Convert.ToDecimal(Settings.Default["G72XAllowance"]);
			g72ZAllowanceInput.Value = Convert.ToDecimal(Settings.Default["G72ZAllowance"]);
			g72FeedRateInput.Value = Convert.ToDecimal(Settings.Default["G72FeedRate"]);
		}
		#endregion

		#region Visualization Events
		private void View_Paint(object sender, PaintEventArgs e)
		{
			//Setup Graphics and modify origin point and coordinates to cartesian system
			Graphics preview = e.Graphics;
			preview.SmoothingMode = SmoothingMode.AntiAlias;
			Matrix cartesian = new Matrix(1, 0, 0, -1, 0, 0);
			preview.Transform = cartesian;
			preview.TranslateTransform(Calculation.TransformWidth(VisuilizationPanel.Width), Calculation.TransformWidth(VisuilizationPanel.Height), MatrixOrder.Append);

			if (axesVisualizeCheckBox.Checked) { Visualize.Axes(preview, (float)VisuilizationPanel.Width * Elements.Parameter.ZoomFactor, (float)VisuilizationPanel.Height * Elements.Parameter.ZoomFactor); }
			preview.Transform = new Matrix(1, 0, 0, -1, 0, 0);
			preview.TranslateTransform(Calculation.TransformWidth(VisuilizationPanel.Width), Calculation.TransformWidth(VisuilizationPanel.Height), MatrixOrder.Append);

			if (Parameter.DxfText == null) return;
			Parameter.ZoomFactor = Calculation.Scale(VisuilizationPanel.Width, VisuilizationPanel.Height);
			preview.ScaleTransform(Parameter.ZoomFactor, Parameter.ZoomFactor);
			//Create die path
			//GraphicsPath diePath = Create.Path();
			GraphicsPath diePath = Create.FullPath();
			GraphicsPath g71Profile = Create.G71Profile();

			//Visualize
			if (dieVisualizeCheckBox.Checked) { Visualize.Die(preview, diePath); }
			if (profileVisualizeCheckBox.Checked) { Visualize.G71Profile(preview, g71Profile); }

			GCode.G71(preview);
		}

		private void View_MouseMove(object sender, MouseEventArgs e)
		{
			//Pixels to millimeters
			//Graphics object to retrieve data
			Graphics screen = CreateGraphics();

			//Move X and Y origin location
			double cursorPositionX = Calculation.TransformWidth(VisuilizationPanel.Width) - e.Location.X;
			double cursorPositionY = Calculation.TransformHeight(VisuilizationPanel.Height) - e.Location.Y;
			//Transform pixels to millimeters
			cursorPositionX += 25.4f / screen.DpiX;
			cursorPositionY += 25.4f / screen.DpiY;

			//Set Labels text to X and Y mouse position
			coordinatesLabel.Text = $@"X:{(cursorPositionY / Elements.Parameter.ZoomFactor),0:F3}, Z:{-cursorPositionX / Elements.Parameter.ZoomFactor,0:F3}";
		}
		#endregion

		#region Visualize Options
		private void axesVisualizeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			VisuilizationPanel.Refresh();
		}

		private void dieVisualizeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			VisuilizationPanel.Refresh();
		}

		private void profileVisualizeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			VisuilizationPanel.Refresh();
		}
		#endregion

		#region Menu File
		private void fileDxfMenuItem_Click(object sender, EventArgs e)
		{
			//Initialize elements parameters
			exportProgressBar.Value = 0;
			gCodeTextBox.Lines = new[] { "" };
			
			//Trigger the user to select a file via a dialog with dxf files filter
			OpenFileDialog selectDxfDialog = new OpenFileDialog()
			{
				Title = @"Select file",
				InitialDirectory = Settings.Default["DxfFolderPath"].ToString(),
				DefaultExt = @".dxf",
				Filter = @"DXF Files (*.dxf)|*.dxf"
			};

			Dxf.Manage(selectDxfDialog);

			//Re-visualize the data
			statusLabel.Text = "Opened";
			statusLabel.ForeColor = Color.Orange;
			VisuilizationPanel.Refresh();
		}
		#endregion

		#region Menu Settings
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

		private void openDXFFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(Settings.Default["DxfFolderPath"].ToString());
		}

		private void openExportFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(Settings.Default["ExportFolderPath"].ToString());
		}
		#endregion

		#region Menu Infos
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
		#endregion

		#region Export
		private void exportGCode_Click(object sender, EventArgs e)
		{
			//Update Progress Bar
			exportProgressBar.Value = 0;
			for (int i = 0; i < 100; i++) { for (int j = 0; j < 10000; j++) { } exportProgressBar.Value++; }

			//Set G71 Attributes
			G71Attributes g71Attributes = new G71Attributes(g71DepthOfCutInput.Value, g71RetractInput.Value, g71XAllowanceInput.Value, g71ZAllowanceInput.Value, g71FeedRateInput.Value);
			G72Attributes g72Attributes = new G72Attributes(g72DepthOfCutInput.Value, g72RetractInput.Value, g72XAllowanceInput.Value, g72ZAllowanceInput.Value, g72FeedRateInput.Value);

			//Get G71 profile points
			Parameter.G71ProfilePoints = Create.G71ProfilePoints(Parameter.G71Lines, Parameter.G71Arcs);
			Parameter.StockX = 3;
			Parameter.StockZ = 3;

			//Fill G-Code Text
			GCode.Text.AddRange(CodeBlock.LatheInitialization());
			GCode.Text.AddRange(CodeBlock.StartPosition(Parameter.G71ProfilePoints));
			GCode.Text.AddRange(CodeBlock.G71Roughing(g71Attributes));
			GCode.Text.AddRange(CodeBlock.G71Profile(Parameter.G71ProfilePoints));
			GCode.Text.AddRange(CodeBlock.G70Finishing());
			GCode.Text.AddRange(CodeBlock.LatheEnd());

			//G-Code Text Export
			GCode.Export();

			//Update File Status
			statusLabel.Text = "Exported";
			statusLabel.ForeColor = Color.Green;
			gCodeTextBox.Lines = GCode.Text.ToArray();
		}
		#endregion

		#region G71 Cycle Values Save
		private void g71DepthOfCutInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71DepthOfCut"] = g71DepthOfCutInput.Value;
			Settings.Default.Save();
		}

		private void g71RetractInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71Retract"] = g71RetractInput.Value;
			Settings.Default.Save();
		}

		private void g71XAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71XAllowance"] = g71XAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void g71ZAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71ZAllowance"] = g71ZAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void g71FeedRateInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71FeedRate"] = g71FeedRateInput.Value;
			Settings.Default.Save();
		}
		#endregion

		#region G72 Cycle Values Save
		private void g72DepthOfCutInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G72DepthOfCut"] = g72DepthOfCutInput.Value;
			Settings.Default.Save();
		}

		private void g72RetractInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G72Retract"] = g72RetractInput.Value;
			Settings.Default.Save();
		}

		private void g72XAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G72XAllowance"] = g72XAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void g72ZAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G72ZAllowance"] = g72ZAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void g72FeedRateInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G72FeedRate"] = g72FeedRateInput.Value;
			Settings.Default.Save();
		}
		#endregion
		
	}
}
