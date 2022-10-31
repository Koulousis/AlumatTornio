using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.SetupFile
{
	public class PointsPair
	{
		public float X1 { get; set; }
		public float Y1 { get; set; }
		public float X2 { get; set; }
		public float Y2 { get; set; }
	}

	public class GCodePoint
	{
		public string Type { get; set;}
		public float X { get; set;}
		public float Z { get; set; }
		public float R { get; set; }
		public bool Clockwise { get; set; }
		public bool AntiClockwise { get; set; }

		public GCodePoint(string type, float x, float z)
		{
			Type = type;
			X = x;
			Z = z;
		}

		public GCodePoint(string type, float x, float z, float r, bool clockwise, bool antiClockwise)
		{
			Type = type;
			X = x;
			Z = z;
			R = r;
			Clockwise = clockwise;
			AntiClockwise = antiClockwise;
		}
	}
}
