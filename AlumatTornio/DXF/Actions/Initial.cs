using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;

namespace DXF.Actions
{
	public static class Initial
	{
		public static void GlobalParameters()
		{
			#region Setted on file selection
			Parameter.FileName = string.Empty;

			Parameter.LinesAsDesigned = new List<Line>();
			Parameter.ArcsAsDesigned = new List<Arc>();

			Parameter.LinesFlipped = new List<Line>();
			Parameter.ArcsFlipped = new List<Arc>();

			Parameter.Diameter = 0f;
			Parameter.DieRadius = 0f;
			Parameter.DieWidth = 0f;
			#endregion

			#region Setted on machining setup
			Parameter.FirstSideLines = new List<Line>();
			Parameter.FirstSideArcs = new List<Arc>();
			Parameter.SecondSideLines = new List<Line>();
			Parameter.SecondSideArcs = new List<Arc>();

			Parameter.StockFromDiameter = 0f;
			Parameter.StockFromRadius = 0f;
			Parameter.StockFromWidthSecondSide = 0f;
			Parameter.StockFromWidthFirstSide = 0f;

			Parameter.FirstSideHorizontalProfileLines = new List<Line>();
			Parameter.FirstSideHorizontalProfileArcs = new List<Arc>();
			Parameter.FirstSideFacingProfile = new List<Line>();
			Parameter.FirstSideOuterVerticalMachiningArcs = new List<Arc>();
			Parameter.FirstSideCavaLines = new List<Line>();
			Parameter.FirstSideArcs = new List<Arc>();

			Parameter.SecondSideHorizontalProfileLines = new List<Line>();
			Parameter.SecondSideHorizontalProfileArcs = new List<Arc>();
			Parameter.SecondSideFacingProfile = new List<Line>();
			Parameter.SecondSideOuterVerticalMachiningArcs = new List<Arc>();
			Parameter.SecondSideCavaLines = new List<Line>();
			Parameter.SecondSideCavaArcs = new List<Arc>();

			Parameter.FirstSideCollarinoLines = new List<Line>();
			Parameter.FirstSideCollarinoArcs = new List<Arc>();
			Parameter.SecondSideCollarinoLines = new List<Line>();
			Parameter.SecondSideCollarinoArcs = new List<Arc>();
			#endregion

			#region Validate dimensions
			Parameter.ElementsHasGap = false;
			#endregion

			#region #Setted on cava manipulation
			Parameter.FirstSideHorizontalProfileLastLine = new Line();
			Parameter.SecondSideHorizontalProfileLastLine = new Line();
			#endregion

			#region Setted on export
			Parameter.G72ProfilePointsFirstSide = new List<ProfilePoint>();
			Parameter.G71ProfilePointsFirstSide = new List<ProfilePoint>();

			Parameter.G72ProfilePointsSecondSide = new List<ProfilePoint>();
			Parameter.G71ProfilePointsSecondSide = new List<ProfilePoint>();

			Parameter.GCodeFirstSide = new List<string>();
			Parameter.GCodeSecondSide = new List<string>();
			#endregion
		}
}
}
