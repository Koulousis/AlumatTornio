using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Elements;
using DXF.Tools;

namespace DXF.Actions
{
	public static class Edit
	{
		public static void FlipElements(List<Line> lines, List<Arc> arcs)
		{
			List<Line> linesFlipped = new List<Line>(lines);
			List<Arc> arcsFlipped = new List<Arc>(arcs);

			linesFlipped = linesFlipped.OrderBy(arc => arc.Index).ToList();
			linesFlipped.Reverse();

			arcsFlipped = arcsFlipped.OrderBy(arc => arc.Index).ToList();
			arcsFlipped.Reverse();

			float distanceFromAxis = 0;
			foreach (Line line in linesFlipped)
			{
				if (line.EndX < distanceFromAxis)
				{
					distanceFromAxis = line.EndX;
				}
			}
			distanceFromAxis = Math.Abs(distanceFromAxis);

			foreach (Line line in linesFlipped)
			{
				line.StartX += distanceFromAxis;
				line.EndX += distanceFromAxis;
				line.StartX = Conversion.StringToThreeDigitFloat(Convert.ToString(line.StartX));
				line.EndX = Conversion.StringToThreeDigitFloat(Convert.ToString(line.EndX));

				line.StartX *= -1;
				line.EndX *= -1;

				(line.StartX, line.StartY, line.EndX, line.EndY) = (line.EndX, line.EndY, line.StartX, line.StartY);
			}

			foreach (Arc arc in arcsFlipped)
			{
				arc.CenterX += distanceFromAxis;
				arc.RectangularCornerX += distanceFromAxis;
				arc.RectangularCornerX += arc.Width;
				arc.StartX += distanceFromAxis;
				arc.EndX += distanceFromAxis;

				arc.CenterX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.CenterX));
				arc.RectangularCornerX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.RectangularCornerX));
				arc.StartX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.StartX));
				arc.EndX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.EndX));

				arc.CenterX *= -1;
				arc.RectangularCornerX *= -1;
				arc.StartX *= -1;
				arc.EndX *= -1;
				
				(arc.StartX, arc.StartY, arc.EndX, arc.EndY) = (arc.EndX, arc.EndY, arc.StartX, arc.StartY);

				if (arc.StartAngle <= 180 && arc.EndAngle <= 180)
				{
					(arc.StartAngle, arc.EndAngle) = (arc.EndAngle, arc.StartAngle);
					arc.StartAngle = 180 - arc.StartAngle;
					arc.EndAngle = 180 - arc.EndAngle;
				}

				if (arc.StartAngle >= 180 && arc.EndAngle >= 180)
				{
					(arc.StartAngle, arc.EndAngle) = (arc.EndAngle, arc.StartAngle);
					arc.StartAngle = 540 - arc.StartAngle;
					arc.EndAngle = 540 - arc.EndAngle;
				}
				
			}
			
		}

		public static void MoveElementsToOrigin(List<Line> lines , List<Arc> arcs, float gapFromX , float gapFromY)
		{
			//Move lines
			if (gapFromX != 0)
			{
				gapFromX = gapFromX > 0 ? -gapFromX : Math.Abs(gapFromX);

				foreach (Line line in lines)
				{
					line.StartX += gapFromX;
					line.EndX += gapFromX;
				}
				foreach (Arc arc in arcs)
				{
					arc.CenterX += gapFromX;
					arc.StartX += gapFromX;
					arc.EndX += gapFromX;
					arc.RectangularCornerX += gapFromX;
				}
			}

			//Move arcs
			if (gapFromY != 0)
			{

				gapFromY = gapFromY > 0 ? -gapFromY : Math.Abs(gapFromY);

				foreach (Line line in lines)
				{
					line.StartY += gapFromY;
					line.EndY += gapFromY;
				}

				foreach (Arc arc in arcs)
				{
					arc.CenterY += gapFromY;
					arc.StartY += gapFromY;
					arc.EndY += gapFromY;
					arc.RectangularCornerY += gapFromY;
				}
			}

		}

		public static void DecimalsCorrection(List<Line> lines, List<Arc> arcs)
		{
			foreach (Line line in lines)
			{
				line.StartX = Conversion.StringToThreeDigitFloat(Convert.ToString(line.StartX));
				line.StartY = Conversion.StringToThreeDigitFloat(Convert.ToString(line.StartY));
				line.EndX = Conversion.StringToThreeDigitFloat(Convert.ToString(line.EndX));
				line.EndY = Conversion.StringToThreeDigitFloat(Convert.ToString(line.EndY));
			}

			foreach (Arc arc in arcs)
			{
				arc.CenterX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.CenterX));
				arc.CenterY = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.CenterY));
				arc.StartX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.StartX));
				arc.StartY = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.StartY));
				arc.EndX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.EndX));
				arc.EndY = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.EndY));
				arc.RectangularCornerX = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.RectangularCornerX));
				arc.RectangularCornerY = Conversion.StringToThreeDigitFloat(Convert.ToString(arc.RectangularCornerY));
			}
		}
	}
}
