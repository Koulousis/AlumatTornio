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
		public static bool ReadDxf()
		{
			//Trigger the user to select a file via a dialog with dxf files filter
			OpenFileDialog selectDxfDialog = new OpenFileDialog()
			{
				Title = @"Select file",
				InitialDirectory = @"C:\",
				DefaultExt = @".dxf",
				Filter = @"DXF Files (*.dxf)|*.dxf"
			};

			//If file has been selected, isolate the ENTITIES part from the dxf in the string list
			//and return true to know that the user has selected a file
			if (selectDxfDialog.ShowDialog() == DialogResult.OK)
			{
				string[] dxfTextArray = System.IO.File.ReadAllLines(selectDxfDialog.FileName);
				MainApp.DxfText = dxfTextArray.ToList();
				MainApp.DxfText.RemoveRange(0, MainApp.DxfText.IndexOf("ENTITIES"));
				MainApp.DxfText.RemoveRange(MainApp.DxfText.IndexOf("ENDSEC") + 1, MainApp.DxfText.LastIndexOf("EOF") - MainApp.DxfText.IndexOf("ENDSEC"));

				selectDxfDialog.Dispose();
				return true;
			}
			selectDxfDialog.Dispose();
			return false;
		}
	}
}
