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
		#region For DXF
		public static List<string> DxfText { get; set; }
		public static List<Line> AllLines { get; set; }
		public static List<Arc> AllArcs { get; set; }

		public static List<Line> DieLines { get; set; }
		public static List<Arc> DieArcs { get; set; }

		public static List<Line> DieLinesFlipped { get; set; }
		public static List<Arc> DieArcsFlipped { get; set; }

		public static List<Line> G71LinesRightSide { get; set; }
		public static List<Arc> G71ArcsRightSide { get; set; }

		public static List<Line> G71LinesLeftSide { get; set; }
		public static List<Arc> G71ArcsLeftSide { get; set; }

		public static List<Line> CavaLines { get; set; }
		public static List<Arc> CavaArcs { get; set; }

		public static string Red = "1";
		public static string Yellow = "2";
		public static string Green = "3";
		public static string Cyan = "4";
		public static string Blue = "5";
		public static string Magenta = "6";
		public static string White = "7";
		public static string ByBlock = "0";
		public static string ByLayer = "256";
		#endregion

		#region For GCode
		public static List<G71ProfilePoint> G71ProfilePointsRightSide { get; set; }
		public static List<G71ProfilePoint> G71ProfilePointsLeftSide { get; set; }
		public static float StockX { get; set; }
		public static float StockZ { get; set; }
		public static float CavaExtra { get; set; }
		#endregion

		#region For Settings
		public static float ZoomFactor = 1f;
		public static string DxfFileName = "Default";
		#endregion



	}
}
