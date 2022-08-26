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
			//Read the file
			entities = File.Read();
			
			//Filter the data
			lines = Entities.GetLines(entities);
			arcs = Entities.GetArcs(entities);

			//Modify the data
			float gap = Position.Gap(lines);
			lines = Position.OffsetLines(lines,gap);
			arcs = Position.OffsetArcs(arcs,gap);

			//Revisualize the data
			View.Refresh();
		}
				
		private void View_Paint(object sender, PaintEventArgs e)
		{
			if (entities != null)
			{				
				Graphics myGraphics = e.Graphics;
				//Mirror Axis
				Matrix cartesian = new Matrix(1, 0, 0, -1, 0, 0);
				myGraphics.Transform = cartesian;
				//Moves Origin Point
				myGraphics.TranslateTransform(View.Width - (View.Width/10), View.Height / 2, MatrixOrder.Append);

				Visualize.Axes(myGraphics, View.Width, View.Height);
				Visualize.Die(myGraphics,lines,arcs);
			}
		}				
	}
}
