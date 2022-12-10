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
		public static void AddIndexesAndCounterClockwiseElements(List<Line> dieLines, List<Arc> dieArcs)
		{
			List<Line> dieLinesAsDesigned = new List<Line>(dieLines);
			List<Arc> dieArcsAsDesigned = new List<Arc>(dieArcs);
			int index = 1;

			//Find the first Vertical Line which has equal to zero starting points or ending points
			Line firstLineMatchingStart = null;
			Line firstLineMatchingEnd = null;

			Line startClosestToZero = dieLinesAsDesigned.OrderBy(line => Math.Abs(line.StartX) + Math.Abs(line.StartY)).FirstOrDefault();
			Line endClosestToZero = dieLinesAsDesigned.OrderBy(line => Math.Abs(line.EndX) + Math.Abs(line.EndY)).FirstOrDefault();

			bool lineWithClosestStart = Math.Abs(startClosestToZero.StartX) + Math.Abs(startClosestToZero.StartY) < Math.Abs(startClosestToZero.EndX) + Math.Abs(endClosestToZero.StartY);
			if (lineWithClosestStart)
			{
				firstLineMatchingStart = startClosestToZero;
			}
			else
			{
				firstLineMatchingEnd = endClosestToZero;
			}

			

			PointF lastPoint = new PointF();
			if (firstLineMatchingStart != null)
			{
				firstLineMatchingStart.Index = index;
				lastPoint.X = firstLineMatchingStart.EndX;
				lastPoint.Y = firstLineMatchingStart.EndY;
				dieLinesAsDesigned.Remove(firstLineMatchingStart);
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

				dieLinesAsDesigned.Remove(firstLineMatchingEnd);
				index++;
			}

			//Iterate through all elements to add them in a queue by giving an Index value and fix their direction
			int totalElements = dieLinesAsDesigned.Count + dieArcsAsDesigned.Count;
			for (int elementsLeft = totalElements; elementsLeft != 0;)
			{
				//Find the point of any element that match the last point
				Line startPointLineMatching = dieLinesAsDesigned.Find(line => line.StartX == lastPoint.X && line.StartY == lastPoint.Y);
				Line endPointLineMatching = dieLinesAsDesigned.Find(line => line.EndX == lastPoint.X && line.EndY == lastPoint.Y);
				Arc startPointArcMatching = dieArcsAsDesigned.Find(arc => arc.StartX == lastPoint.X && arc.StartY == lastPoint.Y);
				Arc endPointArcMatching = dieArcsAsDesigned.Find(arc =>arc.EndX == lastPoint.X && arc.EndY == lastPoint.Y);

				//To the matching element set an index
				//record the new last point
				//reverse the start with the end if the matching point is the end of the element
				if (startPointLineMatching != null)
				{
					startPointLineMatching.Index = index;
					lastPoint.X = startPointLineMatching.EndX;
					lastPoint.Y = startPointLineMatching.EndY;
					dieLinesAsDesigned.Remove(startPointLineMatching);
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

					dieLinesAsDesigned.Remove(endPointLineMatching);
					elementsLeft--;
					index++;
					continue;
				}

				if (startPointArcMatching != null)
				{
					startPointArcMatching.Index = index;
					lastPoint.X = startPointArcMatching.EndX;
					lastPoint.Y = startPointArcMatching.EndY;
					dieArcsAsDesigned.Remove(startPointArcMatching);
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

					dieArcsAsDesigned.Remove(endPointArcMatching);
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

		public static void FlipElements(List<Line> dieLines, List<Arc> dieArcs)
		{
			List<Line> dieLinesFlipped = new List<Line>(dieLines);
			List<Arc> dieArcsFlipped = new List<Arc>(dieArcs);

			dieLinesFlipped = dieLinesFlipped.OrderBy(arc => arc.Index).ToList();
			dieLinesFlipped.Reverse();

			dieArcsFlipped = dieArcsFlipped.OrderBy(arc => arc.Index).ToList();
			dieArcsFlipped.Reverse();

			float distanceFromAxis = 0;
			foreach (Line line in dieLinesFlipped)
			{
				if (line.EndX < distanceFromAxis)
				{
					distanceFromAxis = line.EndX;
				}
			}
			distanceFromAxis = Math.Abs(distanceFromAxis);

			foreach (Line line in dieLinesFlipped)
			{
				line.StartX += distanceFromAxis;
				line.EndX += distanceFromAxis;
				line.StartX = Conversion.StringToThreeDigitFloat(Convert.ToString(line.StartX));
				line.EndX = Conversion.StringToThreeDigitFloat(Convert.ToString(line.EndX));

				line.StartX *= -1;
				line.EndX *= -1;

				(line.StartX, line.StartY, line.EndX, line.EndY) = (line.EndX, line.EndY, line.StartX, line.StartY);
			}

			foreach (Arc arc in dieArcsFlipped)
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
