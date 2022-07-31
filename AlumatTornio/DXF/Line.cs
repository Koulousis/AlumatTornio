using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF
{
	public class Line
	{
		public double StartX; //Value 10 in DXF
		public double StartY; //Value 20 in DXF
		public double EndX;   //Value 11 in DXF
		public double EndY;   //Value 21 in DXF

		public Line(double startX, double startY, double endX, double endY)
		{
			StartX = startX;
			StartY = startY;
			EndX = endX;
			EndY = endY;
		}
	}
}
