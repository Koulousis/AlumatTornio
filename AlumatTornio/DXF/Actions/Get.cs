using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;

namespace DXF.Actions
{
	public static class Get
	{
		public static float Gap()
		{
			float gap = Parameter.AllLines[0].StartX;

			//Get the closest distance from origin
			foreach (Line line in Parameter.AllLines)
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
			//Kalutera na trexw to GetBounds kai meta na frontisw na xwraei to width kai to height sto draw
			float scaleOnWidth = 0;
			float scaleOnHeight = 0;
			float dummyWidth = 0;
			float dummyHeight = 0;

			foreach (Line line in Parameter.AllLines)
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

			foreach (Line line in Parameter.AllLines)
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
				//Once the AcDbLine is found collect the needed data for the Line object
				if (dxfText.ElementAt(i) == "AcDbLine")
				{
					int indexOfStartX = i + 2;
					int indexOfStartY = i + 4;
					int indexOfEndX = i + 8;
					int indexOfEndY = i + 10;

					string textOfStartX = dxfText.ElementAt(indexOfStartX);
					string textOfStartY = dxfText.ElementAt(indexOfStartY);
					string textOfEndX = dxfText.ElementAt(indexOfEndX);
					string textOfEndY = dxfText.ElementAt(indexOfEndY);

					//Parsing to float has a round effect on the number because of digit limitation
					float startX = StringToThreeDigitFloat(textOfStartX);
					float startY = StringToThreeDigitFloat(textOfStartY);
					float endX = StringToThreeDigitFloat(textOfEndX);
					float endY = StringToThreeDigitFloat(textOfEndY);

					dxfLines.Add(new Line(startX, startY, endX, endY));
				}
			}

			return dxfLines;
		}

		public static List<Arc> DxfArcs(List<string> dxfText)
		{
			List<Arc> dxfArcs = new List<Arc>();
			//Create list to add the created arcs
			for (int i = 0; i < dxfText.Count; i++)
			{
				//Once the AcDbCircle is found collect the needed data for the Arc object
				if (Parameter.DxfText.ElementAt(i) == "AcDbCircle")
				{
					int indexOfCenterX = i + 2;
					int indexOfCenterY = i + 4;
					int indexOfRadius = i + 8;
					int indexOfStartAngle = dxfText.ElementAt(i + 10) == "AcDbArc" ? i + 12 : i + 18;
					int indexOfEndAngle = dxfText.ElementAt(i + 10) == "AcDbArc" ? i + 14 : i + 20;

					string textOfCenterX = dxfText.ElementAt(indexOfCenterX);
					string textOfCenterY = dxfText.ElementAt(indexOfCenterY);
					string textOfRadius = dxfText.ElementAt(indexOfRadius);
					string textOfStartAngle = dxfText.ElementAt(indexOfStartAngle);
					string textOfEndAngle = dxfText.ElementAt(indexOfEndAngle);

					//Parsing to float has a round effect on the number because of digit limitation
					float centerX = StringToThreeDigitFloat(textOfCenterX);
					float centerY = StringToThreeDigitFloat(textOfCenterY);
					float radius = StringToThreeDigitFloat(textOfRadius);
					float startAngle = StringToThreeDigitFloat(textOfStartAngle);
					float endAngle = StringToThreeDigitFloat(textOfEndAngle);

					dxfArcs.Add(new Arc(centerX, centerY, radius, startAngle, endAngle));
				}
			}

			return dxfArcs;
		}

		public static float StringToThreeDigitFloat(string textLine)
		{
			//Parse text to float to use interpolation to keep 3 decimals only
			//The converting sequence is: string(parameter) => float(givenText) => string(formatText Interpolation) => float return
			float givenText = float.Parse(textLine);
			string formatText = $"{givenText:0.000}";
			return float.Parse(formatText);
		}

		public static List<Line> DieLines(List<Line> allLines)
		{
			List<Line> dieLines = new List<Line>(Parameter.AllLines);


			return dieLines;
		}
	}
}
