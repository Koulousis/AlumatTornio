using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXF.Lathe
{
	public class SpindleSpeed
	{
		public decimal SpindleSpeedLimit { get; set; }
		public decimal ConstantSurfaceSpeed { get; set; }

		public SpindleSpeed(decimal spindleSpeedLimit, decimal constantSurfaceSpeed)
		{
			SpindleSpeedLimit = spindleSpeedLimit;
			ConstantSurfaceSpeed = constantSurfaceSpeed;
		}
	}
}
