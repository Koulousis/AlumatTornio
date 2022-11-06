using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Lathe
{
	public class G71Attributes
	{
		public decimal DepthOfCut { get; set; }
		public decimal Retract { get; set; }
		public decimal AllowanceX { get; set; }
		public decimal AllowanceZ { get; set; }
		public decimal FeedRate { get; set; }

		public G71Attributes(decimal depthOfCut, decimal retract, decimal allowanceX, decimal allowanceZ, decimal feedRate)
		{
			DepthOfCut = depthOfCut;
			Retract = retract;
			AllowanceX = allowanceX;
			AllowanceZ = allowanceZ;
			FeedRate = feedRate;
		}
	}
}
