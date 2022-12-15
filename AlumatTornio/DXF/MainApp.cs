using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXF.Actions;
using DXF.Elements;
using DXF.Lathe;
using DXF.Properties;
using DXF.Tools;

namespace DXF
{
	public partial class MainApp : Form
	{
		public MainApp()
		{
			InitializeComponent();
		}

		//Main Procedures

		#region Application Load
		private void MainApp_Load(object sender, EventArgs e)
		{
			//Disable UI
			tabPanel.Enabled = false;

			//Fill inputs with saved G71 Settings
			g71DepthOfCutInput.Value = Convert.ToDecimal(Settings.Default["G71DepthOfCut"]);
			g71RetractInput.Value = Convert.ToDecimal(Settings.Default["G71Retract"]);
			g71XAllowanceInput.Value = Convert.ToDecimal(Settings.Default["G71XAllowance"]);
			g71ZAllowanceInput.Value = Convert.ToDecimal(Settings.Default["G71ZAllowance"]);
			g71FeedRateInput.Value = Convert.ToDecimal(Settings.Default["G71FeedRate"]);

			//Fill inputs with saved G72 Settings
			g72DepthOfCutInput.Value = Convert.ToDecimal(Settings.Default["G72DepthOfCut"]);
			g72RetractInput.Value = Convert.ToDecimal(Settings.Default["G72Retract"]);
			g72XAllowanceInput.Value = Convert.ToDecimal(Settings.Default["G72XAllowance"]);
			g72ZAllowanceInput.Value = Convert.ToDecimal(Settings.Default["G72ZAllowance"]);
			g72FeedRateInput.Value = Convert.ToDecimal(Settings.Default["G72FeedRate"]);

			//Fill chock size input with saved value
			chockSizeInput.Value = Convert.ToDecimal(Settings.Default["ChockSize"]);
		}
		#endregion
		
		#region File Elements Setup
		private void fileDxfMenuItem_Click(object sender, EventArgs e)
		{
			//Initial or re-initial  global parameters
			Initial.GlobalParameters();

			//Create file dialog
			OpenFileDialog selectDxfDialog = new OpenFileDialog()
			{
				Title = @"Select file",
				InitialDirectory = Settings.Default["DxfFolderPath"].ToString(),
				DefaultExt = @".dxf",
				Filter = @"DXF Files (*.dxf)|*.dxf"
			};

			//Read the selected file
			if (selectDxfDialog.ShowDialog() == DialogResult.Cancel) return;
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(selectDxfDialog.FileName);
			if (fileNameWithoutExtension.Length > 16)
			{
				fileNameWithoutExtension = fileNameWithoutExtension.Substring(0, 14);
				fileNameWithoutExtension += "...";
			}
			List<string> dxfText = File.ReadAllLines(selectDxfDialog.FileName).ToList();

			//Validate the selected file
			bool fileNotHaveEntities = !dxfText.Contains("ENTITIES");
			if (fileNotHaveEntities)
			{
				MessageBox.Show("The selected DXF file does not contains elements");
				return;
			}

			//Remove file part above entities section
			int indexOfFirstLine = 0;
			int elementsAmountBeforeEntities = dxfText.IndexOf("ENTITIES");
			dxfText.RemoveRange(indexOfFirstLine, elementsAmountBeforeEntities);

			//Remove file part below entities section
			int indexOfFirstLineAfterEntities = dxfText.IndexOf("ENDSEC") + 1;
			int elementsAmountAfterEntities = dxfText.LastIndexOf("EOF") - dxfText.IndexOf("ENDSEC");
			dxfText.RemoveRange(indexOfFirstLineAfterEntities, elementsAmountAfterEntities);

			//Get elements from the entities section of the file
			List<Line> allLines = Get.LinesFromDxf(dxfText);
			List<Arc> allArcs = Get.ArcsFromDxf(dxfText);

			//Check for gap from origin point X0,Y0
			float gapX = Get.GapX(allLines);
			float gapY = Get.GapY(allLines);
			if (gapX != 0 || gapY != 0)
			{
				Edit.MoveElementsToOrigin(allLines, allArcs, gapX, gapY);
				Parameter.ElementsHasGap = true;
			}
			Edit.DecimalsCorrection(allLines, allArcs);

			//Create lines and arcs with coordinates as designed
			List<Line> dieLinesAsDesigned = Get.DieLinesAsDesigned(allLines);
			List<Arc> dieArcsAsDesigned = Get.DieArcsAsDesigned(allArcs);
			Edit.AddIndexesAndCounterClockwiseElements(dieLinesAsDesigned, dieArcsAsDesigned);

			//Create lines and arcs with coordinates as flipped from design
			List<Line> dieLinesFlipped = Get.DieLinesFlipped(dieLinesAsDesigned);
			List<Arc> dieArcsFlipped = Get.DieArcsFlipped(dieArcsAsDesigned);
			Edit.FlipElements(dieLinesFlipped, dieArcsFlipped);

			//Calculate die dimensions
			float dieDiameter = dieLinesAsDesigned.Max(line => line.EndY);
			dieDiameter = Math.Abs(dieDiameter) * 2;
			float dieWidth = dieLinesAsDesigned.Min(line => line.EndX);
			dieWidth = Math.Abs(dieWidth);

			//Set information to user interface
			fileName.Text = fileNameWithoutExtension;
			dieDiameterLabel.Text = string.Empty;
			dieDiameterLabel.Text = $"Diameter : {dieDiameter}";
			dieWidthLabel.Text = string.Empty;
			dieWidthLabel.Text = $"Width : {dieWidth}";

			//Set UI to select first machining side
			tabPanel.Enabled = true;
			validateDimensionsGroup.Enabled = true;
			firstSideSelectorGroup.Enabled = false;
			asDesignedButton.Checked = false;
			flippedButton.Checked = false;
			cavaSelectorGroup.Enabled = false;
			manualCavaSelectorGroup.Enabled = false;
			autoCavaButton.Checked = true;
			viewSideSelectorGroup.Enabled = false;
			chockSizeGroup.Enabled = false;
			stockValuesSelectorGroup.Enabled = false;
			generateCode.Enabled = false;
			drawFirstSideButton.Checked = false;
			drawSecondSideButton.Checked = false;
			exportProgressBar.Value = 0;

			//Set placement for lines and arcs
			foreach (Line line in dieLinesAsDesigned) { line.Placement = "AsDesigned"; }
			foreach (Arc arc in dieArcsAsDesigned) { arc.Placement = "AsDesigned"; }
			foreach (Line line in dieLinesFlipped) { line.Placement = "Flipped"; }
			foreach (Arc arc in dieArcsFlipped) { arc.Placement = "Flipped"; }

			//Set global parameters
			Parameter.DxfFileName = fileNameWithoutExtension;
			Parameter.DieLinesAsDesigned = dieLinesAsDesigned.OrderBy(line => line.Index).ToList();
			Parameter.DieArcsAsDesigned = dieArcsAsDesigned.OrderBy(arc => arc.Index).ToList();
			Parameter.DieLinesFlipped = dieLinesFlipped.OrderBy(line => line.Index).Reverse().ToList();
			Parameter.DieArcsFlipped = dieArcsFlipped.OrderBy(arc => arc.Index).Reverse().ToList();
			Parameter.DieDiameter = dieDiameter;
			Parameter.DieRadius = dieDiameter / 2;
			Parameter.DieWidth = dieWidth;

			//Draw
			visualizationPanel.Refresh();
		}
		#endregion

		#region Validate Dimensions
		private void validateDimensionsButton_Click(object sender, EventArgs e)
		{
			if (Parameter.ElementsHasGap)
			{
				MessageBox.Show("Double check the dimensions because\nthe elements have been moved to be on X0:Y0");
			}

			validateDimensionsGroup.Enabled = false;
			firstSideSelectorGroup.Enabled = true;

		}
		#endregion

		#region Machining Setup
		private void asDesignedButton_CheckedChanged(object sender, EventArgs e)
		{
			if (asDesignedButton.Checked)
			{
				Parameter.FirstSideLines = Parameter.DieLinesAsDesigned;
				Parameter.FirstSideArcs = Parameter.DieArcsAsDesigned;
				Parameter.SecondSideLines = Parameter.DieLinesFlipped;
				Parameter.SecondSideArcs = Parameter.DieArcsFlipped;
			}

			//Draw die
			visualizationPanel.Refresh();
		}

		private void flippedButton_CheckedChanged(object sender, EventArgs e)
		{
			if (flippedButton.Checked)
			{
				Parameter.FirstSideLines = Parameter.DieLinesFlipped;
				Parameter.FirstSideArcs = Parameter.DieArcsFlipped;
				Parameter.SecondSideLines = Parameter.DieLinesAsDesigned;
				Parameter.SecondSideArcs = Parameter.DieArcsAsDesigned;
			}

			//Draw die
			visualizationPanel.Refresh();
		}

		private void setFirstSideSelectionButton_Click(object sender, EventArgs e)
		{
			//Change UI after first machining side selected
			drawFirstSideButton.Checked = true;
			firstSideSelectorGroup.Enabled = false;
			cavaSelectorGroup.Enabled = true;
			viewSideSelectorGroup.Enabled = true;
			stockValuesSelectorGroup.Enabled = true;
			chockSizeGroup.Enabled = true;
			generateCode.Enabled = true;
			
			//Set stock values
			float stockDiameterValue = Parameter.DieDiameter;
			stockDiameterValue += 1 - Parameter.DieDiameter % 1;
			stockDiameterValue += 2;
			stockDiameterInput.Minimum = Convert.ToDecimal(stockDiameterValue);
			stockDiameterInput.Maximum = stockDiameterInput.Minimum + 10;
			stockDiameterInput.Value = stockDiameterInput.Minimum;

			float stockWidthValue = Parameter.DieWidth;
			stockWidthValue += 1 - Parameter.DieWidth % 1;
			stockWidthValue += 2;
			stockWidthInput.Minimum = Convert.ToDecimal(stockWidthValue);
			stockWidthInput.Maximum = stockWidthInput.Minimum + 10;
			stockWidthInput.Value = stockWidthInput.Minimum;

			//
			//Horizontal profile
			//
			List<Line> firstSideOuterHorizontalMachiningLines = Get.OuterHorizontalMachiningLines(Parameter.FirstSideLines);
			List<Arc> firstSideOuterHorizontalMachiningArcs = Get.OuterHorizontalMachiningArcs(firstSideOuterHorizontalMachiningLines, Parameter.FirstSideArcs);

			//Insert lines from stock start position until profile start and from profile end to stock end position for first side
			List<Line> firstSideStockMachiningLines = Get.FirstSideStockMachiningLines(firstSideOuterHorizontalMachiningLines, firstSideOuterHorizontalMachiningArcs);
			firstSideOuterHorizontalMachiningLines.Add(firstSideStockMachiningLines[2]);
			firstSideOuterHorizontalMachiningLines.Insert(0,firstSideStockMachiningLines[1]);
			firstSideOuterHorizontalMachiningLines.Insert(0, firstSideStockMachiningLines[0]);

			//Second side outer horizontal machining profile
			List<Line> secondSideOuterHorizontalMachiningLines = Get.OuterHorizontalMachiningLines(Parameter.SecondSideLines);
			List<Arc> secondSideOuterHorizontalMachiningArcs = Get.OuterHorizontalMachiningArcs(secondSideOuterHorizontalMachiningLines, Parameter.SecondSideArcs);

			//Insert lines from stock start position until profile start and from profile end to stock end position for second side
			List<Line> secondSideStockMachiningLines = Get.SecondSideStockMachiningLines(secondSideOuterHorizontalMachiningLines, secondSideOuterHorizontalMachiningArcs);
			secondSideOuterHorizontalMachiningLines.Add(secondSideStockMachiningLines[2]);
			secondSideOuterHorizontalMachiningLines.Insert(0, secondSideStockMachiningLines[1]);
			secondSideOuterHorizontalMachiningLines.Insert(0, secondSideStockMachiningLines[0]);

			//
			//Facing profile
			//
			List<Line> firstSideOuterVerticalMachiningLines = Get.FirstSideOuterVerticalMachiningLines();
			List<Line> secondSideOuterVerticalMachiningLines = Get.SecondSideOuterVerticalMachiningLines();

			//
			//Cava profile
			//
			List<Line> firstSideCavaLines = Get.CavaLines(Parameter.FirstSideLines);
			List<Arc> firstSideCavaArcs = Get.CavaArcs(Parameter.FirstSideLines, Parameter.FirstSideArcs);
			float cavaLength = Calculation.ElementsLength(firstSideCavaLines, firstSideCavaArcs);

			//Set Global Parameters
			Parameter.FirstSideOuterHorizontalMachiningLines = firstSideOuterHorizontalMachiningLines;
			Parameter.FirstSideOuterHorizontalMachiningArcs = firstSideOuterHorizontalMachiningArcs;
			Parameter.FirstSideOuterVerticalMachiningLines = firstSideOuterVerticalMachiningLines;

			Parameter.SecondSideOuterHorizontalMachiningLines = secondSideOuterHorizontalMachiningLines;
			Parameter.SecondSideOuterHorizontalMachiningArcs = secondSideOuterHorizontalMachiningArcs;
			Parameter.SecondSideOuterVerticalMachiningLines = secondSideOuterVerticalMachiningLines;

			//Draw
			visualizationPanel.Refresh();

		}

		private void stockDiameterInput_ValueChanged(object sender, EventArgs e)
		{
			Parameter.StockFromDiameter = (float)stockDiameterInput.Value - Parameter.DieDiameter;
			Parameter.StockFromRadius = Parameter.StockFromDiameter / 2;

			//Update outer horizontal machining stock to profile lines
			if (Parameter.FirstSideOuterHorizontalMachiningLines.Count != 0)
			{
				Parameter.FirstSideOuterHorizontalMachiningLines[0].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.FirstSideOuterHorizontalMachiningLines[Parameter.FirstSideOuterHorizontalMachiningLines.Count - 1].EndY = Parameter.FirstSideOuterHorizontalMachiningLines[Parameter.FirstSideOuterHorizontalMachiningLines.Count - 1].StartY + Parameter.StockFromRadius;
			}
			if (Parameter.SecondSideOuterHorizontalMachiningLines.Count != 0)
			{
				Parameter.SecondSideOuterHorizontalMachiningLines[0].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.SecondSideOuterHorizontalMachiningLines[Parameter.SecondSideOuterHorizontalMachiningLines.Count - 1].EndY = Parameter.SecondSideOuterHorizontalMachiningLines[Parameter.SecondSideOuterHorizontalMachiningLines.Count - 1].StartY + Parameter.StockFromRadius;
			}

			//Update outer vertical machining lines
			if (Parameter.FirstSideOuterVerticalMachiningLines.Count != 0)
			{
				Parameter.FirstSideOuterVerticalMachiningLines[0].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.FirstSideOuterVerticalMachiningLines[0].EndY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.FirstSideOuterVerticalMachiningLines[1].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
			}
			if (Parameter.SecondSideOuterVerticalMachiningLines.Count != 0)
			{
				Parameter.SecondSideOuterVerticalMachiningLines[0].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.SecondSideOuterVerticalMachiningLines[0].EndY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.SecondSideOuterVerticalMachiningLines[1].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
			}

			visualizationPanel.Refresh();
		}

		private void stockWidthInput_ValueChanged(object sender, EventArgs e)
		{
			Parameter.StockFromWidthSecondSide = 1;
			Parameter.StockFromWidthFirstSide = (float)stockWidthInput.Value - Parameter.DieWidth - Parameter.StockFromWidthSecondSide;
			Parameter.StockFromWidthFirstSide = Conversion.StringToThreeDigitFloat(Parameter.StockFromWidthFirstSide.ToString());

			//Update outer horizontal machining stock to profile lines
			if (Parameter.FirstSideOuterHorizontalMachiningLines.Count != 0)
			{
				Parameter.FirstSideOuterHorizontalMachiningLines[0].StartX = Parameter.StockFromWidthFirstSide;
				Parameter.FirstSideOuterHorizontalMachiningLines[0].EndX = Parameter.StockFromWidthFirstSide;
				Parameter.FirstSideOuterHorizontalMachiningLines[1].StartX = Parameter.StockFromWidthFirstSide;
			}

			//Update outer vertical machining lines
			if (Parameter.FirstSideOuterVerticalMachiningLines.Count != 0)
			{
				Parameter.FirstSideOuterVerticalMachiningLines[0].StartX = Parameter.StockFromWidthFirstSide;
				Parameter.FirstSideOuterVerticalMachiningLines[2].EndX = Parameter.StockFromWidthFirstSide;
			}

			visualizationPanel.Refresh();
		}
		#endregion

		#region Draw on Visualization Panel
		private void visualizationPanel_Paint(object sender, PaintEventArgs e)
		{
			//Initialize graphics and clear the visualization panel
			Graphics visualizationPanelGraphics = e.Graphics;
			visualizationPanelGraphics.Clear(Color.FromArgb(24, 24, 24));

			//Check for file existence to continue drawing 
			if (string.IsNullOrEmpty(Parameter.DxfFileName)) return;

			//Graphics draw mode to smooth
			visualizationPanelGraphics.SmoothingMode = SmoothingMode.AntiAlias;
			
			//Graphics work-plane to cartesian with origin the left-down corner
			Matrix cartesianOnlyPositives = new Matrix(1, 0, 0, -1, 0, visualizationPanel.Height);
			visualizationPanelGraphics.MultiplyTransform(cartesianOnlyPositives);

			//Graphics work-plane movement to provide space for x axis negatives
			float xAxisPercentageMove = (float)(visualizationPanel.Width * 0.9);
			float yAxisPercentageMove = (float)(visualizationPanel.Height * 0.05);
			visualizationPanelGraphics.TranslateTransform(xAxisPercentageMove, yAxisPercentageMove);
			
			//Graphics scale to fit the die to as close as possible
			float scaleToFitDiameter = (float)visualizationPanel.Height / Parameter.DieRadius;
			float scaleToFitWidth = (float)visualizationPanel.Width / Parameter.DieWidth;
			float scaleFactor = scaleToFitDiameter < scaleToFitWidth ? scaleToFitDiameter : scaleToFitWidth;
			scaleFactor *= 0.8f;
			visualizationPanelGraphics.ScaleTransform(scaleFactor, scaleFactor);

			//Set global parameters
			Parameter.ScaleFactor = scaleFactor;
			
			//Draw
			Draw.Axes(visualizationPanel, visualizationPanelGraphics);

			//Draw when selecting first machining side
			if (firstSideSelectorGroup.Enabled)
			{
				Draw.Die(visualizationPanelGraphics, Parameter.FirstSideLines, Parameter.FirstSideArcs);
			}

			//Draw when selecting side to draw and print
			if (viewSideSelectorGroup.Enabled)
			{
				//Side and stock draw
				if (drawFirstSideButton.Checked)
				{
					Draw.Stock(visualizationPanelGraphics, Parameter.StockFromRadius, Parameter.StockFromWidthFirstSide, Parameter.StockFromWidthSecondSide);
					Draw.Chock(visualizationPanelGraphics, Parameter.StockFromRadius, Parameter.StockFromWidthSecondSide, (float)chockSizeInput.Value);
					Draw.Die(visualizationPanelGraphics, Parameter.FirstSideLines, Parameter.FirstSideArcs);
					Draw.OuterHorizontalMachiningProfile(visualizationPanelGraphics, Parameter.FirstSideOuterHorizontalMachiningLines, Parameter.FirstSideOuterHorizontalMachiningArcs);
					Draw.OuterVerticalMachiningProfile(visualizationPanelGraphics, Parameter.FirstSideOuterVerticalMachiningLines);
				}
				else if (drawSecondSideButton.Checked)
				{
					Draw.Stock(visualizationPanelGraphics, Parameter.StockFromRadius, Parameter.StockFromWidthSecondSide, Parameter.StockFromWidthFirstSide);
					Draw.Chock(visualizationPanelGraphics, Parameter.StockFromRadius, 0, (float)chockSizeInput.Value);
					Draw.Die(visualizationPanelGraphics, Parameter.SecondSideLines, Parameter.SecondSideArcs);
					Draw.OuterHorizontalMachiningProfile(visualizationPanelGraphics, Parameter.SecondSideOuterHorizontalMachiningLines, Parameter.SecondSideOuterHorizontalMachiningArcs);
					Draw.OuterVerticalMachiningProfile(visualizationPanelGraphics, Parameter.SecondSideOuterVerticalMachiningLines);
				}
			}
			
			
			
		}

		private void drawFirstSideButton_CheckedChanged(object sender, EventArgs e)
		{
			if (drawFirstSideButton.Checked)
			{
				gCodeTextBox.Lines = Parameter.GCodeFirstSide.ToArray();
			}
			else if (drawSecondSideButton.Checked)
			{
				gCodeTextBox.Lines = Parameter.GCodeSecondSide.ToArray();
			}
			
			visualizationPanel.Refresh();
		}


		private void visualizationPanel_MouseMove(object sender, MouseEventArgs e)
		{
			//Pixels to millimeters
			//Graphics object to retrieve data
			Graphics screen = CreateGraphics();

			//Move X and Y origin location
			double cursorPositionX = (visualizationPanel.Width * 0.9) - e.Location.X;
			double cursorPositionY = (visualizationPanel.Height * 0.95) - e.Location.Y;

			//Transform pixels to millimeters
			cursorPositionX += 25.4f / screen.DpiX;
			cursorPositionY += 25.4f / screen.DpiY;

			//Set Labels text to X and Y mouse position
			float latheCoordinateX = (float)cursorPositionY / Parameter.ScaleFactor * 2;
			float latheCoordinateZ = -(float) cursorPositionX / Parameter.ScaleFactor;
			coordinatesLabel.Text = $@"X:{latheCoordinateX,0:F3}, Z:{latheCoordinateZ,0:F3}";
		}
		#endregion
		
		#region Export
		private void exportGCode_Click(object sender, EventArgs e)
		{
			//Clear texts
			gCodeTextBox.Lines = Array.Empty<string>();
			Parameter.GCodeFirstSide.Clear();
			Parameter.GCodeSecondSide.Clear();

			//Update Progress Bar
			exportProgressBar.Value = 0;
			GCode.FirstSide.Clear();
			for (int i = 0; i < 100; i++) { for (int j = 0; j < 10000; j++) { } exportProgressBar.Value++; }

			//Set G71 and G72 Attributes
			G72 g72 = new G72("10", "20", g72DepthOfCutInput.Value, g72RetractInput.Value, g72XAllowanceInput.Value, g72ZAllowanceInput.Value, g72FeedRateInput.Value);
			G71 g71 = new G71("30", "40",g71DepthOfCutInput.Value, g71RetractInput.Value, g71XAllowanceInput.Value, g71ZAllowanceInput.Value, g71FeedRateInput.Value);

			//Get first side outer horizontal and outer vertical profile points
			List<ProfilePoint> firstSideOuterHorizontalProfilePoints = Get.ProfilePoints(Parameter.FirstSideOuterHorizontalMachiningLines, Parameter.FirstSideOuterHorizontalMachiningArcs);
			List<ProfilePoint> firstSideOuterVerticalProfilePoints = Get.ProfilePoints(Parameter.FirstSideOuterVerticalMachiningLines, Parameter.FirstSideOuterVerticalMachiningArcs);

			//Create g code for first side
			List<string> gCodeFirstSide = new List<string>();
			gCodeFirstSide.AddRange(CodeBlock.LatheInitialization());
			gCodeFirstSide.AddRange(CodeBlock.OuterVerticalProfile(g72, firstSideOuterVerticalProfilePoints));
			gCodeFirstSide.AddRange(CodeBlock.OuterHorizontalProfile(g71, firstSideOuterHorizontalProfilePoints));
			gCodeFirstSide.AddRange(CodeBlock.LatheEnd());

			//Get second side outer horizontal and outer vertical profile points
			List<ProfilePoint> secondSideOuterHorizontalProfilePoints = Get.ProfilePoints(Parameter.SecondSideOuterHorizontalMachiningLines, Parameter.SecondSideOuterHorizontalMachiningArcs);
			List<ProfilePoint> secondSideOuterVerticalProfilePoints = Get.ProfilePoints(Parameter.SecondSideOuterVerticalMachiningLines, Parameter.SecondSideOuterVerticalMachiningArcs);
			
			//Create g code for second side
			List<string> gCodeSecondSide = new List<string>();
			gCodeSecondSide.AddRange(CodeBlock.LatheInitialization());
			gCodeSecondSide.AddRange(CodeBlock.OuterVerticalProfile(g72, secondSideOuterHorizontalProfilePoints));
			gCodeSecondSide.AddRange(CodeBlock.OuterHorizontalProfile(g71, secondSideOuterVerticalProfilePoints));
			gCodeSecondSide.AddRange(CodeBlock.LatheEnd());


			//Fill rich text box
			gCodeTextBox.Lines = drawFirstSideButton.Checked ? gCodeFirstSide.ToArray() : gCodeSecondSide.ToArray();

			//Set global parameters
			Parameter.GCodeFirstSide.AddRange(gCodeFirstSide);
			Parameter.GCodeSecondSide.AddRange(gCodeSecondSide);
		}
		#endregion

		//Secondary Procedures

		#region Menu Settings
		private void changeDXFFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var folderBrowserDialog = new FolderBrowserDialog();
			DialogResult result = folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				Settings.Default["DxfFolderPath"] = folderBrowserDialog.SelectedPath;
				Settings.Default.Save();
			}
		}
		private void changeExportFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var folderBrowserDialog = new FolderBrowserDialog();
			DialogResult result = folderBrowserDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				Settings.Default["ExportFolderPath"] = folderBrowserDialog.SelectedPath;
				Settings.Default.Save();
			}
		}

		private void openDXFFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(Settings.Default["DxfFolderPath"].ToString());
		}

		private void openExportFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process.Start(Settings.Default["ExportFolderPath"].ToString());
		}
		#endregion

		#region Menu Infos
		private void g71RoughingCycleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (Form form = new Form())
			{
				Bitmap img = Resources.g71_roughing_cycle;

				form.StartPosition = FormStartPosition.CenterScreen;
				Size size = new Size(img.Width / 2, img.Height / 2);
				form.Size = size;
				form.ShowIcon = false;

				PictureBox pb = new PictureBox();
				pb.SizeMode = PictureBoxSizeMode.StretchImage;
				pb.Dock = DockStyle.Fill;
				pb.Image = img;

				form.Controls.Add(pb);
				form.ShowDialog();
			}
		}

		private void g72FacingCycleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			using (Form form = new Form())
			{
				Bitmap img = Resources.g72_facing_cycle;

				form.StartPosition = FormStartPosition.CenterScreen;
				Size size = new Size(img.Width / 2, img.Height / 2);
				form.Size = size;
				form.ShowIcon = false;

				PictureBox pb = new PictureBox();
				pb.SizeMode = PictureBoxSizeMode.StretchImage;
				pb.Dock = DockStyle.Fill;
				pb.Image = img;

				form.Controls.Add(pb);
				form.ShowDialog();
			}
		}
		#endregion
		
		#region G71 Cycle Values Save
		private void g71DepthOfCutInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71DepthOfCut"] = g71DepthOfCutInput.Value;
			Settings.Default.Save();
		}

		private void g71RetractInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71Retract"] = g71RetractInput.Value;
			Settings.Default.Save();
		}

		private void g71XAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71XAllowance"] = g71XAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void g71ZAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71ZAllowance"] = g71ZAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void g71FeedRateInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G71FeedRate"] = g71FeedRateInput.Value;
			Settings.Default.Save();
		}
		#endregion

		#region G72 Cycle Values Save
		private void g72DepthOfCutInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G72DepthOfCut"] = g72DepthOfCutInput.Value;
			Settings.Default.Save();
		}

		private void g72RetractInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G72Retract"] = g72RetractInput.Value;
			Settings.Default.Save();
		}

		private void g72XAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G72XAllowance"] = g72XAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void g72ZAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G72ZAllowance"] = g72ZAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void g72FeedRateInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["G72FeedRate"] = g72FeedRateInput.Value;
			Settings.Default.Save();
		}




		#endregion

		#region Chock Size Save
		private void chockSizeInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["ChockSize"] = chockSizeInput.Value;
			Settings.Default.Save();
			visualizationPanel.Refresh();
		}
		#endregion

		private void autoCavaButton_CheckedChanged(object sender, EventArgs e)
		{
			if (autoCavaButton.Checked)
			{
				autoCavaSelectorGroup.Enabled = true;
				manualCavaSelectorGroup.Enabled = false;
			}
			else if (manualCavaButton.Checked)
			{
				autoCavaSelectorGroup.Enabled = false;
				manualCavaSelectorGroup.Enabled = true;
			}
		}
	}
}
