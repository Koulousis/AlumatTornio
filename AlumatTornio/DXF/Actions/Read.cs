using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Elements;
using DXF.Properties;

namespace DXF.Actions
{
	public static class Read
	{
		public static bool DxfFile()
		{
			//Trigger the user to select a file via a dialog with dxf files filter
			OpenFileDialog selectDxfDialog = new OpenFileDialog()
			{
				Title = @"Select file",
				InitialDirectory = Settings.Default["DxfFolderPath"].ToString(),
				DefaultExt = @".dxf",
				Filter = @"DXF Files (*.dxf)|*.dxf"
			};

			//If file has been selected, isolate the ENTITIES part from the dxf in the string list
			//and return true to know that the user has selected a file
			if (selectDxfDialog.ShowDialog() == DialogResult.OK)
			{
				MainApp.DxfFileName = Path.GetFileNameWithoutExtension(selectDxfDialog.FileName);
				string[] dxfTextArray = System.IO.File.ReadAllLines(selectDxfDialog.FileName);
				MainApp.DxfText = dxfTextArray.ToList();
				MainApp.DxfText.RemoveRange(0, MainApp.DxfText.IndexOf("ENTITIES"));
				MainApp.DxfText.RemoveRange(MainApp.DxfText.IndexOf("ENDSEC") + 1, MainApp.DxfText.LastIndexOf("EOF") - MainApp.DxfText.IndexOf("ENDSEC"));

				selectDxfDialog.Dispose();
				return true;
			}
			selectDxfDialog.Dispose();
			return false;
		}

		public static void DxfLines()
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

		public static void DxfArcs()
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
					int indexOfStartAngle = MainApp.DxfText.ElementAt(i + 10) == "AcDbArc" ? i + 12 : i + 18;
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
	}
}
