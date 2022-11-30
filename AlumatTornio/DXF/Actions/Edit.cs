using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Elements;
using DXF.Tools;

namespace DXF.Actions
{
	public static class Edit
	{
		public static void AddIndexesAndMakeCorrections(List<Line> linesList, List<Arc> arcsList)
		{
			List<Line> lines = new List<Line>(linesList);
			List<Arc> arcs = new List<Arc>(arcsList);
			int index = 1;

			//Find the first Vertical Line which has equal to zero starting points or ending points
			Line firstLineMatchingStart = lines.Find(first => first.StartX == 0 && first.StartY == 0 && first.EndX == 0 && first.EndY > 0);
			Line firstLineMatchingEnd = lines.Find(first => first.EndX == 0 && first.EndY == 0 && first.StartX == 0 && first.StartY > 0);

			PointF lastPoint = new PointF();
			if (firstLineMatchingStart != null)
			{
				firstLineMatchingStart.Index = index;
				lastPoint.X = firstLineMatchingStart.EndX;
				lastPoint.Y = firstLineMatchingStart.EndY;
				lines.Remove(firstLineMatchingStart);
				index++;
			}
			if (firstLineMatchingEnd != null)
			{
				firstLineMatchingEnd.Index = index;
				lastPoint.X = firstLineMatchingEnd.StartX;
				lastPoint.Y = firstLineMatchingEnd.StartY;

				firstLineMatchingEnd.StartX = firstLineMatchingEnd.EndX;
				firstLineMatchingEnd.StartY = firstLineMatchingEnd.EndY;
				firstLineMatchingEnd.EndX = lastPoint.X;
				firstLineMatchingEnd.EndY = lastPoint.Y;

				lines.Remove(firstLineMatchingEnd);
				index++;
			}

			//Iterate through all elements to add them in a queue by giving an Index value and fix their direction
			int totalElements = lines.Count + arcs.Count;
			for (int elementsLeft = totalElements; elementsLeft != 0;)
			{
				//Find the point of any element that match the last point
				Line startPointLineMatching = lines.Find(line => line.StartX == lastPoint.X && line.StartY == lastPoint.Y);
				Line endPointLineMatching = lines.Find(line => line.EndX == lastPoint.X && line.EndY == lastPoint.Y);
				Arc startPointArcMatching = arcs.Find(arc => arc.StartX == lastPoint.X && arc.StartY == lastPoint.Y);
				Arc endPointArcMatching = arcs.Find(arc =>arc.EndX == lastPoint.X && arc.EndY == lastPoint.Y);

				//To the matching element set an index
				//record the new last point
				//reverse the start with the end if the matching point is the end of the element
				if (startPointLineMatching != null)
				{
					startPointLineMatching.Index = index;
					lastPoint.X = startPointLineMatching.EndX;
					lastPoint.Y = startPointLineMatching.EndY;
					lines.Remove(startPointLineMatching);
					elementsLeft--;
					index++;
					continue;
				}

				if (endPointLineMatching != null)
				{
					endPointLineMatching.Index = index;
					lastPoint.X = endPointLineMatching.StartX;
					lastPoint.Y = endPointLineMatching.StartY;

					endPointLineMatching.StartX = endPointLineMatching.EndX;
					endPointLineMatching.StartY = endPointLineMatching.EndY;
					endPointLineMatching.EndX = lastPoint.X;
					endPointLineMatching.EndY = lastPoint.Y;

					lines.Remove(endPointLineMatching);
					elementsLeft--;
					index++;
					continue;
				}

				if (startPointArcMatching != null)
				{
					startPointArcMatching.Index = index;
					lastPoint.X = startPointArcMatching.EndX;
					lastPoint.Y = startPointArcMatching.EndY;
					arcs.Remove(startPointArcMatching);
					elementsLeft--;
					index++;
					continue;
				}

				if (endPointArcMatching != null)
				{
					endPointArcMatching.Index = index;
					lastPoint.X = endPointArcMatching.StartX;
					lastPoint.Y = endPointArcMatching.StartY;

					endPointArcMatching.StartX = endPointArcMatching.EndX;
					endPointArcMatching.StartY = endPointArcMatching.EndY;
					endPointArcMatching.EndX = lastPoint.X;
					endPointArcMatching.EndY = lastPoint.Y;

					arcs.Remove(endPointArcMatching);
					elementsLeft--;
					index++;
					continue;
				}

				if (true)
				{
					elementsLeft--;
				}
			}
		}

		public static void FlipElements(List<Line> g71Lines, List<Arc> g71Arcs)
		{
			List<Line> g71LinesLeftSide = new List<Line>(g71Lines);
			List<Arc> g71ArcsLeftSide = new List<Arc>(g71Arcs);

			g71LinesLeftSide = g71LinesLeftSide.OrderBy(arc => arc.Index).ToList();
			g71LinesLeftSide.Reverse();

			g71ArcsLeftSide = g71ArcsLeftSide.OrderBy(arc => arc.Index).ToList();
			g71ArcsLeftSide.Reverse();

			float distanceFromAxis = 0;
			foreach (Line line in g71LinesLeftSide)
			{
				if (line.EndX < distanceFromAxis)
				{
					distanceFromAxis = line.EndX;
				}
			}
			distanceFromAxis = Math.Abs(distanceFromAxis);

			foreach (Line line in g71LinesLeftSide)
			{
				line.StartX += distanceFromAxis;
				line.EndX += distanceFromAxis;
				line.StartX = Conversion.StringToThreeDigitFloat(Convert.ToString(line.StartX));
				line.EndX = Conversion.StringToThreeDigitFloat(Convert.ToString(line.EndX));

				line.StartX *= -1;
				line.EndX *= -1;

				(line.StartX, line.StartY, line.EndX, line.EndY) = (line.EndX, line.EndY, line.StartX, line.StartY);
			}

			foreach (Arc arc in g71ArcsLeftSide)
			{
				arc.CenterX += distanceFromAxis;
				arc.RectangularCornerX += distanceFromAxis;
				arc.RectangularCornerX += arc.Width;
				arc.StartX += distanceFromAxis;
				arc.EndX += distanceFromAxis;

				arc.CenterX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.CenterX));
				arc.RectangularCornerX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.RectangularCornerX));
				arc.StartX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.StartX));
				arc.EndX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.EndX));

				arc.CenterX *= -1;
				arc.RectangularCornerX *= -1;
				arc.StartX *= -1;
				arc.EndX *= -1;
				
				(arc.StartX, arc.StartY, arc.EndX, arc.EndY) = (arc.EndX, arc.EndY, arc.StartX, arc.StartY);

				if (arc.StartAngle <= 180 && arc.EndAngle <= 180)
				{
					(arc.StartAngle, arc.EndAngle) = (arc.EndAngle, arc.StartAngle);
					arc.StartAngle = 180 - arc.StartAngle;
					arc.EndAngle = 180 - arc.EndAngle;
				}

				if (arc.StartAngle > 180 && arc.EndAngle > 180)
				{
					(arc.StartAngle, arc.EndAngle) = (arc.EndAngle, arc.StartAngle);
					arc.StartAngle = 540 - arc.StartAngle;
					arc.EndAngle = 540 - arc.EndAngle;
				}
				
			}
			
		}

		public static void MoveElementsToOrigin(List<Line> lines , List<Arc> arcs, float gapX , float gapY)
		{
			if (gapX != 0)
			{
				gapX = gapX > 0 ? -gapX : Math.Abs(gapX);

				foreach (Line line in lines)
				{
					line.StartX += gapX;
					line.EndX += gapX;
				}
				foreach (Arc arc in arcs)
				{
					arc.CenterX += gapX;
					arc.StartX += gapX;
					arc.EndX += gapX;
					arc.RectangularCornerX += gapX;
				}
			}

			if (gapY != 0)
			{

				gapY = gapY > 0 ? -gapY : Math.Abs(gapY);

				foreach (Line line in lines)
				{
					line.StartY += gapY;
					line.EndY += gapY;
				}

				foreach (Arc arc in arcs)
				{
					arc.CenterY += gapY;
					arc.StartY += gapY;
					arc.EndY += gapY;
					arc.RectangularCornerY += gapY;
				}
			}

		}

		
		public static void DecimalsCorrection(List<Line> lines, List<Arc> arcs)
		{
			foreach (Line line in lines)
			{
				line.StartX = Conversion.StringToThreeDigitFloat(Convert.ToString(line.StartX));
				line.StartY = Conversion.StringToThreeDigitFloat(Convert.ToString(line.StartY));
				line.EndX = Conversion.StringToThreeDigitFloat(Convert.ToString(line.EndX));
				line.EndY = Conversion.StringToThreeDigitFloat(Convert.ToString(line.EndY));
			}

			foreach (Arc arc in arcs)
			{
				arc.CenterX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.CenterX));
				arc.CenterY = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.CenterY));
				arc.StartX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.StartX));
				arc.StartY = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.StartY));
				arc.EndX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.EndX));
				arc.EndY = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.EndY));
				arc.RectangularCornerX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.RectangularCornerX));
				arc.RectangularCornerY = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.RectangularCornerY));
			}
		}
	}
}
