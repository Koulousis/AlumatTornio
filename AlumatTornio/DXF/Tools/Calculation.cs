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
		
		public static float ElementsLength(List<Line> lines, List<Arc> arcs)
		{
			float length = 0;

			foreach (Line line in lines)
			{
				length += Math.Abs(line.EndX) - Math.Abs(line.StartX);
			}

			foreach (Arc arc in arcs)
			{
				length += Math.Abs(arc.EndX) - Math.Abs(arc.StartX);
			}

			length = Conversion.StringToThreeDigitFloat(length.ToString());

			return length;
		}

		public static float CavaLengthFromProfile(List<Line> cavaLines, List<Arc> cavaArcs, Line lastLine)
		{
			float length = 0;
			float cavaEndX = 0;
			float linesEndX = 0;
			float arcsEndX = 0;

			//Cava end position
			linesEndX = cavaLines.Min(x => x.EndX);
			arcsEndX = cavaArcs.Min(x => x.EndX);

			if (linesEndX < arcsEndX)
			{
				cavaEndX = linesEndX;
			}
			else
			{
				cavaEndX = arcsEndX;
			}

			length = Math.Abs(cavaEndX) - Math.Abs(lastLine.EndX);

			return length;
		}
	}
}
