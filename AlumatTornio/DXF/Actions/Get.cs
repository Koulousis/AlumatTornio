﻿using System;
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
			
			//Remove the lines which are before the closer to zero line
			while (outerHorizontalMachiningLines[0] != closerToZeroLine)
			{
				outerHorizontalMachiningLines.RemoveAt(0);
			}

			//Remove lines while it's moving across Y Axis
			while (outerHorizontalMachiningLines[0].StartX == 0 && outerHorizontalMachiningLines[0].EndX == 0)
			{
				outerHorizontalMachiningLines.RemoveAt(0);
			}

			//Keep the lines in the list while the Y points are not going to negative direction
			int i = 0;
			while (outerHorizontalMachiningLines[i].StartY <= outerHorizontalMachiningLines[i].EndY)
			{
				i++;
			}
			outerHorizontalMachiningLines.RemoveRange(i, outerHorizontalMachiningLines.Count - i);

			return outerHorizontalMachiningLines;
		}

		public static List<Arc> OuterHorizontalMachiningArcs(List<Line> outerHorizontalMachiningLines, List<Arc> anySideArcs)
		{
			List<Arc> outerHorizontalMachiningArcs = new List<Arc>();
			foreach (Arc arc in anySideArcs) { outerHorizontalMachiningArcs.Add(arc.Clone()); }

			int i = 0;
			if (outerHorizontalMachiningLines.First().Index < outerHorizontalMachiningLines.Last().Index)
			{
				while (anySideArcs[i].Index < outerHorizontalMachiningLines[outerHorizontalMachiningLines.Count - 1].Index)
				{
					i++;
				}
				outerHorizontalMachiningArcs.RemoveRange(i, outerHorizontalMachiningArcs.Count - i);
			}
			else if (outerHorizontalMachiningLines.First().Index > outerHorizontalMachiningLines.Last().Index)
			{
				while (anySideArcs[i].Index > outerHorizontalMachiningLines[outerHorizontalMachiningLines.Count - 1].Index)
				{
					i++;
				}
				outerHorizontalMachiningArcs.RemoveRange(i, outerHorizontalMachiningArcs.Count - i);
			}
			
			

			return outerHorizontalMachiningArcs;
		}

		public static List<Line> FirstSideStockMachiningLines(List<Line> firstSideMachiningLines, List<Arc> firstSideMachiningArcs)
		{
			List<Line> firstSideStockMachiningLines = new List<Line>();

			PointF firstProfilePoint = new PointF();
			PointF lastProfilePoint = new PointF();
			int stockStartHorizontalIndex = 0;
			int stockStartVerticalIndex = 0;
			int stockEndVerticalIndex = 0;

			//Check if the first side is as designed or flipped
			if (firstSideMachiningLines.First().Index < firstSideMachiningLines.Last().Index)
			{
				//find the first profile point coordinates which can be line or arc
				if (firstSideMachiningLines.First().Index < firstSideMachiningArcs.First().Index)
				{
					firstProfilePoint.X = firstSideMachiningLines.First().StartX;
					firstProfilePoint.Y = firstSideMachiningLines.First().StartY;
					stockStartHorizontalIndex = firstSideMachiningLines.First().Index - 1;
					stockStartVerticalIndex = firstSideMachiningLines.First().Index - 2;
				}
				else if (firstSideMachiningArcs.First().Index < firstSideMachiningLines.First().Index)
				{
					firstProfilePoint.X = firstSideMachiningArcs.First().StartX;
					firstProfilePoint.Y = firstSideMachiningArcs.First().StartY;
					stockStartHorizontalIndex = firstSideMachiningArcs.First().Index - 1;
					stockStartVerticalIndex = firstSideMachiningArcs.First().Index - 2;
				}
				//find the last profile point coordinates which can be line or arc
				if (firstSideMachiningLines.Last().Index > firstSideMachiningArcs.Last().Index)
				{
					lastProfilePoint.X = firstSideMachiningLines.Last().EndX;
					lastProfilePoint.Y = firstSideMachiningLines.Last().EndY;
					stockEndVerticalIndex = firstSideMachiningLines.Last().Index + 1;
				}
				else if (firstSideMachiningArcs.Last().Index > firstSideMachiningLines.Last().Index)
				{
					lastProfilePoint.X = firstSideMachiningArcs.Last().EndX;
					lastProfilePoint.Y = firstSideMachiningArcs.Last().EndY;
					stockEndVerticalIndex = firstSideMachiningArcs.Last().Index + 1;
				}
			}
			else if (firstSideMachiningLines.First().Index > firstSideMachiningLines.Last().Index)
			{
				//find the first profile point coordinates which can be line or arc
				if (firstSideMachiningLines.First().Index > firstSideMachiningArcs.First().Index)
				{
					firstProfilePoint.X = firstSideMachiningLines.First().StartX;
					firstProfilePoint.Y = firstSideMachiningLines.First().StartY;
					stockStartHorizontalIndex = firstSideMachiningLines.First().Index + 1;
					stockStartVerticalIndex = firstSideMachiningLines.First().Index + 2;
				}
				else if (firstSideMachiningArcs.First().Index > firstSideMachiningLines.First().Index)
				{
					firstProfilePoint.X = firstSideMachiningArcs.First().StartX;
					firstProfilePoint.Y = firstSideMachiningArcs.First().StartY;
					stockStartHorizontalIndex = firstSideMachiningArcs.First().Index + 1;
					stockStartVerticalIndex = firstSideMachiningArcs.First().Index + 2;
				}
				//find the last profile point coordinates which can be line or arc
				if (firstSideMachiningLines.Last().Index < firstSideMachiningArcs.Last().Index)
				{
					lastProfilePoint.X = firstSideMachiningLines.Last().EndX;
					lastProfilePoint.Y = firstSideMachiningLines.Last().EndY;
					stockEndVerticalIndex = firstSideMachiningLines.Last().Index - 1;
				}
				else if (firstSideMachiningArcs.Last().Index < firstSideMachiningLines.Last().Index)
				{
					lastProfilePoint.X = firstSideMachiningArcs.Last().EndX;
					lastProfilePoint.Y = firstSideMachiningArcs.Last().EndY;
					stockEndVerticalIndex = firstSideMachiningArcs.Last().Index - 1;
				}
			}

			Line stockStartHorizontal = new Line(Parameter.StockFromWidthFirstSide, firstProfilePoint.Y, firstProfilePoint.X, firstProfilePoint.Y, Parameter.Green);
			stockStartHorizontal.Index = stockStartHorizontalIndex;

			Line stockStartVertical = new Line(Parameter.StockFromWidthFirstSide, Parameter.DieRadius + Parameter.StockFromRadius, stockStartHorizontal.StartX, stockStartHorizontal.StartY, Parameter.Green);
			stockStartVertical.Index = stockStartVerticalIndex;

			Line stockEndVertical = new Line(lastProfilePoint.X, lastProfilePoint.Y, lastProfilePoint.X, lastProfilePoint.Y + Parameter.StockFromRadius, Parameter.Green);
			stockEndVertical.Index = stockEndVerticalIndex;

			firstSideStockMachiningLines.Insert(0, stockEndVertical);
			firstSideStockMachiningLines.Insert(0, stockStartHorizontal);
			firstSideStockMachiningLines.Insert(0, stockStartVertical);

			return firstSideStockMachiningLines;
		}

		public static List<Line> SecondSideStockMachiningLines(List<Line> secondSideMachiningLines, List<Arc> secondSideMachiningArcs)
		{
			List<Line> secondSideStockMachiningLines = new List<Line>();

			PointF firstProfilePoint = new PointF();
			PointF lastProfilePoint = new PointF();
			int stockStartHorizontalIndex = 0;
			int stockStartVerticalIndex = 0;
			int stockEndVerticalIndex = 0;

			//Check if the second side is as designed or flipped
			if (secondSideMachiningLines.First().Index < secondSideMachiningLines.Last().Index)
			{
				//find the first profile point coordinates which can be line or arc
				if (secondSideMachiningLines.First().Index < secondSideMachiningArcs.First().Index)
				{
					firstProfilePoint.X = secondSideMachiningLines.First().StartX;
					firstProfilePoint.Y = secondSideMachiningLines.First().StartY;
					stockStartHorizontalIndex = secondSideMachiningLines.First().Index - 1;
					stockStartVerticalIndex = secondSideMachiningLines.First().Index - 2;
				}
				else if (secondSideMachiningArcs.First().Index < secondSideMachiningLines.First().Index)
				{
					firstProfilePoint.X = secondSideMachiningArcs.First().StartX;
					firstProfilePoint.Y = secondSideMachiningArcs.First().StartY;
					stockStartHorizontalIndex = secondSideMachiningArcs.First().Index - 1;
					stockStartVerticalIndex = secondSideMachiningArcs.First().Index - 2;
				}
				//find the last profile point coordinates which can be line or arc
				if (secondSideMachiningLines.Last().Index > secondSideMachiningArcs.Last().Index)
				{
					lastProfilePoint.X = secondSideMachiningLines.Last().EndX;
					lastProfilePoint.Y = secondSideMachiningLines.Last().EndY;
					stockEndVerticalIndex = secondSideMachiningLines.Last().Index + 1;
				}
				else if (secondSideMachiningArcs.Last().Index > secondSideMachiningLines.Last().Index)
				{
					lastProfilePoint.X = secondSideMachiningArcs.Last().EndX;
					lastProfilePoint.Y = secondSideMachiningArcs.Last().EndY;
					stockEndVerticalIndex = secondSideMachiningArcs.Last().Index + 1;
				}
			}
			else if (secondSideMachiningLines.First().Index > secondSideMachiningLines.Last().Index)
			{
				//find the first profile point coordinates which can be line or arc
				if (secondSideMachiningLines.First().Index > secondSideMachiningArcs.First().Index)
				{
					firstProfilePoint.X = secondSideMachiningLines.First().StartX;
					firstProfilePoint.Y = secondSideMachiningLines.First().StartY;
					stockStartHorizontalIndex = secondSideMachiningLines.First().Index + 1;
					stockStartVerticalIndex = secondSideMachiningLines.First().Index + 2;
				}
				else if (secondSideMachiningArcs.First().Index > secondSideMachiningLines.First().Index)
				{
					firstProfilePoint.X = secondSideMachiningArcs.First().StartX;
					firstProfilePoint.Y = secondSideMachiningArcs.First().StartY;
					stockStartHorizontalIndex = secondSideMachiningArcs.First().Index + 1;
					stockStartVerticalIndex = secondSideMachiningArcs.First().Index + 2;
				}
				//find the last profile point coordinates which can be line or arc
				if (secondSideMachiningLines.Last().Index < secondSideMachiningArcs.Last().Index)
				{
					lastProfilePoint.X = secondSideMachiningLines.Last().EndX;
					lastProfilePoint.Y = secondSideMachiningLines.Last().EndY;
					stockEndVerticalIndex = secondSideMachiningLines.Last().Index - 1;
				}
				else if (secondSideMachiningArcs.Last().Index < secondSideMachiningLines.Last().Index)
				{
					lastProfilePoint.X = secondSideMachiningArcs.Last().EndX;
					lastProfilePoint.Y = secondSideMachiningArcs.Last().EndY;
					stockEndVerticalIndex = secondSideMachiningArcs.Last().Index - 1;
				}
			}

			Line stockStartHorizontal = new Line(Parameter.StockFromWidthSecondSide, firstProfilePoint.Y, firstProfilePoint.X, firstProfilePoint.Y, Parameter.Green);
			stockStartHorizontal.Index = stockStartHorizontalIndex;

			Line stockStartVertical = new Line(Parameter.StockFromWidthSecondSide, Parameter.DieRadius + Parameter.StockFromRadius, stockStartHorizontal.StartX, stockStartHorizontal.StartY, Parameter.Green);
			stockStartVertical.Index = stockStartVerticalIndex;

			Line stockEndVertical = new Line(lastProfilePoint.X, lastProfilePoint.Y, lastProfilePoint.X, lastProfilePoint.Y + Parameter.StockFromRadius, Parameter.Green);
			stockEndVertical.Index = stockEndVerticalIndex;

			secondSideStockMachiningLines.Insert(0, stockEndVertical);
			secondSideStockMachiningLines.Insert(0, stockStartHorizontal);
			secondSideStockMachiningLines.Insert(0, stockStartVertical);

			return secondSideStockMachiningLines;
		}

		public static List<Line> FirstSideOuterVerticalMachiningLines()
		{
			List<Line> firstSideOuterVerticalMachiningLines = new List<Line>();

			//Upper horizontal line
			Line upperHorizontalLine = new Line(Parameter.StockFromWidthFirstSide, Parameter.DieRadius + Parameter.StockFromRadius, 0, Parameter.DieRadius + Parameter.StockFromRadius, Parameter.Green);
			upperHorizontalLine.Index = 1;

			//Left vertical line
			Line leftVerticalLine = new Line(0, Parameter.DieRadius + Parameter.StockFromRadius, 0, -1, Parameter.Green);
			leftVerticalLine.Index = 2;

			//Lower horizontal line
			Line lowerHorizontalLine = new Line(0, -1, Parameter.StockFromWidthFirstSide, -1, Parameter.Green);
			lowerHorizontalLine.Index = 3;

			firstSideOuterVerticalMachiningLines.Add(upperHorizontalLine);
			firstSideOuterVerticalMachiningLines.Add(leftVerticalLine);
			firstSideOuterVerticalMachiningLines.Add(lowerHorizontalLine);

			return firstSideOuterVerticalMachiningLines;
		}

		public static List<Line> SecondSideOuterVerticalMachiningLines()
		{
			List<Line> secondSideOuterVerticalMachiningLines = new List<Line>();

			//Upper horizontal line
			Line upperHorizontalLine = new Line(Parameter.StockFromWidthSecondSide, Parameter.DieRadius + Parameter.StockFromRadius, 0, Parameter.DieRadius + Parameter.StockFromRadius, Parameter.Green);
			upperHorizontalLine.Index = 1;

			//Left vertical line
			Line leftVerticalLine = new Line(0, Parameter.DieRadius + Parameter.StockFromRadius, 0, -1, Parameter.Green);
			leftVerticalLine.Index = 2;

			//Lower horizontal line
			Line lowerHorizontalLine = new Line(0, -1, Parameter.StockFromWidthSecondSide, -1, Parameter.Green);
			lowerHorizontalLine.Index = 3;

			secondSideOuterVerticalMachiningLines.Add(upperHorizontalLine);
			secondSideOuterVerticalMachiningLines.Add(leftVerticalLine);
			secondSideOuterVerticalMachiningLines.Add(lowerHorizontalLine);

			return secondSideOuterVerticalMachiningLines;
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
