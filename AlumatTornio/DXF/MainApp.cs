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
			
			//Set information to user interface
			fileName.Text = fileNameWithoutExtension;
			Set.DieDiameterLabel(dieDiameterLabel, dieLinesAsDesigned);
			Set.DieWidthLabel(dieWidthLabel, dieLinesAsDesigned);
			
			//Enable UI to select first machining side
			tabPanel.Enabled = true;
			sideSelectorGroup.Enabled = false;
			cavaSelectorGroup.Enabled = false;
			stockValuesSelectorGroup.Enabled = false;
			generateCode.Enabled = false;

			//Set global parameters
			Parameter.DxfFileName = fileNameWithoutExtension;
			Parameter.DieLinesAsDesigned = dieLinesAsDesigned;
			Parameter.DieArcsAsDesigned = dieArcsAsDesigned;
			Parameter.DieLinesFlipped = dieLinesFlipped;
			Parameter.DieArcsFlipped = dieArcsFlipped;

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

		#region Events
		private void visualizationPanel_Paint(object sender, PaintEventArgs e)
		{
			if (Parameter.DxfFileName == string.Empty) return;

			//Setup Graphics and modify origin point and coordinates to cartesian system
			Graphics preview = e.Graphics;
			preview.SmoothingMode = SmoothingMode.AntiAlias;
			Matrix cartesian = new Matrix(1, 0, 0, -1, 0, 0);
			preview.Transform = cartesian;
			preview.TranslateTransform(Calculation.TransformWidth(visualizationPanel.Width), Calculation.TransformHeight(visualizationPanel.Height), MatrixOrder.Append);
			
			preview.Transform = new Matrix(1, 0, 0, -1, 0, 0);
			preview.TranslateTransform(Calculation.TransformWidth(visualizationPanel.Width), Calculation.TransformHeight(visualizationPanel.Height), MatrixOrder.Append);
			Parameter.ZoomFactor = Calculation.Scale(visualizationPanel.Width, visualizationPanel.Height);
			preview.ScaleTransform(Parameter.ZoomFactor, Parameter.ZoomFactor);


			Draw.Axes(preview, (float)visualizationPanel.Width * Elements.Parameter.ZoomFactor, (float)visualizationPanel.Height * Elements.Parameter.ZoomFactor);


			//Create die path
			//GraphicsPath diePath = Create.Path();
			//GraphicsPath diePath = Create.FullPath();
			//GraphicsPath g71Profile = Create.G71Profile();

			//Visualize
			//bool firstSideIsRight = firstSide.Checked && Parameter.FirstMachiningSideAsDesigned;
			//bool firstSideIsLeftButRightIsSelected = secondSide.Checked && Parameter.FirstMachiningSideFlipped;
			//bool flippedToRight = Parameter.FirstMachiningSideAsDesigned && flipButton.Enabled;

			//bool firstSideIsLeft = firstSide.Checked && Parameter.FirstMachiningSideFlipped;
			//bool firstSideIsRightButLeftIsSelected = secondSide.Checked && Parameter.FirstMachiningSideAsDesigned;
			//bool flippedToLeft = Parameter.FirstMachiningSideFlipped && flipButton.Enabled;


			//if ((firstSideIsRight) || (firstSideIsLeftButRightIsSelected) || (flippedToRight))
			//{
			//	Draw.RightSide(preview);
			//}
			//else if ((firstSideIsLeft) || (firstSideIsRightButLeftIsSelected) || (flippedToLeft))
			//{
			//	Draw.LeftSide(preview);
			//}

			//Draw.Stock(preview);
			//Draw.Chock(preview, Parameter.DieLinesAsDesigned, Parameter.DieArcsAsDesigned);
		}

		private void flipButton_Click(object sender, EventArgs e)
		{
			Parameter.FirstSideLines = Parameter.DieLinesAsDesigned;
			Parameter.FirstSideArcs = Parameter.DieArcsAsDesigned;

			Parameter.FirstMachiningSideAsDesigned = !Parameter.FirstMachiningSideAsDesigned;
			Parameter.FirstMachiningSideFlipped = !Parameter.FirstMachiningSideFlipped;
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
		
		private void firstSide_CheckedChanged(object sender, EventArgs e)
		{
			gCodeTextBox.Lines = firstSide.Checked ? GCode.FirstSide.ToArray() : GCode.SecondSide.ToArray();
			visualizationPanel.Refresh();
		}
		#endregion

		#region Machining Sides Setup

		

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
			gCodeTextBox.Lines = firstSide.Checked ? GCode.FirstSide.ToArray() : GCode.SecondSide.ToArray();
			
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
			if (firstSide.Checked && cavaCheckBox.Checked)
			{
				Add.CavaToRightSide();
				cavaCheckBox.Enabled = false;
			}

			if (secondSide.Checked && cavaCheckBox.Checked)
			{
				Add.CavaToLeftSide();
				cavaCheckBox.Enabled = false;
			}

			visualizationPanel.Refresh();
		}

		#endregion

		

		private void setFirstSide_CheckedChanged(object sender, EventArgs e)
		{
			flipButton.Enabled = false;
			setFirstSide.Enabled = false;
			firstSide.Enabled = true;
			firstSide.Checked = true;
			secondSide.Enabled = true;
			setFirstSide.Text = "     Setted    ";
		}

		
	}
}
