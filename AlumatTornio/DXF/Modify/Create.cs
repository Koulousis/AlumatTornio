using DXF.SetupFile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace DXF.Modify
{
	public class Create
	{
		public static void IndexesAndCorrections()
		{
			List<Line> lines = new List<Line>(MainApp.Lines);
			List<Arc> arcs = new List<Arc>(MainApp.Arcs);
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

		public static GraphicsPath FullPath()
		{
			GraphicsPath fullPath = new GraphicsPath();
			//TODO: Veltistopoisi me Find.mplampla
			//TODO: Elegxos suntetagmenwn kai sugkrisei me to powershare gia to EXA109710-1 - 1.dxf
			int totalElements = MainApp.Lines.Count + MainApp.Arcs.Count;

			for (int i = 1; i <= totalElements; i++)
			{
				foreach (Line line in MainApp.Lines)
				{
					if (line.Index == i)
					{
						fullPath.AddLine(line.StartX, line.StartY, line.EndX, line.EndY);
						break;
					}
				}

				foreach (Arc arc in MainApp.Arcs)
				{
					if (arc.Index == i)
					{
						if (arc.SweepAngle < 0)
						{
							fullPath.AddArc(arc.RectangularCornerX, arc.RectangularCornerY, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
						}
						else
						{
							fullPath.AddArc(arc.RectangularCornerX, arc.RectangularCornerY, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
						}
						
						break;
					}
				}
			}

			return fullPath;
		}

		public static GraphicsPath G71Profile()
		{
			//TODO: Ginetai lathos generate gia to EXA109710-1 - 1.dxf
			GraphicsPath g71Profile = new GraphicsPath();
			List<Line> lines = new List<Line>(MainApp.Lines);
			List<Arc> arcs = new List<Arc>(MainApp.Arcs);

			//Remove from lines list the vertical and horizontal lines which are attached to X axis
			for (int i = 0; i < lines.Count; i++)
			{
				bool verticalLine = lines[i].StartX == lines[i].EndX && lines[i].StartY != lines[i].EndY;
				bool horizontalLine = lines[i].StartY == lines[i].EndY && lines[i].StartX != lines[i].EndX;
				bool attachedToAxisX = lines[i].StartY == 0 || lines[i].EndY == 0;
				if ((verticalLine || horizontalLine) && (attachedToAxisX) )
				{
					lines.RemoveAt(i);
					i--;
				}
			}

			
			//Sort IndexesAndCorrections
			List<int> Indexers = new List<int>();
			foreach (Line line in lines)
			{
				Indexers.Add(line.Index);
			}

			foreach (Arc arc in arcs)
			{
				Indexers.Add(arc.Index);
			}
			Indexers.Sort();

			//Create profile
			float xValueHolder = 0;
			float yValueHolder = 0;
			bool unmatchedMode = false;
			bool firstEntered = false;
			foreach (int index in Indexers)
			{
				foreach (Line line in lines)
				{
					if (line.Index == index)
					{
						if (unmatchedMode)
						{
							if (line.StartY >= yValueHolder && line.EndY >= yValueHolder)
							{
								g71Profile.AddLine(xValueHolder, yValueHolder, line.StartX, line.StartY);
								g71Profile.AddLine(line.StartX, line.StartY, line.EndX, line.EndY);
								yValueHolder = line.EndY;
								unmatchedMode = false;

								MainApp.GCodePoints.Add(new GCodePoint("line", line.StartY, line.StartX));
								MainApp.GCodePoints.Add(new GCodePoint("line", line.EndY, line.EndX));
							}
						}
						else
						{
							if (line.EndY >= yValueHolder)
							{
								g71Profile.AddLine(line.StartX, line.StartY, line.EndX, line.EndY);
								yValueHolder = line.EndY;

								if (!firstEntered)
								{
									MainApp.GCodePoints.Add(new GCodePoint("line", line.StartY, line.StartX));
								}
								firstEntered = true;
								MainApp.GCodePoints.Add(new GCodePoint("line", line.EndY, line.EndX));
							}
							else
							{
								unmatchedMode = true;
								xValueHolder = line.StartX;
								yValueHolder = line.StartY;
							}
						}
					}
				}

				foreach (Arc arc in arcs)
				{
					if (arc.Index == index)
					{
						if (unmatchedMode)
						{
							if (arc.StartY >= yValueHolder && arc.EndY >= yValueHolder)
							{
								g71Profile.AddLine(xValueHolder , yValueHolder, arc.StartX, arc.StartY);
								g71Profile.AddArc(arc.RectangularCornerX, arc.RectangularCornerY, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
								yValueHolder = arc.EndY;
								unmatchedMode = false;

								MainApp.GCodePoints.Add(new GCodePoint("line", arc.StartY, arc.StartX));
								MainApp.GCodePoints.Add(new GCodePoint("arc", arc.EndY, arc.EndX, arc.Radius, arc.Clockwise, arc.AntiClockwise));
							}
						}
						else
						{
							if (arc.EndY >= yValueHolder)
							{
								g71Profile.AddArc(arc.RectangularCornerX, arc.RectangularCornerY, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
								yValueHolder = arc.EndY;

								if (!firstEntered)
								{
									MainApp.GCodePoints.Add(new GCodePoint("line", arc.StartY, arc.StartX));
								}
								firstEntered = true;
								MainApp.GCodePoints.Add(new GCodePoint("arc", arc.EndY, arc.EndX, arc.Radius, arc.Clockwise, arc.AntiClockwise));
							}
							else
							{
								unmatchedMode = true;
								xValueHolder = arc.StartX;
								yValueHolder = arc.StartY;
							}
						}
					}
				}
			}

			return g71Profile;
		}
	}
}
