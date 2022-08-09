using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF
{
	public class Arc
	{
		public float CenterX;		//Value 10 in DXF
		public float CenterY;		//Value 20 in DXF
		public float Radius;		//Value 40 in DXF
		public float StartAngle;   //Value 50 in DXF
		public float EndAngle;		//Value 51 in DXF

		public Arc(float centerX, float centerY, float radius, float startAngle, float endAngle)
		{
			CenterX = centerX;
			CenterY = centerY;
			Radius = radius;
			StartAngle = startAngle;
			EndAngle = endAngle;
		}
	}
}
