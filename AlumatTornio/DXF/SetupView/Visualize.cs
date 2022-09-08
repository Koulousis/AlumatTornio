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
		public static void Axes(Graphics graphics, int crossX, int crossY)
		{
			Pen axisPen = new Pen(Color.DarkGray);
			axisPen.DashStyle = DashStyle.Dash;
			//Draw X Axis
			graphics.DrawLine(axisPen, -crossX, 0, crossX, 0);
			//Draw Y Axis
			graphics.DrawLine(axisPen, 0, -crossY, 0, crossY);
		}

		public static void Die(Graphics preview, GraphicsPath diePath)
		{
			//Visualize die path
			Pen diePen = new Pen(Color.DarkCyan);
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
			machiningRegion.Exclude(dieRegion);

			//Visualize machining region
			SolidBrush machiningBrush = new SolidBrush(Color.Yellow);
			preview.FillRegion(machiningBrush, machiningRegion);
			machiningBrush.Dispose();
		}
	}
}
