using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;

namespace DXF.Actions
{
	public static class Add
	{
		public static void Indexes(List<Line> dieLines, List<Arc> dieArcs)
		{
			List<Line> dieLinesAsDesigned = new List<Line>(dieLines);
			List<Arc> dieArcsAsDesigned = new List<Arc>(dieArcs);
			int index = 1;

			//Find the first Vertical Line which has equal to zero starting points or ending points
			Line firstLineMatchingStart = null;
			Line firstLineMatchingEnd = null;

			Line startClosestToZero = dieLinesAsDesigned.OrderBy(line => Math.Abs(line.StartX) + Math.Abs(line.StartY)).FirstOrDefault();
			Line endClosestToZero = dieLinesAsDesigned.OrderBy(line => Math.Abs(line.EndX) + Math.Abs(line.EndY)).FirstOrDefault();

			bool lineWithClosestStart = Math.Abs(startClosestToZero.StartX) + Math.Abs(startClosestToZero.StartY) < Math.Abs(endClosestToZero.EndX) + Math.Abs(endClosestToZero.EndY);
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
				Arc endPointArcMatching = dieArcsAsDesigned.Find(arc => arc.EndX == lastPoint.X && arc.EndY == lastPoint.Y);

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

		public static void Placement(List<Line> lines, List<Arc> arcs, string placement)
		{
			foreach (Line line in lines)
			{
				line.Placement = placement;
			}

			foreach (Arc arc in arcs)
			{
				arc.Placement = placement;
			}
		}
	}
}
