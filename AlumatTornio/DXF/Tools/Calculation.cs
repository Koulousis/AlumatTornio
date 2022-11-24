using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;

namespace DXF.Tools
{
	public static class Calculation
	{
		public static double SweepFromHorizontalAxis(float angle, out int quarter)
		{
			//First circle quarter
			if (angle <= 90)
			{
				quarter = 1;
				return (double)Conversion.DegreesToRads(angle);
			}
			//Second circle quarter
			else if (angle > 90 && angle <= 180)
			{
				quarter = 2;
				return (double)Conversion.DegreesToRads(180 - angle);
			}
			//Third circle quarter
			else if (angle > 180 && angle <= 270)
			{
				quarter = 3;
				return (double)Conversion.DegreesToRads(angle - 180);
			}
			//Fourth circle quarter
			else
			{
				quarter = 4;
				return (double)Conversion.DegreesToRads(360 - angle);
			}
		}

		public static float SweepAngle(float startAngle, float endAngle)
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

		public static int TransformWidth(int width)
		{
			int transformWidth = width - (width / 6);
			return transformWidth;
		}

		public static int TransformHeight(int height)
		{
			int transformHeight = height - (height / 10);
			return transformHeight;
		}
		
		public static float Scale(int viewWidth, int viewHeight)
		{
			float scaleOnWidth = 0;
			float scaleOnHeight = 0;
			float dummyWidth = 0;
			float dummyHeight = 0;

			foreach (Line line in Parameter.DieLines)
			{
				//Width
				if (line.StartX < dummyWidth)
				{
					dummyWidth = line.StartX;
				}
				else if (line.EndX < dummyWidth)
				{
					dummyWidth = line.EndX;
				}
				else
				{
					continue;
				}
			}

			foreach (Line line in Parameter.DieLines)
			{
				if (line.StartY > dummyHeight)
				{
					dummyHeight = line.StartY;
				}
				else if (line.EndY > dummyHeight)
				{
					dummyHeight = line.EndY;
				}
				else
				{
					continue;
				}
			}

			scaleOnWidth = ((float)viewWidth - 100) / Math.Abs(dummyWidth);
			scaleOnHeight = ((float)viewHeight - 100) / dummyHeight;

			if (scaleOnWidth < scaleOnHeight)
			{
				return scaleOnWidth;
			}
			else
			{
				return scaleOnHeight;
			}
		}

	}
}
