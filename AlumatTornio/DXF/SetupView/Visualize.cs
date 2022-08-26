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
		public static void Die(Graphics graphics, List<Line> lines, List<Arc> arcs)
		{
			//Lines
			Pen linePen = new Pen(Color.Black);
			float startX, startY, endX, endY;
			foreach (Line line in lines)
			{
				startX = line.StartX;
				startY = line.StartY;
				endX = line.EndX;
				endY = line.EndY;
				graphics.DrawLine(linePen, startX, startY, endX, endY); ;
			}

			//Arcs
			Pen arcPen = new Pen(Color.Red);
			RectangleF rectangle;
			float cornerX, cornerY, width, height, startAngle, sweepAngle;
			foreach (Arc arc in arcs)
			{
				cornerX = arc.CenterX - arc.Radius;
				cornerY = arc.CenterY - arc.Radius;
				width = arc.Radius * 2;
				height = arc.Radius * 2;

				rectangle = new RectangleF(cornerX, cornerY, width, height);
				startAngle = arc.StartAngle;
				if (arc.StartAngle > arc.EndAngle)
				{
					sweepAngle = 360 - (arc.StartAngle - arc.EndAngle);
				}
				else
				{
					sweepAngle = arc.EndAngle - arc.StartAngle;
				}
				graphics.DrawArc(arcPen, rectangle, startAngle, sweepAngle);
			}
		}

		public static void Axes(Graphics graphics, int crossX, int crossY)
		{
			Pen axisPen = new Pen(Color.DarkGray);
			axisPen.DashStyle = DashStyle.Dash;
			//Draw X Axis
			graphics.DrawLine(axisPen, -crossX, 0, crossX, 0);
			//Draw Y Axis
			graphics.DrawLine(axisPen, 0, -crossY, 0, crossY);
		}
	}
}
