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
		public static void Manage(OpenFileDialog selectedDxfDialog)
		{
			Parameter.DxfText = new List<string>();
			Parameter.AllLines = new List<Line>();
			Parameter.AllArcs = new List<Arc>();
			Parameter.DieLines = new List<Line>();
			Parameter.GCodePoints = new List<GCodePoint>();

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

			//Remove.DuplicateLines();
			//Remove.DuplicateArcs();

			//Modify the data
			//float gap = Get.Gap();
			//Edit.OffsetLines(gap);
			//Get.OffsetArcs(gap);
		}
	}
}
