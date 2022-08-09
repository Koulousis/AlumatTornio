using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF
{
	public class Line
	{
		public float StartX; //Value 10 in DXF
		public float StartY; //Value 20 in DXF
		public float EndX;   //Value 11 in DXF
		public float EndY;   //Value 21 in DXF

		public Line(float startX, float startY, float endX, float endY)
		{
			StartX = startX;
			StartY = startY;
			EndX = endX;
			EndY = endY;
		}
	}
}
