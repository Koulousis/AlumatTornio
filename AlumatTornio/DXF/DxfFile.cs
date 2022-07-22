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
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = "C:\\";
			openFileDialog.Filter = "dxf files (*.dxf)|*.dxf|All files (*.*)|*.*";
			openFileDialog.FilterIndex = 1;
			openFileDialog.ShowDialog();

			string inputFile = openFileDialog.FileName;
			string[] entitiesArray = System.IO.File.ReadAllLines(inputFile);
			List<string> entitiesList = entitiesArray.ToList();


			entitiesList.RemoveRange(0, entitiesList.IndexOf("ENTITIES"));
			entitiesList.RemoveRange(entitiesList.IndexOf("ENDSEC") + 1, entitiesList.LastIndexOf("EOF") - entitiesList.IndexOf("ENDSEC"));

			return entitiesList;
		}
	}
}
