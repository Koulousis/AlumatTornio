using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Elements;
using DXF.Properties;

namespace DXF.Lathe
{
	public static class GCode
	{
		public static List<string> FirstSide = new List<string>();
		public static List<string> SecondSide = new List<string>();

		public static void Export()
		{
			string exportRightSide = $@"{Settings.Default["ExportFolderPath"]}\{Parameter.FileName}_Right_Side.txt";
			System.IO.File.WriteAllLines(exportRightSide, GCode.FirstSide);

			string exportLeftSide = $@"{Settings.Default["ExportFolderPath"]}\{Parameter.FileName}_Left_Side.txt";
			System.IO.File.WriteAllLines(exportLeftSide, GCode.SecondSide);
		}
		
		public static void G71(Graphics preview)
		{
			float clearancePointHeight = StartPosition();
			float startingBlockHeight = StartingBlockHeight();
			float endingBlockWidth = EndingBlockWidth();

			SolidBrush clearancePointBrush = new SolidBrush(Color.Yellow);
			SolidBrush startingBlockBrush = new SolidBrush(Color.Yellow);
			SolidBrush endingBlockBrush = new SolidBrush(Color.Yellow);
			preview.FillEllipse(clearancePointBrush, -1, clearancePointHeight + 3 - 1, 2, 2);
			preview.FillEllipse(startingBlockBrush, -1, startingBlockHeight - 1, 2, 2);
			preview.FillEllipse(endingBlockBrush, endingBlockWidth - 1, clearancePointHeight + 3 - 1, 2, 2);
		}

		public static float StartPosition()
		{
			float dummyHeight = 0;

			foreach (Line line in Parameter.LinesAsDesigned)
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
			foreach (Line line in Parameter.LinesAsDesigned)
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

			foreach (Line line in Parameter.LinesAsDesigned)
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
