using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DXF.Actions;
using DXF.Elements;
using DXF.Lathe;
using DXF.Properties;

namespace DXF.Actions
{
	public class Create
	{
		public static GraphicsPath FullPath()
		{
			GraphicsPath fullPath = new GraphicsPath();
			int totalElements = Parameter.AllLines.Count + Parameter.AllArcs.Count;

			for (int i = 1; i <= totalElements; i++)
			{
				foreach (Line line in Parameter.AllLines)
				{
					if (line.Index == i)
					{
						fullPath.AddLine(line.StartX, line.StartY, line.EndX, line.EndY);
						break;
					}
				}

				foreach (Arc arc in Parameter.AllArcs)
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
			List<Line> lines = new List<Line>(Parameter.AllLines);
			List<Arc> arcs = new List<Arc>(Parameter.AllArcs);

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

			
			//Sort AddIndexesAndMakeCorrections
			List<int> indexers = new List<int>();
			foreach (Line line in lines)
			{
				indexers.Add(line.Index);
			}

			foreach (Arc arc in arcs)
			{
				indexers.Add(arc.Index);
			}
			indexers.Sort();

			//Create profile
			float xValueHolder = 0;
			float yValueHolder = 0;
			bool unmatchedMode = false;
			bool firstEntered = false;
			foreach (int index in indexers)
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

								Parameter.GCodePoints.Add(new GCodePoint("line", line.StartY, line.StartX));
								Parameter.GCodePoints.Add(new GCodePoint("line", line.EndY, line.EndX));
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
									Parameter.GCodePoints.Add(new GCodePoint("line", line.StartY, line.StartX));
								}
								firstEntered = true;
								Parameter.GCodePoints.Add(new GCodePoint("line", line.EndY, line.EndX));
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

								Parameter.GCodePoints.Add(new GCodePoint("line", arc.StartY, arc.StartX));
								Parameter.GCodePoints.Add(new GCodePoint("arc", arc.EndY, arc.EndX, arc.Radius, arc.Clockwise, arc.AntiClockwise));
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
									Parameter.GCodePoints.Add(new GCodePoint("line", arc.StartY, arc.StartX));
								}
								firstEntered = true;
								Parameter.GCodePoints.Add(new GCodePoint("arc", arc.EndY, arc.EndX, arc.Radius, arc.Clockwise, arc.AntiClockwise));
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
