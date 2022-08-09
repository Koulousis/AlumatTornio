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

		

		private void View_MouseMove(object sender, MouseEventArgs e)
		{
			coordinates.Text = string.Format("{0}, {1}", e.Location.X, e.Location.Y);
		}

		private void loadDXFToolStripMenuItem_Click(object sender, EventArgs e)
		{
			List<string> entities = DxfFile.Read();
			List<Line> lines = Entities.GetLines(entities);
			List<Arc> arcs = Entities.GetArcs(entities);

			Console.WriteLine(lines.Count.ToString());
			Console.WriteLine(arcs.Count.ToString());
			Console.ReadLine();
		}
	}
}
