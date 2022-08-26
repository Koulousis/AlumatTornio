using DXF.SetupFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Modify
{
	public class Position
	{
		public static float Gap(List<Line> lines)
		{
			float gap = lines[0].StartX;

			//Get the closest distance from origin
			foreach (Line line in lines)
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
		public static List<Line> OffsetLines(List<Line> lines, float gap)
		{
			for (int i = 0; i  < lines.Count; i ++)
			{
				lines[i].StartX = lines[i].StartX + Math.Abs(gap);
				lines[i].EndX = lines[i].EndX + Math.Abs(gap);
			}
			return lines;
		}

		public static List<Arc> OffsetArcs(List<Arc> arcs, float gap)
		{			
			for (int i = 0; i < arcs.Count; i++)
			{
				arcs[i].CenterX = arcs[i].CenterX + Math.Abs(gap);
			}
			return arcs;
		}
	}
}
