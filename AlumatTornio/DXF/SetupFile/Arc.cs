using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.SetupFile
{
	public class Arc
	{
		public int Index { get; set; }
		public float CenterX { get; set; }		//Value 10 in DXF
		public float CenterY { get; set; }       //Value 20 in DXF
		public float Radius { get; set; }        //Value 40 in DXF
		public float StartAngle { get; set; }   //Value 50 in DXF
		public float EndAngle { get; set; }      //Value 51 in DXF
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



		public Arc(float centerX, float centerY, float radius, float startAngle, float endAngle)
		{
			CenterX = centerX;
			CenterY = centerY;
			Radius = radius;
			RectangularCornerX = centerX - radius;
			RectangularCornerY = centerY - radius;
			Width = radius * 2;
			Height = radius * 2;
			if (startAngle >= 0 && startAngle <= 90 && endAngle >= 0 && endAngle <= 90)
			{
				AntiClockwise = true;
				StartAngle = startAngle;
				EndAngle = endAngle;
				SweepAngle = CalculateSweepAngle(startAngle, endAngle);
			}

			if (startAngle >= 180 && startAngle <= 270 && endAngle >= 180 && endAngle <= 270)
			{
				Clockwise = true;
				StartAngle = endAngle;
				EndAngle = startAngle;
				SweepAngle = -CalculateSweepAngle(startAngle, endAngle);
			}
			

			int quarter;
			//Math types are: x = Radius * Cos(angle) and y = Radius * Sin(angle)
			float distanceFromCenterOfStartX = Radius * (float) Math.Cos(SweepFromHorizontalAxis(startAngle, out quarter));
			float distanceFromCenterOfStartY = Radius * (float)Math.Sin(SweepFromHorizontalAxis(startAngle, out quarter));
			float distanceFromCenterOfEndX = Radius * (float)Math.Cos(SweepFromHorizontalAxis(endAngle, out quarter));
			float distanceFromCenterOfEndY = Radius * (float)Math.Sin(SweepFromHorizontalAxis(endAngle, out quarter));

			//To know if the new X,Y points are positive or negative movement from the center
			//is know from the quarter where the points are
			StartX = quarter == 1 || quarter == 4 ? centerX + distanceFromCenterOfStartX : centerX - distanceFromCenterOfStartX;
			StartX = FromDxf.StringToThreeDigitFloat(StartX.ToString());

			StartY = quarter == 1 || quarter == 2 ? centerY + distanceFromCenterOfStartY : centerY - distanceFromCenterOfStartY;
			StartY = FromDxf.StringToThreeDigitFloat(StartY.ToString());

			EndX = quarter == 1 || quarter == 4 ? centerX + distanceFromCenterOfEndX : centerX - distanceFromCenterOfEndX;
			EndX = FromDxf.StringToThreeDigitFloat(EndX.ToString());

			EndY = quarter == 1 || quarter == 2 ? centerY + distanceFromCenterOfEndY : centerY - distanceFromCenterOfEndY;
			EndY = FromDxf.StringToThreeDigitFloat(EndY.ToString());

		}
		float CalculateSweepAngle(float startAngle, float endAngle)
		{
			float sweepAngle;
			if (startAngle > endAngle)
			{
				sweepAngle = 360 - (startAngle - endAngle);
			}
			else
			{
				sweepAngle = endAngle - startAngle;
			}
			return sweepAngle;
		}

		double SweepFromHorizontalAxis(float angle, out int quarter)
		{
			//First circle quarter
			if (angle <= 90)
			{
				quarter = 1;
				return (double)ConvertDegreesToRads(angle);
			}
			//Second circle quarter
			else if (angle > 90 && angle <= 180)
			{
				quarter = 2;
				return (double)ConvertDegreesToRads(180 - angle);
			}
			//Third circle quarter
			else if (angle > 180 && angle <= 270)
			{
				quarter = 3;
				return (double)ConvertDegreesToRads(angle - 180);
			}
			//Fourth circle quarter
			else
			{
				quarter = 4;
				return (double)ConvertDegreesToRads(360 - angle);
			}
		}

		double ConvertDegreesToRads(double angle)
		{
			return (Math.PI * angle) / 180;
		}


	}	
}
