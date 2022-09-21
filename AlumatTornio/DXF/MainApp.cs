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
		public static List<string> entities;
		public static List<Line> lines;
		public static List<Arc> arcs;
		public static float zoomFactor = 1.5f;
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
			double cursorPositionX = View.Width - View.Width/10 - e.Location.X;
			double cursorPositionY = View.Height / 2 - e.Location.Y;
			//Transform pixels to millimeters
			cursorPositionX = cursorPositionX + 25.4f / screen.DpiX;			
			cursorPositionY = cursorPositionY + 25.4f / screen.DpiY;

			//Set Labels text to X and Y mouse position
			coordinatesLabel.Text = string.Format("{0,0:F2}, {1,0:F2}", cursorPositionX / zoomFactor, cursorPositionY / zoomFactor);
		}

		private void fileDxfMenuItem_Click(object sender, EventArgs e)
		{
			//Read the file
			entities = File.Read();
			if (File.choosedFile)
			{
				//Filter the data
				lines = Entities.GetLines(entities);
				lines = Entities.RemoveDuplicateLines(lines);
				arcs = Entities.GetArcs(entities);
				arcs = Entities.RemoveDuplicateArcs(arcs);

				//Modify the data
				float gap = Position.Gap(lines);
				lines = Position.OffsetLines(lines, gap);
				arcs = Position.OffsetArcs(arcs, gap);

				//Revisualize the data
				View.Refresh();
			}
		}

		private void View_Paint(object sender, PaintEventArgs e)
		{
			if (entities != null)
			{	
				//Setup Graphics and modify origin point and coordinates to cartesian system
				Graphics preview = e.Graphics;
				Matrix cartesian = new Matrix(1, 0, 0, -1, 0, 0);
				preview.Transform = cartesian;
				preview.TranslateTransform(View.Width - (View.Width/10), View.Height / 2, MatrixOrder.Append);
				preview.ScaleTransform(zoomFactor, zoomFactor);				

				//Create die path
				GraphicsPath diePath = Create.Path(lines,arcs);

				//Visualize Axes
				if (axesVisualizeCheckBox.Checked)
				{
					Visualize.Axes(preview, View.Width, View.Height);
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



				//RectangleF[] machiningScanCoordinates = stockRegion.GetRegionScans(cartesian);
				//GraphicsPath newPath = new GraphicsPath();
				//newPath.AddRectangles(rectangles);
				//preview.DrawPath(stockPen, newPath);



				Console.ReadLine();

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
