using DXF.SetupFile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Modify
{
	public class Create
	{
		public static GraphicsPath Path(List<Line> lines, List<Arc> arcs)
		{
			GraphicsPath graphicsPath = new GraphicsPath(FillMode.Alternate);


			//float distance = ((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1));
			//dis = Math.Sqrt(Convert.ToDouble(distance));
			float basePointX = lines[0].EndX;
			float basePointY = lines[0].EndY;
			float baseCenterX = 0;
			float baseCenterY = 0;
			float baseRadius = 0;
			string baseIs = "line";
			graphicsPath.AddLine(lines[0].StartX, lines[0].StartY, lines[0].EndX, lines[0].EndY);
			lines.RemoveAt(0);

			//Loop times equal to the entities amount
			int entitiesAmount = lines.Count + arcs.Count;
			while (entitiesAmount != 0)
			{
				//Search on lines
				for (int l = 0; l < lines.Count; l++)
				{
					if (baseIs == "line")
					{
						bool meetsStart = basePointX == lines[l].StartX && basePointY == lines[l].StartY;
						bool meetsEnd = basePointX == lines[l].EndX && basePointY == lines[l].EndY;
						if (meetsStart)
						{
							//Add the line to path
							graphicsPath.AddLine(lines[l].StartX, lines[l].StartY, lines[l].EndX, lines[l].EndY);
							//Target the opposite point as the base point
							basePointX = lines[l].EndX;
							basePointY = lines[l].EndY;
							lines.Remove(lines[l]);
							baseIs = "line";
							entitiesAmount--;
						}
						if (meetsEnd)
						{
							//Add the line to path
							graphicsPath.AddLine(lines[l].StartX, lines[l].StartY, lines[l].EndX, lines[l].EndY);
							//Target the opposite point as the base point
							basePointX = lines[l].StartX;
							basePointY = lines[l].StartY;
							lines.Remove(lines[l]);
							baseIs = "line";
							entitiesAmount--;
						}
					}
					else if (baseIs == "arc")
					{
						float formulaStart = ((lines[l].StartX - baseCenterX) * (lines[l].StartX - baseCenterX)) + ((lines[l].StartY - baseCenterY) * (lines[l].StartY - baseCenterY));
						double distanceStart = Math.Sqrt(Convert.ToDouble(formulaStart));
						bool meetsStart = distanceStart - baseRadius < 0.01;

						float formulaEnd = ((lines[l].EndX - baseCenterX) * (lines[l].EndX - baseCenterX)) + ((lines[l].EndY - baseCenterY) * (lines[l].EndY - baseCenterY));
						double distanceEnd = Math.Sqrt(Convert.ToDouble(formulaEnd));
						bool meetsEnd = distanceEnd - baseRadius < 0.01;

						if (meetsStart)
						{
							//Add the line to path
							graphicsPath.AddLine(lines[l].StartX, lines[l].StartY, lines[l].EndX, lines[l].EndY);
							//Target the opposite point as the base point
							basePointX = lines[l].EndX;
							basePointY = lines[l].EndY;
							lines.Remove(lines[l]);
							baseIs = "line";
							entitiesAmount--;
						}
						if (meetsEnd)
						{
							//Add the line to path
							graphicsPath.AddLine(lines[l].StartX, lines[l].StartY, lines[l].EndX, lines[l].EndY);
							//Target the opposite point as the base point
							basePointX = lines[l].StartX;
							basePointY = lines[l].StartY;
							lines.Remove(lines[l]);
							baseIs = "line";
							entitiesAmount--;
						}
					}
					else
					{
						continue;
					}
				}

				//Search on arcs
				for (int a = 0; a < arcs.Count; a++)
				{
					//formula = ((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) & Math.Sqrt(Convert.ToDouble(formula)) 

					//Measure the distance from the base point to the center of the arc
					float formula = ((basePointX - arcs[a].CenterX) * (basePointX - arcs[a].CenterX)) + ((basePointY - arcs[a].CenterY) * (basePointY - arcs[a].CenterY));
					double distance = Math.Sqrt(Convert.ToDouble(formula));

					//Check if the distance is approximate equal to the arc radius
					bool distanceApproxToRadius = distance - arcs[a].Radius < 0.01;
					if (distanceApproxToRadius)
					{
						float cornerX = arcs[a].CenterX - arcs[a].Radius;
						float cornerY = arcs[a].CenterY - arcs[a].Radius;
						float width = arcs[a].Radius * 2;
						float height = width;
						float startAngle, sweepAngle;

						startAngle = arcs[a].StartAngle;
						if (arcs[a].StartAngle > arcs[a].EndAngle)
						{
							sweepAngle = 360 - (arcs[a].StartAngle - arcs[a].EndAngle);
						}
						else
						{
							sweepAngle = arcs[a].EndAngle - arcs[a].StartAngle;
						}
						graphicsPath.AddArc(cornerX, cornerY, width, height, startAngle, sweepAngle);
						baseCenterX = arcs[a].CenterX;
						baseCenterY = arcs[a].CenterY;
						baseRadius = arcs[a].Radius;
						arcs.Remove(arcs[a]);
						baseIs = "arc";
						entitiesAmount--;
					}
				}
			}
			return graphicsPath;
		}
	}
}
