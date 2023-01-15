using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Elements;

namespace DXF.Actions
{
	public static class Draw
	{
		public static void Axes(PictureBox visualizationPanel, Graphics visualizationPanelGraphics)
		{
			//Instantiate a specific Pen
			Pen axisPen = new Pen(Color.DarkGray);
			axisPen.DashStyle = DashStyle.Dash;
			axisPen.ScaleTransform(0, 0);

			//Draw X Axis
			PointF horizontalAxisStart = new PointF( );
			horizontalAxisStart.X = (visualizationPanel.Width * 0.1f) * Parameter.ScaleFactor;
			PointF horizontalAxisEnd = new PointF();
			horizontalAxisEnd.X = (visualizationPanel.Width * -0.9f) * Parameter.ScaleFactor;
			visualizationPanelGraphics.DrawLine(axisPen, horizontalAxisStart, horizontalAxisEnd);

			//Draw Y Axis
			PointF verticalAxisStart = new PointF();
			verticalAxisStart.Y = -(visualizationPanel.Height * 0.05f) * Parameter.ScaleFactor;
			PointF verticalAxisEnd = new PointF();
			verticalAxisEnd.Y = (visualizationPanel.Height * 0.95f) * Parameter.ScaleFactor;
			visualizationPanelGraphics.DrawLine(axisPen, verticalAxisStart, verticalAxisEnd);

			axisPen.Dispose();

		}
		
		public static void Die(Graphics visualizationPanel, List<Line> dieLines, List<Arc> dieArcs)
		{
			//Indexes
			if (dieLines == null || dieLines.Count == 0) return;
			List<int> indexes = new List<int>();
			indexes.AddRange(dieLines.Select(line => line.Index).ToList());
			indexes.AddRange(dieArcs.Select(arc => arc.Index).ToList());

			if (dieLines.First().Index < dieLines.Last().Index ) 
			{ indexes.Sort(); }
			else
			{ indexes.Sort(); indexes.Reverse(); }

			//Draw die lines and arcs
			GraphicsPath diePath = new GraphicsPath();
			Brush dieBrush = new SolidBrush(Color.FromArgb(255, 173, 178, 189));
			foreach (int index in indexes)
			{
				foreach (Line line in dieLines)
				{
					if (line.Index == index)
					{
						diePath.AddLine(line.StartX, line.StartY, line.EndX, line.EndY);
					}
				}

				foreach (Arc arc in dieArcs)
				{
					if (arc.Index == index)
					{
						diePath.AddArc(arc.RectangularCornerX, arc.RectangularCornerY, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
					}
				}
			}

			RectangleF dieBounds = diePath.GetBounds();
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(dieBounds, Color.FromArgb(87, 95, 100), Color.FromArgb(222, 224, 226), 90);
			ColorBlend cblend = new ColorBlend(3);
			cblend.Colors = new Color[4] { Color.FromArgb(87, 95, 100), Color.FromArgb(135, 144, 150), Color.FromArgb(196, 200, 203), Color.FromArgb(222, 224, 226) };
			cblend.Positions = new float[4] { 0f, 0.3f, 0.7f, 1f };
			linearGradientBrush.InterpolationColors = cblend;

			visualizationPanel.FillPath(linearGradientBrush, diePath);

			//Dispose
			dieBrush.Dispose();
		}

		public static void Stock(Graphics visualizationPanel, float stockRadius, float stockRight, float stockLeft)
		{
			PointF[] stockPoints =
			{
				new PointF(stockRight, 0),
				new PointF(stockRight, Parameter.DieRadius + stockRadius),
				new PointF(-Parameter.DieWidth - stockLeft, Parameter.DieRadius + stockRadius),
				new PointF(-Parameter.DieWidth - stockLeft, 0)
			};

			byte[] stockPointsType =
			{
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line
			};

			GraphicsPath stockPath = new GraphicsPath(stockPoints, stockPointsType);
			Brush stockBrush = new SolidBrush(Color.LightSlateGray);
			visualizationPanel.FillPath(stockBrush,stockPath);

			//Dispose
			stockPath.Dispose();
		}

		public static void Chock(Graphics visualizationPanel, float stockRadius, float stockLeft, float chockSize)
		{
			PointF[] chockPoints = 
			{
				new PointF(-Parameter.DieWidth - stockLeft, 0),
				new PointF(-Parameter.DieWidth - stockLeft, Parameter.DieRadius + stockRadius),
				new PointF(-Parameter.DieWidth - stockLeft + chockSize, Parameter.DieRadius + stockRadius),
				new PointF(-Parameter.DieWidth - stockLeft + chockSize, Parameter.DieRadius + stockRadius + 40),
				new PointF(-Parameter.DieWidth - stockLeft - 40, Parameter.DieRadius + stockRadius + 40),
				new PointF(-Parameter.DieWidth - stockLeft -40, 0)
			};

			byte[] chockPointsType =
			{
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line,
				(byte)PathPointType.Line
			};

			GraphicsPath chockPath = new GraphicsPath(chockPoints, chockPointsType);
			Brush chockBrush = new SolidBrush(Color.DarkCyan);
			visualizationPanel.FillPath(chockBrush, chockPath);

			//Dispose
			chockBrush.Dispose();
		}

		public static void OuterHorizontalMachiningProfile(Graphics visualizationPanelGraphics, List<Line> outerHorizontalMachiningLines, List<Arc> outerHorizontalMachiningArcs)
		{
			//Instantiate a specific Pen
			Pen profilePen = new Pen(Color.DarkMagenta);
			profilePen.Alignment = PenAlignment.Center;
			profilePen.ScaleTransform(0, 0);

			//Indexes
			if (outerHorizontalMachiningLines == null || outerHorizontalMachiningLines.Count == 0) return;
			List<int> indexes = new List<int>();
			indexes.AddRange(outerHorizontalMachiningLines.Select(line => line.Index).ToList());
			indexes.AddRange(outerHorizontalMachiningArcs.Select(arc => arc.Index).ToList());

			if (outerHorizontalMachiningLines.First().Index < outerHorizontalMachiningLines.Last().Index)
			{ indexes.Sort(); }
			else
			{ indexes.Sort(); indexes.Reverse(); }

			//Draw profile lines and arcs
			GraphicsPath outerHorizontalMachiningPath = new GraphicsPath();
			Brush outerHorizontalMachiningBrush = new HatchBrush(HatchStyle.NarrowHorizontal,Color.DarkMagenta, Color.FromArgb(0, 0, 0, 0));
			foreach (int index in indexes)
			{
				foreach (Line line in outerHorizontalMachiningLines)
				{
					if (line.Index == index)
					{
						outerHorizontalMachiningPath.AddLine(line.StartX, line.StartY, line.EndX, line.EndY);
					}
				}

				foreach (Arc arc in outerHorizontalMachiningArcs)
				{
					if (arc.Index == index)
					{
						outerHorizontalMachiningPath.AddArc(arc.RectangularCornerX, arc.RectangularCornerY, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
					}
				}
			}

			visualizationPanelGraphics.FillPath(outerHorizontalMachiningBrush, outerHorizontalMachiningPath);
			visualizationPanelGraphics.DrawPath(profilePen, outerHorizontalMachiningPath);
		}

		public static void OuterVerticalMachiningProfile(Graphics visualizationPanelGraphics, List<Line> firstSideOuterVerticalMachiningLines)
		{
			//Instantiate a specific Pen
			Pen profilePen = new Pen(Color.DarkGoldenrod);
			profilePen.Alignment = PenAlignment.Center;
			profilePen.ScaleTransform(0, 0);
			
			//Draw profile lines
			GraphicsPath outerVerticalMachiningPath = new GraphicsPath();
			Brush outerHorizontalMachiningBrush = new HatchBrush(HatchStyle.NarrowVertical, Color.DarkGoldenrod, Color.FromArgb(0,0,0,0));
			
			foreach (Line line in firstSideOuterVerticalMachiningLines)
			{
				outerVerticalMachiningPath.AddLine(line.StartX, line.StartY, line.EndX, line.EndY);
			}

			visualizationPanelGraphics.FillPath(outerHorizontalMachiningBrush, outerVerticalMachiningPath);
			visualizationPanelGraphics.DrawPath(profilePen, outerVerticalMachiningPath);
		}
		
		public static void FemaleCollarino(Graphics visualizationPanelGraphics, List<Line> collarinoLines, List<Arc> collarinoArcs)
		{
			//Instantiate a specific Pen
			Pen collarinoPen = new Pen(Color.Aquamarine);
			collarinoPen.Alignment = PenAlignment.Center;
			collarinoPen.ScaleTransform(0, 0);

			//Indexes
			if (collarinoLines == null || collarinoLines.Count == 0) return;
			List<int> indexes = new List<int>();
			indexes.AddRange(collarinoLines.Select(line => line.Index).ToList());
			indexes.AddRange(collarinoArcs.Select(arc => arc.Index).ToList());

			if (collarinoLines.First().Index < collarinoLines.Last().Index)
			{ indexes.Sort(); }
			else
			{ indexes.Sort(); indexes.Reverse(); }

			//Draw profile lines and arcs
			GraphicsPath collarinoPath = new GraphicsPath();
			Brush collarinoBrush = new HatchBrush(HatchStyle.NarrowVertical, Color.Aquamarine, Color.FromArgb(0, 0, 0, 0));
			foreach (int index in indexes)
			{
				foreach (Line line in collarinoLines)
				{
					if (line.Index == index)
					{
						collarinoPath.AddLine(line.StartX, line.StartY, line.EndX, line.EndY);
					}
				}

				foreach (Arc arc in collarinoArcs)
				{
					if (arc.Index == index)
					{
						collarinoPath.AddArc(arc.RectangularCornerX, arc.RectangularCornerY, arc.Width, arc.Height, arc.EndAngle, -arc.SweepAngle);
					}
				}
			}

			visualizationPanelGraphics.FillPath(collarinoBrush, collarinoPath);
			visualizationPanelGraphics.DrawPath(collarinoPen, collarinoPath);
		}

		public static void Cava(Graphics visualizationPanelGraphics, List<Line> cavaLines, List<Arc> cavaArcs, bool sideAppliedAuto, bool sideAppliedManual)
		{
			if (!sideAppliedAuto && !sideAppliedManual) return;

			//Instantiate a specific Pen
			Pen cavaPen = new Pen(Color.Lime);
			cavaPen.Alignment = PenAlignment.Center;
			cavaPen.ScaleTransform(0, 0);

			//Indexes
			if (cavaLines == null || cavaLines.Count == 0) return;
			List<int> indexes = new List<int>();
			indexes.AddRange(cavaLines.Select(line => line.Index).ToList());
			indexes.AddRange(cavaArcs.Select(arc => arc.Index).ToList());

			if (cavaLines.First().Index < cavaLines.Last().Index)
			{ indexes.Sort(); }
			else
			{ indexes.Sort(); indexes.Reverse(); }

			//Draw profile lines and arcs
			GraphicsPath cavaPath = new GraphicsPath();
			Brush cavaBrush = new HatchBrush(HatchStyle.NarrowHorizontal, Color.Lime, Color.FromArgb(0, 0, 0, 0));
			foreach (int index in indexes)
			{
				foreach (Line line in cavaLines)
				{
					if (line.Index == index)
					{
						cavaPath.AddLine(line.StartX, line.StartY, line.EndX, line.EndY);
					}
				}

				foreach (Arc arc in cavaArcs)
				{
					if (arc.Index == index)
					{
						cavaPath.AddArc(arc.RectangularCornerX, arc.RectangularCornerY, arc.Width, arc.Height, arc.EndAngle, -arc.SweepAngle);
					}
				}
			}

			visualizationPanelGraphics.FillPath(cavaBrush, cavaPath);
			visualizationPanelGraphics.DrawPath(cavaPen, cavaPath);
		}
	}
}
