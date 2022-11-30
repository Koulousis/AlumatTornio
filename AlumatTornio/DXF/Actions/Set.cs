using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;
using DXF.Tools;

namespace DXF.Actions
{
	public class Set
	{
		public static void StockDiameter(float dieDiameter)
		{
			Parameter.StockDiameter = (float)Math.Ceiling(dieDiameter);
			Parameter.StockDiameter += Parameter.StockDiameterExtra;
		}


		public static void StockWidth(float dieWidth)
		{
			Parameter.StockWidth = (float)Math.Ceiling(dieWidth);
			Parameter.StockWidth += Parameter.StockWidthExtra;
		}

		public static void StockX(float stockDiameter, float dieDiameter)
		{
			Parameter.StockX = stockDiameter - dieDiameter;
			Parameter.StockX = Conversion.StringToThreeDigitFloat(Convert.ToString(Parameter.StockX));
		}

		public static void StockZFirstSide(float stockWidth, float dieWidth)
		{
			Parameter.StockZFirstSide = stockWidth - dieWidth - Parameter.StockZSecondSide;
			Parameter.StockZFirstSide = Conversion.StringToThreeDigitFloat(Convert.ToString(Parameter.StockZFirstSide));
		}

		public static void StockZSecondSide(float dieWidth)
		{
			Parameter.StockZSecondSide = 1 + 1 - Parameter.DieWidth % 1;
			Parameter.StockZSecondSide = Conversion.StringToThreeDigitFloat(Convert.ToString(Parameter.StockZSecondSide));
		}
	}
}
