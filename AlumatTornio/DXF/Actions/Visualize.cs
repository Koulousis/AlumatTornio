using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Elements;

namespace DXF.Actions
{
	public class Visualize
	{		
		public static void Axes(Graphics graphics, float crossX, float crossY)
		{
			//Instantiate a specific Pen
			Pen axisPen = new Pen(Color.DarkGray);
			axisPen.DashStyle = DashStyle.Dash;
			axisPen.ScaleTransform(1/Parameter.ZoomFactor, 1/Parameter.ZoomFactor);
			axisPen.Alignment = PenAlignment.Center;

			//Draw X Axis
			graphics.DrawLine(axisPen, -crossX, 0, crossX, 0);
			//Draw Y Axis
			graphics.DrawLine(axisPen, 0, -crossY, 0, crossY);


			Pen arrowZ = new Pen(Color.Aqua);
			Brush letterZ = new SolidBrush(Color.Aqua);
			Font fontZ = new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel);
			graphics.DrawLine(arrowZ, -220, -40, -200, -40);
			graphics.DrawLine(arrowZ, -200, -38, -200, -42);
			graphics.DrawLine(arrowZ, -200, -42, -195, -40);
			graphics.DrawLine(arrowZ, -195, -40, -200, -38);

			Pen arrowX = new Pen(Color.Aqua);
			graphics.DrawLine(arrowX, -220, -40, -220, -20);
			graphics.DrawLine(arrowX, -222, -20, -218, -20);
			graphics.DrawLine(arrowX, -222, -20, -220, -15);
			graphics.DrawLine(arrowX, -220, -15, -218, -20);

			graphics.Transform = new Matrix(1, 0, 0, 1, 0, 0);
			graphics.DrawString("Z",fontZ, letterZ, 30, 478);
			graphics.DrawString("X", fontZ, letterZ, -3, 450);

			//Dispose
			axisPen.Dispose();
		}

		public static void Die(Graphics preview, GraphicsPath diePath)
		{
			//Instantiate a specific Pen and Brush
			Pen diePen = new Pen(Color.DarkCyan);
			diePen.ScaleTransform(1 / Parameter.ZoomFactor, 1 / Parameter.ZoomFactor);
			diePen.Alignment = PenAlignment.Outset;
			SolidBrush dieBrush = new SolidBrush(Color.DarkCyan);

			//Draw and Fill Full Die Path
			preview.DrawPath(diePen, diePath);
			preview.FillPath(dieBrush, diePath);

			//Dispose
			diePen.Dispose();
			dieBrush.Dispose();
		}

		public static void G71Profile(Graphics preview, GraphicsPath g71Profile)
		{
			//Instantiate a specific Pen
			Pen profilePen = new Pen(Color.Yellow);
			profilePen.DashStyle = DashStyle.Dash;
			profilePen.ScaleTransform(1 / Parameter.ZoomFactor, 1 / Parameter.ZoomFactor);
			profilePen.Alignment = PenAlignment.Center;

			//Draw G71 Profile
			preview.DrawPath(profilePen, g71Profile);

			//Dispose
			profilePen.Dispose();
		}


	}
}
