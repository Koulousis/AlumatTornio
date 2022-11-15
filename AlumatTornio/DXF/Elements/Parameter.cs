using System;
using System.Collections.Generic;
using System.Drawing;
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
		public static List<Line> G71Lines { get; set; }
		public static List<Arc> G71Arcs { get; set; }

		public static float ZoomFactor = 1f;
		public static List<GCodePoint> GCodePoints { get; set; }

		public static string DxfFileName = "Default";
		
		public static string Red = "1";
		public static string Yellow = "2";
		public static string Green = "3";
		public static string Cyan = "4";
		public static string Blue = "5";
		public static string Magenta = "6";
		public static string White = "7";
		public static string ByBlock = "0";
		public static string ByLayer = "256";
	}
}
