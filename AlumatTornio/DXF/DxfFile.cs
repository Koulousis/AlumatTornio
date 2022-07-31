using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DXF
{
	public class DxfFile
	{
		public static List<string> Read()
		{
			//Open a file dialog to choose a dxf file
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "dxf files (*.dxf)|*.dxf|All files (*.*)|*.*";
			openFileDialog.FilterIndex = 1;
			openFileDialog.ShowDialog();

			//Read the file and set it on a string list
			string selectedDxf = openFileDialog.FileName;
			string[] entitiesArray = File.ReadAllLines(selectedDxf);
			List<string> entitiesList = entitiesArray.ToList();

			//Keep the lines from "ENTITIES" until the first "ENDSEC"
			entitiesList.RemoveRange(0, entitiesList.IndexOf("ENTITIES"));
			entitiesList.RemoveRange(entitiesList.IndexOf("ENDSEC") + 1, entitiesList.LastIndexOf("EOF") - entitiesList.IndexOf("ENDSEC"));

			//Return the selected file with the entities part only
			return entitiesList;
		}
	}
}
