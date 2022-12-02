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
using DXF.Organizer;
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
			}
			Edit.DecimalsCorrection(allLines, allArcs);

			//Create lines and arcs with coordinates as designed
			List<Line> dieLinesAsDesigned = Get.DieLinesAsDisigned(allLines);
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
			dieDiameterLabel.Text = $"Die Diameter: {dieDiameter}";
			dieWidthLabel.Text = string.Empty;
			dieWidthLabel.Text = $"Die Width: {dieWidth}";

			//Enable UI to select first machining side
			tabPanel.Enabled = true;

			firstSideSelectorGroup.Enabled = true;
			asDesignedButton.Checked = false;
			flippedButton.Checked = false;

			viewSideSelectorGroup.Enabled = false;
			cavaSelectorGroup.Enabled = false;
			stockValuesSelectorGroup.Enabled = false;
			generateCode.Enabled = false;

			drawFirstSideButton.Checked = false;
			drawSecondSideButton.Checked = false;

			//Set global parameters
			Parameter.DxfFileName = fileNameWithoutExtension;
			Parameter.DieLinesAsDesigned = dieLinesAsDesigned;
			Parameter.DieArcsAsDesigned = dieArcsAsDesigned;
			Parameter.DieLinesFlipped = dieLinesFlipped;
			Parameter.DieArcsFlipped = dieArcsFlipped;
			Parameter.DieDiameter = dieDiameter;
			Parameter.DieRadius = dieDiameter / 2;
			Parameter.DieWidth = dieWidth;

			//Draw
			visualizationPanel.Refresh();

			//Application Changes
			//ReloadApplicationItemsStatus();
			//SetStockValues();

			//File management
			//Dxf.ManageRightSide();
			//Dxf.ManageLeftSide();
			//Dxf.ManageCava();
		}

		private void ReloadApplicationItemsStatus()
		{

			exportProgressBar.Value = 0;
			gCodeTextBox.Lines = Array.Empty<string>();
			GCode.FirstSide.Clear();
			GCode.SecondSide.Clear();

		}

		private void SetStockValues()
		{
			Parameter.ComesFromFileLoad = true;
			Parameter.StockDiameter = 0;
			Parameter.StockWidth = 0;
			Parameter.StockX = 0;
			Parameter.StockZSecondSide = 0;
			Parameter.StockZFirstSide = 0;

			xStockDiameterInput.Maximum = 0;
			zStockWidthInput.Maximum = 0;
			zStockSecondSide.Maximum = 0;
			zStockFirstSide.Maximum = 0;

			xStockDiameterInput.Minimum = 0;
			zStockWidthInput.Minimum = 0;
			zStockSecondSide.Minimum = 0;
			zStockFirstSide.Minimum = 0;

			Set.StockDiameter(Parameter.DieDiameter);
			Set.StockWidth(Parameter.DieWidth);
			Set.StockX(Parameter.StockDiameter, Parameter.DieDiameter);
			Set.StockZSecondSide(Parameter.DieWidth);
			Set.StockZFirstSide(Parameter.StockWidth, Parameter.DieWidth);

			xStockDiameterInput.Maximum = Convert.ToDecimal(Parameter.StockDiameter + Parameter.StockDiameterExtraMax);
			zStockWidthInput.Maximum = Convert.ToDecimal(Parameter.StockWidth + Parameter.StockWidthExtraMax);
			zStockSecondSide.Maximum = Convert.ToDecimal(Parameter.StockZSecondSide);
			zStockFirstSide.Maximum = Convert.ToDecimal(Parameter.StockZFirstSide + Parameter.StockWidthExtraMax);

			xStockDiameterInput.Minimum = Convert.ToDecimal(Parameter.StockDiameter);
			zStockWidthInput.Minimum = Convert.ToDecimal(Parameter.StockWidth);
			zStockSecondSide.Minimum = Convert.ToDecimal(Parameter.StockZSecondSide);
			zStockFirstSide.Minimum = Convert.ToDecimal(Parameter.StockZFirstSide);

			Parameter.ComesFromFileLoad = false;
		}
		#endregion

		#region Set First Machining Side Setup
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
			viewSideSelectorGroup.Enabled = true;
			cavaSelectorGroup.Enabled = true;
			stockValuesSelectorGroup.Enabled = true;
			generateCode.Enabled = true;
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
				if (drawFirstSideButton.Checked)
				{
					Draw.Die(visualizationPanelGraphics, Parameter.FirstSideLines, Parameter.FirstSideArcs);
				}
				else if (drawSecondSideButton.Checked)
				{
					Draw.Die(visualizationPanelGraphics, Parameter.SecondSideLines, Parameter.SecondSideArcs);
				}
			}
			
			
			
		}

		private void firstSide_CheckedChanged(object sender, EventArgs e)
		{
			visualizationPanel.Refresh();
		}
		

		private void visualizationPanel_MouseMove(object sender, MouseEventArgs e)
		{
			//Pixels to millimeters
			//Graphics object to retrieve data
			Graphics screen = CreateGraphics();

			//Move X and Y origin location
			double cursorPositionX = Calculation.TransformWidth(visualizationPanel.Width) - e.Location.X;
			double cursorPositionY = Calculation.TransformHeight(visualizationPanel.Height) - e.Location.Y;
			//Transform pixels to millimeters
			cursorPositionX += 25.4f / screen.DpiX;
			cursorPositionY += 25.4f / screen.DpiY;

			//Set Labels text to X and Y mouse position
			coordinatesLabel.Text = $@"X:{(cursorPositionY / Elements.Parameter.ZoomFactor) * 2,0:F3}, Z:{-cursorPositionX / Elements.Parameter.ZoomFactor,0:F3}";
		}
		#endregion
		
		#region Export
		private void exportGCode_Click(object sender, EventArgs e)
		{
			if (cavaCheckBox.Enabled) { MessageBox.Show("Cava is not applied"); return; }

			//Update Progress Bar
			exportProgressBar.Value = 0;
			gCodeTextBox.Lines = Array.Empty<string>();
			GCode.FirstSide.Clear();
			for (int i = 0; i < 100; i++) { for (int j = 0; j < 10000; j++) { } exportProgressBar.Value++; }

			//Set G71 Attributes
			G71Attributes g71Attributes = new G71Attributes(g71DepthOfCutInput.Value, g71RetractInput.Value, g71XAllowanceInput.Value, g71ZAllowanceInput.Value, g71FeedRateInput.Value);
			G72Attributes g72Attributes = new G72Attributes(g72DepthOfCutInput.Value, g72RetractInput.Value, g72XAllowanceInput.Value, g72ZAllowanceInput.Value, g72FeedRateInput.Value);

			//Get G71 profile points
			Parameter.G72ProfilePointsFirstSide = Create.G72ProfilePoints(Parameter.DieLinesAsDesigned);
			Parameter.G71ProfilePointsFirstSide = Create.G71ProfilePointsFirstSide(Parameter.G71LinesRightSide, Parameter.G71ArcsRightSide);
			Parameter.G71ProfilePointsSecondSide = Create.G71ProfilePointsSecondSide(Parameter.G71LinesLeftSide, Parameter.G71ArcsLeftSide);

			//Fill G-Code File
			//First Side
			GCode.FirstSide.AddRange(CodeBlock.LatheInitialization());

			GCode.FirstSide.AddRange(CodeBlock.StartPosition(Parameter.G72ProfilePointsFirstSide));
			GCode.FirstSide.AddRange(CodeBlock.G72Facing(g72Attributes));
			GCode.FirstSide.AddRange(CodeBlock.G72Profile(Parameter.G72ProfilePointsFirstSide));

			GCode.FirstSide.AddRange(CodeBlock.StartPosition(Parameter.G71ProfilePointsFirstSide));
			GCode.FirstSide.AddRange(CodeBlock.G71Roughing(g71Attributes));
			GCode.FirstSide.AddRange(CodeBlock.G71Profile(Parameter.G71ProfilePointsFirstSide));
			GCode.FirstSide.AddRange(CodeBlock.G70Finishing());
			GCode.FirstSide.AddRange(CodeBlock.LatheEnd());

			//Second Side
			GCode.SecondSide.AddRange(CodeBlock.LatheInitialization());
			GCode.SecondSide.AddRange(CodeBlock.StartPosition(Parameter.G72ProfilePointsFirstSide));
			GCode.SecondSide.AddRange(CodeBlock.G72Facing(g72Attributes));
			GCode.SecondSide.AddRange(CodeBlock.G72Profile(Parameter.G72ProfilePointsFirstSide));

			
			GCode.SecondSide.AddRange(CodeBlock.StartPosition(Parameter.G71ProfilePointsSecondSide));
			GCode.SecondSide.AddRange(CodeBlock.G71Roughing(g71Attributes));
			GCode.SecondSide.AddRange(CodeBlock.G71Profile(Parameter.G71ProfilePointsSecondSide));
			GCode.SecondSide.AddRange(CodeBlock.G70Finishing());
			GCode.SecondSide.AddRange(CodeBlock.LatheEnd());

			//G-Code File Export
			GCode.Export();

			//Update File Status
			fileName.Text = Parameter.DxfFileName;
			gCodeTextBox.Lines = drawFirstSideButton.Checked ? GCode.FirstSide.ToArray() : GCode.SecondSide.ToArray();
			
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

		#region Stock Values Changes
		private void xStockDiameterInput_ValueChanged(object sender, EventArgs e)
		{
			if (Parameter.ComesFromFileLoad) return;
			Parameter.StockDiameter = (float)xStockDiameterInput.Value;
			Parameter.StockX = Parameter.StockDiameter - Parameter.DieDiameter;
			Parameter.StockX = Conversion.StringToThreeDigitFloat(Convert.ToString(Parameter.StockX));
			visualizationPanel.Refresh();
		}

		private void zStockWidthInput_ValueChanged(object sender, EventArgs e)
		{
			if (Parameter.ComesFromFileLoad) return;
			Parameter.StockWidth = (float) zStockWidthInput.Value;
			Parameter.StockZFirstSide = Parameter.StockWidth - Parameter.DieWidth - Parameter.StockZSecondSide;
			Parameter.StockZFirstSide = Conversion.StringToThreeDigitFloat(Convert.ToString(Parameter.StockZFirstSide));
			zStockFirstSide.Value = Convert.ToDecimal(Parameter.StockZFirstSide);
			visualizationPanel.Refresh();
		}

		private void zStockFirstSide_ValueChanged(object sender, EventArgs e)
		{
			if (Parameter.ComesFromFileLoad) return;
			Parameter.StockZFirstSide = (float)zStockFirstSide.Value;
			Parameter.StockWidth = Parameter.DieWidth + Parameter.StockZFirstSide + Parameter.StockZSecondSide;
			zStockWidthInput.Value = Convert.ToDecimal(Parameter.StockWidth);
			visualizationPanel.Refresh();

		}
		#endregion

		#region Cava Handle
		private void cavaCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (drawFirstSideButton.Checked && cavaCheckBox.Checked)
			{
				Add.CavaToRightSide();
				cavaCheckBox.Enabled = false;
			}

			if (drawSecondSideButton.Checked && cavaCheckBox.Checked)
			{
				Add.CavaToLeftSide();
				cavaCheckBox.Enabled = false;
			}

			visualizationPanel.Refresh();
		}

		#endregion

		

		private void setFirstSide_CheckedChanged(object sender, EventArgs e)
		{
			//flipButton.Enabled = false;
			setFirstSide.Enabled = false;
			drawFirstSideButton.Enabled = true;
			drawFirstSideButton.Checked = true;
			drawSecondSideButton.Enabled = true;
			setFirstSide.Text = "     Setted    ";
		}

		
	}
}
