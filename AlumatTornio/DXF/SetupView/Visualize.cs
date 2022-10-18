using DXF.SetupFile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXF.SetupView
{
	public class Visualize
	{		
		public static void Axes(Graphics graphics, float crossX, float crossY)
		{
			Pen axisPen = new Pen(Color.DarkGray);
			axisPen.DashStyle = DashStyle.Dash;
			axisPen.ScaleTransform(1/MainApp.ZoomFactor, 1/MainApp.ZoomFactor);
			axisPen.Alignment = PenAlignment.Center;
			//Draw X Axis
			graphics.DrawLine(axisPen, -crossX, 0, crossX, 0);
			//Draw Y Axis
			graphics.DrawLine(axisPen, 0, -crossY, 0, crossY);
		}

		public static void Die(Graphics preview, GraphicsPath diePath)
		{
			//Visualize die path
			Pen diePen = new Pen(Color.DarkCyan);
			diePen.ScaleTransform(1 / MainApp.ZoomFactor, 1 / MainApp.ZoomFactor);
			diePen.Alignment = PenAlignment.Outset;
			SolidBrush dieBrush = new SolidBrush(Color.DarkCyan);
			preview.DrawPath(diePen, diePath);
			preview.FillPath(dieBrush, diePath);
			diePen.Dispose();
			dieBrush.Dispose();
		}

		public static void MachiningRegion(Graphics preview, GraphicsPath diePath)
		{
			//Create die region
			Region dieRegion = new Region(diePath);

			//Create stock region
			//which is the bounding box of the die section
			RectangleF stockCoordinates = diePath.GetBounds();
			Region stockRegion = new Region(stockCoordinates);

			//Create machining region
			Region machiningRegion = stockRegion;
			//Remove from stock the die region and get the rest
			machiningRegion.Exclude(dieRegion);

			//Visualize machining region
			SolidBrush machiningBrush = new SolidBrush(Color.MediumPurple);
			preview.FillRegion(machiningBrush, machiningRegion);
			machiningBrush.Dispose();
		}

		public static void MachiningRegionScans(Graphics preview, GraphicsPath diePath)
		{
			//Create die region
			Region dieRegion = new Region(diePath);

			//Create stock region
			//which is the bounding box of the die section
			RectangleF stockCoordinates = diePath.GetBounds();
			Region stockRegion = new Region(stockCoordinates);

			//Create machining region
			Region machiningRegion = stockRegion;
			//Remove from stock the die region and get the rest
			machiningRegion.Exclude(dieRegion);

			//Get rectangles which fit on the machining region
			Matrix cartesian = new Matrix(1, 0, 0, 1, 0, 0);
			RectangleF[] machiningRegionScans = machiningRegion.GetRegionScans(cartesian);

			//Add those rectangles in a graphics path
			GraphicsPath scansPath = new GraphicsPath();
			scansPath.AddRectangles(machiningRegionScans);

			//Draw the Path
			Pen machiningRegionsPen = new Pen(Color.Yellow);
			machiningRegionsPen.ScaleTransform(1 / MainApp.ZoomFactor, 1 / MainApp.ZoomFactor);
			machiningRegionsPen.Alignment = PenAlignment.Inset;
			preview.DrawPath(machiningRegionsPen, scansPath);
		}
	}
}
