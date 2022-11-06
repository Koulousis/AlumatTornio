using DXF.SetupFile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Properties;

namespace DXF.Generate
{
	public class GCode
	{
		public static string[] Export(Dictionary<string, decimal> g71Attributes)
		{
			List<string> gCodeFile = new List<string>();
			LatheInitialization(gCodeFile);
			StartPosition(gCodeFile);
			G71Roughing(gCodeFile,g71Attributes);
			ProfileBlock(gCodeFile);
			G70Finishing(gCodeFile);
			LatheEnd(gCodeFile);
			
			string exportFolderPath = $@"{Settings.Default["ExportFolderPath"]}\{MainApp.DxfFileName}.txt";
			System.IO.File.WriteAllLines(exportFolderPath, gCodeFile);
			return gCodeFile.ToArray();
		}

		static void LatheInitialization(List<string> gCodeFile)
		{
			//Fill G Code
			gCodeFile.Add("%");
			gCodeFile.Add("O71");
			gCodeFile.Add("(LATHE INITIALIZATION)");
			gCodeFile.Add("G54");
			gCodeFile.Add("M46");
			gCodeFile.Add("G99G18");
			gCodeFile.Add("G0");
			gCodeFile.Add("G40");
			gCodeFile.Add("G28U0");
			gCodeFile.Add("G28U0");
			gCodeFile.Add("G0");
			gCodeFile.Add("G28W0");
			gCodeFile.Add("G50S200");
			gCodeFile.Add("G96S230M4");
			gCodeFile.Add("T2W202");
			gCodeFile.Add("");
		}

		static void StartPosition(List<string> gCodeFile)
		{
			float maximumHeight = 0;
			float stockHeight = 2;
			float stockWidth = 2;

			foreach (Line line in MainApp.Lines)
			{
				//Find Maximum Height
				if (line.StartY > maximumHeight)
				{
					maximumHeight = line.StartY;
				}
				else if (line.EndY > maximumHeight)
				{
					maximumHeight = line.EndY;
				}

				//Add stock material
				maximumHeight += stockHeight;
			}
			//Fill G Code
			gCodeFile.Add("(START POSITION)");
			gCodeFile.Add($"G0 X{maximumHeight * 2} Z{stockWidth}");
			gCodeFile.Add("");
		}

		static void G71Roughing(List<string> gCodeFile, Dictionary<string, decimal> g71Attributes)
		{
			//Fill G Code
			gCodeFile.Add("(G71 ROUGHING)");
			gCodeFile.Add($"G71 U{g71Attributes["depthOfCut"]} R{g71Attributes["retractValue"]}");
			gCodeFile.Add($"G71 P1 Q2 U{g71Attributes["xAllowance"]} W{g71Attributes["zAllowance"]} F{g71Attributes["feedRate"]}");
			gCodeFile.Add("");
		}

		static void ProfileBlock(List<string> gCodeFile)
		{
			//Fill G Code
			gCodeFile.Add("(PROFILE BLOCK)");
			gCodeFile.Add("N1");
			foreach (GCodePoint gCodePoint in MainApp.GCodePoints)
			{
				if (gCodePoint.Type == "line")
				{
					gCodeFile.Add($"G0 X{gCodePoint.X * 2} Z{gCodePoint.Z}");
				}

				if (gCodePoint.Type == "arc" && gCodePoint.Clockwise)
				{
					gCodeFile.Add($"G2 X{gCodePoint.X * 2} Z{gCodePoint.Z} R{gCodePoint.R}");
				}

				if (gCodePoint.Type == "arc" && gCodePoint.AntiClockwise)
				{
					gCodeFile.Add($"G3 X{gCodePoint.X * 2} Z{gCodePoint.Z} R{gCodePoint.R}");
				}
			}
			gCodeFile.Add("N2");
			gCodeFile.Add("");
		}

		static void G70Finishing(List<string> gCodeFile)
		{
			//Fill G Code
			gCodeFile.Add("(G70 FINISHING)");
			gCodeFile.Add("G70 P1 Q2");
			gCodeFile.Add("");
		}

		static void LatheEnd(List<string> gCodeFile)
		{
			//Fill G Code
			gCodeFile.Add("(LATHE END)");
			gCodeFile.Add("G0");
			gCodeFile.Add("G40");
			gCodeFile.Add("G28U0");
			gCodeFile.Add("G0");
			gCodeFile.Add("G28W0");
			gCodeFile.Add("M99");
			gCodeFile.Add("%");
			gCodeFile.Add("");
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
