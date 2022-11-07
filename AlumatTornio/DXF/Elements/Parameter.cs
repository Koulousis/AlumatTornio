using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Elements
{
	public static class Parameter
	{
		public static List<string> DxfText { get; set; }
		public static List<Line> AllLines { get; set; }
		public static List<Arc> AllArcs { get; set; }
		public static List<Line> DieLines { get; set; }
		public static List<Arc> DieArcs { get; set; }
		public static float ZoomFactor = 1f;
		public static List<GCodePoint> GCodePoints { get; set; }

		public static string DxfFileName = "Default";
	}
}
