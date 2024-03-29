﻿using System;
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
		public static string FileName { get; set; }

		public static List<Line> LinesAsDesigned { get; set; }
		public static List<Arc> ArcsAsDesigned { get; set; }

		public static List<Line> LinesFlipped { get; set; }
		public static List<Arc> ArcsFlipped { get; set; }
		
		public static float Diameter { get; set; }
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

		public static List<Line> FirstSideHorizontalProfileLines { get; set; }
		public static List<Arc> FirstSideHorizontalProfileArcs { get; set; }
		public static List<Line> FirstSideFacingProfile { get; set; }
		public static List<Arc> FirstSideOuterVerticalMachiningArcs { get; set; }
		public static List<Line> FirstSideCavaLines { get; set; }
		public static List<Arc> FirstSideCavaArcs { get; set; }

		public static List<Line> SecondSideHorizontalProfileLines { get; set; }
		public static List<Arc> SecondSideHorizontalProfileArcs { get; set; }
		public static List<Line> SecondSideFacingProfile { get; set; }
		public static List<Arc> SecondSideOuterVerticalMachiningArcs { get; set; }
		public static List<Line> SecondSideCavaLines { get; set; }
		public static List<Arc> SecondSideCavaArcs { get; set; }

		public static List<Line> FirstSideCollarinoLines { get; set; }
		public static List<Arc> FirstSideCollarinoArcs { get; set; }
		public static List<Line> SecondSideCollarinoLines { get; set; }
		public static List<Arc> SecondSideCollarinoArcs { get; set; }
		#endregion

		#region Validate dimensions
		public static bool ElementsHasGap { get; set; }
		#endregion

		#region Setted on export
		public static List<ProfilePoint> G72ProfilePointsFirstSide { get; set; }
		public static List<ProfilePoint> G71ProfilePointsFirstSide { get; set; }

		public static List<ProfilePoint> G72ProfilePointsSecondSide { get; set; }
		public static List<ProfilePoint> G71ProfilePointsSecondSide { get; set; }

		public static List<string> GCodeFirstSide { get; set; }
		public static List<string> GCodeSecondSide { get; set; }
		public static Line FirstSideHorizontalProfileLastLine { get; set; }
		public static Line SecondSideHorizontalProfileLastLine { get; set; }
		#endregion

		#region For Settings
		public static float ScaleFactor = 1f;
		public static bool ComesFromFileLoad = false;

		#endregion

		#region DXF Color Tags
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
	}
}
