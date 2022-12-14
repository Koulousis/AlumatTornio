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
				"(-----LATHE INITIALIZATION-----)",
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

		public static List<string> OuterVerticalProfile(G72 g72, List<ProfilePoint> profilePoints)
		{
			List<string> gCode = new List<string>();

			//Get specific profile points to add extra attributes
			ProfilePoint startPosition = profilePoints[0];
			ProfilePoint profileStart = profilePoints[1];
			ProfilePoint profileEnd = profilePoints[profilePoints.Count - 1];
			profilePoints.RemoveAt(0);
			profilePoints.RemoveAt(1);
			profilePoints.RemoveAt(profilePoints.Count - 1);

			//Set g code
			gCode.Add("(-----VERTICAL FACING-----)");
			gCode.Add("(START POSITION)");
			gCode.Add($"G0 Z{startPosition.Z}");
			gCode.Add($"G0 X{startPosition.X}");
			gCode.Add("");
			gCode.Add("(G72 PARAMETERS)");
			gCode.Add($"G72 W{g72.DepthOfCut} R{g72.Retract}");
			gCode.Add($"G72 P{g72.ProfileStart} Q{g72.ProfileEnd} U{g72.AllowanceX} W{g72.AllowanceZ} F{g72.FeedRate}");
			gCode.Add("");
			gCode.Add("PROFILE");
			gCode.Add($"N{g72.ProfileStart} G0 G41 X{profileStart.X} Z{profileStart.Z}");

			foreach (ProfilePoint profilePoint in profilePoints)
			{
				if (profilePoint.R == 0)
				{
					gCode.Add($"G1 X{profilePoint.X} Z{profilePoint.Z}");
				}
				else if (profilePoint.Clockwise)
				{
					gCode.Add($"G2 X{profilePoint.X} Z{profilePoint.Z} R{profilePoint.R}");
				}
				else if (profilePoint.CounterClockwise)
				{
					gCode.Add($"G3 X{profilePoint.X} Z{profilePoint.Z} R{profilePoint.R}");
				}
			}

			gCode.Add($"N{g72.ProfileEnd} G1 G40 X{profileEnd.X} Z{profileEnd.Z}");
			gCode.Add("");
			gCode.Add("(-----VERTICAL FINISHING-----)");
			gCode.Add($"G70 P{g72.ProfileStart} Q{g72.ProfileEnd}");
			gCode.Add("");

			return gCode;
		}

		public static List<string> OuterHorizontalProfile(G71 g71, List<ProfilePoint> profilePoints)
		{
			List<string> gCode = new List<string>();

			//Get specific profile points to add extra attributes
			ProfilePoint startPosition = profilePoints[0];
			ProfilePoint profileStart = profilePoints[1];
			ProfilePoint profileEnd = profilePoints[profilePoints.Count - 1];
			profilePoints.RemoveAt(0);
			profilePoints.RemoveAt(1);
			profilePoints.RemoveAt(profilePoints.Count - 1);

			//Set g code
			gCode.Add("(-----HORIZONTAL ROUGHING-----)");
			gCode.Add("(START POSITION)");
			gCode.Add($"G0 Z{startPosition.Z}");
			gCode.Add($"G0 X{startPosition.X}");
			gCode.Add("");
			gCode.Add("(G71 PARAMETERS)");
			gCode.Add($"G71 U{g71.DepthOfCut} R{g71.Retract}");
			gCode.Add($"G71 P{g71.ProfileStart} Q{g71.ProfileEnd} U{g71.AllowanceX} W{g71.AllowanceZ} F{g71.FeedRate}");
			gCode.Add("");
			gCode.Add("(PROFILE)");
			gCode.Add($"N{g71.ProfileStart} G0 G42 X{profileStart.X} Z{profileStart.Z}");

			foreach (ProfilePoint profilePoint in profilePoints)
			{
				if (profilePoint.R == 0)
				{
					gCode.Add($"G1 X{profilePoint.X} Z{profilePoint.Z}");
				}
				else if (profilePoint.Clockwise)
				{
					gCode.Add($"G2 X{profilePoint.X} Z{profilePoint.Z} R{profilePoint.R}");
				}
				else if (profilePoint.CounterClockwise)
				{
					gCode.Add($"G3 X{profilePoint.X} Z{profilePoint.Z} R{profilePoint.R}");
				}
			}
			
			gCode.Add($"N{g71.ProfileEnd} G1 G40 X{profileEnd.X} Z{profileEnd.Z}");
			gCode.Add("");
			gCode.Add("(-----HORIZONTAL FINISHING-----)");
			gCode.Add($"G70 P{g71.ProfileStart} Q{g71.ProfileEnd}");
			gCode.Add("");

			return gCode;
		}

		public static List<string> LatheEnd()
		{
			//Fill G Code
			List<string> latheEnd = new List<string>
			{
				"(-----LATHE END-----)",
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
