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

			//Construct specific element lists
			Parameter.DieLines = Get.DieLines(Parameter.AllLines);
			Parameter.DieArcs = Get.DieArcs(Parameter.AllArcs);
			Edit.AddIndexesAndMakeCorrections(Parameter.DieLines, Parameter.DieArcs);

			Parameter.DieLinesMirrored = Get.DieLinesMirrored(Parameter.DieLines);
			Parameter.DieArcsMirrored = Get.DieArcsMirrored(Parameter.DieArcs);
			Edit.Mirror(Parameter.DieLinesMirrored, Parameter.DieArcsMirrored);

			//Remove.DuplicateLines();
			//Remove.DuplicateArcs();

			//Modify the data
			//float gap = Get.Gap();
			//Edit.OffsetLines(gap);
			//Get.OffsetArcs(gap);
		}

		public static void ManageRightSide()
		{
			Parameter.G71LinesRightSide = Get.G71LinesRightSide(Parameter.DieLines);
			Parameter.G71ArcsRightSide = Get.G71ArcsRightSide(Parameter.DieArcs);
		}

		public static void ManageLeftSide()
		{
			Parameter.G71LinesLeftSide = Get.G71LinesLeftSide(Parameter.DieLinesMirrored);
			Parameter.G71ArcsLeftSide = Get.G71ArcsLeftSide(Parameter.DieArcsMirrored);

			//Edit.Mirror(Parameter.G71LinesLeftSide, Parameter.G71ArcsLeftSide);
		}
	}
}
