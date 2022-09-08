using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DXF.SetupFile
{
	public static class File
	{
		public static bool choosedFile;
		public static List<string> Read()
		{
			//Set File Dialog properties
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "dxf files (*.dxf)|*.dxf|All files (*.*)|*.*";
			openFileDialog.FilterIndex = 1;

			//Instanciate file variables
			string[] entitiesArray;
			List<string> entitiesList;
			string selectedDxf;

			//Open File Dialog
			DialogResult dialogResult = openFileDialog.ShowDialog();

			//If file selected, add text on a list or return nothing
			if (dialogResult == DialogResult.OK)
			{
				selectedDxf = openFileDialog.FileName;
				entitiesArray = System.IO.File.ReadAllLines(selectedDxf);
				entitiesList = entitiesArray.ToList();

				//Keep the lines from "ENTITIES" until the first "ENDSEC"
				entitiesList.RemoveRange(0, entitiesList.IndexOf("ENTITIES"));
				entitiesList.RemoveRange(entitiesList.IndexOf("ENDSEC") + 1, entitiesList.LastIndexOf("EOF") - entitiesList.IndexOf("ENDSEC"));
				choosedFile = true;
				return entitiesList;
			}
			else
			{
				choosedFile = false;
				List<string> nothing = new List<string>();
				return nothing;
			}			
		}
	}
}
