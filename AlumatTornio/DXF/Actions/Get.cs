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
		public static float GapFromX(List<Line> lines)
		{
			float gapFromX = lines[0].StartX;

			//Get the closest distance from origin
			foreach (Line line in lines)
			{
				if (line.StartX > gapFromX)
				{
					gapFromX = line.StartX;
				}
				if (line.EndX > gapFromX)
				{
					gapFromX = line.EndX;
				}
			}
			return gapFromX;
		}

		public static float GapFromY(List<Line> lines)
		{
			float gapFromY = lines[0].StartY;

			//Get the closest distance from origin
			foreach (Line line in lines)
			{
				if (line.StartY < gapFromY)
				{
					gapFromY = line.StartY;
				}
				if (line.EndY < gapFromY)
				{
					gapFromY = line.EndY;
				}
			}
			return gapFromY;
		}

		public static List<Line> LinesFromFile(List<string> file)
		{
			List<Line> dxfLines = new List<Line>();
			for (int i = 0; i < file.Count; i++)
			{
				if (file.ElementAt(i) == "LINE")
				{
					float startX = 0, startY = 0, endX = 0, endY = 0; string color = "";
					do
					{
						i++;
						switch (file.ElementAt(i).Trim())
						{
							case "AcDbEntity":
								color = file.ElementAt(i + 6).Trim();
								if (color.Length > 1) { color = file.ElementAt(i + 4).Trim(); }								break;
							case "10":
								startX = Conversion.StringToFourDigitFloat(file.ElementAt(i + 1));
								break;
							case "20":
								startY = Conversion.StringToFourDigitFloat(file.ElementAt(i + 1));
								break;
							case "11":
								endX = Conversion.StringToFourDigitFloat(file.ElementAt(i + 1));
								break;
							case "21":
								endY = Conversion.StringToFourDigitFloat(file.ElementAt(i + 1));
								break;
						}
					} while (!Validation.DxfElementTitle(file.ElementAt(i + 1)));
					dxfLines.Add(new Line(startX, startY, endX, endY, color));
				}
			}
			return dxfLines;
		}

		public static List<Arc> ArcsFromFile(List<string> file)
		{
			List<Arc> dxfArcs = new List<Arc>();
			for (int i = 0; i < file.Count; i++)
			{
				if (file.ElementAt(i) == "ARC")
				{
					float centerX = 0, centerY = 0, radius = 0, startAngle = 0, endAngle = 0; string color = "";
					do
					{
						i++;
						switch (file.ElementAt(i).Trim())
						{
							case "AcDbEntity":
								color = file.ElementAt(i + 6).Trim();
								if (color.Length > 1) { color = file.ElementAt(i + 4).Trim(); }
								break;
							case "10":
								centerX = Conversion.StringToFourDigitFloat(file.ElementAt(i + 1));
								break;
							case "20":
								centerY = Conversion.StringToFourDigitFloat(file.ElementAt(i + 1));
								break;
							case "40":
								radius = Conversion.StringToFourDigitFloat(file.ElementAt(i + 1));
								break;
							case "50":
								startAngle = Conversion.StringToFourDigitFloat(file.ElementAt(i + 1));
								break;
							case "51":
								endAngle = Conversion.StringToFourDigitFloat(file.ElementAt(i + 1));
								break;
						}
					} while (!Validation.DxfElementTitle(file.ElementAt(i + 1)));
					dxfArcs.Add(new Arc(centerX, centerY, radius, startAngle, endAngle, color));
				}
			}

			return dxfArcs;
		}
		
		public static List<Line> LinesAsDesigned(List<Line> lines)
		{
			List<Line> linesAsDesigned = new List<Line>();
			foreach (Line line in lines) { linesAsDesigned.Add(line.Clone()); }

			//List<Line> anySideLines = new List<Line>(allLines);
			for (int i = 0; i < linesAsDesigned.Count; i++)
			{
				if (linesAsDesigned[i].Color != Parameter.Green)
				{
					linesAsDesigned.Remove(linesAsDesigned[i]);
					i--;
				}
			}
			return linesAsDesigned;
		}

		public static List<Arc> ArcsAsDesigned(List<Arc> arcs)
		{
			List<Arc> arcsAsDesigned = new List<Arc>();
			foreach (Arc arc in arcs) { arcsAsDesigned.Add(arc.Clone()); }

			for (int i = 0; i < arcsAsDesigned.Count; i++)
			{
				if (arcsAsDesigned[i].Color != Parameter.Green)
				{
					arcsAsDesigned.Remove(arcsAsDesigned[i]);
					i--;
				}
			}
			return arcsAsDesigned;
		}

		public static List<Line> HorizontalProfileLines(List<Line> lines)
		{
			//Read die lines ordered by index
			List<Line> outerHorizontalMachiningLines = new List<Line>();
			foreach (Line line in lines) { outerHorizontalMachiningLines.Add(line.Clone()); }

			//Find the first line which is closer to Y Axis
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

			//Remove lines while it's moving vertical
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

		public static List<Arc> HorizontalProfileArcs(List<Line> lines, List<Arc> arcs)
		{
			List<Arc> outerHorizontalMachiningArcs = new List<Arc>();
			foreach (Arc arc in arcs) { outerHorizontalMachiningArcs.Add(arc.Clone()); }

			int i = 0;
			if (lines.First().Placement == "AsDesigned")
			{
				while (arcs[i].Index < lines[lines.Count - 1].Index)
				{
					i++;
				}
				outerHorizontalMachiningArcs.RemoveRange(i, outerHorizontalMachiningArcs.Count - i);
			}
			else if (lines.First().Placement == "Flipped")
			{
				while (arcs[i].Index > lines[lines.Count - 1].Index)
				{
					i++;
				}
				outerHorizontalMachiningArcs.RemoveRange(i, outerHorizontalMachiningArcs.Count - i);
			}

			if (outerHorizontalMachiningArcs.Count > 1)
			{
				while (outerHorizontalMachiningArcs[0].StartX < outerHorizontalMachiningArcs[0].EndX)
				{
					outerHorizontalMachiningArcs.RemoveAt(0);
				}
			}
			
				
			

			return outerHorizontalMachiningArcs;
		}

		public static List<Line> FirstSideHorizontalProfileStockLines(List<Line> lines, List<Arc> arcs)
		{
			List<Line> firstSideStockMachiningLines = new List<Line>();

			PointF firstProfilePoint = new PointF();
			PointF lastProfilePoint = new PointF();
			int stockStartHorizontalIndex = 0;
			int stockStartVerticalIndex = 0;
			int stockEndVerticalIndex = 0;
			string placement = lines.First().Placement;

			//Set conditions
			bool elementsAsDesigned = lines.First().Placement == "AsDesigned";
			bool elementsFlipped = lines.First().Placement == "Flipped";
			bool arcElementsExist = arcs.Count != 0;
			bool firstElementIsLine = true;
			bool firstElementIsArc = false;
			bool lastElementIsLine = true;
			bool lastElementIsArc = false;

			//Check if the first side is as designed or flipped
			if (elementsAsDesigned)
			{
				//find the first and last element if it is line or arc
				if (arcElementsExist)
				{
					firstElementIsLine = lines.First().Index < arcs.First().Index;
					firstElementIsArc = arcs.First().Index < lines.First().Index;
					lastElementIsLine = lines.Last().Index > arcs.Last().Index;
					lastElementIsArc = arcs.Last().Index > lines.Last().Index;
				}
				//Get first point
				if (firstElementIsLine)
				{
					firstProfilePoint.X = lines.First().StartX;
					firstProfilePoint.Y = lines.First().StartY;
					stockStartHorizontalIndex = lines.First().Index - 1;
					stockStartVerticalIndex = lines.First().Index - 2;
				}
				else if (firstElementIsArc)
				{
					firstProfilePoint.X = arcs.First().StartX;
					firstProfilePoint.Y = arcs.First().StartY;
					stockStartHorizontalIndex = arcs.First().Index - 1;
					stockStartVerticalIndex = arcs.First().Index - 2;
				}
				//Get last point
				if (lastElementIsLine)
				{
					lastProfilePoint.X = lines.Last().EndX;
					lastProfilePoint.Y = lines.Last().EndY;
					stockEndVerticalIndex = lines.Last().Index + 1;
				}
				else if (lastElementIsArc)
				{
					lastProfilePoint.X = arcs.Last().EndX;
					lastProfilePoint.Y = arcs.Last().EndY;
					stockEndVerticalIndex = arcs.Last().Index + 1;
				}
			}
			else if (elementsFlipped)
			{
				//find the first and last element if it is line or arc
				if (arcElementsExist)
				{
					firstElementIsLine = lines.First().Index > arcs.First().Index;
					firstElementIsArc = arcs.First().Index > lines.First().Index;
					lastElementIsLine = lines.Last().Index < arcs.Last().Index;
					lastElementIsArc = arcs.Last().Index < lines.Last().Index;
				}
				//Get first point
				if (firstElementIsLine)
				{
					firstProfilePoint.X = lines.First().StartX;
					firstProfilePoint.Y = lines.First().StartY;
					stockStartHorizontalIndex = lines.First().Index + 1;
					stockStartVerticalIndex = lines.First().Index + 2;
				}
				else if (firstElementIsArc)
				{
					firstProfilePoint.X = arcs.First().StartX;
					firstProfilePoint.Y = arcs.First().StartY;
					stockStartHorizontalIndex = arcs.First().Index + 1;
					stockStartVerticalIndex = arcs.First().Index + 2;
				}
				//Get last point
				if (lastElementIsLine)
				{
					lastProfilePoint.X = lines.Last().EndX;
					lastProfilePoint.Y = lines.Last().EndY;
					stockEndVerticalIndex = lines.Last().Index - 1;
				}
				else if (lastElementIsArc)
				{
					lastProfilePoint.X = arcs.Last().EndX;
					lastProfilePoint.Y = arcs.Last().EndY;
					stockEndVerticalIndex = arcs.Last().Index - 1;
				}
			}

			Line stockStartHorizontal = new Line(Parameter.StockFromWidthFirstSide, firstProfilePoint.Y, firstProfilePoint.X, firstProfilePoint.Y, Parameter.Green);
			stockStartHorizontal.Index = stockStartHorizontalIndex;
			stockStartHorizontal.Placement = placement;

			Line stockStartVertical = new Line(Parameter.StockFromWidthFirstSide, Parameter.DieRadius + Parameter.StockFromRadius, stockStartHorizontal.StartX, stockStartHorizontal.StartY, Parameter.Green);
			stockStartVertical.Index = stockStartVerticalIndex;
			stockStartVertical.Placement = placement;

			Line stockEndVertical = new Line(lastProfilePoint.X, lastProfilePoint.Y, lastProfilePoint.X, lastProfilePoint.Y + Parameter.StockFromRadius, Parameter.Green);
			stockEndVertical.Index = stockEndVerticalIndex;
			stockEndVertical.Placement = placement;

			firstSideStockMachiningLines.Insert(0, stockEndVertical);
			firstSideStockMachiningLines.Insert(0, stockStartHorizontal);
			firstSideStockMachiningLines.Insert(0, stockStartVertical);

			return firstSideStockMachiningLines;
		}

		public static List<Line> SecondSideHorizontalProfileStockLines(List<Line> lines, List<Arc> arcs)
		{
			List<Line> secondSideStockMachiningLines = new List<Line>();

			PointF firstProfilePoint = new PointF();
			PointF lastProfilePoint = new PointF();
			int stockStartHorizontalIndex = 0;
			int stockStartVerticalIndex = 0;
			int stockEndVerticalIndex = 0;
			string placement = lines.First().Placement;

			//Set conditions
			bool elementsAsDesigned = lines.First().Placement == "AsDesigned";
			bool elementsFlipped = lines.First().Placement == "Flipped";
			bool arcElementsExist = arcs.Count != 0;
			bool firstElementIsLine = true;
			bool firstElementIsArc = false;
			bool lastElementIsLine = true;
			bool lastElementIsArc = false;

			//Check if the second side is as designed or flipped
			if (elementsAsDesigned)
			{
				//find the first and last element if it is line or arc
				if (arcElementsExist)
				{
					firstElementIsLine = lines.First().Index < arcs.First().Index;
					firstElementIsArc = arcs.First().Index < lines.First().Index;
					lastElementIsLine = lines.Last().Index > arcs.Last().Index;
					lastElementIsArc = arcs.Last().Index > lines.Last().Index;
				}
				//Get first point
				if (firstElementIsLine)
				{
					firstProfilePoint.X = lines.First().StartX;
					firstProfilePoint.Y = lines.First().StartY;
					stockStartHorizontalIndex = lines.First().Index - 1;
					stockStartVerticalIndex = lines.First().Index - 2;
				}
				else if (firstElementIsArc)
				{
					firstProfilePoint.X = arcs.First().StartX;
					firstProfilePoint.Y = arcs.First().StartY;
					stockStartHorizontalIndex = arcs.First().Index - 1;
					stockStartVerticalIndex = arcs.First().Index - 2;
				}
				//Get last point
				if (lastElementIsLine)
				{
					lastProfilePoint.X = lines.Last().EndX;
					lastProfilePoint.Y = lines.Last().EndY;
					stockEndVerticalIndex = lines.Last().Index + 1;
				}
				else if (lastElementIsArc)
				{
					lastProfilePoint.X = arcs.Last().EndX;
					lastProfilePoint.Y = arcs.Last().EndY;
					stockEndVerticalIndex = arcs.Last().Index + 1;
				}
			}
			else if (elementsFlipped)
			{
				//find the first and last element if it is line or arc
				if (arcElementsExist)
				{
					firstElementIsLine = lines.First().Index > arcs.First().Index;
					firstElementIsArc = arcs.First().Index > lines.First().Index;
					lastElementIsLine = lines.Last().Index < arcs.Last().Index;
					lastElementIsArc = arcs.Last().Index < lines.Last().Index;
				}
				//Get first point
				if (firstElementIsLine)
				{
					firstProfilePoint.X = lines.First().StartX;
					firstProfilePoint.Y = lines.First().StartY;
					stockStartHorizontalIndex = lines.First().Index + 1;
					stockStartVerticalIndex = lines.First().Index + 2;
				}
				else if (firstElementIsArc)
				{
					firstProfilePoint.X = arcs.First().StartX;
					firstProfilePoint.Y = arcs.First().StartY;
					stockStartHorizontalIndex = arcs.First().Index + 1;
					stockStartVerticalIndex = arcs.First().Index + 2;
				}
				//Get last point
				if (lastElementIsLine)
				{
					lastProfilePoint.X = lines.Last().EndX;
					lastProfilePoint.Y = lines.Last().EndY;
					stockEndVerticalIndex = lines.Last().Index - 1;
				}
				else if (lastElementIsArc)
				{
					lastProfilePoint.X = arcs.Last().EndX;
					lastProfilePoint.Y = arcs.Last().EndY;
					stockEndVerticalIndex = arcs.Last().Index - 1;
				}
			}

			Line stockStartHorizontal = new Line(Parameter.StockFromWidthSecondSide, firstProfilePoint.Y, firstProfilePoint.X, firstProfilePoint.Y, Parameter.Green);
			stockStartHorizontal.Index = stockStartHorizontalIndex;
			stockStartHorizontal.Placement = placement;

			Line stockStartVertical = new Line(Parameter.StockFromWidthSecondSide, Parameter.DieRadius + Parameter.StockFromRadius, stockStartHorizontal.StartX, stockStartHorizontal.StartY, Parameter.Green);
			stockStartVertical.Index = stockStartVerticalIndex;
			stockStartVertical.Placement = placement;

			Line stockEndVertical = new Line(lastProfilePoint.X, lastProfilePoint.Y, lastProfilePoint.X, lastProfilePoint.Y + Parameter.StockFromRadius, Parameter.Green);
			stockEndVertical.Index = stockEndVerticalIndex;
			stockEndVertical.Placement = placement;

			secondSideStockMachiningLines.Insert(0, stockEndVertical);
			secondSideStockMachiningLines.Insert(0, stockStartHorizontal);
			secondSideStockMachiningLines.Insert(0, stockStartVertical);

			return secondSideStockMachiningLines;
		}

		public static List<Line> FirstSideFacingProfile()
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

		public static List<Line> SecondSideFacingProfile()
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

		public static List<ProfilePoint> ProfilePoints(List<Line> lines, List<Arc> arcs)
		{
			//Profiles points list
			List<ProfilePoint> profilePoints = new List<ProfilePoint>();

			if (lines.Count == 0 || lines == null) return profilePoints;
			
			//Set index list to loop through profile
			List<int> indexes = new List<int>();
			foreach (Line line in lines) { indexes.Add(line.Index); }
			foreach (Arc arc in arcs) { indexes.Add(arc.Index); }
			indexes.Sort();
			if (lines.First().Placement == "Flipped") { indexes.Reverse(); }

			foreach (int index in indexes)
			{
				Line dummyLine = lines.Find(line => line.Index == index);
				Arc dummyArc = arcs.Find(arc => arc.Index == index);

				if (dummyLine != null)
				{
					profilePoints.Add(new ProfilePoint(dummyLine.StartY * 2, dummyLine.StartX));
					profilePoints.Add(new ProfilePoint(dummyLine.EndY * 2, dummyLine.EndX));
				}
				else if (dummyArc != null)
				{
					profilePoints.Add(new ProfilePoint(dummyArc.EndY * 2, dummyArc.EndX, dummyArc.Radius, dummyArc.Clockwise, dummyArc.AntiClockwise));
				}
			}

			//Use the GroupBy method to group the ProfilePoints by their X,Z properties
			var groups = profilePoints.GroupBy(p => new { p.X, p.Z });

			//Create a new list from the groups, taking only the first element from each group
			List<ProfilePoint> profilePointsWithoutDuplicates = groups.Select(g => g.First()).ToList();

			//The result must be equal to (lines.Count + 1) + arcs.Count 
			if (profilePointsWithoutDuplicates.Count != lines.Count + 1 + arcs.Count)
			{
				MessageBox.Show("Outer horizintal profile points amount\n are not equal to the planned amount");
			}

			return profilePointsWithoutDuplicates;
		}
		
		public static List<Line> CavaLines(List<Line> lines)
		{
			//Create cava lines list
			List<Line> cavaLines = new List<Line>();

			//Remove lines until the line is on diameter
			bool lineOnDiameter = false;
			bool lineOnCava = false;
			foreach (Line line in lines)
			{
				if (!lineOnDiameter)
				{
					lineOnDiameter = line.EndY == Parameter.DieRadius;
				}
				else if (lineOnDiameter)
				{
					if(line.StartY < Parameter.DieRadius || line.EndY < Parameter.DieRadius)
					{
						lineOnCava = true;
						cavaLines.Add(line.Clone());
					}
					else if (cavaLines.Count != 0)
					{
						if (Parameter.DieRadius - cavaLines.Min(cavaLine => cavaLine.StartY) > 5)
						{
							cavaLines.Clear();
							lineOnCava = false;
							lineOnDiameter = line.EndY == Parameter.DieRadius;
						}
						else if (lineOnCava)
						{
							break;
						}
					}
						
				}
			}

			return cavaLines;
		}

		public static List<Arc> CavaArcs(List<Line> lines, List<Arc> arcs)
		{
			//Create cava lines list
			List<Arc> cavaArcs = new List<Arc>();

			//Get the arcs which can be before and after cava in index
			int firstIndex = lines.Min(line => line.Index) - 1;
			Arc arcFirst = arcs.Find(arc => arc.Index == firstIndex);
			if (arcFirst != null)
			{
				cavaArcs.Add(arcFirst.Clone());
			}

			int lastIndex = lines.Max(line => line.Index) + 1;
			Arc arcLast = arcs.Find(arc => arc.Index == lastIndex);
			if (arcLast != null)
			{
				cavaArcs.Add(arcLast.Clone());
			}

			return cavaArcs;
		}

		public static List<Line> CollarinoLines(List<Line> lines)
		{
			//Create collarino lines list
			List<Line> collarinoLines = new List<Line>();

			//If the profile not starts from zero then there is a collarino, get those lines
			if (lines.First().StartX < 0 && lines.First().EndX < 0 && lines.First().StartX == lines.First().EndX)
			{
				//Create extend line from collarino start to X0,Y0
				Line axisLine = lines.First().Clone();
				(axisLine.StartX, axisLine.StartY, axisLine.EndX, axisLine.EndY) = (0, 0, axisLine.StartX, axisLine.StartY);
				axisLine.Index = axisLine.Placement == "AsDesigned" ? axisLine.Index - 1 : axisLine.Index + 1;
				collarinoLines.Add(axisLine);

				//Get the lines that create the collarino
				int i = 0;
				while (lines[i].StartX != 0)
				{
					collarinoLines.Add(lines[i].Clone());
					i++;
				}

				//Give an offset to collarino, with the value of tool diameter
				collarinoLines[0].StartY = 16;
				collarinoLines[0].EndY = 16;
				collarinoLines[1].StartY = 16;
			}

			return collarinoLines;
		}

		public static List<Arc> CollarinoArcs(List<Line> lines, List<Arc> arcs)
		{
			//Create collarino arcs list
			List<Arc> collarinoArcs = new List<Arc>();

			if (lines.Count != 0)
			{
				int lastIndex = lines.First().Placement == "AsDesigned" ? lines.Last().Index + 1 : lines.Last().Index - 1;

				int i = 0;
				if (lines.First().Placement == "AsDesigned")
				{
					while (arcs[i].Index <= lastIndex)
					{
						collarinoArcs.Add(arcs[i].Clone());
						i++;
					}
				}
				else if (lines.First().Placement == "Flipped")
				{
					while (arcs[i].Index >= lastIndex)
					{
						collarinoArcs.Add(arcs[i].Clone());
						i++;
					}
				}
			}

			return collarinoArcs;
		}
	}
}
