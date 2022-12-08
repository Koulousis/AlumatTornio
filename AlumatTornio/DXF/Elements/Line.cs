using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Elements
{
	public class Line
	{
		public string Placement { get; set; }
		public int Index { get; set; }
		public float StartX { get; set; } //Value 10 in DXF
		public float StartY { get; set; } //Value 20 in DXF
		public float EndX { get; set; }   //Value 11 in DXF
		public float EndY { get; set; }   //Value 21 in DXF
		public string Color { get; set; }

		public Line()
		{
			
		}

		public Line(float startX, float startY, float endX, float endY , string color)
		{
			StartX = startX;
			StartY = startY;
			EndX = endX;
			EndY = endY;
			Color = color;
		}

		public Line Clone()
		{
			return new Line()
			{
				StartX = this.StartX,
				StartY = this.StartY,
				EndX = this.EndX,
				EndY = this.EndY,
				Placement = this.Placement,
				Index = this.Index,
				Color = this.Color
			};
		}
	}
}
