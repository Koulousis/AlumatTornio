using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF
{
	class Line
	{
		public int StartX; //Value 10 in DXF
		public int StartY; //Value 20 in DXF
		public int EndX;   //Value 11 in DXF
		public int EndY;   //Value 21 in DXF

		public Line(int startX, int startY, int endX, int endY)
		{
			StartX = startX;
			StartY = startY;
			EndX = endX;
			EndY = endY;
		}
	}
}
