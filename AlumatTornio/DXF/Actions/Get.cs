using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Elements;
using DXF.Tools;

namespace DXF.Actions
{
	public static class Get
	{
		public static float GapX(List<Line> allLines)
		{
			float gapX = allLines[0].StartX;

			//Get the closest distance from origin
			foreach (Line line in allLines)
			{
				if (line.StartX > gapX)
				{
					gapX = line.StartX;
				}
				if (line.EndX > gapX)
				{
					gapX = line.EndX;
				}
			}
			return gapX;
		}

		public static float GapY(List<Line> allLines)
		{
			float gapY = allLines[0].StartY;

			//Get the closest distance from origin
			foreach (Line line in allLines)
			{
				if (line.StartY < gapY)
				{
					gapY = line.StartY;
				}
				if (line.EndY < gapY)
				{
					gapY = line.EndY;
				}
			}
			return gapY;
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
								if (color.Length > 1) { color = dxfText.ElementAt(i + 4).Trim(); }								break;
							case "10":
								startX = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "20":
								startY = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "11":
								endX = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "21":
								endY = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
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
								if (color.Length > 1) { color = dxfText.ElementAt(i + 4).Trim(); }
								break;
							case "10":
								centerX = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "20":
								centerY = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "40":
								radius = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "50":
								startAngle = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
								break;
							case "51":
								endAngle = Conversion.StringToFourDigitFloat(dxfText.ElementAt(i + 1));
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
			List<Line> dieLines = new List<Line>();
			foreach (Line line in allLines) { dieLines.Add(line.Clone()); }

			//List<Line> dieLines = new List<Line>(allLines);
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
			List<Arc> dieArcs = new List<Arc>();
			foreach (Arc arc in allArcs) { dieArcs.Add(arc.Clone()); }

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

		public static List<Line> DieLinesMirrored(List<Line> dieLines)
		{
			List<Line> dieLinesMirrored = new List<Line>();
			foreach (Line line in Parameter.DieLines)
			{
				dieLinesMirrored.Add(line.Clone());
			}

			return dieLinesMirrored;
		}

		public static List<Arc> DieArcsMirrored(List<Arc> dieArcs)
		{
			List<Arc> dieArcsMirrored = new List<Arc>();
			foreach (Arc arc in Parameter.DieArcs)
			{
				dieArcsMirrored.Add(arc.Clone());
			}

			return dieArcsMirrored;
		}

		public static List<Line> G71LinesRightSide(List<Line> dieLines)
		{
			//Read die lines ordered by index
			List<Line> g71LinesRightSide = new List<Line>();
			foreach (Line line in dieLines) { g71LinesRightSide.Add(line.Clone()); }
			g71LinesRightSide = g71LinesRightSide.OrderBy(line => line.Index).ToList();

			//Remove lines attached to Vertical Axis
			g71LinesRightSide = Remove.LinesAttachedToAxisX(g71LinesRightSide);

			//Remove lines that has decreased Y from the previous iterated line
			g71LinesRightSide = Remove.NotProfileLines(g71LinesRightSide);

			return g71LinesRightSide;
		}

		public static List<Arc> G71ArcsRightSide(List<Line> dieLines, List<Arc> dieArcs)
		{
			List<Arc> g71ArcsRightSide = new List<Arc>();
			foreach (Arc arc in dieArcs) { g71ArcsRightSide.Add(arc.Clone()); }
			g71ArcsRightSide = g71ArcsRightSide.OrderBy(arc => arc.Index).ToList();

			//Remove arcs that has decreased Y from the previous iterated arc
			g71ArcsRightSide = Remove.NotProfileArcs(dieLines, g71ArcsRightSide, "Right");

			return g71ArcsRightSide;
		}

		public static List<Line> G71LinesLeftSide(List<Line> dieLines)
		{
			//Read die lines ordered by index and reverse them
			List<Line> g71LinesLeftSide = new List<Line>();
			foreach (Line line in dieLines) { g71LinesLeftSide.Add(line.Clone()); }
			g71LinesLeftSide = g71LinesLeftSide.OrderBy(line => line.Index).ToList();
			g71LinesLeftSide.Reverse();

			//Remove lines attached to Vertical Axis
			g71LinesLeftSide = Remove.LinesAttachedToAxisX(g71LinesLeftSide);

			//Remove lines that has decreased Y from the previous iterated line
			g71LinesLeftSide = Remove.NotProfileLines(g71LinesLeftSide);

			return g71LinesLeftSide;
		}

		public static List<Arc> G71ArcsLeftSide(List<Line> dieLinesMirrored, List<Arc> dieArcsMirrored)
		{
			//Read die arcs ordered by index and reverse them
			List<Arc> g71ArcsLeftSide = new List<Arc>();
			foreach (Arc arc in dieArcsMirrored) { g71ArcsLeftSide.Add(arc.Clone()); }
			g71ArcsLeftSide = g71ArcsLeftSide.OrderBy(arc => arc.Index).ToList();
			g71ArcsLeftSide.Reverse();

			//Remove arcs that has decreased Y from the previous iterated arc
			g71ArcsLeftSide = Remove.NotProfileArcs(dieLinesMirrored, g71ArcsLeftSide, "Left");

			return g71ArcsLeftSide;
		}

		public static List<Line> CavaLines(List<Line> dieLines, List<Line> rightProfileLines, List<Line> leftProfileLines)
		{
			List<Line> cavaLines = new List<Line>();
			foreach (Line line in dieLines) { cavaLines.Add(line.Clone()); }
			cavaLines = Remove.LinesAttachedToAxisX(cavaLines);

			for (int i = 0; i < cavaLines.Count; i++)
			{
				foreach (Line line in rightProfileLines)
				{
					if (cavaLines[i].Index == line.Index)
					{
						cavaLines.Remove(cavaLines[i]);
						i--;
						break;
					}
				}
			}

			for (int i = 0; i < cavaLines.Count; i++)
			{
				foreach (Line line in leftProfileLines)
				{
					if (cavaLines[i].Index == line.Index)
					{
						cavaLines.Remove(cavaLines[i]);
						i--;
						break;
					}
				}
			}


			return cavaLines;
		}

		public static List<Arc> CavaArcs(List<Arc> dieArcs, List<Arc> rightProfileArcs, List<Arc> leftProfilesArcs)
		{
			List<Arc> cavaArcs = new List<Arc>();
			foreach (Arc arc in dieArcs) { cavaArcs.Add(arc.Clone()); }

			for (int i = 0; i < cavaArcs.Count; i++)
			{
				foreach (Arc arc in rightProfileArcs)
				{
					if (cavaArcs[i].Index == arc.Index)
					{
						cavaArcs.Remove(cavaArcs[i]);
						i--;
						break;
					}
				}
			}

			for (int i = 0; i < cavaArcs.Count; i++)
			{
				foreach (Arc arc in leftProfilesArcs)
				{
					if (cavaArcs[i].Index == arc.Index)
					{
						cavaArcs.Remove(cavaArcs[i]);
						i--;
						break;
					}
				}
			}

			return cavaArcs;
		}

	}
}
