using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Actions
{
	public static class Remove
	{
		public static void DuplicateLines()
		{
			MainApp.Lines.GroupBy(x => new { x.StartX, x.StartY, x.EndX, x.EndY }).Select(x => x.First());
		}

		public static void DuplicateArcs()
		{
			MainApp.Arcs.GroupBy(x => new { x.CenterX, x.CenterY, x.Radius, x.StartAngle, x.EndAngle }).Select(x => x.First()).ToList();
		}
	}
}
