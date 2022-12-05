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
			Brush stockBrush = new SolidBrush(Color.FromArgb(255, 120, 120, 90));
			visualizationPanel.FillPath(stockBrush,stockPath);

			//Dispose
			stockPath.Dispose();
		}

		public static void Chock(Graphics visualizationPanel, float stockRadius, float stockLeft)
		{
			PointF[] chockPoints = 
			{
				new PointF(-Parameter.DieWidth - stockLeft, 0),
				new PointF(-Parameter.DieWidth - stockLeft, Parameter.DieRadius + stockRadius),
				new PointF(-Parameter.DieWidth - stockLeft + 40, Parameter.DieRadius + stockRadius),
				new PointF(-Parameter.DieWidth - stockLeft + 40, Parameter.DieRadius + stockRadius + 40),
				new PointF(-Parameter.DieWidth - stockLeft + 40 - 80, Parameter.DieRadius + stockRadius + 40),
				new PointF(-Parameter.DieWidth - stockLeft + 40 - 80, 0)
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

		public static void Profile(Graphics drawPanel, List<Line> profileLines, List<Arc> profileArcs)
		{
			//Instantiate a specific Pen
			Pen profilePen = new Pen(Color.Yellow);
			profilePen.DashStyle = DashStyle.Dash;
			profilePen.ScaleTransform(1 / Parameter.ScaleFactor, 1 / Parameter.ScaleFactor);
			profilePen.Alignment = PenAlignment.Center;

			//Draw G71 Profile
			//Draw and Fill Full Die Path
			foreach (Line line in profileLines)
			{
				drawPanel.DrawLine(profilePen, line.StartX, line.StartY, line.EndX, line.EndY);
			}

			foreach (Arc arc in profileArcs)
			{
				drawPanel.DrawArc(profilePen, arc.RectangularCornerX, arc.RectangularCornerY, arc.Width, arc.Height, arc.StartAngle, arc.SweepAngle);
			}

			//Dispose
			profilePen.Dispose();
		}

		public static void StartPositionToProfileStart(Graphics drawPanel, List<Line> profileLines, List<Arc> profileArcs)
		{
			//Instantiate a specific Pen
			Pen profilePen = new Pen(Color.Yellow);
			profilePen.DashStyle = DashStyle.Dash;
			profilePen.ScaleTransform(1 / Parameter.ScaleFactor, 1 / Parameter.ScaleFactor);
			profilePen.Alignment = PenAlignment.Center;

			float maximumProfilePointY = 0;
			foreach (Line line in profileLines)
			{
				if (line.EndY > maximumProfilePointY)
				{
					maximumProfilePointY = line.EndY;
				}
			}

			float firstElementY = 0;
			Line lineWithZeroStartX = profileLines.Find(line => line.StartX == 0);
			Arc arcWithZeroStartX = profileArcs.Find(arc => arc.StartX == 0);

			if (lineWithZeroStartX != null)
			{
				firstElementY = lineWithZeroStartX.StartY;
			}
			else
			{
				firstElementY = arcWithZeroStartX.StartY;
			}

			//Draw G71 Profile
			//Draw and Fill Full Die Path

			drawPanel.DrawLine(profilePen, Parameter.StockZFirstSide, maximumProfilePointY + Parameter.StockX, Parameter.StockZFirstSide, firstElementY);
			drawPanel.DrawLine(profilePen, Parameter.StockZFirstSide, firstElementY, 0, firstElementY);


			//Dispose
			profilePen.Dispose();
		}

		public static void ProfileEndToEndPosition(Graphics drawPanel, List<Line> profileLines, List<Arc> profileArcs)
		{
			//Instantiate a specific Pen
			Pen profilePen = new Pen(Color.Yellow);
			profilePen.DashStyle = DashStyle.Dash;
			profilePen.ScaleTransform(1 / Parameter.ScaleFactor, 1 / Parameter.ScaleFactor);
			profilePen.Alignment = PenAlignment.Center;
			
			float lastElementX = 0;
			float lastElementY = 0;

			foreach (Line line in profileLines)
			{
				if (line.EndX < lastElementX)
				{
					lastElementX = line.EndX;
					lastElementY = line.EndY;
				}
			}
			foreach (Arc arc in profileArcs)
			{
				if (arc.EndX < lastElementX)
				{
					lastElementX = arc.EndX;
					lastElementY = arc.EndY;
				}
			}

			//Draw G71 Profile
			//Draw and Fill Full Die Path
			drawPanel.DrawLine(profilePen, lastElementX, lastElementY, lastElementX, lastElementY + Parameter.StockX);
			drawPanel.DrawLine(profilePen, lastElementX, lastElementY + Parameter.StockX, Parameter.StockZFirstSide, lastElementY + Parameter.StockX);

			//Dispose
			profilePen.Dispose();
		}

		public static void RightSide(Graphics drawPanel)
		{
			Draw.Die(drawPanel, Parameter.DieLinesAsDesigned, Parameter.DieArcsAsDesigned);
			Draw.StartPositionToProfileStart(drawPanel, Parameter.G71LinesRightSide, Parameter.G71ArcsRightSide);
			Draw.Profile(drawPanel, Parameter.G71LinesRightSide, Parameter.G71ArcsRightSide);
			Draw.ProfileEndToEndPosition(drawPanel, Parameter.G71LinesRightSide, Parameter.G71ArcsRightSide);
		}

		public static void LeftSide(Graphics drawPanel)
		{
			Draw.Die(drawPanel, Parameter.DieLinesFlipped, Parameter.DieArcsFlipped);
			Draw.StartPositionToProfileStart(drawPanel, Parameter.G71LinesLeftSide, Parameter.G71ArcsLeftSide);
			Draw.Profile(drawPanel, Parameter.G71LinesLeftSide, Parameter.G71ArcsLeftSide);
			Draw.ProfileEndToEndPosition(drawPanel, Parameter.G71LinesLeftSide, Parameter.G71ArcsLeftSide);
		}
	}
}
