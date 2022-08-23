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
		public MainApp()
		{
			InitializeComponent();			
		}

		

		private void View_MouseMove(object sender, MouseEventArgs e)
		{
			coordinates.Text = string.Format("{0}, {1}", e.Location.X, e.Location.Y);
		}

		private void loadDXFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			entities = DxfFile.Read();
			View.Refresh();
		}
				
		private void View_Paint(object sender, PaintEventArgs e)
		{
			if (entities != null)
			{				
				SolidBrush mySolidBrush1 = new SolidBrush(Color.Red);
				SolidBrush mySolidBrush2 = new SolidBrush(Color.Yellow);


				Graphics myGraphics = e.Graphics;
				Matrix myMatrix = new Matrix(1, 0, 0, -1, 0, 0); //Mirror Axis
				myGraphics.Transform = myMatrix;
				myGraphics.TranslateTransform(View.Width/2, View.Height/2, MatrixOrder.Append); //Moves Origin Point
				
				myGraphics.DrawLine(new Pen(Color.Black), -View.Width / 2, 0, View.Width / 2, 0);
				myGraphics.DrawLine(new Pen(Color.Black), 0, -View.Height / 2, 0, View.Height / 2);

				List<Line> lines = Entities.GetLines(entities);
				List<Arc> arcs = Entities.GetArcs(entities);

				foreach (Line line in lines)
				{
					myGraphics.DrawLine(new Pen(Color.Black), line.StartX, line.StartY, line.EndX, line.EndY);
				}

				Pen pen = new Pen(Color.Red);
				RectangleF rectangle;
				float cornerX;
				float cornerY;
				float width;
				float height;
				float startAngle;
				float sweepAngle;
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
					
					
					myGraphics.DrawArc(pen, rectangle, startAngle, sweepAngle);
				}

				//Rectangle rec = new Rectangle(50,-150,100,100);
				//myGraphics.DrawArc(new Pen(Color.Red), rec, 225, 225 - 74);

				//myGraphics.DrawArc(new Pen(Color.DarkViolet), rec, 0, 90);

			}
		}

		private void View_SizeChanged(object sender, EventArgs e)
		{
			View.Refresh();
		}
	}
}
