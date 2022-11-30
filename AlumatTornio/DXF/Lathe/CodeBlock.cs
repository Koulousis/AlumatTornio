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

		public static List<string> StartPosition(List<GCodePoint> g71ProfilePoints)
		{
			float maximumProfilePointX = 0;
			foreach (GCodePoint g71ProfilePoint in g71ProfilePoints)
			{
				if (g71ProfilePoint.X > maximumProfilePointX)
				{
					maximumProfilePointX = g71ProfilePoint.X;
				}
			}

			//Fill G Code
			List<string> startPosition = new List<string>
			{
				"(START POSITION)",
				$"G0 Z{g71ProfilePoints[0].Z + Parameter.StockZFirstSide}",
				$"X{(maximumProfilePointX* 2) + Parameter.StockX}",
				""
			};

			return startPosition;
		}

		public static List<string> G72Facing(G72Attributes g72Attributes)
		{
			//Fill G Code
			List<string> g72Roughing = new List<string>
			{
				"(G72 FACING)",
				$"G72 W{g72Attributes.DepthOfCut} R{g72Attributes.Retract}",
				$"G72 P1 Q2 U{g72Attributes.AllowanceX} W{g72Attributes.AllowanceZ} F{g72Attributes.FeedRate}",
				""
			};

			return g72Roughing;
		}

		public static List<string> G71Roughing(G71Attributes g71Attributes)
		{
			//Fill G Code
			List<string> g71Roughing = new List<string>
			{
				"(G71 ROUGHING)",
				$"G71 U{g71Attributes.DepthOfCut} R{g71Attributes.Retract}",
				$"G71 P3 Q4 U{g71Attributes.AllowanceX} W{g71Attributes.AllowanceZ} F{g71Attributes.FeedRate}",
				""
			};

			return g71Roughing;
		}

		public static List<string> G72Profile(List<GCodePoint> g72ProfilePoints)
		{
			//Fill G Code
			List<string> profileBlock = new List<string>();
			profileBlock.Add("(PROFILE START)");
			profileBlock.Add($"N1 G0 G41 X{(g72ProfilePoints[0].X * 2) + Parameter.StockX} Z{g72ProfilePoints[0].Z}");
			profileBlock.Add($"G1 X{g72ProfilePoints[1].X} Z{g72ProfilePoints[1].Z}");
			profileBlock.Add($"N2 G1 G40 X{g72ProfilePoints[1].X} Z{g72ProfilePoints[1].Z + Parameter.StockZFirstSide}");
			profileBlock.Add("(PROFILE END)");
			profileBlock.Add("");
			profileBlock.Add("(G70 FINISHING)");
			profileBlock.Add("G70 P1 Q2");
			profileBlock.Add("");

			return profileBlock;
		}

		public static List<string> G71Profile(List<GCodePoint> g71ProfilePoints)
		{
			//Fill G Code
			List<string> profileBlock = new List<string>();
			profileBlock.Add("(PROFILE START)");
			profileBlock.Add($"N3 G0 G42 X{(g71ProfilePoints[0].X) * 2} Z{g71ProfilePoints[0].Z + Parameter.StockZFirstSide}");
			foreach (GCodePoint g71ProfilePoint in g71ProfilePoints)
			{
				if (g71ProfilePoint.R == 0)
				{
					profileBlock.Add($"G1 X{g71ProfilePoint.X * 2} Z{g71ProfilePoint.Z}");
				}
				else if(g71ProfilePoint.Clockwise)
				{
					profileBlock.Add($"G2 X{g71ProfilePoint.X * 2} Z{g71ProfilePoint.Z} R{g71ProfilePoint.R}");
				}
				else
				{
					profileBlock.Add($"G3 X{g71ProfilePoint.X * 2} Z{g71ProfilePoint.Z} R{g71ProfilePoint.R}");
				}
			}

			profileBlock.Add($"N4 G1 G40 X{(g71ProfilePoints[g71ProfilePoints.Count - 1].X + Parameter.StockX) * 2} Z{g71ProfilePoints[g71ProfilePoints.Count - 1].Z}");
			profileBlock.Add("(PROFILE END)");
			profileBlock.Add("");

			return profileBlock;
		}

		public static List<string> G70Finishing()
		{
			//Fill G Code
			List<string> g70Finishing = new List<string>
			{
				"(G70 FINISHING)",
				"G70 P3 Q4",
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
