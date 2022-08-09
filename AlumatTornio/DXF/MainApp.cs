using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXF
{
	public partial class MainApp : Form
	{		
		public MainApp()
		{
			InitializeComponent();
		}

		private void MainForm_Paint(object sender, PaintEventArgs e)
		{
			List<string> entities = DxfFile.Read();
			List<Line> lines = Entities.GetLines(entities);
			List<Arc> arcs = Entities.GetArcs(entities);

			Console.WriteLine(lines.Count.ToString());
			Console.WriteLine(arcs.Count.ToString());

			Graphics graphics = e.Graphics;
			Pen pen = new Pen(Color.Black);
			Brush brush = new SolidBrush(Color.Red);

			foreach (var line in lines)
			{
				graphics.DrawLine(pen, line.StartX, line.StartY, line.EndX, line.EndY);
				
			}

			Console.ReadLine();
		}
	}
}
