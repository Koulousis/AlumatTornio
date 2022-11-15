using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Elements;
using DXF.Tools;

namespace DXF.Actions
{
	public static class Get
	{
		public static float Gap()
		{
			float gap = Parameter.DieLines[0].StartX;

			//Get the closest distance from origin
			foreach (Line line in Parameter.DieLines)
			{
				if (line.StartX > gap)
				{
					gap = line.StartX;
				}
				if (line.EndX > gap)
				{
					gap = line.EndX;
				}
			}
			return gap;
		}

		public static List<Line> DxfLines(List<string> dxfText)
		{
			List<Line> dxfLines = new List<Line>();
			for (int i = 0; i < dxfText.Count; i++)
			{
				if (dxfText.ElementAt(i) == "LINE")
				{
					float startX = 0, startY = 0, endX = 0, endY = 0; string color = "";
					do
					{
						i++;
						switch (dxfText.ElementAt(i).Trim())
						{
							case "AcDbEntity":
								color = dxfText.ElementAt(i + 6).Trim();
								break;
							case "10":
								startX = Conversion.StringToThreeDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "20":
								startY = Conversion.StringToThreeDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "11":
								endX = Conversion.StringToThreeDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "21":
								endY = Conversion.StringToThreeDigitFloat(dxfText.ElementAt(i + 1));
								break;
						}
					} while (!Validation.DxfElementTitle(dxfText.ElementAt(i + 1)));
					dxfLines.Add(new Line(startX, startY, endX, endY, color));
				}
			}
			return dxfLines;
		}

		public static List<Arc> DxfArcs(List<string> dxfText)
		{
			List<Arc> dxfArcs = new List<Arc>();
			for (int i = 0; i < dxfText.Count; i++)
			{
				if (dxfText.ElementAt(i) == "ARC")
				{
					float centerX = 0, centerY = 0, radius = 0, startAngle = 0, endAngle = 0; string color = "";
					do
					{
						i++;
						switch (dxfText.ElementAt(i).Trim())
						{
							case "AcDbEntity":
								color = dxfText.ElementAt(i + 6).Trim();
								break;
							case "10":
								centerX = Conversion.StringToThreeDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "20":
								centerY = Conversion.StringToThreeDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "40":
								radius = Conversion.StringToThreeDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "50":
								startAngle = Conversion.StringToThreeDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "51":
								endAngle = Conversion.StringToThreeDigitFloat(dxfText.ElementAt(i + 1));
								break;
						}
					} while (!Validation.DxfElementTitle(dxfText.ElementAt(i + 1)));
					dxfArcs.Add(new Arc(centerX, centerY, radius, startAngle, endAngle, color));
				}
			}

			return dxfArcs;
		}
		
		public static List<Line> DieLines(List<Line> allLines)
		{
			List<Line> dieLines = new List<Line>(allLines);
			for (int i = 0; i < dieLines.Count; i++)
			{
				if (dieLines[i].Color != Parameter.Green)
				{
					dieLines.Remove(dieLines[i]);
					i--;
				}
			}
			return dieLines;
		}

		public static List<Arc> DieArcs(List<Arc> allArcs)
		{
			List<Arc> dieArcs = new List<Arc>(allArcs);
			for (int i = 0; i < dieArcs.Count; i++)
			{
				if (dieArcs[i].Color != Parameter.Green)
				{
					dieArcs.Remove(dieArcs[i]);
					i--;
				}
			}
			return dieArcs;
		}

		public static List<Line> G71Lines(List<Line> dieLines)
		{
			List<Line> g71Lines = new List<Line>(dieLines).OrderBy(line => line.Index).ToList();

			//Remove lines attached to Vertical Axis
			Line lineAttachedToVerticalAxis = g71Lines.Find(line => line.StartX == 0 && line.EndX == 0);
			while (lineAttachedToVerticalAxis != null)
			{
				g71Lines.Remove(lineAttachedToVerticalAxis);
				lineAttachedToVerticalAxis = g71Lines.Find(line => line.StartX == 0 && line.EndX == 0);
			}

			//Remove lines that has decreased Y from the previous iterated line
			float y1 = g71Lines[0].StartY; 
			float y2 = g71Lines[0].EndY;
			for (int i = 1; i < g71Lines.Count; i++)
			{
				if (g71Lines[i].StartY < y1 || g71Lines[i].EndY < y1 || g71Lines[i].StartY < y2 || g71Lines[i].EndY < y2)
				{
					g71Lines.Remove(g71Lines[i]);
					i--;
				}
				else
				{
					y1 = g71Lines[i].StartY;
					y2 = g71Lines[i].EndY;
				}
			}
			return g71Lines;
		}

		public static List<Arc> G71Arcs(List<Arc> dieArcs)
		{
			List<Arc> g71Arcs = new List<Arc>(dieArcs).OrderBy(arc => arc.Index).ToList();

			//Remove arcs that has decreased Y from the previous iterated arc
			float y1 = g71Arcs[0].StartY;
			float y2 = g71Arcs[0].EndY;
			for (int i = 1; i < g71Arcs.Count; i++)
			{
				if (g71Arcs[i].StartY < y1 || g71Arcs[i].EndY < y1 || g71Arcs[i].StartY < y2 || g71Arcs[i].EndY < y2)
				{
					g71Arcs.Remove(g71Arcs[i]);
					i--;
				}
				else
				{
					y1 = g71Arcs[i].StartY;
					y2 = g71Arcs[i].EndY;
				}
			}
			return g71Arcs;
		}
	}
}
