﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF
{
	public class Arc
	{
		public double CenterX;		//Value 10 in DXF
		public double CenterY;		//Value 20 in DXF
		public double Radius;		//Value 40 in DXF
		public double StartAngle;   //Value 50 in DXF
		public double EndAngle;		//Value 51 in DXF

		public Arc(double centerX, double centerY, double radius, double startAngle, double endAngle)
		{
			CenterX = centerX;
			CenterY = centerY;
			Radius = radius;
			StartAngle = startAngle;
			EndAngle = endAngle;
		}
	}
}
