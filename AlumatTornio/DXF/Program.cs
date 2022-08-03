using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXF
{
	public class Program
	{
		//[STAThread]
		static void Main(string[] args)
		{
			//List<string> entities = DxfFile.Read();
			//List<Line> lines = Entities.GetLines(entities);
			//List<Arc> arcs = Entities.GetArcs(entities);

			//Console.WriteLine(lines.Count.ToString());
			//Console.WriteLine(arcs.Count.ToString());

			Application.Run(new MainApp());
		}
	}
}
