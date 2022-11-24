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
		public static void ManageGeneral(OpenFileDialog selectedDxfDialog)
		{
			Parameter.DxfText = new List<string>();
			Parameter.AllLines = new List<Line>();
			Parameter.AllArcs = new List<Arc>();
			Parameter.DieLines = new List<Line>();
			Parameter.G71ProfilePointsRightSide = new List<G71ProfilePoint>();

			//Read the selected file
			Parameter.DxfText = Read.DxfFile(selectedDxfDialog);
			if (Parameter.DxfText == null) return;

			//Read Dxf elements
			Parameter.AllLines = Get.DxfLines(Parameter.DxfText);
			Parameter.AllArcs = Get.DxfArcs(Parameter.DxfText);

			//Check if the dxf starts from X0:Y0
			float gapX = Get.GapX(Parameter.AllLines);
			float gapY = Get.GapY(Parameter.AllLines);
			if (gapX != 0 || gapY != 0)
			{
				Edit.CenterLines(Parameter.AllLines, gapX, gapY);
				Edit.CenterArcs(Parameter.AllArcs, gapX, gapY);
			}
			Edit.DecimalsCorrection(Parameter.AllLines, Parameter.AllArcs);


			//Construct specific element lists
			Parameter.DieLines = Get.DieLines(Parameter.AllLines);
			Parameter.DieArcs = Get.DieArcs(Parameter.AllArcs);
			Edit.AddIndexesAndMakeCorrections(Parameter.DieLines, Parameter.DieArcs);

			Parameter.DieLinesFlipped = Get.DieLinesMirrored(Parameter.DieLines);
			Parameter.DieArcsFlipped = Get.DieArcsMirrored(Parameter.DieArcs);
			Edit.FlipElements(Parameter.DieLinesFlipped, Parameter.DieArcsFlipped);

			//Remove.DuplicateLines();
			//Remove.DuplicateArcs();

			//Modify the data
			//
			//Edit.CenterLines(gap);
			//Get.CenterArcs(gap);
		}

		public static void ManageRightSide()
		{
			Parameter.G71LinesRightSide = Get.G71LinesRightSide(Parameter.DieLines);
			Parameter.G71ArcsRightSide = Get.G71ArcsRightSide(Parameter.DieLines, Parameter.DieArcs);
		}

		public static void ManageLeftSide()
		{
			Parameter.G71LinesLeftSide = Get.G71LinesLeftSide(Parameter.DieLinesFlipped);
			Parameter.G71ArcsLeftSide = Get.G71ArcsLeftSide(Parameter.DieLinesFlipped, Parameter.DieArcsFlipped);

			//Edit.FlipElements(Parameter.G71LinesLeftSide, Parameter.G71ArcsLeftSide);
		}

		public static void ManageCava()
		{
			Parameter.CavaLines = Get.CavaLines(Parameter.DieLines, Parameter.G71LinesRightSide, Parameter.G71LinesLeftSide);
			Parameter.CavaArcs = Get.CavaArcs(Parameter.DieArcs, Parameter.G71ArcsRightSide, Parameter.G71ArcsLeftSide);
		}
	}
}
