using DXF.Lathe;
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

namespace DXF
{
	public partial class MainApp : Form
	{
		public static List<string> DxfText { get; set; }
		public static List<Line> Lines { get; set; }
		public static List<Arc> Arcs { get; set; }
		public static float ZoomFactor = 1f;
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
			coordinatesLabel.Text = $@"{cursorPositionX / ZoomFactor,0:F2}, {cursorPositionY / ZoomFactor,0:F2}";
		}

		private void fileDxfMenuItem_Click(object sender, EventArgs e)
		{
			//Prompt the user to select dxf and if selected continue
			Lines = new List<Line>();
			Arcs = new List<Arc>();
			if (!File.ReadDxf()) return;
			
			FromDxf.GetLines();
			FromDxf.RemoveDuplicateLines();
			FromDxf.GetArcs();
			FromDxf.RemoveDuplicateArcs();

			//Modify the data
			float gap = Position.GetGap();
			//Position.OffsetLines(gap);
			//Position.OffsetArcs(gap);

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
				GraphicsPath diePath = Create.FullDieProfile();

				//Visualize Axes
				if (axesVisualizeCheckBox.Checked)
				{
					Visualize.Axes(preview, (float)View.Width / ZoomFactor, (float)View.Height / ZoomFactor);
				}

				//Visualize Die
				if (dieVisualizeCheckBox.Checked)
				{
					Visualize.Die(preview, diePath);
				}

				//Visualize machining region
				if (machiningVisualizeCheckBox.Checked)
				{
					Visualize.MachiningRegion(preview, diePath);
				}

				if (scansVisualizeCheckBox.Checked)
				{
					Visualize.MachiningRegionScans(preview, diePath);
				}

				Cycle.G71(preview, diePath);
				//RectangleF[] machiningScanCoordinates = stockRegion.GetRegionScans(cartesian);
				//GraphicsPath newPath = new GraphicsPath();
				//newPath.AddRectangles(rectangles);
				//preview.DrawPath(stockPen, newPath);
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

		private void machiningVisualizeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			View.Refresh();
		}

		private void scansVisualizeCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			View.Refresh();
		}
	}
}
