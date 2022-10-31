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
		public static void Indexes()
		{
			List<Line> lines = new List<Line>(MainApp.Lines);
			List<Arc> arcs = new List<Arc>(MainApp.Arcs);
			List<PointsPair> pointsPair = new List<PointsPair>();

			Line firstLine = lines.Find(first => first.StartX == 0 && first.StartY == 0 && first.EndX == 0 && first.EndY > 0);
			pointsPair.Add(new PointsPair(){X1 = firstLine.StartX, Y1 = firstLine.StartY, X2 = firstLine.EndX, Y2 = firstLine.EndY });
			PointF lastPoint = new PointF(firstLine.EndX, firstLine.EndY);
			lines.Remove(firstLine);

			int totalElements = lines.Count + arcs.Count;
			for (int elementsLeft = totalElements; elementsLeft != 0;)
			{
				Line startPointLineMatching = lines.Find(line => line.StartX == lastPoint.X && line.StartY == lastPoint.Y);
				Line endPointLineMatching = lines.Find(line => line.EndX == lastPoint.X && line.EndY == lastPoint.Y);
				Arc startPointArcMatching = arcs.Find(arc => arc.StartX == lastPoint.X && arc.StartY == lastPoint.Y);
				Arc endPointArcMatching = arcs.Find(arc => arc.EndX == lastPoint.X && arc.EndY == lastPoint.Y);

				if (startPointLineMatching != null)
				{
					pointsPair.Add(new PointsPair() { X1 = startPointLineMatching.StartX, Y1 = startPointLineMatching.StartY, X2 = startPointLineMatching.EndX, Y2 = startPointLineMatching.EndY });
					lastPoint.X = startPointLineMatching.EndX;
					lastPoint.Y = startPointLineMatching.EndY;
					lines.Remove(startPointLineMatching);
					elementsLeft--;
					continue;
				}

				if (endPointLineMatching != null)
				{
					pointsPair.Add(new PointsPair() { X1 = endPointLineMatching.EndX, Y1 = endPointLineMatching.EndY, X2 = endPointLineMatching.StartX, Y2 = endPointLineMatching.StartY });
					lastPoint.X = endPointLineMatching.StartX;
					lastPoint.Y = endPointLineMatching.StartY;
					lines.Remove(endPointLineMatching);
					elementsLeft--;
					continue;
				}

				if (startPointArcMatching != null)
				{
					pointsPair.Add(new PointsPair() { X1 = startPointArcMatching.StartX, Y1 = startPointArcMatching.StartY, X2 = startPointArcMatching.EndX, Y2 = startPointArcMatching.EndY });
					lastPoint.X = startPointArcMatching.EndX;
					lastPoint.Y = startPointArcMatching.EndY;
					arcs.Remove(startPointArcMatching);
					elementsLeft--;
					continue;
				}

				if (endPointArcMatching != null)
				{
					pointsPair.Add(new PointsPair() { X1 = endPointArcMatching.EndX, Y1 = endPointArcMatching.EndY, X2 = endPointArcMatching.StartX, Y2 = endPointArcMatching.StartY });
					lastPoint.X = endPointArcMatching.StartX;
					lastPoint.Y = endPointArcMatching.StartY;
					arcs.Remove(endPointArcMatching);
					elementsLeft--;
					continue;
				}

				if (true)
				{
					DialogResult notMatchingPoint = MessageBox.Show("Points from the file didn't match");
					break;
				}
			}

			int indexer = 0;
			foreach (PointsPair pair in pointsPair)
			{
				indexer++;
				Line startLineMatching = MainApp.Lines.Find(line => line.StartX == pair.X1 && line.StartY == pair.Y1 && line.EndX == pair.X2 && line.EndY == pair.Y2);
				Line endLineMatching = MainApp.Lines.Find(line => line.EndX == pair.X1 && line.EndY == pair.Y1 && line.StartX == pair.X2 && line.StartY == pair.Y2);
				Arc startArcMatching = MainApp.Arcs.Find(arc => arc.StartX == pair.X1 && arc.StartY == pair.Y1 && arc.EndX == pair.X2 && arc.EndY == pair.Y2);
				Arc endArcMatching = MainApp.Arcs.Find(arc => arc.EndX == pair.X1 && arc.EndY == pair.Y1 && arc.StartX == pair.X2 && arc.StartY == pair.Y2);

				if (startLineMatching != null) { startLineMatching.Index = indexer; }
				if (endLineMatching != null) { endLineMatching.Index = indexer; }
				if (startArcMatching != null) { startArcMatching.Index = indexer; }
				if (endArcMatching != null) { endArcMatching.Index = indexer; }
			}

		}

		public static GraphicsPath FullPath()
		{
			GraphicsPath fullPath = new GraphicsPath();

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

			
			//Sort Indexes
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
