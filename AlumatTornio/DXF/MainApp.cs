using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
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

			//Fill diametrical cycle inputs with saved values
			diametricalDepthOfCutInput.Value = Convert.ToDecimal(Settings.Default["DiametricalDepthOfCut"]);
			diametricalRetractInput.Value = Convert.ToDecimal(Settings.Default["DiametricalRetract"]);
			diametricalXAllowanceInput.Value = Convert.ToDecimal(Settings.Default["DiametricalXAllowance"]);
			diametricalZAllowanceInput.Value = Convert.ToDecimal(Settings.Default["DiametricalZAllowance"]);
			diametricalFeedRateInput.Value = Convert.ToDecimal(Settings.Default["DiametricalFeedRate"]);

			//Fill facing cycle inputs with saved values
			facingDepthOfCutInput.Value = Convert.ToDecimal(Settings.Default["FacingDepthOfCut"]);
			facingRetractInput.Value = Convert.ToDecimal(Settings.Default["FacingRetract"]);
			facingXAllowanceInput.Value = Convert.ToDecimal(Settings.Default["FacingXAllowance"]);
			facingZAllowanceInput.Value = Convert.ToDecimal(Settings.Default["FacingZAllowance"]);
			facingFeedRateInput.Value = Convert.ToDecimal(Settings.Default["FacingFeedRate"]);

			//Fill collarino cycle inputs with saved values
			collarinoDepthOfCutInput.Value = Convert.ToDecimal(Settings.Default["CollarinoDepthOfCut"]);
			collarinoRetractInput.Value = Convert.ToDecimal(Settings.Default["CollarinoRetract"]);
			collarinoXAllowanceInput.Value = Convert.ToDecimal(Settings.Default["CollarinoXAllowance"]);
			collarinoZAllowanceInput.Value = Convert.ToDecimal(Settings.Default["CollarinoZAllowance"]);
			collarinoFeedRateInput.Value = Convert.ToDecimal(Settings.Default["CollarinoFeedRate"]);

			//Fill cava cycle inputs with saved values
			cavaDepthOfCutInput.Value = Convert.ToDecimal(Settings.Default["CavaDepthOfCut"]);
			cavaRetractInput.Value = Convert.ToDecimal(Settings.Default["CavaRetract"]);
			cavaXAllowanceInput.Value = Convert.ToDecimal(Settings.Default["CavaXAllowance"]);
			cavaZAllowanceInput.Value = Convert.ToDecimal(Settings.Default["CavaZAllowance"]);
			cavaFeedRateInput.Value = Convert.ToDecimal(Settings.Default["CavaFeedRate"]);

			//Fill spindle speed inputs with saved values
			diametricalSpeedLimitInput.Value = Convert.ToDecimal(Settings.Default["DiametricalSpeedLimit"]);
			diametricalSurfaceSpeedInput.Value = Convert.ToDecimal(Settings.Default["DiametricalSurfaceSpeed"]);
			facingSpeedLimitInput.Value = Convert.ToDecimal(Settings.Default["FacingSpeedLimit"]);
			facingSurfaceSpeedInput.Value = Convert.ToDecimal(Settings.Default["FacingSurfaceSpeed"]);
			collarinoSpeedLimitInput.Value = Convert.ToDecimal(Settings.Default["CollarinoSpeedLimit"]);
			collarinoSurfaceSpeedInput.Value = Convert.ToDecimal(Settings.Default["CollarinoSurfaceSpeed"]);
			cavaSpeedLimitInput.Value = Convert.ToDecimal(Settings.Default["CavaSpeedLimit"]);
			cavaSurfaceSpeedInput.Value = Convert.ToDecimal(Settings.Default["CavaSurfaceSpeed"]);

			//Fill tool number inputs with saved values
			diametricalToolNumberInput.Text = Convert.ToString(Settings.Default["DiametricalToolNumber"]);
			facingToolNumberInput.Text = Convert.ToString(Settings.Default["FacingToolNumber"]);
			collarinoToolNumberInput.Text = Convert.ToString(Settings.Default["CollarinoToolNumber"]);
			cavaToolNumberInput.Text = Convert.ToString(Settings.Default["CavaToolNumber"]);

			//Fill workplane origin parameter with saved value
			workplaneOriginParameterInput.Text = Convert.ToString(Settings.Default["WorkplaneOriginParameter"]);

			//Fill chock size input with saved value
			chockSizeInput.Value = Convert.ToDecimal(Settings.Default["ChockSize"]);
		}
		#endregion
		
		#region File Elements Setup
		private void fileDxfMenuItem_Click(object sender, EventArgs e)
		{
			//Initial global parameters on every new file opening
			Initial.GlobalParameters();

			//Create file dialog
			OpenFileDialog fileDialog = new OpenFileDialog()
			{
				Title = @"Select file",
				InitialDirectory = Settings.Default["DxfFolderPath"].ToString(),
				DefaultExt = @".dxf",
				Filter = @"DXF Files (*.dxf)|*.dxf"
			};

			//Trigger the file dialog and read the selected file
			if (fileDialog.ShowDialog() == DialogResult.Cancel) return;
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileDialog.FileName);
			if (fileNameWithoutExtension.Length > 16) { fileNameWithoutExtension = fileNameWithoutExtension.Substring(0, 14) + "..."; }
			List<string> file = File.ReadAllLines(fileDialog.FileName).ToList();

			//Validate the selected file
			bool fileNotHaveEntities = !file.Contains("ENTITIES");
			if (fileNotHaveEntities)
			{
				MessageBox.Show("The selected DXF file does not contains elements");
				return;
			}

			//Remove file part above entities section
			const int indexOfFirstLine = 0;
			int linesCountAboveEntities = file.IndexOf("ENTITIES");
			file.RemoveRange(indexOfFirstLine, linesCountAboveEntities);

			//Remove file part below entities section
			int indexOfFirstLineAfterEntities = file.IndexOf("ENDSEC") + 1;
			int linesCountBelowEntities = file.LastIndexOf("EOF") - file.IndexOf("ENDSEC");
			file.RemoveRange(indexOfFirstLineAfterEntities, linesCountBelowEntities);

			//Get all line and arc elements from the entities section of the file
			List<Line> allLines = Get.LinesFromFile(file);
			List<Arc> allArcs = Get.ArcsFromFile(file);

			//Check for gap from origin point X0,Y0
			float gapFromX = Get.GapFromX(allLines);
			float gapFromY = Get.GapFromY(allLines);
			bool elementsHasGap = gapFromX != 0 || gapFromY != 0;
			if (elementsHasGap)
			{
				Edit.MoveElementsToOrigin(allLines, allArcs, gapFromX, gapFromY);
				//To inform the user to double check the dimensions
				Parameter.ElementsHasGap = true;
			}

			//Round up decimals of elements coordinate values
			Edit.DecimalsCorrection(allLines, allArcs);

			//Create lists of lines and arcs with their elements placement as designed
			List<Line> linesAsDesigned = Get.LinesAsDesigned(allLines);
			List<Arc> arcsAsDesigned = Get.ArcsAsDesigned(allArcs);

			//Set index on each element with counter clockwise order
			Add.Indexes(linesAsDesigned, arcsAsDesigned);

			//Check if every element has an index
			Line notIndexedLine = linesAsDesigned.Find(line => line.Index == 0);
			Arc notIndexedArc = arcsAsDesigned.Find(arc => arc.Index == 0);
			if (notIndexedLine != null || notIndexedArc != null)
			{
				MessageBox.Show("The profile from the DXF file is open!\nCheck the cad file for gap between elements!");
				Application.Restart();
			}

			//Clone lines and arcs from as designed placement and flip them
			List<Line> linesFlipped = linesAsDesigned.Select(line => line.Clone()).ToList();
			List<Arc> arcsFlipped = arcsAsDesigned.Select(arc => arc.Clone()).ToList();
			Edit.FlipElements(linesFlipped, arcsFlipped);

			//Set placement for lines and arcs
			Add.Placement(linesAsDesigned, arcsAsDesigned, "AsDesigned");
			Add.Placement(linesFlipped, arcsFlipped, "Flipped");

			//Calculate dimensions
			float diameter = Math.Abs(linesAsDesigned.Max(line => line.EndY)) * 2;
			float width = Math.Abs(linesAsDesigned.Min(line => line.EndX));

			//Set information to user interface
			fileName.Text = fileNameWithoutExtension;
			dieDiameterLabel.Text = string.Empty;
			dieDiameterLabel.Text = $"Diameter : {diameter}";
			dieWidthLabel.Text = string.Empty;
			dieWidthLabel.Text = $"Width : {width}";

			//Set UI to select first machining side
			tabPanel.Enabled = true;
			gCodeTextBox.Lines = Array.Empty<string>();
			validateDimensionsGroup.Enabled = true;
			firstSideSelectorGroup.Enabled = false;
			asDesignedButton.Checked = false;
			flippedButton.Checked = false;
			cavaSelectorGroup.Enabled = false;
			manualCavaSelectorGroup.Enabled = false;
			autoCavaButton.Checked = true;
			autoCavaSelectorGroup.Enabled = true;
			cavaFirstSideAuto.Checked = false;
			cavaSecondSideAuto.Checked = false;
			cavaFirstSideManual.Checked = false;
			cavaSecondSideManual.Checked = false;
			viewSideSelectorGroup.Enabled = false;
			stockValuesSelectorGroup.Enabled = false;
			generateCode.Enabled = false;
			drawFirstSideButton.Checked = false;
			drawSecondSideButton.Checked = false;
			exportProgressBar.Value = 0;

			//Set global parameters
			Parameter.FileName = fileNameWithoutExtension;
			Parameter.LinesAsDesigned = linesAsDesigned.OrderBy(line => line.Index).ToList();
			Parameter.ArcsAsDesigned = arcsAsDesigned.OrderBy(arc => arc.Index).ToList();
			Parameter.LinesFlipped = linesFlipped.OrderBy(line => line.Index).Reverse().ToList();
			Parameter.ArcsFlipped = arcsFlipped.OrderBy(arc => arc.Index).Reverse().ToList();
			Parameter.Diameter = diameter;
			Parameter.DieRadius = diameter / 2;
			Parameter.DieWidth = width;

			//Draw
			visualizationPanel.Refresh();
		}
		#endregion

		#region Validate Dimensions
		private void validateDimensionsButton_Click(object sender, EventArgs e)
		{
			//Inform the user amount elements movement to origin X0:Y0
			if (Parameter.ElementsHasGap)
			{
				MessageBox.Show("Double check the dimensions because\nthe elements have been moved to be on X0:Y0");
			}

			//Enable UI to continue the procedure
			validateDimensionsGroup.Enabled = false;
			firstSideSelectorGroup.Enabled = true;
		}
		#endregion

		#region Profiles Setup
		private void asDesignedButton_CheckedChanged(object sender, EventArgs e)
		{
			if (asDesignedButton.Checked)
			{
				//First side
				Parameter.FirstSideLines = Parameter.LinesAsDesigned;
				Parameter.FirstSideArcs = Parameter.ArcsAsDesigned;

				//Second side
				Parameter.SecondSideLines = Parameter.LinesFlipped;
				Parameter.SecondSideArcs = Parameter.ArcsFlipped;
			}

			//Draw
			visualizationPanel.Refresh();
		}

		private void flippedButton_CheckedChanged(object sender, EventArgs e)
		{
			if (flippedButton.Checked)
			{
				//First side
				Parameter.FirstSideLines = Parameter.LinesFlipped;
				Parameter.FirstSideArcs = Parameter.ArcsFlipped;

				//Second side
				Parameter.SecondSideLines = Parameter.LinesAsDesigned;
				Parameter.SecondSideArcs = Parameter.ArcsAsDesigned;
			}

			//Draw
			visualizationPanel.Refresh();
		}

		private void setSidesButton_Click(object sender, EventArgs e)
		{
			//
			//Minimum stock values
			//
			//Diameter stock round up to first decimal plus 2mm
			float stockDiameterValue = Parameter.Diameter;
			stockDiameterValue += 1 - Parameter.Diameter % 1;
			stockDiameterValue += 2;
			stockDiameterInput.Minimum = Convert.ToDecimal(stockDiameterValue);
			stockDiameterInput.Maximum = stockDiameterInput.Minimum + 20;
			stockDiameterInput.Value = stockDiameterInput.Minimum;

			//Width stock round up to first decimal plus 2mm
			float stockWidthValue = Parameter.DieWidth;
			stockWidthValue += 1 - Parameter.DieWidth % 1;
			stockWidthValue += 2;
			stockWidthInput.Minimum = Convert.ToDecimal(stockWidthValue);
			stockWidthInput.Maximum = stockWidthInput.Minimum + 20;
			stockWidthInput.Value = stockWidthInput.Minimum;

			//
			//First side horizontal profile
			//
			List<Line> firstSideHorizontalProfileLines = Get.HorizontalProfileLines(Parameter.FirstSideLines);
			List<Arc> firstSideHorizontalProfileArcs = Get.HorizontalProfileArcs(firstSideHorizontalProfileLines, Parameter.FirstSideArcs);

			//Insert lines from stock start position until profile start and from profile end to stock end position for first side
			List<Line> firstSideHorizontalProfileStockLines = Get.FirstSideHorizontalProfileStockLines(firstSideHorizontalProfileLines, firstSideHorizontalProfileArcs);
			firstSideHorizontalProfileLines.Add(firstSideHorizontalProfileStockLines[2]);
			firstSideHorizontalProfileLines.Insert(0,firstSideHorizontalProfileStockLines[1]);
			firstSideHorizontalProfileLines.Insert(0, firstSideHorizontalProfileStockLines[0]);

			//
			//Second side outer horizontal profile
			//
			List<Line> secondSideHorizontalProfileLines = Get.HorizontalProfileLines(Parameter.SecondSideLines);
			List<Arc> secondSideHorizontalProfileArcs = Get.HorizontalProfileArcs(secondSideHorizontalProfileLines, Parameter.SecondSideArcs);

			//Insert lines from stock start position until profile start and from profile end to stock end position for second side
			List<Line> secondSideHorizontalProfileStockLines = Get.SecondSideHorizontalProfileStockLines(secondSideHorizontalProfileLines, secondSideHorizontalProfileArcs);
			secondSideHorizontalProfileLines.Add(secondSideHorizontalProfileStockLines[2]);
			secondSideHorizontalProfileLines.Insert(0, secondSideHorizontalProfileStockLines[1]);
			secondSideHorizontalProfileLines.Insert(0, secondSideHorizontalProfileStockLines[0]);

			//
			//First side facing profile
			//
			List<Line> firstSideFacingProfile = Get.FirstSideFacingProfile();

			//
			//Second side facing profile
			//
			List<Line> secondSideFacingProfile = Get.SecondSideFacingProfile();

			//
			//First side cava profile
			//
			List<Line> firstSideCavaLines = Get.CavaLines(Parameter.FirstSideLines);
			List<Arc> firstSideCavaArcs = Get.CavaArcs(firstSideCavaLines, Parameter.FirstSideArcs);

			//
			//Second side cava profile
			//
			List<Line> secondSideCavaLines = Get.CavaLines(Parameter.SecondSideLines);
			List<Arc> secondSideCavaArcs = Get.CavaArcs(secondSideCavaLines, Parameter.SecondSideArcs);

			//
			//First side female collarino profile
			//
			List<Line> firstSideCollarinoLines = Get.CollarinoLines(Parameter.FirstSideLines);
			List<Arc> firstSideCollarinoArcs = Get.CollarinoArcs(firstSideCollarinoLines, Parameter.FirstSideArcs);

			//
			//Second side female collarino profile
			//
			List<Line> secondSideCollarinoLines = Get.CollarinoLines(Parameter.SecondSideLines);
			List<Arc> secondSideCollarinoArcs = Get.CollarinoArcs(secondSideCollarinoLines, Parameter.SecondSideArcs);

			//Set Global Parameters
			Parameter.FirstSideHorizontalProfileLines = firstSideHorizontalProfileLines;
			Parameter.FirstSideHorizontalProfileArcs = firstSideHorizontalProfileArcs;
			Parameter.FirstSideFacingProfile = firstSideFacingProfile;

			Parameter.SecondSideHorizontalProfileLines = secondSideHorizontalProfileLines;
			Parameter.SecondSideHorizontalProfileArcs = secondSideHorizontalProfileArcs;
			Parameter.SecondSideFacingProfile = secondSideFacingProfile;

			Parameter.FirstSideCavaLines = firstSideCavaLines;
			Parameter.FirstSideCavaArcs = firstSideCavaArcs;
			Parameter.SecondSideCavaLines = secondSideCavaLines;
			Parameter.SecondSideCavaArcs = secondSideCavaArcs;

			Parameter.FirstSideCollarinoLines = firstSideCollarinoLines;
			Parameter.FirstSideCollarinoArcs = firstSideCollarinoArcs;
			Parameter.SecondSideCollarinoLines = secondSideCollarinoLines;
			Parameter.SecondSideCollarinoArcs = secondSideCollarinoArcs;
			
			Parameter.FirstSideHorizontalProfileLastLine = Parameter.FirstSideHorizontalProfileLines.Last().Clone();
			Parameter.SecondSideHorizontalProfileLastLine = Parameter.SecondSideHorizontalProfileLines.Last().Clone();

			//Change UI after sides selected
			drawFirstSideButton.Checked = true;
			firstSideSelectorGroup.Enabled = false;
			cavaSelectorGroup.Enabled = true;
			viewSideSelectorGroup.Enabled = true;
			stockValuesSelectorGroup.Enabled = true;
			generateCode.Enabled = true;

			//Draw
			visualizationPanel.Refresh();

		}
		#endregion

		#region Stock Manipulation
		private void stockDiameterInput_ValueChanged(object sender, EventArgs e)
		{
			//Set global parameters
			Parameter.StockFromDiameter = (float)stockDiameterInput.Value - Parameter.Diameter;
			Parameter.StockFromRadius = Parameter.StockFromDiameter / 2;

			//Update horizontal profile lines
			if (Parameter.FirstSideHorizontalProfileLines.Count != 0)
			{
				Parameter.FirstSideHorizontalProfileLines[0].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.FirstSideHorizontalProfileLines[Parameter.FirstSideHorizontalProfileLines.Count - 1].EndY = Parameter.FirstSideHorizontalProfileLines[Parameter.FirstSideHorizontalProfileLines.Count - 1].StartY + Parameter.StockFromRadius;
			}
			if (Parameter.SecondSideHorizontalProfileLines.Count != 0)
			{
				Parameter.SecondSideHorizontalProfileLines[0].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.SecondSideHorizontalProfileLines[Parameter.SecondSideHorizontalProfileLines.Count - 1].EndY = Parameter.SecondSideHorizontalProfileLines[Parameter.SecondSideHorizontalProfileLines.Count - 1].StartY + Parameter.StockFromRadius;
			}

			//Update facing profile lines
			if (Parameter.FirstSideFacingProfile.Count != 0)
			{
				Parameter.FirstSideFacingProfile[0].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.FirstSideFacingProfile[0].EndY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.FirstSideFacingProfile[1].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
			}
			if (Parameter.SecondSideFacingProfile.Count != 0)
			{
				Parameter.SecondSideFacingProfile[0].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.SecondSideFacingProfile[0].EndY = Parameter.DieRadius + Parameter.StockFromRadius;
				Parameter.SecondSideFacingProfile[1].StartY = Parameter.DieRadius + Parameter.StockFromRadius;
			}

			//Draw
			visualizationPanel.Refresh();
		}

		private void stockWidthInput_ValueChanged(object sender, EventArgs e)
		{
			//Set global parameters
			Parameter.StockFromWidthSecondSide = 1;
			Parameter.StockFromWidthFirstSide = (float)stockWidthInput.Value - Parameter.DieWidth - Parameter.StockFromWidthSecondSide;
			Parameter.StockFromWidthFirstSide = Conversion.StringToThreeDigitFloat(Parameter.StockFromWidthFirstSide.ToString());

			//Update horizontal profile lines
			if (Parameter.FirstSideHorizontalProfileLines.Count != 0)
			{
				Parameter.FirstSideHorizontalProfileLines[0].StartX = Parameter.StockFromWidthFirstSide;
				Parameter.FirstSideHorizontalProfileLines[0].EndX = Parameter.StockFromWidthFirstSide;
				Parameter.FirstSideHorizontalProfileLines[1].StartX = Parameter.StockFromWidthFirstSide;
			}

			//Update facing profile lines
			if (Parameter.FirstSideFacingProfile.Count != 0)
			{
				Parameter.FirstSideFacingProfile[0].StartX = Parameter.StockFromWidthFirstSide;
				Parameter.FirstSideFacingProfile[2].EndX = Parameter.StockFromWidthFirstSide;
			}

			//Draw
			visualizationPanel.Refresh();
		}
		#endregion

		#region Cava Manipulation

		private void autoCavaButton_CheckedChanged(object sender, EventArgs e)
		{
			cavaFirstSideManual.Checked = false;
			cavaSecondSideManual.Checked = false;

			if (Parameter.FirstSideHorizontalProfileLines.Count == 0 || Parameter.SecondSideHorizontalProfileLines.Count == 0) return;
			if (autoCavaButton.Checked)
			{
				autoCavaSelectorGroup.Enabled = true;
				manualCavaSelectorGroup.Enabled = false;

				Parameter.FirstSideHorizontalProfileLines[Parameter.FirstSideHorizontalProfileLines.Count - 1] = Parameter.FirstSideHorizontalProfileLastLine.Clone();
				Parameter.FirstSideHorizontalProfileLines[Parameter.FirstSideHorizontalProfileLines.Count - 2].EndX = Parameter.FirstSideHorizontalProfileLines.Last().StartX;

				Parameter.SecondSideHorizontalProfileLines[Parameter.SecondSideHorizontalProfileLines.Count - 1] = Parameter.SecondSideHorizontalProfileLastLine.Clone();
				Parameter.SecondSideHorizontalProfileLines[Parameter.SecondSideHorizontalProfileLines.Count - 2].EndX = Parameter.SecondSideHorizontalProfileLines.Last().StartX;
			}
			else if (manualCavaButton.Checked)
			{
				autoCavaSelectorGroup.Enabled = false;
				manualCavaSelectorGroup.Enabled = true;
			}

			//Draw
			visualizationPanel.Refresh();
		}

		private void cavaFirstSideButton_CheckedChanged(object sender, EventArgs e)
		{
			float cavaLength = 0;
			if (Parameter.FirstSideCavaLines.Count != 0)
			{
				cavaLength = Calculation.CavaLengthFromProfile(Parameter.FirstSideCavaLines, Parameter.FirstSideCavaArcs, Parameter.FirstSideHorizontalProfileLastLine);
			}

			if (cavaFirstSideAuto.Checked)
			{
				Parameter.FirstSideHorizontalProfileLines.Last().StartX -= cavaLength;
				Parameter.FirstSideHorizontalProfileLines.Last().EndX -= cavaLength;
				Parameter.FirstSideHorizontalProfileLines[Parameter.FirstSideHorizontalProfileLines.Count - 2].EndX = Parameter.FirstSideHorizontalProfileLines.Last().StartX;
			}
			else if (cavaSecondSideAuto.Checked)
			{
				Parameter.FirstSideHorizontalProfileLines.Last().StartX += cavaLength;
				Parameter.FirstSideHorizontalProfileLines.Last().EndX += cavaLength;
				Parameter.FirstSideHorizontalProfileLines[Parameter.FirstSideHorizontalProfileLines.Count - 2].EndX = Parameter.FirstSideHorizontalProfileLines.Last().StartX;
			}
			visualizationPanel.Refresh();
		}

		private void cavaSecondSideButton_CheckedChanged(object sender, EventArgs e)
		{
			float cavaLength = 0;
			if (Parameter.SecondSideCavaLines.Count != 0)
			{
				cavaLength = Calculation.CavaLengthFromProfile(Parameter.SecondSideCavaLines, Parameter.SecondSideCavaArcs, Parameter.SecondSideHorizontalProfileLastLine);
			}
			if (cavaSecondSideAuto.Checked)
			{
				Parameter.SecondSideHorizontalProfileLines.Last().StartX -= cavaLength;
				Parameter.SecondSideHorizontalProfileLines.Last().EndX -= cavaLength;
				Parameter.SecondSideHorizontalProfileLines[Parameter.SecondSideHorizontalProfileLines.Count - 2].EndX = Parameter.SecondSideHorizontalProfileLines.Last().StartX;
			}
			else if (cavaFirstSideAuto.Checked)
			{
				Parameter.SecondSideHorizontalProfileLines.Last().StartX += cavaLength;
				Parameter.SecondSideHorizontalProfileLines.Last().EndX += cavaLength;
				Parameter.SecondSideHorizontalProfileLines[Parameter.SecondSideHorizontalProfileLines.Count - 2].EndX = Parameter.SecondSideHorizontalProfileLines.Last().StartX;
			}
			visualizationPanel.Refresh();
		}

		private void manualCavaButton_CheckedChanged(object sender, EventArgs e)
		{
			if (Parameter.FirstSideCavaLines.Count == 0) return;

			float cavaLengthFirstSide = Calculation.CavaLengthFromProfile(Parameter.FirstSideCavaLines, Parameter.FirstSideCavaArcs, Parameter.FirstSideHorizontalProfileLastLine);
			float cavaLengthSecondSide = Calculation.CavaLengthFromProfile(Parameter.SecondSideCavaLines, Parameter.SecondSideCavaArcs, Parameter.SecondSideHorizontalProfileLastLine);
			if (manualCavaButton.Checked)
			{
				//Set the horizontal profile back to initial
				if (cavaFirstSideAuto.Checked)
				{
					cavaFirstSideAuto.Checked = false;
					Parameter.FirstSideHorizontalProfileLines.Last().StartX += cavaLengthFirstSide;
					Parameter.FirstSideHorizontalProfileLines.Last().EndX += cavaLengthFirstSide;
					Parameter.FirstSideHorizontalProfileLines[Parameter.FirstSideHorizontalProfileLines.Count - 2].EndX = Parameter.FirstSideHorizontalProfileLines.Last().StartX;
				}
				else if (cavaSecondSideAuto.Checked)
				{
					cavaSecondSideAuto.Checked = false;
					Parameter.SecondSideHorizontalProfileLines.Last().StartX += cavaLengthSecondSide;
					Parameter.SecondSideHorizontalProfileLines.Last().EndX += cavaLengthSecondSide;
					Parameter.SecondSideHorizontalProfileLines[Parameter.SecondSideHorizontalProfileLines.Count - 2].EndX = Parameter.SecondSideHorizontalProfileLines.Last().StartX;
				}


				//Save initial horizontal profile values to change the profile back to normal if swap to automatic
				Parameter.FirstSideHorizontalProfileLastLine = Parameter.FirstSideHorizontalProfileLines.Last().Clone();
				Parameter.SecondSideHorizontalProfileLastLine = Parameter.SecondSideHorizontalProfileLines.Last().Clone();

			}

			visualizationPanel.Refresh();
		}

		private void increaseFirstSideButton_Click(object sender, EventArgs e)
		{
			Parameter.FirstSideHorizontalProfileLines.Last().StartX -= 1;
			Parameter.FirstSideHorizontalProfileLines.Last().EndX -= 1;
			Parameter.FirstSideHorizontalProfileLines[Parameter.FirstSideHorizontalProfileLines.Count - 2].EndX = Parameter.FirstSideHorizontalProfileLines.Last().StartX;

			//Draw
			visualizationPanel.Refresh();
		}

		private void decreaseFirstSideButton_Click(object sender, EventArgs e)
		{
			if (Parameter.FirstSideHorizontalProfileLastLine.EndX == Parameter.FirstSideHorizontalProfileLines.Last().EndX)
			{
				MessageBox.Show("You can move until initial profile point");
			}
			else
			{
				Parameter.FirstSideHorizontalProfileLines.Last().StartX += 1;
				Parameter.FirstSideHorizontalProfileLines.Last().EndX += 1;
				Parameter.FirstSideHorizontalProfileLines[Parameter.FirstSideHorizontalProfileLines.Count - 2].EndX = Parameter.FirstSideHorizontalProfileLines.Last().StartX;
			}

			//Draw
			visualizationPanel.Refresh();
		}

		private void increaseSecondSideButton_Click(object sender, EventArgs e)
		{
			Parameter.SecondSideHorizontalProfileLines.Last().StartX -= 1;
			Parameter.SecondSideHorizontalProfileLines.Last().EndX -= 1;
			Parameter.SecondSideHorizontalProfileLines[Parameter.SecondSideHorizontalProfileLines.Count - 2].EndX = Parameter.SecondSideHorizontalProfileLines.Last().StartX;

			//Draw
			visualizationPanel.Refresh();
		}

		private void decreaseSecondSideButton_Click(object sender, EventArgs e)
		{
			if (Parameter.SecondSideHorizontalProfileLastLine.EndX == Parameter.SecondSideHorizontalProfileLines.Last().EndX)
			{
				MessageBox.Show("You can move until initial profile point");
			}
			else
			{
				Parameter.SecondSideHorizontalProfileLines.Last().StartX += 1;
				Parameter.SecondSideHorizontalProfileLines.Last().EndX += 1;
				Parameter.SecondSideHorizontalProfileLines[Parameter.SecondSideHorizontalProfileLines.Count - 2].EndX = Parameter.SecondSideHorizontalProfileLines.Last().StartX;
			}

			//Draw
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
			if (string.IsNullOrEmpty(Parameter.FileName)) return;

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
					Draw.OuterHorizontalMachiningProfile(visualizationPanelGraphics, Parameter.FirstSideHorizontalProfileLines, Parameter.FirstSideHorizontalProfileArcs);
					Draw.OuterVerticalMachiningProfile(visualizationPanelGraphics, Parameter.FirstSideFacingProfile);
					Draw.FemaleCollarino(visualizationPanelGraphics, Parameter.FirstSideCollarinoLines,Parameter.FirstSideCollarinoArcs);
					Draw.Cava(visualizationPanelGraphics, Parameter.FirstSideCavaLines, Parameter.FirstSideCavaArcs, cavaFirstSideAuto.Checked, cavaFirstSideManual.Checked);
				}
				else if (drawSecondSideButton.Checked)
				{
					Draw.Stock(visualizationPanelGraphics, Parameter.StockFromRadius, Parameter.StockFromWidthSecondSide, Parameter.StockFromWidthFirstSide);
					Draw.Chock(visualizationPanelGraphics, Parameter.StockFromRadius, 0, (float)chockSizeInput.Value);
					Draw.Die(visualizationPanelGraphics, Parameter.SecondSideLines, Parameter.SecondSideArcs);
					Draw.OuterHorizontalMachiningProfile(visualizationPanelGraphics, Parameter.SecondSideHorizontalProfileLines, Parameter.SecondSideHorizontalProfileArcs);
					Draw.OuterVerticalMachiningProfile(visualizationPanelGraphics, Parameter.SecondSideFacingProfile);
					Draw.FemaleCollarino(visualizationPanelGraphics, Parameter.SecondSideCollarinoLines, Parameter.SecondSideCollarinoArcs);
					Draw.Cava(visualizationPanelGraphics, Parameter.SecondSideCavaLines, Parameter.SecondSideCavaArcs, cavaSecondSideAuto.Checked, cavaSecondSideManual.Checked);
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

		private void cavaFirstSideManual_CheckedChanged(object sender, EventArgs e)
		{
			visualizationPanel.Refresh();
		}

		private void cavaSecondSideManual_CheckedChanged(object sender, EventArgs e)
		{
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
			for (int i = 0; i < 100; i++) { for (int j = 0; j < 10000; j++) { } exportProgressBar.Value++; }

			//Set general Attributes
			string workplaneOriginParameter = workplaneOriginParameterInput.Text;
			float firstSideWorkplaneValue = Parameter.DieWidth + Parameter.StockFromWidthSecondSide;
			float secondSideWorkplaneValue = Parameter.DieWidth;

			//Spindle speeds
			SpindleSpeed diametricalSpindleSpeed = new SpindleSpeed(diametricalSpeedLimitInput.Value, diametricalSurfaceSpeedInput.Value);
			SpindleSpeed facingSpindleSpeed = new SpindleSpeed(facingSpeedLimitInput.Value, facingSurfaceSpeedInput.Value);
			SpindleSpeed collarinoSpindleSpeed = new SpindleSpeed(collarinoSpeedLimitInput.Value, collarinoSurfaceSpeedInput.Value);
			SpindleSpeed cavaSpindleSpeed = new SpindleSpeed(cavaSpeedLimitInput.Value, cavaSurfaceSpeedInput.Value);

			//Tool numbers
			string diametricalTool = diametricalToolNumberInput.Text;
			string facingTool = facingToolNumberInput.Text;
			string collarinoTool = collarinoToolNumberInput.Text;
			string cavaTool = cavaToolNumberInput.Text;
			
			//Set G71 and G72 Attributes
			G72 facingCycle = new G72("10", "20", facingDepthOfCutInput.Value, facingRetractInput.Value, facingXAllowanceInput.Value, facingZAllowanceInput.Value, facingFeedRateInput.Value);
			G71 diametricalCycle = new G71("30", "40",diametricalDepthOfCutInput.Value, diametricalRetractInput.Value, diametricalXAllowanceInput.Value, diametricalZAllowanceInput.Value, diametricalFeedRateInput.Value);
			G72 collarinoCycle = new G72("50", "60", collarinoDepthOfCutInput.Value, collarinoRetractInput.Value, collarinoXAllowanceInput.Value, collarinoZAllowanceInput.Value, collarinoFeedRateInput.Value);
			G71 cavaCycle = new G71("70", "80", cavaDepthOfCutInput.Value, cavaRetractInput.Value, cavaXAllowanceInput.Value, cavaZAllowanceInput.Value, cavaFeedRateInput.Value);

			//Get first side profiles points
			List<ProfilePoint> firstSideOuterHorizontalProfilePoints = Get.ProfilePoints(Parameter.FirstSideHorizontalProfileLines, Parameter.FirstSideHorizontalProfileArcs);
			List<ProfilePoint> firstSideOuterVerticalProfilePoints = Get.ProfilePoints(Parameter.FirstSideFacingProfile, Parameter.FirstSideOuterVerticalMachiningArcs);
			List<ProfilePoint> firstSideFemaleCollarinoProfilePoints = Get.ProfilePoints(Parameter.FirstSideCollarinoLines, Parameter.FirstSideCollarinoArcs);
			List<ProfilePoint> firstSideCavaProfilePoints = Get.ProfilePoints(Parameter.FirstSideCavaLines, Parameter.FirstSideCavaArcs);

			//Create g code for first side
			List<string> gCodeFirstSide = new List<string>();
			gCodeFirstSide.AddRange(CodeBlock.LatheInitialization(workplaneOriginParameter, firstSideWorkplaneValue));
			gCodeFirstSide.AddRange(CodeBlock.FacingProfile(facingCycle, firstSideOuterVerticalProfilePoints, facingSpindleSpeed, facingTool));
			gCodeFirstSide.AddRange(CodeBlock.DiametricalProfile(diametricalCycle, firstSideOuterHorizontalProfilePoints, diametricalSpindleSpeed, diametricalTool));
			gCodeFirstSide.AddRange(CodeBlock.CollarinoProfile(collarinoCycle, firstSideFemaleCollarinoProfilePoints, collarinoSpindleSpeed, collarinoTool));
			gCodeFirstSide.AddRange(CodeBlock.CavaProfile(cavaCycle, firstSideCavaProfilePoints, cavaSpindleSpeed, cavaTool, cavaFirstSideAuto.Checked, cavaFirstSideManual.Checked));
			gCodeFirstSide.AddRange(CodeBlock.LatheEnd());

			for (int i = 0; i < gCodeFirstSide.Count; i++)
			{
				if (gCodeFirstSide[i].Contains(','))
				{
					gCodeFirstSide[i] = gCodeFirstSide[i].Replace(',', '.');
				}
			}

			//Get second side profiles points
			List<ProfilePoint> secondSideOuterHorizontalProfilePoints = Get.ProfilePoints(Parameter.SecondSideHorizontalProfileLines, Parameter.SecondSideHorizontalProfileArcs);
			List<ProfilePoint> secondSideOuterVerticalProfilePoints = Get.ProfilePoints(Parameter.SecondSideFacingProfile, Parameter.SecondSideOuterVerticalMachiningArcs);
			List<ProfilePoint> secondtSideFemaleCollarinoProfilePoints = Get.ProfilePoints(Parameter.SecondSideCollarinoLines, Parameter.SecondSideCollarinoArcs);
			List<ProfilePoint> secondSideCavaProfilePoints = Get.ProfilePoints(Parameter.SecondSideCavaLines, Parameter.SecondSideCavaArcs);

			//Create g code for second side
			List<string> gCodeSecondSide = new List<string>();
			gCodeSecondSide.AddRange(CodeBlock.LatheInitialization(workplaneOriginParameter, secondSideWorkplaneValue));
			gCodeSecondSide.AddRange(CodeBlock.FacingProfile(facingCycle, secondSideOuterVerticalProfilePoints, facingSpindleSpeed, facingTool));
			gCodeSecondSide.AddRange(CodeBlock.DiametricalProfile(diametricalCycle, secondSideOuterHorizontalProfilePoints, diametricalSpindleSpeed, diametricalTool));
			gCodeSecondSide.AddRange(CodeBlock.CollarinoProfile(collarinoCycle, secondtSideFemaleCollarinoProfilePoints, collarinoSpindleSpeed, collarinoTool));
			gCodeSecondSide.AddRange(CodeBlock.CavaProfile(cavaCycle, secondSideCavaProfilePoints, cavaSpindleSpeed, cavaTool, cavaSecondSideAuto.Checked, cavaSecondSideManual.Checked));
			gCodeSecondSide.AddRange(CodeBlock.LatheEnd());

			//Set dot on values in case of comma
			for (int i = 0; i < gCodeSecondSide.Count; i++)
			{
				if (gCodeSecondSide[i].Contains(','))
				{
					gCodeSecondSide[i] = gCodeSecondSide[i].Replace(',', '.');
				}
			}

			//Export
			if (string.IsNullOrEmpty(Settings.Default["ExportFolderPath"].ToString()))
			{
				MessageBox.Show(@"There is no export folder selected");
			}
			else
			{
				string exportFile = $@"{Settings.Default["ExportFolderPath"]}\{Parameter.FileName}";
				File.WriteAllLines($"{exportFile}_FIRST.txt", gCodeFirstSide);
				File.WriteAllLines($"{exportFile}_SECOND.txt", gCodeSecondSide);
			}
			
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
		
		#region Diametrical Cycle Values Save
		private void diametricalDepthOfCutInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["DiametricalDepthOfCut"] = diametricalDepthOfCutInput.Value;
			Settings.Default.Save();
		}

		private void diametricalRetractInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["DiametricalRetract"] = diametricalRetractInput.Value;
			Settings.Default.Save();
		}

		private void diametricalXAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["DiametricalXAllowance"] = diametricalXAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void diametricalZAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["DiametricalZAllowance"] = diametricalZAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void diametricalFeedRateInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["DiametricalFeedRate"] = diametricalFeedRateInput.Value;
			Settings.Default.Save();
		}

		private void diametricalSpeedLimitInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["DiametricalSpeedLimit"] = diametricalSpeedLimitInput.Value;
			Settings.Default.Save();
		}

		private void diametricalSurfaceSpeedInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["DiametricalSurfaceSpeed"] = diametricalSurfaceSpeedInput.Value;
			Settings.Default.Save();
		}

		private void diametricalToolNumberInput_TextChanged(object sender, EventArgs e)
		{
			Settings.Default["DiametricalToolNumber"] = diametricalToolNumberInput.Text;
			Settings.Default.Save();
		}
		#endregion

		#region Facing Cycle Values Save
		private void facingDepthOfCutInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["FacingDepthOfCut"] = facingDepthOfCutInput.Value;
			Settings.Default.Save();
		}

		private void facingRetractInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["FacingRetract"] = facingRetractInput.Value;
			Settings.Default.Save();
		}

		private void facingXAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["FacingXAllowance"] = facingXAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void facingZAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["FacingZAllowance"] = facingZAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void facingFeedRateInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["FacingFeedRate"] = facingFeedRateInput.Value;
			Settings.Default.Save();
		}

		private void facingSpeedLimitInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["FacingSpeedLimit"] = facingSpeedLimitInput.Value;
			Settings.Default.Save();
		}

		private void facingSurfaceSpeedInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["FacingSurfaceSpeed"] = facingSurfaceSpeedInput.Value;
			Settings.Default.Save();
		}

		private void facingToolNumberInput_TextChanged(object sender, EventArgs e)
		{
			Settings.Default["FacingToolNumber"] = facingToolNumberInput.Text;
			Settings.Default.Save();
		}
		#endregion

		#region Collarino Cycle Values Save
		private void collarinoDepthOfCutInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CollarinoDepthOfCut"] = collarinoDepthOfCutInput.Value;
			Settings.Default.Save();
		}

		private void collarinoRetractInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CollarinoRetract"] = collarinoRetractInput.Value;
			Settings.Default.Save();
		}

		private void collarinoXAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CollarinoXAllowance"] = collarinoXAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void collarinoZAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CollarinoZAllowance"] = collarinoZAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void collarinoFeedRateInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CollarinoFeedRate"] = facingFeedRateInput.Value;
			Settings.Default.Save();
		}

		private void collarinoSpeedLimitInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CollarinoSpeedLimit"] = collarinoSpeedLimitInput.Value;
			Settings.Default.Save();
		}

		private void collarinoSurfaceSpeedInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CollarinoSurfaceSpeed"] = collarinoSurfaceSpeedInput.Value;
			Settings.Default.Save();
		}

		private void collarinoToolNumberInput_TextChanged(object sender, EventArgs e)
		{
			Settings.Default["CollarinoToolNumber"] = collarinoToolNumberInput.Text;
			Settings.Default.Save();
		}
		#endregion

		#region Cava Cycle Values Save
		private void cavaDepthOfCutInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CavaDepthOfCut"] = cavaDepthOfCutInput.Value;
			Settings.Default.Save();
		}

		private void cavaRetractInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CavaRetract"] = cavaRetractInput.Value;
			Settings.Default.Save();
		}

		private void cavaXAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CavaXAllowance"] = cavaXAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void cavaZAllowanceInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CavaZAllowance"] = collarinoZAllowanceInput.Value;
			Settings.Default.Save();
		}

		private void cavaFeedRateInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CavaFeedRate"] = facingFeedRateInput.Value;
			Settings.Default.Save();
		}

		private void cavaSpeedLimitInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CavaSpeedLimit"] = cavaSpeedLimitInput.Value;
			Settings.Default.Save();
		}

		private void cavaSurfaceSpeedInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["CavaSurfaceSpeed"] = cavaSurfaceSpeedInput.Value;
			Settings.Default.Save();
		}

		private void cavaToolNumberInput_TextChanged(object sender, EventArgs e)
		{
			Settings.Default["CavaToolNumber"] = cavaToolNumberInput.Text;
			Settings.Default.Save();
		}
		#endregion

		#region Workplane Origin Parameter Save
		private void workplaneOriginParameterInput_TextChanged(object sender, EventArgs e)
		{
			Settings.Default["WorkplaneOriginParameter"] = workplaneOriginParameterInput.Text;
			Settings.Default.Save();
		}
		#endregion

		#region Chock Size Value Save
		private void chockSizeInput_ValueChanged(object sender, EventArgs e)
		{
			Settings.Default["ChockSize"] = chockSizeInput.Value;
			Settings.Default.Save();
			visualizationPanel.Refresh();
		}















		#endregion

		
	}
}
