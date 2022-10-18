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
		public static float GetGap()
		{
			float gap = MainApp.Lines[0].StartX;

			//Get the closest distance from origin
			foreach (Line line in MainApp.Lines)
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
		public static void OffsetLines(float gap)
		{
			foreach (Line line in MainApp.Lines)
			{
				line.StartX += Math.Abs(gap);
				line.EndX += Math.Abs(gap);
			}
		}

		public static void OffsetArcs(float gap)
		{
			foreach (Arc arc in MainApp.Arcs)
			{
				arc.CenterX += Math.Abs(gap);
				arc.StartX += Math.Abs(gap);
				arc.EndX += Math.Abs(gap);
			}
		}

	}
}
