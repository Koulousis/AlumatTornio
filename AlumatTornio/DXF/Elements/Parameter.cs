using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Elements
{
	public static class Parameter
	{
		#region Setted on file selection
		public static string DxfFileName { get; set; }

		public static List<Line> DieLinesAsDesigned { get; set; }
		public static List<Arc> DieArcsAsDesigned { get; set; }

		public static List<Line> DieLinesFlipped { get; set; }
		public static List<Arc> DieArcsFlipped { get; set; }
		
		public static float DieDiameter { get; set; }
		public static float DieRadius { get; set; }
		public static float DieWidth { get; set; }
		#endregion

		#region Setted on machining setup
		public static List<Line> FirstSideLines { get; set; }
		public static List<Arc> FirstSideArcs { get; set; }
		
		public static List<Line> SecondSideLines { get; set; }
		public static List<Arc> SecondSideArcs { get; set; }

		public static float StockFromDiameter { get; set; }
		public static float StockFromRadius { get; set; }
		public static float StockFromWidthSecondSide { get; set; }
		public static float StockFromWidthFirstSide { get; set; }

		public static List<Line> FirstSideOuterHorizontalMachiningLines { get; set; }
		public static List<Arc> FirstSideOuterHorizontalMachiningArcs { get; set; }
		public static List<Line> FirstSideOuterVerticalMachiningLines { get; set; }

		public static List<Line> SecondSideOuterHorizontalMachiningLines { get; set; }
		public static List<Arc> SecondSideOuterHorizontalMachiningArcs { get; set; }
		public static List<Line> SecondSideOuterVerticalMachiningLines { get; set; }
		#endregion


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
		
		#region Common Values
		#endregion

		#region For GCode
		public static List<GCodePoint> G72ProfilePointsFirstSide { get; set; }
		public static List<GCodePoint> G71ProfilePointsFirstSide { get; set; }

		public static List<GCodePoint> G72ProfilePointsSecondSide { get; set; }
		public static List<GCodePoint> G71ProfilePointsSecondSide { get; set; }

		
		public static float StockDiameterExtra = 1;
		public static float StockDiameterExtraMax = 7;

		
		public static float StockWidthExtra = 2;
		public static float StockWidthExtraMax = 7;

		public static float StockX { get; set; }
		public static float StockZFirstSide { get; set; }
		public static float StockZSecondSide { get; set; }
		public static float CavaExtra { get; set; }

		#endregion

		#region For Settings
		public static float ScaleFactor = 1f;
		public static bool ComesFromFileLoad = false;

		#endregion
	}
}
