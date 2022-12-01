using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DXF.Elements;

namespace DXF.Actions
{
	public static class Draw
	{
		public static void Axes(Graphics graphics, float crossX, float crossY)
		{
			//Instantiate a specific Pen
			Pen axisPen = new Pen(Color.DarkGray);
			axisPen.DashStyle = DashStyle.Dash;
			axisPen.ScaleTransform(1 / Parameter.ZoomFactor, 1 / Parameter.ZoomFactor);
			axisPen.Alignment = PenAlignment.Center;

			//Draw X Axis
			graphics.DrawLine(axisPen, -crossX, 0, crossX, 0);
			//Draw Y Axis
			graphics.DrawLine(axisPen, 0, -crossY, 0, crossY);


			//Pen arrowZ = new Pen(Color.Aqua);
			//Brush letterZ = new SolidBrush(Color.Aqua);
			//Font fontZ = new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel);
			//graphics.DrawLine(arrowZ, -245, -40, -220, -40);
			//graphics.DrawLine(arrowZ, -225, -38, -225, -42);
			//graphics.DrawLine(arrowZ, -225, -42, -220, -40);
			//graphics.DrawLine(arrowZ, -220, -40, -225, -38);

			//Pen arrowX = new Pen(Color.Aqua);
			//graphics.DrawLine(arrowX, -245, -40, -245, -20);
			//graphics.DrawLine(arrowX, -247, -20, -243, -20);
			//graphics.DrawLine(arrowX, -247, -20, -245, -15);
			//graphics.DrawLine(arrowX, -245, -15, -243, -20);

			////graphics.Transform = new Matrix(1, 0, 0, 1, 0, 0);
			//graphics.DrawString("Z", fontZ, letterZ, -150, -15);
			//graphics.DrawString("X", fontZ, letterZ, -125, -20);

			////Dispose
			//axisPen.Dispose();
		}
		
		public static void Die(Graphics drawPanel, List<Line> dieLines, List<Arc> dieArcs)
		{
			Pen diePen = new Pen(Color.DarkCyan);
			diePen.ScaleTransform(1 / Parameter.ZoomFactor, 1 / Parameter.ZoomFactor);
			diePen.Alignment = PenAlignment.Outset;
			SolidBrush dieBrush = new SolidBrush(Color.DarkCyan);

			//Draw and Fill Full Die Path
			foreach (Line line in dieLines)
			{
				drawPanel.DrawLine(diePen, line.StartX, line.StartY, line.EndX, line.EndY);
			}

			foreach (Arc arc in dieArcs)
			{
				drawPanel.DrawArc(diePen,arc.RectangularCornerX,arc.RectangularCornerY, arc.Width,arc.Height,arc.StartAngle,arc.SweepAngle);
			}

			//Dispose
			//diePen.Dispose();
			//dieBrush.Dispose();
		}

		public static void Stock(Graphics drawPanel)
		{
			Pen stockPen = new Pen(Color.Beige);
			stockPen.DashStyle = DashStyle.Solid;
			stockPen.ScaleTransform(1 / Parameter.ZoomFactor, 1 / Parameter.ZoomFactor);
			stockPen.Alignment = PenAlignment.Center;

			PointF stockPoint1 = new PointF(Parameter.StockZFirstSide, 0);
			PointF stockPoint2 = new PointF(Parameter.StockZFirstSide, Parameter.DieDiameter / 2 + Parameter.StockX / 2);
			PointF stockPoint3 = new PointF(-Parameter.DieWidth - Parameter.StockZSecondSide, Parameter.DieDiameter / 2 + Parameter.StockX / 2);
			PointF stockPoint4 = new PointF(-Parameter.DieWidth - Parameter.StockZSecondSide, 0);
			
			drawPanel.DrawLine(stockPen, stockPoint1, stockPoint2);
			drawPanel.DrawLine(stockPen, stockPoint2, stockPoint3);
			drawPanel.DrawLine(stockPen, stockPoint3, stockPoint4);
		}

		public static void Chock(Graphics drawPanel, List<Line> dieLines, List<Arc> dieArcs)
		{
			Pen chockPen = new Pen(Color.FromArgb(255, 173, 178, 189));
			chockPen.ScaleTransform(1 / Parameter.ZoomFactor, 1 / Parameter.ZoomFactor);
			chockPen.Alignment = PenAlignment.Center;

			Brush chochBrush = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(255, 173, 178, 189), Color.FromArgb(255, 24, 24, 24));

			float maximumProfilePointY = 0;
			foreach (Line line in dieLines)
			{
				if (line.EndY > maximumProfilePointY)
				{
					maximumProfilePointY = line.EndY;
				}
			}

			float minimumProfilePointX = 0;
			foreach (Line line in dieLines)
			{
				if (line.EndX < minimumProfilePointX)
				{
					minimumProfilePointX = line.EndX;
				}
			}

			GraphicsPath chock = new GraphicsPath();
			chock.StartFigure();
			chock.AddLine(minimumProfilePointX - Parameter.StockZFirstSide, 0, minimumProfilePointX - Parameter.StockZFirstSide, maximumProfilePointY + Parameter.StockX);
			chock.AddLine(minimumProfilePointX - Parameter.StockZFirstSide, maximumProfilePointY + Parameter.StockX, minimumProfilePointX - Parameter.StockZFirstSide + 40, maximumProfilePointY + Parameter.StockX);
			chock.AddLine(minimumProfilePointX - Parameter.StockZFirstSide + 40, maximumProfilePointY + Parameter.StockX, minimumProfilePointX - Parameter.StockZFirstSide + 40, maximumProfilePointY + Parameter.StockX + 40);
			chock.AddLine(minimumProfilePointX - Parameter.StockZFirstSide + 40, maximumProfilePointY + Parameter.StockX + 40, minimumProfilePointX - Parameter.StockZFirstSide + 40 - 80, maximumProfilePointY + Parameter.StockX + 40);
			chock.AddLine(minimumProfilePointX - Parameter.StockZFirstSide + 40 - 80, maximumProfilePointY + Parameter.StockX + 40, minimumProfilePointX - Parameter.StockZFirstSide + 40 - 80, 0);
			chock.CloseFigure();

			drawPanel.FillPath(chochBrush,chock);

			drawPanel.DrawLine(chockPen, minimumProfilePointX - Parameter.StockZFirstSide, 0, minimumProfilePointX - Parameter.StockZFirstSide, maximumProfilePointY + Parameter.StockX);
			drawPanel.DrawLine(chockPen, minimumProfilePointX - Parameter.StockZFirstSide, maximumProfilePointY + Parameter.StockX, minimumProfilePointX - Parameter.StockZFirstSide + 40, maximumProfilePointY + Parameter.StockX);
			drawPanel.DrawLine(chockPen, minimumProfilePointX - Parameter.StockZFirstSide + 40, maximumProfilePointY + Parameter.StockX, minimumProfilePointX - Parameter.StockZFirstSide + 40, maximumProfilePointY + Parameter.StockX + 40);
			drawPanel.DrawLine(chockPen, minimumProfilePointX - Parameter.StockZFirstSide + 40, maximumProfilePointY + Parameter.StockX + 40, minimumProfilePointX - Parameter.StockZFirstSide + 40 - 80, maximumProfilePointY + Parameter.StockX + 40);
			drawPanel.DrawLine(chockPen, minimumProfilePointX - Parameter.StockZFirstSide + 40 - 80, maximumProfilePointY + Parameter.StockX + 40, minimumProfilePointX - Parameter.StockZFirstSide + 40 - 80, 0);
		}

		public static void Profile(Graphics drawPanel, List<Line> profileLines, List<Arc> profileArcs)
		{
			//Instantiate a specific Pen
			Pen profilePen = new Pen(Color.Yellow);
			profilePen.DashStyle = DashStyle.Dash;
			profilePen.ScaleTransform(1 / Parameter.ZoomFactor, 1 / Parameter.ZoomFactor);
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
			profilePen.ScaleTransform(1 / Parameter.ZoomFactor, 1 / Parameter.ZoomFactor);
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
			profilePen.ScaleTransform(1 / Parameter.ZoomFactor, 1 / Parameter.ZoomFactor);
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
