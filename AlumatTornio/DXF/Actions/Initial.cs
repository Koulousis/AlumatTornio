using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;

namespace DXF.Actions
{
	public class Initial
	{
		public static void GlobalParameters()
		{
			Parameter.DxfFileName = string.Empty;
			Parameter.AllLines = new List<Line>();
			Parameter.AllArcs = new List<Arc>();

			Parameter.FirstSideLines = new List<Line>();
			Parameter.FirstSideArcs = new List<Arc>();

			Parameter.SecondSideLines = new List<Line>();
			Parameter.SecondSideArcs = new List<Arc>();
	}
	}
}
