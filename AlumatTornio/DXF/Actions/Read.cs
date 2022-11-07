using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Elements;
using DXF.Properties;

namespace DXF.Actions
{
	public static class Read
	{
		public static List<string> DxfFile(OpenFileDialog selectDxfDialog)
		{
			List<string> dxfText = new List<string>();
			
			//If file has been selected, isolate the ENTITIES part from the dxf in the string list
			//and return true to know that the user has selected a file
			if (selectDxfDialog.ShowDialog() == DialogResult.OK)
			{
				Parameter.DxfFileName = Path.GetFileNameWithoutExtension(selectDxfDialog.FileName);
				string[] dxfTextArray = File.ReadAllLines(selectDxfDialog.FileName);
				dxfText = dxfTextArray.ToList();
				dxfText.RemoveRange(0, dxfText.IndexOf("ENTITIES"));
				dxfText.RemoveRange(dxfText.IndexOf("ENDSEC") + 1, dxfText.LastIndexOf("EOF") - dxfText.IndexOf("ENDSEC"));

				selectDxfDialog.Dispose();
				return dxfText;
			}
			selectDxfDialog.Dispose();
			return dxfText;
		}

		
		
	}
}
