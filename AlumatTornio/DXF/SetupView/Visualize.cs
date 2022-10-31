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
			//Instantiate a specific Pen
			Pen axisPen = new Pen(Color.DarkGray);
			axisPen.DashStyle = DashStyle.Dash;
			axisPen.ScaleTransform(1/MainApp.ZoomFactor, 1/MainApp.ZoomFactor);
			axisPen.Alignment = PenAlignment.Center;

			//Draw X Axis
			graphics.DrawLine(axisPen, -crossX, 0, crossX, 0);
			//Draw Y Axis
			graphics.DrawLine(axisPen, 0, -crossY, 0, crossY);

			//Dispose
			axisPen.Dispose();
		}

		public static void Die(Graphics preview, GraphicsPath diePath)
		{
			//Instantiate a specific Pen and Brush
			Pen diePen = new Pen(Color.DarkCyan);
			diePen.ScaleTransform(1 / MainApp.ZoomFactor, 1 / MainApp.ZoomFactor);
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
			profilePen.ScaleTransform(1 / MainApp.ZoomFactor, 1 / MainApp.ZoomFactor);
			profilePen.Alignment = PenAlignment.Center;

			//Draw G71 Profile
			preview.DrawPath(profilePen, g71Profile);

			//Dispose
			profilePen.Dispose();
		}


	}
}
