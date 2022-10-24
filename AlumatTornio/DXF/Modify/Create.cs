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

			pointsPair.Add(new PointsPair(){X1 = lines[0].StartX, Y1 = lines[0].StartY, X2 = lines[0].EndX, Y2 = lines[0].EndY });
			PointF lastPoint = new PointF(lines[0].EndX, lines[0].EndY);
			lines.RemoveAt(0);

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
					pointsPair.Add(new PointsPair() { X1 = startPointLineMatching.EndX, Y1 = startPointLineMatching.EndY, X2 = startPointLineMatching.StartX, Y2 = startPointLineMatching.StartY });
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
					pointsPair.Add(new PointsPair() { X1 = startPointArcMatching.EndX, Y1 = startPointArcMatching.EndY, X2 = startPointArcMatching.StartX, Y2 = startPointArcMatching.StartY });
					lastPoint.X = endPointArcMatching.StartX;
					lastPoint.Y = endPointArcMatching.StartY;
					arcs.Remove(endPointArcMatching);
					elementsLeft--;
					continue;
				}

				if (true)
				{
					DialogResult notMatchingPoint = MessageBox.Show("Points from the file didn't match");
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
						fullPath.AddArc(arc.RectangularCornerX,arc.RectangularCornerY,arc.Width,arc.Height,arc.StartAngle,arc.SweepAngle);
						break;
					}
				}
			}

			return fullPath;
		}

		public static GraphicsPath FullProfile()
		{
			GraphicsPath fullDieProfile = new GraphicsPath();
			List<Line> lines = new List<Line>(MainApp.Lines);
			List<Arc> arcs = new List<Arc>(MainApp.Arcs);

			//Add a line to the graphics path to start searching matching lines or arcs
			fullDieProfile.AddLine(lines[0].StartX, lines[0].StartY, lines[0].EndX, lines[0].EndY);
			PointF lastPoint = new PointF(lines[0].EndX, lines[0].EndY);
			lines.RemoveAt(0);

			//Find the next element which has a matching point with the last point and add it to the path
			int totalElements = lines.Count + arcs.Count;
			for (int elementsLeft = totalElements; elementsLeft != 0;)
			{
				Line startPointLine = lines.Find(line => line.StartX == lastPoint.X && line.StartY == lastPoint.Y);
				Line endPointLine = lines.Find(line => line.EndX == lastPoint.X && line.EndY == lastPoint.Y);
				Arc startPointArc = arcs.Find(arc => arc.StartX == lastPoint.X && arc.StartY == lastPoint.Y);
				Arc endPointArc = arcs.Find(arc => arc.EndX == lastPoint.X && arc.EndY == lastPoint.Y);

				if (startPointLine != null)
				{
					fullDieProfile.AddLine(startPointLine.StartX, startPointLine.StartY, startPointLine.EndX, startPointLine.EndY);
					lastPoint.X = startPointLine.EndX;
					lastPoint.Y = startPointLine.EndY;
					lines.Remove(startPointLine);
					elementsLeft--;
					continue;
				}

				if (endPointLine != null)
				{
					fullDieProfile.AddLine(endPointLine.EndX, endPointLine.EndY, endPointLine.StartX, endPointLine.StartY);
					lastPoint.X = endPointLine.StartX;
					lastPoint.Y = endPointLine.StartY;
					lines.Remove(endPointLine);
					elementsLeft--;
					continue;
				}

				if (startPointArc != null)
				{
					fullDieProfile.AddArc(startPointArc.RectangularCornerX, startPointArc.RectangularCornerY, startPointArc.Width, startPointArc.Height, startPointArc.StartAngle, startPointArc.SweepAngle);
					lastPoint.X = startPointArc.EndX;
					lastPoint.Y = startPointArc.EndY;
					arcs.Remove(startPointArc);
					elementsLeft--;
					continue;
				}

				if (endPointArc != null)
				{
					fullDieProfile.AddArc(endPointArc.RectangularCornerX, endPointArc.RectangularCornerY, endPointArc.Width, endPointArc.Height, endPointArc.StartAngle, endPointArc.SweepAngle);
					lastPoint.X = endPointArc.StartX;
					lastPoint.Y = endPointArc.StartY;
					arcs.Remove(endPointArc);
					elementsLeft--;
					continue;
				}

				if (true)
				{
					DialogResult notMatchingPoint = MessageBox.Show("Points from the file didn't match");
				}
			}
			return fullDieProfile;
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

			//Find first index
			int totalElements = lines.Count + arcs.Count;
			int firstIndex = totalElements;
			foreach (Line line in lines)
			{
				if (line.Index < firstIndex)
				{
					firstIndex = line.Index;
				}
			}

			foreach (Arc arc in arcs)
			{
				if (arc.Index < firstIndex)
				{
					firstIndex = arc.Index;
				}
			}

			for (int i = 1; i <= totalElements; i++)
			{
				foreach (Line line in lines)
				{
					if (line.Index == firstIndex)
					{
						g71Profile.AddLine(line.StartX,line.StartY,line.EndX,line.EndY);
						break;
					}
				}

				foreach (Arc arc in arcs)
				{
					if (arc.Index == firstIndex)
					{
						g71Profile.AddArc(arc.RectangularCornerX, arc.RectangularCornerY, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
						break;
					}
				}

				firstIndex++;
			}

			//TODO: Investigate how to create an algorithm which creates a profile by avoiding "left turns"
			//TODO: Add element number sequence when creating the FullDieProfile


			


			return g71Profile;
		}
	}
}
