using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Elements;
using DXF.Tools;

namespace DXF.Actions
{
	public static class Get
	{
		public static float GapX(List<Line> allLines)
		{
			float gapX = allLines[0].StartX;

			//Get the closest distance from origin
			foreach (Line line in allLines)
			{
				if (line.StartX > gapX)
				{
					gapX = line.StartX;
				}
				if (line.EndX > gapX)
				{
					gapX = line.EndX;
				}
			}
			return gapX;
		}

		public static float GapY(List<Line> allLines)
		{
			float gapY = allLines[0].StartY;

			//Get the closest distance from origin
			foreach (Line line in allLines)
			{
				if (line.StartY < gapY)
				{
					gapY = line.StartY;
				}
				if (line.EndY < gapY)
				{
					gapY = line.EndY;
				}
			}
			return gapY;
		}

		public static List<Line> LinesFromDxf(List<string> dxfText)
		{
			List<Line> dxfLines = new List<Line>();
			for (int i = 0; i < dxfText.Count; i++)
			{
				if (dxfText.ElementAt(i) == "LINE")
				{
					float startX = 0, startY = 0, endX = 0, endY = 0; string color = "";
					do
					{
						i++;
						switch (dxfText.ElementAt(i).Trim())
						{
							case "AcDbEntity":
								color = dxfText.ElementAt(i + 6).Trim();
								if (color.Length > 1) { color = dxfText.ElementAt(i + 4).Trim(); }								break;
							case "10":
								startX = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "20":
								startY = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "11":
								endX = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "21":
								endY = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
						}
					} while (!Validation.DxfElementTitle(dxfText.ElementAt(i + 1)));
					dxfLines.Add(new Line(startX, startY, endX, endY, color));
				}
			}
			return dxfLines;
		}

		public static List<Arc> ArcsFromDxf(List<string> dxfText)
		{
			List<Arc> dxfArcs = new List<Arc>();
			for (int i = 0; i < dxfText.Count; i++)
			{
				if (dxfText.ElementAt(i) == "ARC")
				{
					float centerX = 0, centerY = 0, radius = 0, startAngle = 0, endAngle = 0; string color = "";
					do
					{
						i++;
						switch (dxfText.ElementAt(i).Trim())
						{
							case "AcDbEntity":
								color = dxfText.ElementAt(i + 6).Trim();
								if (color.Length > 1) { color = dxfText.ElementAt(i + 4).Trim(); }
								break;
							case "10":
								centerX = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "20":
								centerY = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "40":
								radius = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "50":
								startAngle = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "51":
								endAngle = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
						}
					} while (!Validation.DxfElementTitle(dxfText.ElementAt(i + 1)));
					dxfArcs.Add(new Arc(centerX, centerY, radius, startAngle, endAngle, color));
				}
			}

			return dxfArcs;
		}
		
		public static List<Line> DieLinesAsDesigned(List<Line> allLines)
		{
			List<Line> dieLines = new List<Line>();
			foreach (Line line in allLines) { dieLines.Add(line.Clone()); }

			//List<Line> anySideLines = new List<Line>(allLines);
			for (int i = 0; i < dieLines.Count; i++)
			{
				if (dieLines[i].Color != Parameter.Green)
				{
					dieLines.Remove(dieLines[i]);
					i--;
				}
			}
			return dieLines;
		}

		public static List<Arc> DieArcsAsDesigned(List<Arc> allArcs)
		{
			List<Arc> dieArcs = new List<Arc>();
			foreach (Arc arc in allArcs) { dieArcs.Add(arc.Clone()); }

			for (int i = 0; i < dieArcs.Count; i++)
			{
				if (dieArcs[i].Color != Parameter.Green)
				{
					dieArcs.Remove(dieArcs[i]);
					i--;
				}
			}
			return dieArcs;
		}

		public static List<Line> DieLinesFlipped(List<Line> dieLines)
		{
			List<Line> dieLinesToBeFlipped = new List<Line>();
			foreach (Line line in dieLines)
			{
				dieLinesToBeFlipped.Add(line.Clone());
			}

			return dieLinesToBeFlipped;
		}

		public static List<Arc> DieArcsFlipped(List<Arc> dieArcs)
		{
			List<Arc> dieArcsToBeFlipped = new List<Arc>();
			foreach (Arc arc in dieArcs)
			{
				dieArcsToBeFlipped.Add(arc.Clone());
			}

			return dieArcsToBeFlipped;
		}

		public static List<Line> OuterHorizontalMachiningLines(List<Line> anySideLines)
		{
			//Read die lines ordered by index
			List<Line> outerHorizontalMachiningLines = new List<Line>();
			foreach (Line line in anySideLines) { outerHorizontalMachiningLines.Add(line.Clone()); }

			//Find the first line which is closer to origin
			Line closerToZeroLine = new Line();
			float closerToZeroX = -100;
			foreach (Line line in outerHorizontalMachiningLines)
			{
				if (line.StartX > closerToZeroX)
				{
					closerToZeroX = line.StartX;
					closerToZeroLine = line;
				}
			}
			
			//Removed the lines which are before the found line
			while (outerHorizontalMachiningLines[0] != closerToZeroLine)
			{
				outerHorizontalMachiningLines.RemoveAt(0);
			}

			//Start the iteration when the coordinates of X is not attached to axis and do it until coordinates of Y are moving negative
			



			float y1 = outerHorizontalMachiningLines[0].StartY;
			float y2 = outerHorizontalMachiningLines[0].EndY;
			bool profileDone = false;

			for (int i = 1; i < outerHorizontalMachiningLines.Count; i++)
			{
				bool atLeastOnePointSmallerY = outerHorizontalMachiningLines[i].StartY < y1 || outerHorizontalMachiningLines[i].EndY < y1 || outerHorizontalMachiningLines[i].StartY < y2 || outerHorizontalMachiningLines[i].EndY < y2;
				if (profileDone)
				{
					outerHorizontalMachiningLines.Remove(outerHorizontalMachiningLines[i]);
					i--;
				}
				else if (atLeastOnePointSmallerY)
				{
					profileDone = true;
					outerHorizontalMachiningLines.Remove(outerHorizontalMachiningLines[i]);
					i--;
				}
				else
				{
					y1 = outerHorizontalMachiningLines[i].StartY;
					y2 = outerHorizontalMachiningLines[i].EndY;
				}
			}



			return outerHorizontalMachiningLines;
		}

		public static List<Arc> OuterHorizontalMachiningArcs(List<Line> anySideLines, List<Arc> anySideArcs)
		{
			List<Arc> horizontalProfileArcs = new List<Arc>();
			foreach (Arc arc in anySideArcs) { horizontalProfileArcs.Add(arc.Clone()); }
			horizontalProfileArcs = horizontalProfileArcs.OrderBy(arc => arc.Index).ToList();

			//Remove arcs that has decreased Y from the previous iterated arc
			horizontalProfileArcs = Remove.NotProfileArcs(anySideLines, horizontalProfileArcs, "Right");

			return horizontalProfileArcs;
		}

		public static List<Line> CavaLines(List<Line> dieLines, List<Line> rightProfileLines, List<Line> leftProfileLines)
		{
			List<Line> cavaLines = new List<Line>();
			foreach (Line line in dieLines) { cavaLines.Add(line.Clone()); }
			cavaLines = Remove.LinesAttachedToAxisX(cavaLines);

			for (int i = 0; i < cavaLines.Count; i++)
			{
				foreach (Line line in rightProfileLines)
				{
					if (cavaLines[i].Index == line.Index)
					{
						cavaLines.Remove(cavaLines[i]);
						i--;
						break;
					}
				}
			}

			for (int i = 0; i < cavaLines.Count; i++)
			{
				foreach (Line line in leftProfileLines)
				{
					if (cavaLines[i].Index == line.Index)
					{
						cavaLines.Remove(cavaLines[i]);
						i--;
						break;
					}
				}
			}


			return cavaLines;
		}

		public static List<Arc> CavaArcs(List<Arc> dieArcs, List<Arc> rightProfileArcs, List<Arc> leftProfilesArcs)
		{
			List<Arc> cavaArcs = new List<Arc>();
			foreach (Arc arc in dieArcs) { cavaArcs.Add(arc.Clone()); }

			for (int i = 0; i < cavaArcs.Count; i++)
			{
				foreach (Arc arc in rightProfileArcs)
				{
					if (cavaArcs[i].Index == arc.Index)
					{
						cavaArcs.Remove(cavaArcs[i]);
						i--;
						break;
					}
				}
			}

			for (int i = 0; i < cavaArcs.Count; i++)
			{
				foreach (Arc arc in leftProfilesArcs)
				{
					if (cavaArcs[i].Index == arc.Index)
					{
						cavaArcs.Remove(cavaArcs[i]);
						i--;
						break;
					}
				}
			}

			return cavaArcs;
		}

		

		
	}
}
