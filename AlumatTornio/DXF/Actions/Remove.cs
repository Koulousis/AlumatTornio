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
