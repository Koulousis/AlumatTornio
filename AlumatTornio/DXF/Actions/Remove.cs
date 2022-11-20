using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;

namespace DXF.Actions
{
	public static class Remove
	{
		public static List<Line> LinesAttachedToAxisX(List<Line> lines)
		{
			//Remove lines attached to Vertical Axis
			Line lineAttachedToAxisX = lines.Find(line => (line.StartX == 0 && line.EndX == 0) || line.StartY == 0 || line.EndY == 0);
			while (lineAttachedToAxisX != null)
			{
				lines.Remove(lineAttachedToAxisX);
				lineAttachedToAxisX = lines.Find(line => (line.StartX == 0 && line.EndX == 0) || line.StartY == 0 || line.EndY == 0);
			}

			return lines;
		}

		public static List<Line> NotProfileLines(List<Line> lines)
		{
			float y1 = lines[0].StartY;
			float y2 = lines[0].EndY;
			bool profileDone = false;

			for (int i = 1; i < lines.Count; i++)
			{
				bool atLeastOnePointSmallerY = lines[i].StartY < y1 || lines[i].EndY < y1 || lines[i].StartY < y2 || lines[i].EndY < y2;
				if (profileDone)
				{
					lines.Remove(lines[i]);
					i--;
				}
				else if (atLeastOnePointSmallerY)
				{
					profileDone = true;
					lines.Remove(lines[i]);
					i--;
				}
				else
				{
					y1 = lines[i].StartY;
					y2 = lines[i].EndY;
				}
			}

			return lines;
		}

		public static List<Arc> NotProfileArcs(List<Arc> arcs)
		{
			float y1 = arcs[0].StartY;
			float y2 = arcs[0].EndY;
			bool profileDone = false;

			for (int i = 1; i < arcs.Count; i++)
			{
				bool atLeastOnePointSmallerY = arcs[i].StartY < y1 || arcs[i].EndY < y1 || arcs[i].StartY < y2 || arcs[i].EndY < y2;
				if (profileDone)
				{
					arcs.Remove(arcs[i]);
					i--;
				}
				else if (atLeastOnePointSmallerY)
				{
					profileDone = true;
					arcs.Remove(arcs[i]);
					i--;
				}
				else
				{
					y1 = arcs[i].StartY;
					y2 = arcs[i].EndY;
				}
			}

			return arcs;
		}

		public static void DuplicateLines()
		{
			Parameter.AllLines.GroupBy(x => new { x.StartX, x.StartY, x.EndX, x.EndY }).Select(x => x.First());
		}

		public static void DuplicateArcs()
		{
			Parameter.AllArcs.GroupBy(x => new { x.CenterX, x.CenterY, x.Radius, x.StartAngle, x.EndAngle }).Select(x => x.First()).ToList();
		}
	}
}
