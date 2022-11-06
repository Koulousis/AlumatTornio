using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;

namespace DXF.Lathe
{
	public class CodeBlock
	{
		public static List<string> LatheInitialization()
		{
			//Fill G Code
			List<string> latheInitialization = new List<string>
			{
				"%",
				"O71",
				"(LATHE INITIALIZATION)",
				"G54",
				"M46",
				"G99G18",
				"G0",
				"G40",
				"G28U0",
				"G28U0",
				"G0",
				"G28W0",
				"G50S200",
				"G96S230M4",
				"T2W202",
				""
			};

			return latheInitialization;
		}

		public static List<string> StartPosition()
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
			List<string> startPosition = new List<string>
			{
				"(START POSITION)",
				$"G0 X{maximumHeight * 2} Z{stockWidth}",
				""
			};

			return startPosition;
		}

		public static List<string> G71Roughing(G71Attributes g71Attributes)
		{
			//Fill G Code
			List<string> g71Roughing = new List<string>
			{
				"(G71 ROUGHING)",
				$"G71 U{g71Attributes.DepthOfCut} R{g71Attributes.Retract}",
				$"G71 P1 Q2 U{g71Attributes.AllowanceX} W{g71Attributes.AllowanceZ} F{g71Attributes.FeedRate}",
				""
			};

			return g71Roughing;
		}

		public static List<string> G71Profile()
		{
			//Fill G Code
			List<string> profileBlock = new List<string>();
			profileBlock.Add("(PROFILE BLOCK)");
			profileBlock.Add("N1");
			foreach (GCodePoint gCodePoint in MainApp.GCodePoints)
			{
				if (gCodePoint.Type == "line")
				{
					profileBlock.Add($"G0 X{gCodePoint.X * 2} Z{gCodePoint.Z}");
				}

				if (gCodePoint.Type == "arc" && gCodePoint.Clockwise)
				{
					profileBlock.Add($"G2 X{gCodePoint.X * 2} Z{gCodePoint.Z} R{gCodePoint.R}");
				}

				if (gCodePoint.Type == "arc" && gCodePoint.AntiClockwise)
				{
					profileBlock.Add($"G3 X{gCodePoint.X * 2} Z{gCodePoint.Z} R{gCodePoint.R}");
				}
			}
			profileBlock.Add("N2");
			profileBlock.Add("");

			return profileBlock;
		}

		public static List<string> G70Finishing()
		{
			//Fill G Code
			List<string> g70Finishing = new List<string>
			{
				"(G70 FINISHING)",
				"G70 P1 Q2",
				""
			};

			return g70Finishing;
		}

		public static List<string> LatheEnd()
		{
			//Fill G Code
			List<string> latheEnd = new List<string>
			{
				"(LATHE END)",
				"G0",
				"G40",
				"G28U0",
				"G0",
				"G28W0",
				"M99",
				"%",
				""
			};

			return latheEnd;
		}
	}
}
