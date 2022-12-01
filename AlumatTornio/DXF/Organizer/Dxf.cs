using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Actions;
using DXF.Elements;

namespace DXF.Organizer
{
	public static class Dxf
	{
		public static void ManageRightSide()
		{
			Parameter.G71LinesRightSide = Get.G71LinesRightSide(Parameter.DieLinesAsDesigned);
			Parameter.G71ArcsRightSide = Get.G71ArcsRightSide(Parameter.DieLinesAsDesigned, Parameter.DieArcsAsDesigned);
		}

		public static void ManageLeftSide()
		{
			Parameter.G71LinesLeftSide = Get.G71LinesLeftSide(Parameter.DieLinesFlipped);
			Parameter.G71ArcsLeftSide = Get.G71ArcsLeftSide(Parameter.DieLinesFlipped, Parameter.DieArcsFlipped);

			//Edit.FlipElements(Parameter.G71LinesLeftSide, Parameter.G71ArcsLeftSide);
		}

		public static void ManageCava()
		{
			Parameter.CavaLines = Get.CavaLines(Parameter.DieLinesAsDesigned, Parameter.G71LinesRightSide, Parameter.G71LinesLeftSide);
			Parameter.CavaArcs = Get.CavaArcs(Parameter.DieArcsAsDesigned, Parameter.G71ArcsRightSide, Parameter.G71ArcsLeftSide);
		}
	}
}
