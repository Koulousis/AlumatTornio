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

			List<int> indexes = new List<int>();

			//Create sorted indexes list
			foreach (Line line in Parameter.DieLinesAsDesigned)
			{
				indexes.Add(line.Index);
			}
			foreach (Arc arc in Parameter.DieArcsAsDesigned)
			{
				indexes.Add(arc.Index);
			}
			indexes.Sort();


			foreach (int index in indexes)
			{
				foreach (Line line in Parameter.DieLinesAsDesigned)
				{
					if (line.Index == index)
					{
						fullPath.AddLine(line.StartX, line.StartY, line.EndX, line.EndY);
						break;
					}
				}

				foreach (Arc arc in Parameter.DieArcsAsDesigned)
				{
					if (arc.Index == index)
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
			List<Line> lines = new List<Line>(Parameter.DieLinesAsDesigned);
			List<Arc> arcs = new List<Arc>(Parameter.DieArcsAsDesigned);

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

			
			//Sort AddIndexesAndCounterClockwiseElements
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

								Parameter.G71ProfilePointsFirstSide.Add(new GCodePoint(line.StartY, line.StartX));
								Parameter.G71ProfilePointsFirstSide.Add(new GCodePoint(line.EndY, line.EndX));
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
									Parameter.G71ProfilePointsFirstSide.Add(new GCodePoint(line.StartY, line.StartX));
								}
								firstEntered = true;
								Parameter.G71ProfilePointsFirstSide.Add(new GCodePoint(line.EndY, line.EndX));
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

								Parameter.G71ProfilePointsFirstSide.Add(new GCodePoint(arc.StartY, arc.StartX));
								Parameter.G71ProfilePointsFirstSide.Add(new GCodePoint(arc.EndY, arc.EndX, arc.Radius, arc.Clockwise, arc.AntiClockwise));
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
									Parameter.G71ProfilePointsFirstSide.Add(new GCodePoint(arc.StartY, arc.StartX));
								}
								firstEntered = true;
								Parameter.G71ProfilePointsFirstSide.Add(new GCodePoint(arc.EndY, arc.EndX, arc.Radius, arc.Clockwise, arc.AntiClockwise));
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

		public static List<GCodePoint> G72ProfilePoints(List<Line> dieLines)
		{
			List<GCodePoint> g72ProfilePoints = new List<GCodePoint>();

			float maximumY = 0;
			foreach (Line line in dieLines)
			{
				if (line.EndY > maximumY)
				{
					maximumY = line.EndY;
				}
			}
			
			g72ProfilePoints.Add(new GCodePoint(maximumY, 0));
			g72ProfilePoints.Add(new GCodePoint(-1, 0));

			return g72ProfilePoints;
		}

		public static List<GCodePoint> G71ProfilePointsFirstSide(List<Line> g71Lines, List<Arc> g71Arcs)
		{
			List<GCodePoint> g71ProfilePoints = new List<GCodePoint>();
			List<int> indexes = new List<int>();

			//Create sorted indexes list
			foreach (Line line in g71Lines)
			{
				indexes.Add(line.Index);
			}
			foreach (Arc arc in g71Arcs)
			{
				indexes.Add(arc.Index);
			}
			indexes.Sort();

			//Pick the start point if it is the first element or the previous element is not chained
			//Pick the end point of each element
			for (int i = 0; i < indexes.Count; i++)
			{
				foreach (Line line in g71Lines)
				{
					if (line.Index == indexes[i])
					{
						if (i == 0)
						{
							g71ProfilePoints.Add(new GCodePoint(line.StartY, line.StartX));
						} 
						else if (indexes[i] - indexes[i-1] != 1)
						{
							g71ProfilePoints.Add(new GCodePoint(line.StartY, line.StartX));
						}
						g71ProfilePoints.Add(new GCodePoint(line.EndY, line.EndX));
					}
				}
				foreach (Arc arc in g71Arcs)
				{
					if (arc.Index == indexes[i])
					{
						if (i == 0)
						{
							g71ProfilePoints.Add(new GCodePoint(arc.StartY, arc.StartX));
						}
						else if (indexes[i] - indexes[i - 1] != 1)
						{
							g71ProfilePoints.Add(new GCodePoint(arc.StartY, arc.StartX, arc.Radius, arc.Clockwise, arc.AntiClockwise));
						}
						g71ProfilePoints.Add(new GCodePoint(arc.EndY, arc.EndX,arc.Radius, arc.Clockwise, arc.AntiClockwise));
					}
				}
			}
			
			return g71ProfilePoints;
		}

		public static List<GCodePoint> G71ProfilePointsSecondSide(List<Line> g71Lines, List<Arc> g71Arcs)
		{
			List<GCodePoint> g71ProfilePoints = new List<GCodePoint>();
			List<int> indexes = new List<int>();

			//Create sorted indexes list
			foreach (Line line in g71Lines)
			{
				indexes.Add(line.Index);
			}
			foreach (Arc arc in g71Arcs)
			{
				indexes.Add(arc.Index);
			}
			indexes.Sort();
			indexes.Reverse();

			//Pick the start point if it is the first element or the previous element is not chained
			//Pick the end point of each element
			for (int i = 0; i < indexes.Count; i++)
			{
				foreach (Line line in g71Lines)
				{
					if (line.Index == indexes[i])
					{
						if (i == 0)
						{
							g71ProfilePoints.Add(new GCodePoint(line.StartY, line.StartX));
						}
						g71ProfilePoints.Add(new GCodePoint(line.EndY, line.EndX));
					}
				}
				foreach (Arc arc in g71Arcs)
				{
					if (arc.Index == indexes[i])
					{
						if (i == 0)
						{
							g71ProfilePoints.Add(new GCodePoint(arc.StartY, arc.StartX));
						}
						g71ProfilePoints.Add(new GCodePoint(arc.EndY, arc.EndX, arc.Radius, arc.Clockwise, arc.AntiClockwise));
					}
				}
			}

			return g71ProfilePoints;
		}
	}
}
