﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;

namespace DXF.Actions
{
	public static class Initial
	{
		public static void GlobalParameters()
		{
			Parameter.DxfFileName = string.Empty;

			Parameter.FirstSideLines = new List<Line>();
			Parameter.FirstSideArcs = new List<Arc>();

			Parameter.SecondSideLines = new List<Line>();
			Parameter.SecondSideArcs = new List<Arc>();

			Parameter.DieDiameter = 0f;
			Parameter.DieRadius = 0f;
			Parameter.DieWidth = 0f;
		}
	}
}
