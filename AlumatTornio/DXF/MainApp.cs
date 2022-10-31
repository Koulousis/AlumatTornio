using DXF.Modify;
using DXF.SetupFile;
using DXF.SetupView;
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
using DXF.Generate;

namespace DXF
{
	public partial class MainApp : Form
	{
		public static List<string> DxfText { get; set; }
		public static List<Line> Lines { get; set; }
		public static List<Arc> Arcs { get; set; }
		public static float ZoomFactor = 1f;

		public static List<GCodePoint> GCodePoints { get; set; }

		public MainApp()
		{
			InitializeComponent();
		}		

		private void View_MouseMove(object sender, MouseEventArgs e)
		{
			//Pixels to millimeters
			//Graphics object to retrieve data
			Graphics screen = CreateGraphics();

			//Move X and Y origin location
			double cursorPositionX = Get.TransforWidth(View.Width) - e.Location.X;
			double cursorPositionY = Get.TransforHeight(View.Height) - e.Location.Y;
			//Transform pixels to millimeters
			cursorPositionX += 25.4f / screen.DpiX;			
			cursorPositionY += 25.4f / screen.DpiY;

			//Set Labels text to X and Y mouse position
			coordinatesLabel.Text = $@"{cursorPositionX / ZoomFactor,0:F3}, {cursorPositionY / ZoomFactor,0:F3}";
		}

		private void fileDxfMenuItem_Click(object sender, EventArgs e)
		{
			//Prompt the user to select dxf and if selected continue
			Lines = new List<Line>();
			Arcs = new List<Arc>();
			GCodePoints = new List<GCodePoint>();
			if (!File.ReadDxf()) return;
			
			FromDxf.GetLines();
			FromDxf.RemoveDuplicateLines();
			FromDxf.GetArcs();
			FromDxf.RemoveDuplicateArcs();

			//Modify the data
			float gap = Position.GetGap();
			//Position.OffsetLines(gap);
			//Position.OffsetArcs(gap);

			Create.Indexes();
			//Re-visualize the data
			View.Refresh();
		}

		private void View_Paint(object sender, PaintEventArgs e)
		{
			if (MainApp.DxfText != null)
			{	
				//Setup Graphics and modify origin point and coordinates to cartesian system
				Graphics preview = e.Graphics;
				preview.SmoothingMode = SmoothingMode.AntiAlias;
				Matrix cartesian = new Matrix(1, 0, 0, -1, 0, 0);
				preview.Transform = cartesian;
				preview.TranslateTransform(Get.TransforWidth(View.Width), Get.TransforWidth(View.Height), MatrixOrder.Append);
				ZoomFactor = Get.Scale(View.Width, View.Height);
				preview.ScaleTransform(ZoomFactor, ZoomFactor);

				//Create die path
				//GraphicsPath diePath = Create.Path();
				GraphicsPath diePath = Create.FullPath();
				GraphicsPath g71Profile = Create.G71Profile();

				//Visualize
				if (axesVisualizeCheckBox.Checked) { Visualize.Axes(preview, (float)View.Width / ZoomFactor, (float)View.Height / ZoomFactor); }
				if (dieVisualizeCheckBox.Checked) { Visualize.Die(preview, diePath); }
				if (profileVisualizeCheckBox.Checked) { Visualize.G71Profile(preview, g71Profile); }

				Cycle.G71(preview);
			}
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

		private void exportGCode_Click(object sender, EventArgs e)
		{
			exportProgressBar.Value = 0;
			for (int i = 0; i < 100; i++)
			{
				for (int j = 0; j < 10000; j++)
				{
					
				}
				exportProgressBar.Value++;
			}

			
			Cycle.G71Profile();
		}
	}
}
