using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.SetupFile
{
	public class Entities
	{
		public static List<Line> GetLines(List<string> entitiesList)
		{
			//Create list to add the created lines
			List<Line> lines = new List<Line>();
			for (int i = 0; i < entitiesList.Count; i++)
			{
				//Once the AcDbLine is found fill the needed data for the Line object
				if (entitiesList.ElementAt(i) == "AcDbLine")
				{
					//Since is double datatype, dot must be replaced with comma
					string sX = entitiesList.ElementAt(i + 2);
					int sXDigitsCrop = sX.LastIndexOf(".") + 4;
					int sXDigitsLength = sX.Length - sX.LastIndexOf(".") - 1;
					if (sXDigitsLength > 3)
					{
						sX = sX.Substring(0, sXDigitsCrop);
					}
					//sX = sX.Replace('.', ',');
					float startX = float.Parse(sX);

					string sY = entitiesList.ElementAt(i + 4);
					int sYDigitsCrop = sY.LastIndexOf(".") + 4;
					int sYDigitsLength = sY.Length - sY.LastIndexOf(".") - 1;
					if (sYDigitsLength > 3)
					{
						sY = sY.Substring(0, sYDigitsCrop);
					}
					//sY = sY.Replace('.', ',');
					float startY = float.Parse(sY);

					string eX = entitiesList.ElementAt(i + 8);
					int eXDigitsCrop = eX.LastIndexOf(".") + 4;
					int eXDigitsLength = eX.Length - eX.LastIndexOf(".") - 1;
					if (eXDigitsLength > 3)
					{
						eX = eX.Substring(0, eXDigitsCrop);
					}
					//eX = eX.Replace('.', ',');
					float endX = float.Parse(eX);

					string eY = entitiesList.ElementAt(i + 10);
					int eYDigitsCrop = eY.LastIndexOf(".") + 4;
					int eYDigitsLength = eY.Length - eY.LastIndexOf(".") - 1;
					if (eYDigitsLength > 3)
					{
						eY = eY.Substring(0, eYDigitsCrop);
					}
					//eY = eY.Replace('.', ',');
					float endY = float.Parse(eY);

					//Create the found line and add it on the list
					lines.Add(new Line(startX, startY, endX, endY));
				}
			}
			return lines;
		}

		public static List<Arc> GetArcs(List<string> entitiesList)
		{
			//Create list to add the created arcs
			List<Arc> arcs = new List<Arc>();
			for (int i = 0; i < entitiesList.Count; i++)
			{
				float centerX = 0;
				float centerY = 0;
				float radius = 0;
				float startAngle = 0;
				float endAngle = 0;

				//Once the AcDbCircle is found fill the needed data for the Arc object
				if (entitiesList.ElementAt(i) == "AcDbCircle")
				{
					//Since is double datatype, dot must be replaced with comma
					string cX = entitiesList.ElementAt(i + 2);
					int cXDigitsCrop = cX.LastIndexOf(".") + 4;
					int cXDigitsLength = cX.Length - cX.LastIndexOf(".") - 1;
					if (cXDigitsLength > 3)
					{
						cX = cX.Substring(0, cXDigitsCrop);
					}
					//cX = cX.Replace('.', ',');
					centerX = float.Parse(cX);

					string cY = entitiesList.ElementAt(i + 4);
					int cYDigitsCrop = cY.LastIndexOf(".") + 4;
					int cYDigitsLength = cY.Length - cY.LastIndexOf(".") - 1;
					if (cYDigitsLength > 3)
					{
						cY = cY.Substring(0, cYDigitsCrop);
					}
					//cY = cY.Replace('.', ',');
					centerY = float.Parse(cY);

					string rad = entitiesList.ElementAt(i + 8);
					int radDigitsCrop = rad.LastIndexOf(".") + 4;
					int radDigitsLength = rad.Length - rad.LastIndexOf(".") - 1;
					if (radDigitsLength > 3)
					{
						rad = rad.Substring(0, radDigitsCrop);
					}
					//rad = rad.Replace('.', ',');
					radius = float.Parse(rad);

					int j = 0;
					int k = 0;
					if (entitiesList.ElementAt(i+10) == "AcDbArc")
					{
						j = 12;
						k = 14;
					}
					else
					{
						j = 18;
						k = 20;
					}

					string sA = entitiesList.ElementAt(i + j);
					int sADigitsCrop = sA.LastIndexOf(".") + 4;
					int sADigitsLength = sA.Length - sA.LastIndexOf(".") - 1;
					if (sADigitsLength > 3)
					{
						sA = sA.Substring(0, sADigitsCrop);
					}
					//sA = sA.Replace('.', ',');
					startAngle = float.Parse(sA);

					string eA = entitiesList.ElementAt(i + k);
					int eADigitsCrop = eA.LastIndexOf(".") + 4;
					int eADigitsLength = eA.Length - eA.LastIndexOf(".") - 1;
					if (eADigitsLength > 3)
					{
						eA = eA.Substring(0, eADigitsCrop);
					}
					//eA = eA.Replace('.', ',');
					endAngle = float.Parse(eA);

					//Create the found arc and add it on the list
					arcs.Add(new Arc(centerX, centerY, radius, startAngle, endAngle));
				}				
			}
			return arcs;
		}
	}
}
