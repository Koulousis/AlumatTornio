using DXF.SetupFile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Lathe
{
	public class Cycle
	{
		public static void G71(Graphics preview, GraphicsPath diePath)
		{
			float clearancePointHeight = ClearancePointHeight();
			float startingBlockHeight = StartingBlockHeight();
			float endingBlockWidth = EndingBlockWidth();

			SolidBrush clearancePointBrush = new SolidBrush(Color.Yellow);
			SolidBrush startingBlockBrush = new SolidBrush(Color.MediumPurple);
			SolidBrush endingBlockBrush = new SolidBrush(Color.LightCyan);
			preview.FillEllipse(clearancePointBrush, - 1, clearancePointHeight + 3 - 1, 2, 2);
			preview.FillEllipse(startingBlockBrush, -1, startingBlockHeight - 1, 2, 2);
			preview.FillEllipse(endingBlockBrush, endingBlockWidth - 1, clearancePointHeight + 3 - 1, 2, 2);

			GraphicsPath diePathClone = (GraphicsPath)diePath.Clone();
			PathData dummy = diePathClone.PathData;
			



		}

		public static GraphicsPath Profile()
		{
			GraphicsPath graphicsPath = new GraphicsPath();

			//Allocate new memory position to be able to modify the copies
			List<Line> pathLines = new List<Line>(MainApp.Lines);
			List<Arc> pathArcs = new List<Arc>(MainApp.Arcs);
			
			return graphicsPath;
		}

		public static float ClearancePointHeight()
		{
			float dummyHeight = 0;

			foreach (Line line in MainApp.Lines)
			{
				if (line.StartY > dummyHeight)
				{
					dummyHeight = line.StartY;
				}
				else if (line.EndY > dummyHeight)
				{
					dummyHeight = line.EndY;
				}
				else
				{
					continue;
				}
			}
			return dummyHeight;
		}
		public static float StartingBlockHeight()
		{
			float dummyHeight2 = 0;
			foreach (Line line in MainApp.Lines)
			{
				if (line.StartX == 0 && line.EndX == 0)
				{
					if (line.StartY > dummyHeight2)
					{
						dummyHeight2 = line.StartY;
					}
					else if (line.EndY > dummyHeight2)
					{
						dummyHeight2 = line.EndY;
					}
					else
					{
						continue;
					}
				}
			}
			return dummyHeight2;
		}

		public static float EndingBlockWidth()
		{
			float dummyWidth = 0;

			foreach (Line line in MainApp.Lines)
			{
				if (line.StartX < dummyWidth)
				{
					dummyWidth = line.StartX;
				}
				else if (line.EndX < dummyWidth)
				{
					dummyWidth = line.EndX;
				}
				else
				{
					continue;
				}
			}
			return dummyWidth;
		}
	}
}
