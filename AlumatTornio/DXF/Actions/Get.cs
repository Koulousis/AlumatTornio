using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;

namespace DXF.Actions
{
	public static class Get
	{
		public static float Gap()
		{
			float gap = MainApp.Lines[0].StartX;

			//Get the closest distance from origin
			foreach (Line line in MainApp.Lines)
			{
				if (line.StartX > gap)
				{
					gap = line.StartX;
				}
				if (line.EndX > gap)
				{
					gap = line.EndX;
				}
			}
			return gap;
		}

		public static int TransformWidth(int width)
		{
			int tranformWidth = width - (width / 10);
			return tranformWidth;
		}
		public static int TransformHeight(int height)
		{
			int tranformHeight = height - (height / 10);
			return tranformHeight;
		}
		public static float Scale(int viewWidth, int viewHeight)
		{
			//Kalutera na trexw to GetBounds kai meta na frontisw na xwraei to width kai to height sto draw
			float scaleOnWidth = 0;
			float scaleOnHeight = 0;
			float dummyWidth = 0;
			float dummyHeight = 0;

			foreach (Line line in MainApp.Lines)
			{
				//Width
				if (line.StartX < dummyWidth)
				{
					dummyWidth = line.StartX;
				}
				else if (line.EndX < dummyWidth)
				{
					dummyWidth = line.EndX;
				}
				else
				{
					continue;
				}
			}

			foreach (Line line in MainApp.Lines)
			{
				if (line.StartY > dummyHeight)
				{
					dummyHeight = line.StartY;
				}
				else if (line.EndY > dummyHeight)
				{
					dummyHeight = line.EndY;
				}
				else
				{
					continue;
				}
			}

			scaleOnWidth = ((float)viewWidth - 50) / Math.Abs(dummyWidth);
			scaleOnHeight = ((float)viewHeight - 100) / dummyHeight;

			if (scaleOnWidth < scaleOnHeight)
			{
				return scaleOnWidth;
			}
			else
			{
				return scaleOnHeight;
			}
		}
	}
}
