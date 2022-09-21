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
			GraphicsPath graphicsPath = new GraphicsPath();

			//Clone thes lists on new listsm because on the iteration they will become empty
			List<Line> pathLines = new List<Line>(lines);
			List<Arc> pathArcs = new List<Arc>(arcs); 

			//float distance = ((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1));
			//dis = Math.Sqrt(Convert.ToDouble(distance));
			float basePointX = pathLines[0].EndX;
			float basePointY = pathLines[0].EndY;
			float baseCenterX = 0;
			float baseCenterY = 0;
			float baseRadius = 0;
			string baseIs = "line";
			graphicsPath.AddLine(pathLines[0].StartX, pathLines[0].StartY, pathLines[0].EndX, pathLines[0].EndY);
			pathLines.RemoveAt(0);

			//Loop times equal to the entities amount
			int entitiesAmount = pathLines.Count + pathArcs.Count;
			while (entitiesAmount != 0)
			{
				//Search on lines
				for (int l = 0; l < pathLines.Count; l++)
				{
					if (baseIs == "line")
					{
						bool meetsStart = basePointX == pathLines[l].StartX && basePointY == pathLines[l].StartY;
						bool meetsEnd = basePointX == pathLines[l].EndX && basePointY == pathLines[l].EndY;
						if (meetsStart)
						{
							//Add the line to path
							graphicsPath.AddLine(pathLines[l].StartX, pathLines[l].StartY, pathLines[l].EndX, pathLines[l].EndY);
							//Target the opposite point as the base point
							basePointX = pathLines[l].EndX;
							basePointY = pathLines[l].EndY;
							pathLines.Remove(pathLines[l]);
							baseIs = "line";
							entitiesAmount--;
						}
						if (meetsEnd)
						{
							//Add the line to path
							graphicsPath.AddLine(pathLines[l].EndX, pathLines[l].EndY, pathLines[l].StartX, pathLines[l].StartY);
							//Target the opposite point as the base point
							basePointX = pathLines[l].StartX;
							basePointY = pathLines[l].StartY;
							pathLines.Remove(pathLines[l]);
							baseIs = "line";
							entitiesAmount--;
						}
					}
					else if (baseIs == "arc")
					{
						float formulaStart = ((pathLines[l].StartX - baseCenterX) * (pathLines[l].StartX - baseCenterX)) + ((pathLines[l].StartY - baseCenterY) * (pathLines[l].StartY - baseCenterY));
						double distanceStart = Math.Sqrt(Convert.ToDouble(formulaStart));
						bool meetsStart = distanceStart - baseRadius < 0.01;

						float formulaEnd = ((pathLines[l].EndX - baseCenterX) * (pathLines[l].EndX - baseCenterX)) + ((pathLines[l].EndY - baseCenterY) * (pathLines[l].EndY - baseCenterY));
						double distanceEnd = Math.Sqrt(Convert.ToDouble(formulaEnd));
						bool meetsEnd = distanceEnd - baseRadius < 0.01;

						if (meetsStart)
						{
							//Add the line to path
							graphicsPath.AddLine(pathLines[l].StartX, pathLines[l].StartY, pathLines[l].EndX, pathLines[l].EndY);
							//Target the opposite point as the base point
							basePointX = pathLines[l].EndX;
							basePointY = pathLines[l].EndY;
							pathLines.Remove(pathLines[l]);
							baseIs = "line";
							entitiesAmount--;
						}
						if (meetsEnd)
						{
							//Add the line to path
							graphicsPath.AddLine(pathLines[l].StartX, pathLines[l].StartY, pathLines[l].EndX, pathLines[l].EndY);
							//Target the opposite point as the base point
							basePointX = pathLines[l].StartX;
							basePointY = pathLines[l].StartY;
							pathLines.Remove(pathLines[l]);
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
				for (int a = 0; a < pathArcs.Count; a++)
				{
					//formula = ((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) & Math.Sqrt(Convert.ToDouble(formula)) 

					//Measure the distance from the base point to the center of the arc
					float formula = ((basePointX - pathArcs[a].CenterX) * (basePointX - pathArcs[a].CenterX)) + ((basePointY - pathArcs[a].CenterY) * (basePointY - pathArcs[a].CenterY));
					double distance = Math.Sqrt(Convert.ToDouble(formula));

					//Check if the distance is approximate equal to the arc radius
					bool distanceApproxToRadius = distance - pathArcs[a].Radius < 0.01;
					if (distanceApproxToRadius)
					{
						float cornerX = pathArcs[a].CenterX - pathArcs[a].Radius;
						float cornerY = pathArcs[a].CenterY - pathArcs[a].Radius;
						float width = pathArcs[a].Radius * 2;
						float height = width;
						float startAngle, sweepAngle;

						startAngle = pathArcs[a].StartAngle;
						if (pathArcs[a].StartAngle > pathArcs[a].EndAngle)
						{
							sweepAngle = 360 - (pathArcs[a].StartAngle - pathArcs[a].EndAngle);
						}
						else
						{
							sweepAngle = pathArcs[a].EndAngle - pathArcs[a].StartAngle;
						}
						graphicsPath.AddArc(cornerX, cornerY, width, height, startAngle, sweepAngle);
						baseCenterX = pathArcs[a].CenterX;
						baseCenterY = pathArcs[a].CenterY;
						baseRadius = pathArcs[a].Radius;
						pathArcs.Remove(pathArcs[a]);
						baseIs = "arc";
						entitiesAmount--;
					}
				}
			}
			return graphicsPath;
		}
	}
}
