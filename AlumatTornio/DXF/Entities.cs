using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF
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
					float startX = float.Parse(entitiesList.ElementAt(i + 2).Replace('.', ','));
					float startY = float.Parse(entitiesList.ElementAt(i + 4).Replace('.', ','));
					float endX = float.Parse(entitiesList.ElementAt(i + 8).Replace('.', ','));
					float endY = float.Parse(entitiesList.ElementAt(i + 10).Replace('.', ','));

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
				//Once the AcDbCircle is found fill the needed data for the Arc object
				if (entitiesList.ElementAt(i) == "AcDbCircle")
				{
					//Since is double datatype, dot must be replaced with comma
					float centerX = float.Parse(entitiesList.ElementAt(i + 2).Replace('.', ','));
					float centerY = float.Parse(entitiesList.ElementAt(i + 4).Replace('.', ','));
					float radius = float.Parse(entitiesList.ElementAt(i + 8).Replace('.', ','));
					float startAngle = float.Parse(entitiesList.ElementAt(i + 12).Replace('.', ','));
					float endAngle = float.Parse(entitiesList.ElementAt(i + 14).Replace('.', ','));

					//Create the found arc and add it on the list
					arcs.Add(new Arc(centerX, centerY, radius, startAngle, endAngle));
				}
			}
			return arcs;
		}
	}
}
