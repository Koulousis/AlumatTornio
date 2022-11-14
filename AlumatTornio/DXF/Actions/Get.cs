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

		public static int TransformWidth(int width)
		{
			int tranformWidth = width - (width / 10);
			return tranformWidth;
		}

		public static int TransformHeight(int height)
		{
			int tranformHeight = height - (height / 10);
			return tranformHeight;
		}

		public static float Scale(int viewWidth, int viewHeight)
		{
			float scaleOnWidth = 0;
			float scaleOnHeight = 0;
			float dummyWidth = 0;
			float dummyHeight = 0;

			foreach (Line line in Parameter.DieLines)
			{
				//Width
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

			foreach (Line line in Parameter.DieLines)
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

			scaleOnWidth = ((float)viewWidth - 50) / Math.Abs(dummyWidth);
			scaleOnHeight = ((float)viewHeight - 100) / dummyHeight;

			if (scaleOnWidth < scaleOnHeight)
			{
				return scaleOnWidth;
			}
			else
			{
				return scaleOnHeight;
			}
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
	}
}
