using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Elements;

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
				Arc endPointArcMatching = arcs.Find(arc => arc.EndX == lastPoint.X && arc.EndY == lastPoint.Y);

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
					arcs.Remove(endPointArcMatching);
					elementsLeft--;
					index++;
					continue;
				}

				if (true)
				{
					DialogResult notMatchingPoint = MessageBox.Show("Points from the file didn't match");
					break;
				}
			}
		}

		public static void OffsetLines(float gap)
		{
			foreach (Line line in Parameter.DieLines)
			{
				line.StartX += Math.Abs(gap);
				line.EndX += Math.Abs(gap);
			}
		}

		public static void OffsetArcs(float gap)
		{
			foreach (Arc arc in Parameter.DieArcs)
			{
				arc.CenterX += Math.Abs(gap);
				arc.StartX += Math.Abs(gap);
				arc.EndX += Math.Abs(gap);
			}
		}
	}
}
