using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Elements
{
	public class ProfilePoint
	{
		public float X { get; set;}
		public float Z { get; set; }
		public float R { get; set; }
		public bool Clockwise { get; set; }
		public bool AntiClockwise { get; set; }

		public ProfilePoint(float x, float z)
		{
			X = x;
			Z = z;
		}

		public ProfilePoint(float x, float z, float r, bool clockwise, bool antiClockwise)
		{
			X = x;
			Z = z;
			R = r;
			Clockwise = clockwise;
			AntiClockwise = antiClockwise;
		}
	}
}
