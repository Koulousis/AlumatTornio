﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.SetupFile
{
	public class Line
	{
		public int Index { get; set; }
		public float StartX { get; set; } //Value 10 in DXF
		public float StartY { get; set; } //Value 20 in DXF
		public float EndX { get; set; }   //Value 11 in DXF
		public float EndY { get; set; }   //Value 21 in DXF

		public Line(float startX, float startY, float endX, float endY)
		{
			StartX = startX;
			StartY = startY;
			EndX = endX;
			EndY = endY;
		}
	}
}
