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
					double startX = Convert.ToDouble(entitiesList.ElementAt(i + 2).Replace('.', ','));
					double startY = Convert.ToDouble(entitiesList.ElementAt(i + 4).Replace('.', ','));
					double endX = Convert.ToDouble(entitiesList.ElementAt(i + 8).Replace('.', ','));
					double endY = Convert.ToDouble(entitiesList.ElementAt(i + 10).Replace('.', ','));

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
					double centerX = Convert.ToDouble(entitiesList.ElementAt(i + 2).Replace('.', ','));
					double centerY= Convert.ToDouble(entitiesList.ElementAt(i + 4).Replace('.', ','));
					double radius = Convert.ToDouble(entitiesList.ElementAt(i + 8).Replace('.', ','));
					double startAngle = Convert.ToDouble(entitiesList.ElementAt(i + 12).Replace('.', ','));
					double endAngle = Convert.ToDouble(entitiesList.ElementAt(i + 14).Replace('.', ','));

					//Create the found arc and add it on the list
					arcs.Add(new Arc(centerX, centerY, radius, startAngle, endAngle));
				}
			}
			return arcs;
		}
	}
}
