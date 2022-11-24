﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Tools
{
	public static class Conversion
	{
		public static float StringToThreeDigitFloat(string textLine)
		{
			//Parse text to float to use interpolation to keep 3 decimals only
			//The converting sequence is: string(parameter) => float(givenText) => string(formatText Interpolation) => float return
			float givenText = float.Parse(textLine);
			string formatText = $"{givenText:0.000}";
			return float.Parse(formatText);
		}

		public static float StringToFourDigitFloat(string textLine)
		{
			//Parse text to float to use interpolation to keep 3 decimals only
			//The converting sequence is: string(parameter) => float(givenText) => string(formatText Interpolation) => float return
			float givenText = float.Parse(textLine);
			string formatText = $"{givenText:0.0000}";
			return float.Parse(formatText);
		}

		public static double DegreesToRads(double angle)
		{
			return (Math.PI * angle) / 180;
		}
	}
}
