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
		public static List<string> Text = new List<string>();
		
		public static void Export()
		{
			string exportFolderPath = $@"{Settings.Default["ExportFolderPath"]}\{MainApp.DxfFileName}.txt";
			System.IO.File.WriteAllLines(exportFolderPath, GCode.Text);
		}

		

		public static void G71ProfileCode(decimal depthOfCut, decimal retractValue, decimal xAllowance, decimal zAllowance, decimal feedRate)
		{
			List<string> gCode = new List<string>();

			//G71 Initialization
			gCode.Add("(G71 ROUGHING)");
			gCode.Add($"G71 U{depthOfCut} R{retractValue}");
			gCode.Add($"G71 P1 Q2 U{xAllowance} W{zAllowance} F{feedRate}");

			//Profile
			gCode.Add("(PROFILE)");
			gCode.Add("N1");
			foreach (GCodePoint gCodePoint in MainApp.GCodePoints)
			{
				if (gCodePoint.Type == "line")
				{
					gCode.Add($"G0 X{gCodePoint.X * 2} Z{gCodePoint.Z}");
				}

				if (gCodePoint.Type == "arc" && gCodePoint.Clockwise)
				{
					gCode.Add($"G2 X{gCodePoint.X * 2} Z{gCodePoint.Z} R{gCodePoint.R}");
				}

				if (gCodePoint.Type == "arc" && gCodePoint.AntiClockwise)
				{
					gCode.Add($"G3 X{gCodePoint.X * 2} Z{gCodePoint.Z} R{gCodePoint.R}");
				}

			}
			gCode.Add("N2");
			gCode.Add("(G70 FINISHING)");
			gCode.Add("G70 P1 Q2");

			string exportFolderPath = $@"{Settings.Default["ExportFolderPath"]}\{MainApp.DxfFileName}.txt";
			System.IO.File.WriteAllLines(exportFolderPath, gCode);
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
