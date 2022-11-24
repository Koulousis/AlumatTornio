using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;

namespace DXF.Actions
{
	public static class Add
	{
		public static void CavaToRightSide()
		{
			float cavaLength = 0;
			foreach (Line line in Parameter.CavaLines)
			{
				cavaLength += line.EndX - line.StartX;
			}
			foreach (Arc arc in Parameter.CavaArcs)
			{
				cavaLength += arc.EndX - arc.StartX;
			}

			cavaLength = Math.Abs(cavaLength);

			float cavaStartX = Parameter.G71LinesRightSide[Parameter.G71LinesRightSide.Count - 1].EndX;
			float cavaStartY = Parameter.G71LinesRightSide[Parameter.G71LinesRightSide.Count - 1].EndY;
			Line cavaLine = new Line(cavaStartX, cavaStartY, cavaStartX - cavaLength, cavaStartY, "3")
			{
				Index = Parameter.G71LinesRightSide[Parameter.G71LinesRightSide.Count - 1].Index + 1
			};

			Parameter.G71LinesRightSide.Add(cavaLine);
		}

		public static void CavaToLeftSide()
		{
			float cavaLength = 0;
			foreach (Line line in Parameter.CavaLines)
			{
				cavaLength += line.EndX - line.StartX;
			}
			foreach (Arc arc in Parameter.CavaArcs)
			{
				cavaLength += arc.EndX - arc.StartX;
			}

			cavaLength = Math.Abs(cavaLength);

			float cavaStartX = Parameter.G71LinesLeftSide[Parameter.G71LinesLeftSide.Count - 1].EndX;
			float cavaStartY = Parameter.G71LinesLeftSide[Parameter.G71LinesLeftSide.Count - 1].EndY;
			Line cavaLine = new Line(cavaStartX, cavaStartY, cavaStartX - cavaLength, cavaStartY, "3")
			{
				Index = Parameter.G71LinesLeftSide[Parameter.G71LinesLeftSide.Count - 1].Index - 1
			};

			Parameter.G71LinesLeftSide.Add(cavaLine);
		}
	}
}
