using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Actions;
using DXF.Tools;

namespace DXF.Elements
{
	public class Arc
	{
		public int Index { get; set; }
		public float CenterX { get; set; }		//Value 10 in DXF
		public float CenterY { get; set; }       //Value 20 in DXF
		public float Radius { get; set; }        //Value 40 in DXF
		public float StartAngle { get; set; }   //Value 50 in DXF
		public float EndAngle { get; set; }      //Value 51 in DXF
		public string Color { get; set; }
		public float RectangularCornerX { get; set; }
		public float RectangularCornerY { get; set; }
		public float Width { get; set; }
		public float Height { get; set; }
		public float SweepAngle { get; set; }
		public float StartX { get; set; }
		public float StartY { get; set; }
		public float EndX { get; set; }
		public float EndY { get; set; }
		public bool Clockwise { get; set; }
		public bool AntiClockwise { get; set; }
		
		public Arc(float centerX, float centerY, float radius, float startAngle, float endAngle, string color)
		{
			CenterX = centerX;
			CenterY = centerY;
			Radius = radius;
			Color = color;
			RectangularCornerX = centerX - radius;
			RectangularCornerY = centerY - radius;
			Width = radius * 2;
			Height = radius * 2;
			if (startAngle > endAngle && endAngle == 0)
			{
				endAngle = 360;
			}
			if (startAngle >= 0 && startAngle <= 180 && endAngle >= 0 && endAngle <= 180)
			{
				AntiClockwise = true;
				StartAngle = startAngle;
				EndAngle = endAngle;
				SweepAngle = Calculation.SweepAngle(startAngle, endAngle);
			}

			if (startAngle >= 180 && startAngle < 360 && endAngle >= 180 && endAngle <= 360)
			{
				Clockwise = true;
				StartAngle = endAngle;
				EndAngle = startAngle;
				SweepAngle = -Calculation.SweepAngle(startAngle, endAngle);
			}

			int quarter;
			//Math types are: x = Radius * Cos(angle) and y = Radius * Sin(angle)
			float distanceFromCenterOfStartX = Radius * (float)Math.Cos(Calculation.SweepFromHorizontalAxis(startAngle, out quarter));
			float distanceFromCenterOfStartY = Radius * (float)Math.Sin(Calculation.SweepFromHorizontalAxis(startAngle, out quarter));
			float distanceFromCenterOfEndX = Radius * (float)Math.Cos(Calculation.SweepFromHorizontalAxis(endAngle, out quarter));
			float distanceFromCenterOfEndY = Radius * (float)Math.Sin(Calculation.SweepFromHorizontalAxis(endAngle, out quarter));

			//distanceFromCenterOfStartX = Conversion.StringToThreeDigitFloat(distanceFromCenterOfStartX.ToString());
			//distanceFromCenterOfStartY = Conversion.StringToThreeDigitFloat(distanceFromCenterOfStartY.ToString());
			//distanceFromCenterOfEndX = Conversion.StringToThreeDigitFloat(distanceFromCenterOfEndX.ToString());
			//distanceFromCenterOfEndY = Conversion.StringToThreeDigitFloat(distanceFromCenterOfEndY.ToString());

			//To know if the new X,Y points are positive or negative movement from the center
			//is know from the quarter where the points are
			StartX = quarter == 1 || quarter == 4 ? centerX + distanceFromCenterOfStartX : centerX - distanceFromCenterOfStartX;
			StartX = Conversion.StringToFourDigitFloat(StartX.ToString());

			StartY = quarter == 1 || quarter == 2 ? centerY + distanceFromCenterOfStartY : centerY - distanceFromCenterOfStartY;
			StartY = Conversion.StringToFourDigitFloat(StartY.ToString());

			EndX = quarter == 1 || quarter == 4 ? centerX + distanceFromCenterOfEndX : centerX - distanceFromCenterOfEndX;
			EndX = Conversion.StringToFourDigitFloat(EndX.ToString());

			EndY = quarter == 1 || quarter == 2 ? centerY + distanceFromCenterOfEndY : centerY - distanceFromCenterOfEndY;
			EndY = Conversion.StringToFourDigitFloat(EndY.ToString());

		}

		public Arc Clone()
		{
			return new Arc(this.CenterX, this.CenterY, this.Radius, this.StartAngle, this.EndAngle, this.Color)
			{
				Index = this.Index,
				RectangularCornerX = this.RectangularCornerX,
				RectangularCornerY = this.RectangularCornerY,
				Width = this.Width,
				Height = this.Height,
				SweepAngle = this.SweepAngle,
				StartX = this.StartX,
				StartY = this.StartY,
				EndX = this.EndX,
				EndY = this.EndY,
				Clockwise = this.Clockwise,
				AntiClockwise = this.AntiClockwise
			};
		}
	}	
}
