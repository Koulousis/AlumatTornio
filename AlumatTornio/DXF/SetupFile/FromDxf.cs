using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.SetupFile
{
	public static class FromDxf
	{
		public static void GetLines()
		{
			for (int i = 0; i < MainApp.DxfText.Count; i++)
			{
				//Once the AcDbLine is found collect the needed data for the Line object
				if (MainApp.DxfText.ElementAt(i) == "AcDbLine")
				{
					int indexOfStartX = i + 2;
					int indexOfStartY = i + 4;
					int indexOfEndX = i + 8;
					int indexOfEndY = i + 10;

					string textOfStartX = MainApp.DxfText.ElementAt(indexOfStartX);
					string textOfStartY = MainApp.DxfText.ElementAt(indexOfStartY);
					string textOfEndX = MainApp.DxfText.ElementAt(indexOfEndX);
					string textOfEndY = MainApp.DxfText.ElementAt(indexOfEndY);

					//Parsing to float has a round effect on the number because of digit limitation
					float startX = StringToThreeDigitFloat(textOfStartX);
					float startY = StringToThreeDigitFloat(textOfStartY);
					float endX = StringToThreeDigitFloat(textOfEndX);
					float endY = StringToThreeDigitFloat(textOfEndY);

					MainApp.Lines.Add(new Line(startX, startY, endX, endY));
				}
			}
		}

		public static void GetArcs()
		{
			//Create list to add the created arcs
			for (int i = 0; i < MainApp.DxfText.Count; i++)
			{
				//Once the AcDbCircle is found collect the needed data for the Arc object
				if (MainApp.DxfText.ElementAt(i) == "AcDbCircle")
				{
					int indexOfCenterX = i + 2;
					int indexOfCenterY = i + 4;
					int indexOfRadius = i + 8;
					int indexOfStartAngle = MainApp.DxfText.ElementAt(i + 10) == "AcDbArc"? i + 12 : i + 18;
					int indexOfEndAngle = MainApp.DxfText.ElementAt(i + 10) == "AcDbArc" ? i + 14 : i + 20;

					string textOfCenterX = MainApp.DxfText.ElementAt(indexOfCenterX);
					string textOfCenterY = MainApp.DxfText.ElementAt(indexOfCenterY);
					string textOfRadius = MainApp.DxfText.ElementAt(indexOfRadius);
					string textOfStartAngle = MainApp.DxfText.ElementAt(indexOfStartAngle);
					string textOfEndAngle = MainApp.DxfText.ElementAt(indexOfEndAngle);

					//Parsing to float has a round effect on the number because of digit limitation
					float centerX = StringToThreeDigitFloat(textOfCenterX);
					float centerY = StringToThreeDigitFloat(textOfCenterY);
					float radius = StringToThreeDigitFloat(textOfRadius);
					float startAngle = StringToThreeDigitFloat(textOfStartAngle);
					float endAngle = StringToThreeDigitFloat(textOfEndAngle);
					
					MainApp.Arcs.Add(new Arc(centerX, centerY, radius, startAngle, endAngle));
				}				
			}		
		}

		public static float StringToThreeDigitFloat(string textLine)
		{
			//Parse text to float to use interpolation to keep 3 decimals only
			//The converting sequence is: string(parameter) => float(givenText) => string(formatText Interpolation) => float return
			float givenText = float.Parse(textLine);
			string formatText = $"{givenText:0.000}";
			return float.Parse(formatText);
		}

		public static void RemoveDuplicateLines()
		{
			MainApp.Lines.GroupBy(x => new { x.StartX, x.StartY, x.EndX, x.EndY }).Select(x => x.First());
		}

		public static void RemoveDuplicateArcs()
		{
			MainApp.Arcs.GroupBy(x => new { x.CenterX, x.CenterY, x.Radius, x.StartAngle, x.EndAngle }).Select(x => x.First()).ToList();
		}
	}
}
