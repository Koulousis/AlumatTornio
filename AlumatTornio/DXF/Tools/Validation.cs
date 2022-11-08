using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Tools
{
	public static class Validation
	{
		public static bool DxfElementTitle(string text)
		{
			for(int i =0; i < text.Length; i++)
			{
				if (Char.IsWhiteSpace(text[i]) || Char.IsDigit(text[i]) || Char.IsLower(text[i]))
				{
					return false;
				}
			}
			return true;
		}
	}
}
