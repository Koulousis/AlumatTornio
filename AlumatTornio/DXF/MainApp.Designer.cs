
namespace DXF
{
	public partial class MainApp
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainApp));
			this.coordinatesLabel = new System.Windows.Forms.Label();
			this.mainAppMenu = new System.Windows.Forms.MenuStrip();
			this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileDxfMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeDXFFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeExportFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openDXFFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openExportFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.g71RoughingCycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.g72FacingCycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewSideSelectorGroup = new System.Windows.Forms.GroupBox();
			this.viewSideSelectorLabel = new System.Windows.Forms.Label();
			this.drawSecondSideButton = new System.Windows.Forms.RadioButton();
			this.drawFirstSideButton = new System.Windows.Forms.RadioButton();
			this.copyrightsBanner = new System.Windows.Forms.Panel();
			this.copyrights = new System.Windows.Forms.TextBox();
			this.banner = new System.Windows.Forms.PictureBox();
			this.generateCode = new System.Windows.Forms.Button();
			this.exportProgressBar = new System.Windows.Forms.ProgressBar();
			this.diametricalCycleGroup = new System.Windows.Forms.GroupBox();
			this.diametricalFeedRateInput = new System.Windows.Forms.NumericUpDown();
			this.diametricalZAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.diametricalXAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.diametricalRetractInput = new System.Windows.Forms.NumericUpDown();
			this.diametricalDepthOfCutInput = new System.Windows.Forms.NumericUpDown();
			this.diametricalFeedRateLabel = new System.Windows.Forms.Label();
			this.diametricalAllowanceZLabel = new System.Windows.Forms.Label();
			this.diametricalAllowanceXLabel = new System.Windows.Forms.Label();
			this.diametricalRetractLabel = new System.Windows.Forms.Label();
			this.diametricalDepthOfCutLabel = new System.Windows.Forms.Label();
			this.facingCycleGroup = new System.Windows.Forms.GroupBox();
			this.facingFeedRateInput = new System.Windows.Forms.NumericUpDown();
			this.facingZAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.facingXAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.facingRetractInput = new System.Windows.Forms.NumericUpDown();
			this.facingDepthOfCutInput = new System.Windows.Forms.NumericUpDown();
			this.facingFeedRateLabel = new System.Windows.Forms.Label();
			this.facingAllowanceZLabel = new System.Windows.Forms.Label();
			this.facingAllowanceXLabel = new System.Windows.Forms.Label();
			this.facingRetractLabel = new System.Windows.Forms.Label();
			this.facingDepthOfCutLabel = new System.Windows.Forms.Label();
			this.gCodeTextBox = new System.Windows.Forms.RichTextBox();
			this.fileName = new System.Windows.Forms.Label();
			this.fileNameLabel = new System.Windows.Forms.Label();
			this.stockValuesSelectorGroup = new System.Windows.Forms.GroupBox();
			this.stockWidthInput = new System.Windows.Forms.NumericUpDown();
			this.stockWidthLabel = new System.Windows.Forms.Label();
			this.stockDiameterInput = new System.Windows.Forms.NumericUpDown();
			this.stockDiameterLabel = new System.Windows.Forms.Label();
			this.tabPanel = new System.Windows.Forms.TabControl();
			this.tabSetup = new System.Windows.Forms.TabPage();
			this.chockSizeGroup = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chockSizeInput = new System.Windows.Forms.NumericUpDown();
			this.validateDimensionsGroup = new System.Windows.Forms.GroupBox();
			this.validateDimensionsLabel = new System.Windows.Forms.Label();
			this.validateDimensionsButton = new System.Windows.Forms.Button();
			this.dieDiameterLabel = new System.Windows.Forms.Label();
			this.dieWidthLabel = new System.Windows.Forms.Label();
			this.cavaSelectorGroup = new System.Windows.Forms.GroupBox();
			this.setCavaSelectorGroupSecondSideLabel = new System.Windows.Forms.Label();
			this.setCavaSelectorFirstSideLabel = new System.Windows.Forms.Label();
			this.manualCavaSelectorGroup = new System.Windows.Forms.GroupBox();
			this.cavaSecondSideManual = new System.Windows.Forms.CheckBox();
			this.cavaFirstSideManual = new System.Windows.Forms.CheckBox();
			this.decreaseSecondSideButton = new System.Windows.Forms.Button();
			this.increaseSecondSideButton = new System.Windows.Forms.Button();
			this.decreaseFirstSideButton = new System.Windows.Forms.Button();
			this.increaseFirstSideButton = new System.Windows.Forms.Button();
			this.autoCavaSelectorGroup = new System.Windows.Forms.GroupBox();
			this.cavaSecondSideAuto = new System.Windows.Forms.RadioButton();
			this.cavaFirstSideAuto = new System.Windows.Forms.RadioButton();
			this.manualCavaButton = new System.Windows.Forms.RadioButton();
			this.autoCavaButton = new System.Windows.Forms.RadioButton();
			this.visualizationPanel = new System.Windows.Forms.PictureBox();
			this.firstSideSelectorGroup = new System.Windows.Forms.GroupBox();
			this.setSidesButton = new System.Windows.Forms.Button();
			this.firstSideSelectorLabel = new System.Windows.Forms.Label();
			this.flippedButton = new System.Windows.Forms.RadioButton();
			this.asDesignedButton = new System.Windows.Forms.RadioButton();
			this.tabSettings = new System.Windows.Forms.TabPage();
			this.cavaCycleGroup = new System.Windows.Forms.GroupBox();
			this.cavaFeedRateInput = new System.Windows.Forms.NumericUpDown();
			this.cavaZAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.cavaXAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.cavaRetractInput = new System.Windows.Forms.NumericUpDown();
			this.cavaDepthOfCutInput = new System.Windows.Forms.NumericUpDown();
			this.cavaFeedRateLabel = new System.Windows.Forms.Label();
			this.cavaAllowanceZLabel = new System.Windows.Forms.Label();
			this.cavaAllowanceXLabel = new System.Windows.Forms.Label();
			this.cavaRetractLabel = new System.Windows.Forms.Label();
			this.cavaDepthOfCutLabel = new System.Windows.Forms.Label();
			this.collarinoCycleGroup = new System.Windows.Forms.GroupBox();
			this.collarinoFeedRateInput = new System.Windows.Forms.NumericUpDown();
			this.collarinoZAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.collarinoXAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.collarinoRetractInput = new System.Windows.Forms.NumericUpDown();
			this.collarinoDepthOfCutInput = new System.Windows.Forms.NumericUpDown();
			this.collarinoFeedRateLabel = new System.Windows.Forms.Label();
			this.collarinoAllowanceZLabel = new System.Windows.Forms.Label();
			this.collarinoAllowanceXLabel = new System.Windows.Forms.Label();
			this.collarinoRetractLabel = new System.Windows.Forms.Label();
			this.collarinoDepthOfCutLabel = new System.Windows.Forms.Label();
			this.workplaneOriginGroup = new System.Windows.Forms.GroupBox();
			this.workplaneOriginParameterInput = new System.Windows.Forms.TextBox();
			this.workplaneOriginLabel = new System.Windows.Forms.Label();
			this.diametricalSpeedLimitLabel = new System.Windows.Forms.Label();
			this.diametricalSurfaceSpeedLabel = new System.Windows.Forms.Label();
			this.diametricalSpeedLimitInput = new System.Windows.Forms.NumericUpDown();
			this.diametricalSurfaceSpeedInput = new System.Windows.Forms.NumericUpDown();
			this.facingSurfaceSpeedInput = new System.Windows.Forms.NumericUpDown();
			this.facingSpeedLimitInput = new System.Windows.Forms.NumericUpDown();
			this.facingSurfaceSpeedLabel = new System.Windows.Forms.Label();
			this.facingSpeedLimitLabel = new System.Windows.Forms.Label();
			this.collarinoSurfaceSpeedInput = new System.Windows.Forms.NumericUpDown();
			this.collarinoSpeedLimitInput = new System.Windows.Forms.NumericUpDown();
			this.collarinoSurfaceSpeedLabel = new System.Windows.Forms.Label();
			this.collarinoSpeedLimitLabel = new System.Windows.Forms.Label();
			this.cavaSurfaceSpeedInput = new System.Windows.Forms.NumericUpDown();
			this.cavaSpeedLimitInput = new System.Windows.Forms.NumericUpDown();
			this.cavaSurfaceSpeedLabel = new System.Windows.Forms.Label();
			this.cavaSpeedLimitLabel = new System.Windows.Forms.Label();
			this.diametricalToolNumberLabel = new System.Windows.Forms.Label();
			this.diametricalToolNumberInput = new System.Windows.Forms.TextBox();
			this.facingToolNumberInput = new System.Windows.Forms.TextBox();
			this.facingToolNumberLabel = new System.Windows.Forms.Label();
			this.collarinoToolNumberInput = new System.Windows.Forms.TextBox();
			this.collarinoToolNumberLabel = new System.Windows.Forms.Label();
			this.cavaToolNumberInput = new System.Windows.Forms.TextBox();
			this.cavaToolNumberLabel = new System.Windows.Forms.Label();
			this.mainAppMenu.SuspendLayout();
			this.viewSideSelectorGroup.SuspendLayout();
			this.copyrightsBanner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.banner)).BeginInit();
			this.diametricalCycleGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.diametricalFeedRateInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.diametricalZAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.diametricalXAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.diametricalRetractInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.diametricalDepthOfCutInput)).BeginInit();
			this.facingCycleGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.facingFeedRateInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.facingZAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.facingXAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.facingRetractInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.facingDepthOfCutInput)).BeginInit();
			this.stockValuesSelectorGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.stockWidthInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stockDiameterInput)).BeginInit();
			this.tabPanel.SuspendLayout();
			this.tabSetup.SuspendLayout();
			this.chockSizeGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chockSizeInput)).BeginInit();
			this.validateDimensionsGroup.SuspendLayout();
			this.cavaSelectorGroup.SuspendLayout();
			this.manualCavaSelectorGroup.SuspendLayout();
			this.autoCavaSelectorGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.visualizationPanel)).BeginInit();
			this.firstSideSelectorGroup.SuspendLayout();
			this.tabSettings.SuspendLayout();
			this.cavaCycleGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cavaFeedRateInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaZAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaXAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaRetractInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaDepthOfCutInput)).BeginInit();
			this.collarinoCycleGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.collarinoFeedRateInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoZAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoXAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoRetractInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoDepthOfCutInput)).BeginInit();
			this.workplaneOriginGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.diametricalSpeedLimitInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.diametricalSurfaceSpeedInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.facingSurfaceSpeedInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.facingSpeedLimitInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoSurfaceSpeedInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoSpeedLimitInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaSurfaceSpeedInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaSpeedLimitInput)).BeginInit();
			this.SuspendLayout();
			// 
			// coordinatesLabel
			// 
			this.coordinatesLabel.AutoSize = true;
			this.coordinatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.coordinatesLabel.Location = new System.Drawing.Point(312, 415);
			this.coordinatesLabel.Name = "coordinatesLabel";
			this.coordinatesLabel.Size = new System.Drawing.Size(152, 20);
			this.coordinatesLabel.TabIndex = 1;
			this.coordinatesLabel.Text = "Coordinates Reader";
			// 
			// mainAppMenu
			// 
			this.mainAppMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.mainAppMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.mainAppMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.mainAppMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
			this.mainAppMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.mainAppMenu.Location = new System.Drawing.Point(0, 0);
			this.mainAppMenu.Name = "mainAppMenu";
			this.mainAppMenu.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
			this.mainAppMenu.Size = new System.Drawing.Size(789, 21);
			this.mainAppMenu.TabIndex = 2;
			this.mainAppMenu.Text = "menuStrip1";
			// 
			// fileMenuItem
			// 
			this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileDxfMenuItem});
			this.fileMenuItem.Name = "fileMenuItem";
			this.fileMenuItem.Size = new System.Drawing.Size(37, 19);
			this.fileMenuItem.Text = "File";
			// 
			// fileDxfMenuItem
			// 
			this.fileDxfMenuItem.Name = "fileDxfMenuItem";
			this.fileDxfMenuItem.Size = new System.Drawing.Size(95, 22);
			this.fileDxfMenuItem.Text = "DXF";
			this.fileDxfMenuItem.Click += new System.EventHandler(this.fileDxfMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeDXFFolderToolStripMenuItem,
            this.changeExportFolderToolStripMenuItem,
            this.openDXFFolderToolStripMenuItem,
            this.openExportFolderToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 19);
			this.settingsToolStripMenuItem.Text = "Options";
			// 
			// changeDXFFolderToolStripMenuItem
			// 
			this.changeDXFFolderToolStripMenuItem.Name = "changeDXFFolderToolStripMenuItem";
			this.changeDXFFolderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.changeDXFFolderToolStripMenuItem.Text = "Choose DXF Folder";
			this.changeDXFFolderToolStripMenuItem.Click += new System.EventHandler(this.changeDXFFolderToolStripMenuItem_Click);
			// 
			// changeExportFolderToolStripMenuItem
			// 
			this.changeExportFolderToolStripMenuItem.Name = "changeExportFolderToolStripMenuItem";
			this.changeExportFolderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.changeExportFolderToolStripMenuItem.Text = "Choose Export Folder";
			this.changeExportFolderToolStripMenuItem.Click += new System.EventHandler(this.changeExportFolderToolStripMenuItem_Click);
			// 
			// openDXFFolderToolStripMenuItem
			// 
			this.openDXFFolderToolStripMenuItem.Name = "openDXFFolderToolStripMenuItem";
			this.openDXFFolderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.openDXFFolderToolStripMenuItem.Text = "Open DXF Folder";
			this.openDXFFolderToolStripMenuItem.Click += new System.EventHandler(this.openDXFFolderToolStripMenuItem_Click);
			// 
			// openExportFolderToolStripMenuItem
			// 
			this.openExportFolderToolStripMenuItem.Name = "openExportFolderToolStripMenuItem";
			this.openExportFolderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
			this.openExportFolderToolStripMenuItem.Text = "Open Export Folder";
			this.openExportFolderToolStripMenuItem.Click += new System.EventHandler(this.openExportFolderToolStripMenuItem_Click);
			// 
			// infoToolStripMenuItem
			// 
			this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.g71RoughingCycleToolStripMenuItem,
            this.g72FacingCycleToolStripMenuItem});
			this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 19);
			this.infoToolStripMenuItem.Text = "Info";
			// 
			// g71RoughingCycleToolStripMenuItem
			// 
			this.g71RoughingCycleToolStripMenuItem.Name = "g71RoughingCycleToolStripMenuItem";
			this.g71RoughingCycleToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.g71RoughingCycleToolStripMenuItem.Text = "G71 Roughing Cycle";
			this.g71RoughingCycleToolStripMenuItem.Click += new System.EventHandler(this.g71RoughingCycleToolStripMenuItem_Click);
			// 
			// g72FacingCycleToolStripMenuItem
			// 
			this.g72FacingCycleToolStripMenuItem.Name = "g72FacingCycleToolStripMenuItem";
			this.g72FacingCycleToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
			this.g72FacingCycleToolStripMenuItem.Text = "G72 Facing Cycle";
			this.g72FacingCycleToolStripMenuItem.Click += new System.EventHandler(this.g72FacingCycleToolStripMenuItem_Click);
			// 
			// viewSideSelectorGroup
			// 
			this.viewSideSelectorGroup.Controls.Add(this.viewSideSelectorLabel);
			this.viewSideSelectorGroup.Controls.Add(this.drawSecondSideButton);
			this.viewSideSelectorGroup.Controls.Add(this.drawFirstSideButton);
			this.viewSideSelectorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.viewSideSelectorGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.viewSideSelectorGroup.Location = new System.Drawing.Point(520, 384);
			this.viewSideSelectorGroup.Margin = new System.Windows.Forms.Padding(2);
			this.viewSideSelectorGroup.Name = "viewSideSelectorGroup";
			this.viewSideSelectorGroup.Padding = new System.Windows.Forms.Padding(2);
			this.viewSideSelectorGroup.Size = new System.Drawing.Size(255, 72);
			this.viewSideSelectorGroup.TabIndex = 3;
			this.viewSideSelectorGroup.TabStop = false;
			this.viewSideSelectorGroup.Text = "Draw and Print";
			// 
			// viewSideSelectorLabel
			// 
			this.viewSideSelectorLabel.AutoSize = true;
			this.viewSideSelectorLabel.ForeColor = System.Drawing.Color.Black;
			this.viewSideSelectorLabel.Location = new System.Drawing.Point(6, 21);
			this.viewSideSelectorLabel.Name = "viewSideSelectorLabel";
			this.viewSideSelectorLabel.Size = new System.Drawing.Size(177, 16);
			this.viewSideSelectorLabel.TabIndex = 21;
			this.viewSideSelectorLabel.Text = "Select the side to draw/print :";
			// 
			// drawSecondSideButton
			// 
			this.drawSecondSideButton.AutoSize = true;
			this.drawSecondSideButton.ForeColor = System.Drawing.Color.Black;
			this.drawSecondSideButton.Location = new System.Drawing.Point(116, 45);
			this.drawSecondSideButton.Name = "drawSecondSideButton";
			this.drawSecondSideButton.Size = new System.Drawing.Size(102, 20);
			this.drawSecondSideButton.TabIndex = 1;
			this.drawSecondSideButton.Text = "Second side";
			this.drawSecondSideButton.UseVisualStyleBackColor = true;
			// 
			// drawFirstSideButton
			// 
			this.drawFirstSideButton.AutoSize = true;
			this.drawFirstSideButton.ForeColor = System.Drawing.Color.Black;
			this.drawFirstSideButton.Location = new System.Drawing.Point(12, 45);
			this.drawFirstSideButton.Name = "drawFirstSideButton";
			this.drawFirstSideButton.Size = new System.Drawing.Size(80, 20);
			this.drawFirstSideButton.TabIndex = 0;
			this.drawFirstSideButton.Text = "First side";
			this.drawFirstSideButton.UseVisualStyleBackColor = true;
			this.drawFirstSideButton.CheckedChanged += new System.EventHandler(this.drawFirstSideButton_CheckedChanged);
			// 
			// copyrightsBanner
			// 
			this.copyrightsBanner.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.copyrightsBanner.Controls.Add(this.copyrights);
			this.copyrightsBanner.Controls.Add(this.banner);
			this.copyrightsBanner.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.copyrightsBanner.Location = new System.Drawing.Point(0, 560);
			this.copyrightsBanner.Name = "copyrightsBanner";
			this.copyrightsBanner.Size = new System.Drawing.Size(789, 95);
			this.copyrightsBanner.TabIndex = 4;
			// 
			// copyrights
			// 
			this.copyrights.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.copyrights.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.copyrights.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.copyrights.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.copyrights.Location = new System.Drawing.Point(313, 79);
			this.copyrights.Name = "copyrights";
			this.copyrights.Size = new System.Drawing.Size(226, 13);
			this.copyrights.TabIndex = 1;
			this.copyrights.Text = "© Alumat Srl 2022 - 2023. All Rights Reserved";
			// 
			// banner
			// 
			this.banner.BackColor = System.Drawing.SystemColors.Window;
			this.banner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.banner.Dock = System.Windows.Forms.DockStyle.Top;
			this.banner.Image = ((System.Drawing.Image)(resources.GetObject("banner.Image")));
			this.banner.Location = new System.Drawing.Point(0, 0);
			this.banner.Name = "banner";
			this.banner.Size = new System.Drawing.Size(789, 74);
			this.banner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.banner.TabIndex = 0;
			this.banner.TabStop = false;
			// 
			// generateCode
			// 
			this.generateCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.generateCode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.generateCode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.generateCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.generateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.generateCode.Location = new System.Drawing.Point(312, 474);
			this.generateCode.Name = "generateCode";
			this.generateCode.Size = new System.Drawing.Size(199, 29);
			this.generateCode.TabIndex = 5;
			this.generateCode.Text = "Generate G Code";
			this.generateCode.UseVisualStyleBackColor = false;
			this.generateCode.Click += new System.EventHandler(this.exportGCode_Click);
			// 
			// exportProgressBar
			// 
			this.exportProgressBar.Location = new System.Drawing.Point(520, 474);
			this.exportProgressBar.Name = "exportProgressBar";
			this.exportProgressBar.Size = new System.Drawing.Size(255, 29);
			this.exportProgressBar.TabIndex = 6;
			// 
			// diametricalCycleGroup
			// 
			this.diametricalCycleGroup.Controls.Add(this.diametricalToolNumberInput);
			this.diametricalCycleGroup.Controls.Add(this.diametricalToolNumberLabel);
			this.diametricalCycleGroup.Controls.Add(this.diametricalSurfaceSpeedInput);
			this.diametricalCycleGroup.Controls.Add(this.diametricalSpeedLimitInput);
			this.diametricalCycleGroup.Controls.Add(this.diametricalSurfaceSpeedLabel);
			this.diametricalCycleGroup.Controls.Add(this.diametricalSpeedLimitLabel);
			this.diametricalCycleGroup.Controls.Add(this.diametricalFeedRateInput);
			this.diametricalCycleGroup.Controls.Add(this.diametricalZAllowanceInput);
			this.diametricalCycleGroup.Controls.Add(this.diametricalXAllowanceInput);
			this.diametricalCycleGroup.Controls.Add(this.diametricalRetractInput);
			this.diametricalCycleGroup.Controls.Add(this.diametricalDepthOfCutInput);
			this.diametricalCycleGroup.Controls.Add(this.diametricalFeedRateLabel);
			this.diametricalCycleGroup.Controls.Add(this.diametricalAllowanceZLabel);
			this.diametricalCycleGroup.Controls.Add(this.diametricalAllowanceXLabel);
			this.diametricalCycleGroup.Controls.Add(this.diametricalRetractLabel);
			this.diametricalCycleGroup.Controls.Add(this.diametricalDepthOfCutLabel);
			this.diametricalCycleGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalCycleGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.diametricalCycleGroup.Location = new System.Drawing.Point(8, 6);
			this.diametricalCycleGroup.Name = "diametricalCycleGroup";
			this.diametricalCycleGroup.Size = new System.Drawing.Size(185, 323);
			this.diametricalCycleGroup.TabIndex = 7;
			this.diametricalCycleGroup.TabStop = false;
			this.diametricalCycleGroup.Text = "Diametrical Cycle";
			// 
			// diametricalFeedRateInput
			// 
			this.diametricalFeedRateInput.DecimalPlaces = 2;
			this.diametricalFeedRateInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalFeedRateInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.diametricalFeedRateInput.Location = new System.Drawing.Point(108, 140);
			this.diametricalFeedRateInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.diametricalFeedRateInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.diametricalFeedRateInput.Name = "diametricalFeedRateInput";
			this.diametricalFeedRateInput.Size = new System.Drawing.Size(71, 26);
			this.diametricalFeedRateInput.TabIndex = 9;
			this.diametricalFeedRateInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.diametricalFeedRateInput.ValueChanged += new System.EventHandler(this.diametricalFeedRateInput_ValueChanged);
			// 
			// diametricalZAllowanceInput
			// 
			this.diametricalZAllowanceInput.DecimalPlaces = 2;
			this.diametricalZAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalZAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.diametricalZAllowanceInput.Location = new System.Drawing.Point(108, 110);
			this.diametricalZAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.diametricalZAllowanceInput.Name = "diametricalZAllowanceInput";
			this.diametricalZAllowanceInput.Size = new System.Drawing.Size(71, 26);
			this.diametricalZAllowanceInput.TabIndex = 8;
			this.diametricalZAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.diametricalZAllowanceInput.ValueChanged += new System.EventHandler(this.diametricalZAllowanceInput_ValueChanged);
			// 
			// diametricalXAllowanceInput
			// 
			this.diametricalXAllowanceInput.DecimalPlaces = 2;
			this.diametricalXAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalXAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.diametricalXAllowanceInput.Location = new System.Drawing.Point(108, 80);
			this.diametricalXAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.diametricalXAllowanceInput.Name = "diametricalXAllowanceInput";
			this.diametricalXAllowanceInput.Size = new System.Drawing.Size(71, 26);
			this.diametricalXAllowanceInput.TabIndex = 7;
			this.diametricalXAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.diametricalXAllowanceInput.ValueChanged += new System.EventHandler(this.diametricalXAllowanceInput_ValueChanged);
			// 
			// diametricalRetractInput
			// 
			this.diametricalRetractInput.DecimalPlaces = 2;
			this.diametricalRetractInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalRetractInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.diametricalRetractInput.Location = new System.Drawing.Point(108, 50);
			this.diametricalRetractInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.diametricalRetractInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.diametricalRetractInput.Name = "diametricalRetractInput";
			this.diametricalRetractInput.Size = new System.Drawing.Size(71, 26);
			this.diametricalRetractInput.TabIndex = 6;
			this.diametricalRetractInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.diametricalRetractInput.ValueChanged += new System.EventHandler(this.diametricalRetractInput_ValueChanged);
			// 
			// diametricalDepthOfCutInput
			// 
			this.diametricalDepthOfCutInput.DecimalPlaces = 2;
			this.diametricalDepthOfCutInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalDepthOfCutInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.diametricalDepthOfCutInput.Location = new System.Drawing.Point(108, 20);
			this.diametricalDepthOfCutInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.diametricalDepthOfCutInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.diametricalDepthOfCutInput.Name = "diametricalDepthOfCutInput";
			this.diametricalDepthOfCutInput.Size = new System.Drawing.Size(71, 26);
			this.diametricalDepthOfCutInput.TabIndex = 5;
			this.diametricalDepthOfCutInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.diametricalDepthOfCutInput.ValueChanged += new System.EventHandler(this.diametricalDepthOfCutInput_ValueChanged);
			// 
			// diametricalFeedRateLabel
			// 
			this.diametricalFeedRateLabel.AutoSize = true;
			this.diametricalFeedRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalFeedRateLabel.ForeColor = System.Drawing.Color.Black;
			this.diametricalFeedRateLabel.Location = new System.Drawing.Point(34, 145);
			this.diametricalFeedRateLabel.Name = "diametricalFeedRateLabel";
			this.diametricalFeedRateLabel.Size = new System.Drawing.Size(69, 16);
			this.diametricalFeedRateLabel.TabIndex = 4;
			this.diametricalFeedRateLabel.Text = "Feed rate:";
			// 
			// diametricalAllowanceZLabel
			// 
			this.diametricalAllowanceZLabel.AutoSize = true;
			this.diametricalAllowanceZLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalAllowanceZLabel.ForeColor = System.Drawing.Color.Black;
			this.diametricalAllowanceZLabel.Location = new System.Drawing.Point(19, 115);
			this.diametricalAllowanceZLabel.Name = "diametricalAllowanceZLabel";
			this.diametricalAllowanceZLabel.Size = new System.Drawing.Size(84, 16);
			this.diametricalAllowanceZLabel.TabIndex = 3;
			this.diametricalAllowanceZLabel.Text = "Z Allowance:";
			// 
			// diametricalAllowanceXLabel
			// 
			this.diametricalAllowanceXLabel.AutoSize = true;
			this.diametricalAllowanceXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalAllowanceXLabel.ForeColor = System.Drawing.Color.Black;
			this.diametricalAllowanceXLabel.Location = new System.Drawing.Point(19, 85);
			this.diametricalAllowanceXLabel.Name = "diametricalAllowanceXLabel";
			this.diametricalAllowanceXLabel.Size = new System.Drawing.Size(84, 16);
			this.diametricalAllowanceXLabel.TabIndex = 2;
			this.diametricalAllowanceXLabel.Text = "X Allowance:";
			// 
			// diametricalRetractLabel
			// 
			this.diametricalRetractLabel.AutoSize = true;
			this.diametricalRetractLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalRetractLabel.ForeColor = System.Drawing.Color.Black;
			this.diametricalRetractLabel.Location = new System.Drawing.Point(13, 55);
			this.diametricalRetractLabel.Name = "diametricalRetractLabel";
			this.diametricalRetractLabel.Size = new System.Drawing.Size(90, 16);
			this.diametricalRetractLabel.TabIndex = 1;
			this.diametricalRetractLabel.Text = "Retract value:";
			// 
			// diametricalDepthOfCutLabel
			// 
			this.diametricalDepthOfCutLabel.AutoSize = true;
			this.diametricalDepthOfCutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalDepthOfCutLabel.ForeColor = System.Drawing.Color.Black;
			this.diametricalDepthOfCutLabel.Location = new System.Drawing.Point(22, 25);
			this.diametricalDepthOfCutLabel.Name = "diametricalDepthOfCutLabel";
			this.diametricalDepthOfCutLabel.Size = new System.Drawing.Size(81, 16);
			this.diametricalDepthOfCutLabel.TabIndex = 0;
			this.diametricalDepthOfCutLabel.Text = "Depth of cut:";
			// 
			// facingCycleGroup
			// 
			this.facingCycleGroup.Controls.Add(this.facingToolNumberInput);
			this.facingCycleGroup.Controls.Add(this.facingSurfaceSpeedInput);
			this.facingCycleGroup.Controls.Add(this.facingToolNumberLabel);
			this.facingCycleGroup.Controls.Add(this.facingFeedRateInput);
			this.facingCycleGroup.Controls.Add(this.facingSpeedLimitInput);
			this.facingCycleGroup.Controls.Add(this.facingZAllowanceInput);
			this.facingCycleGroup.Controls.Add(this.facingSurfaceSpeedLabel);
			this.facingCycleGroup.Controls.Add(this.facingXAllowanceInput);
			this.facingCycleGroup.Controls.Add(this.facingSpeedLimitLabel);
			this.facingCycleGroup.Controls.Add(this.facingRetractInput);
			this.facingCycleGroup.Controls.Add(this.facingDepthOfCutInput);
			this.facingCycleGroup.Controls.Add(this.facingFeedRateLabel);
			this.facingCycleGroup.Controls.Add(this.facingAllowanceZLabel);
			this.facingCycleGroup.Controls.Add(this.facingAllowanceXLabel);
			this.facingCycleGroup.Controls.Add(this.facingRetractLabel);
			this.facingCycleGroup.Controls.Add(this.facingDepthOfCutLabel);
			this.facingCycleGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingCycleGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.facingCycleGroup.Location = new System.Drawing.Point(200, 6);
			this.facingCycleGroup.Name = "facingCycleGroup";
			this.facingCycleGroup.Size = new System.Drawing.Size(185, 323);
			this.facingCycleGroup.TabIndex = 10;
			this.facingCycleGroup.TabStop = false;
			this.facingCycleGroup.Text = "Facing Cycle";
			// 
			// facingFeedRateInput
			// 
			this.facingFeedRateInput.DecimalPlaces = 2;
			this.facingFeedRateInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingFeedRateInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.facingFeedRateInput.Location = new System.Drawing.Point(108, 140);
			this.facingFeedRateInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.facingFeedRateInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.facingFeedRateInput.Name = "facingFeedRateInput";
			this.facingFeedRateInput.Size = new System.Drawing.Size(71, 26);
			this.facingFeedRateInput.TabIndex = 9;
			this.facingFeedRateInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.facingFeedRateInput.ValueChanged += new System.EventHandler(this.facingFeedRateInput_ValueChanged);
			// 
			// facingZAllowanceInput
			// 
			this.facingZAllowanceInput.DecimalPlaces = 2;
			this.facingZAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingZAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.facingZAllowanceInput.Location = new System.Drawing.Point(108, 110);
			this.facingZAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.facingZAllowanceInput.Name = "facingZAllowanceInput";
			this.facingZAllowanceInput.Size = new System.Drawing.Size(71, 26);
			this.facingZAllowanceInput.TabIndex = 8;
			this.facingZAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.facingZAllowanceInput.ValueChanged += new System.EventHandler(this.facingZAllowanceInput_ValueChanged);
			// 
			// facingXAllowanceInput
			// 
			this.facingXAllowanceInput.DecimalPlaces = 2;
			this.facingXAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingXAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.facingXAllowanceInput.Location = new System.Drawing.Point(108, 80);
			this.facingXAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.facingXAllowanceInput.Name = "facingXAllowanceInput";
			this.facingXAllowanceInput.Size = new System.Drawing.Size(71, 26);
			this.facingXAllowanceInput.TabIndex = 7;
			this.facingXAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.facingXAllowanceInput.ValueChanged += new System.EventHandler(this.facingXAllowanceInput_ValueChanged);
			// 
			// facingRetractInput
			// 
			this.facingRetractInput.DecimalPlaces = 2;
			this.facingRetractInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingRetractInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.facingRetractInput.Location = new System.Drawing.Point(108, 50);
			this.facingRetractInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.facingRetractInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.facingRetractInput.Name = "facingRetractInput";
			this.facingRetractInput.Size = new System.Drawing.Size(71, 26);
			this.facingRetractInput.TabIndex = 6;
			this.facingRetractInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.facingRetractInput.ValueChanged += new System.EventHandler(this.facingRetractInput_ValueChanged);
			// 
			// facingDepthOfCutInput
			// 
			this.facingDepthOfCutInput.DecimalPlaces = 2;
			this.facingDepthOfCutInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingDepthOfCutInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.facingDepthOfCutInput.Location = new System.Drawing.Point(108, 20);
			this.facingDepthOfCutInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.facingDepthOfCutInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.facingDepthOfCutInput.Name = "facingDepthOfCutInput";
			this.facingDepthOfCutInput.Size = new System.Drawing.Size(71, 26);
			this.facingDepthOfCutInput.TabIndex = 5;
			this.facingDepthOfCutInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.facingDepthOfCutInput.ValueChanged += new System.EventHandler(this.facingDepthOfCutInput_ValueChanged);
			// 
			// facingFeedRateLabel
			// 
			this.facingFeedRateLabel.AutoSize = true;
			this.facingFeedRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingFeedRateLabel.ForeColor = System.Drawing.Color.Black;
			this.facingFeedRateLabel.Location = new System.Drawing.Point(33, 145);
			this.facingFeedRateLabel.Name = "facingFeedRateLabel";
			this.facingFeedRateLabel.Size = new System.Drawing.Size(69, 16);
			this.facingFeedRateLabel.TabIndex = 4;
			this.facingFeedRateLabel.Text = "Feed rate:";
			// 
			// facingAllowanceZLabel
			// 
			this.facingAllowanceZLabel.AutoSize = true;
			this.facingAllowanceZLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingAllowanceZLabel.ForeColor = System.Drawing.Color.Black;
			this.facingAllowanceZLabel.Location = new System.Drawing.Point(18, 115);
			this.facingAllowanceZLabel.Name = "facingAllowanceZLabel";
			this.facingAllowanceZLabel.Size = new System.Drawing.Size(84, 16);
			this.facingAllowanceZLabel.TabIndex = 3;
			this.facingAllowanceZLabel.Text = "Z Allowance:";
			// 
			// facingAllowanceXLabel
			// 
			this.facingAllowanceXLabel.AutoSize = true;
			this.facingAllowanceXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingAllowanceXLabel.ForeColor = System.Drawing.Color.Black;
			this.facingAllowanceXLabel.Location = new System.Drawing.Point(18, 85);
			this.facingAllowanceXLabel.Name = "facingAllowanceXLabel";
			this.facingAllowanceXLabel.Size = new System.Drawing.Size(84, 16);
			this.facingAllowanceXLabel.TabIndex = 2;
			this.facingAllowanceXLabel.Text = "X Allowance:";
			// 
			// facingRetractLabel
			// 
			this.facingRetractLabel.AutoSize = true;
			this.facingRetractLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingRetractLabel.ForeColor = System.Drawing.Color.Black;
			this.facingRetractLabel.Location = new System.Drawing.Point(12, 55);
			this.facingRetractLabel.Name = "facingRetractLabel";
			this.facingRetractLabel.Size = new System.Drawing.Size(90, 16);
			this.facingRetractLabel.TabIndex = 1;
			this.facingRetractLabel.Text = "Retract value:";
			// 
			// facingDepthOfCutLabel
			// 
			this.facingDepthOfCutLabel.AutoSize = true;
			this.facingDepthOfCutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingDepthOfCutLabel.ForeColor = System.Drawing.Color.Black;
			this.facingDepthOfCutLabel.Location = new System.Drawing.Point(21, 25);
			this.facingDepthOfCutLabel.Name = "facingDepthOfCutLabel";
			this.facingDepthOfCutLabel.Size = new System.Drawing.Size(81, 16);
			this.facingDepthOfCutLabel.TabIndex = 0;
			this.facingDepthOfCutLabel.Text = "Depth of cut:";
			// 
			// gCodeTextBox
			// 
			this.gCodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
			this.gCodeTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.gCodeTextBox.Location = new System.Drawing.Point(313, 3);
			this.gCodeTextBox.Name = "gCodeTextBox";
			this.gCodeTextBox.ReadOnly = true;
			this.gCodeTextBox.Size = new System.Drawing.Size(198, 409);
			this.gCodeTextBox.TabIndex = 11;
			this.gCodeTextBox.Text = "";
			// 
			// fileName
			// 
			this.fileName.AutoSize = true;
			this.fileName.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.fileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.fileName.Location = new System.Drawing.Point(346, 435);
			this.fileName.Name = "fileName";
			this.fileName.Size = new System.Drawing.Size(98, 20);
			this.fileName.TabIndex = 12;
			this.fileName.Text = "Not selected";
			// 
			// fileNameLabel
			// 
			this.fileNameLabel.AutoSize = true;
			this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fileNameLabel.Location = new System.Drawing.Point(312, 435);
			this.fileNameLabel.Name = "fileNameLabel";
			this.fileNameLabel.Size = new System.Drawing.Size(38, 20);
			this.fileNameLabel.TabIndex = 13;
			this.fileNameLabel.Text = "File:";
			// 
			// stockValuesSelectorGroup
			// 
			this.stockValuesSelectorGroup.Controls.Add(this.stockWidthInput);
			this.stockValuesSelectorGroup.Controls.Add(this.stockWidthLabel);
			this.stockValuesSelectorGroup.Controls.Add(this.stockDiameterInput);
			this.stockValuesSelectorGroup.Controls.Add(this.stockDiameterLabel);
			this.stockValuesSelectorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stockValuesSelectorGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.stockValuesSelectorGroup.Location = new System.Drawing.Point(520, 176);
			this.stockValuesSelectorGroup.Name = "stockValuesSelectorGroup";
			this.stockValuesSelectorGroup.Size = new System.Drawing.Size(141, 80);
			this.stockValuesSelectorGroup.TabIndex = 14;
			this.stockValuesSelectorGroup.TabStop = false;
			this.stockValuesSelectorGroup.Text = "Stock";
			// 
			// stockWidthInput
			// 
			this.stockWidthInput.DecimalPlaces = 1;
			this.stockWidthInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stockWidthInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.stockWidthInput.Location = new System.Drawing.Point(72, 46);
			this.stockWidthInput.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.stockWidthInput.Name = "stockWidthInput";
			this.stockWidthInput.Size = new System.Drawing.Size(60, 26);
			this.stockWidthInput.TabIndex = 15;
			this.stockWidthInput.ValueChanged += new System.EventHandler(this.stockWidthInput_ValueChanged);
			// 
			// stockWidthLabel
			// 
			this.stockWidthLabel.AutoSize = true;
			this.stockWidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stockWidthLabel.ForeColor = System.Drawing.Color.Black;
			this.stockWidthLabel.Location = new System.Drawing.Point(22, 51);
			this.stockWidthLabel.Name = "stockWidthLabel";
			this.stockWidthLabel.Size = new System.Drawing.Size(45, 16);
			this.stockWidthLabel.TabIndex = 14;
			this.stockWidthLabel.Text = "Width:";
			// 
			// stockDiameterInput
			// 
			this.stockDiameterInput.DecimalPlaces = 1;
			this.stockDiameterInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stockDiameterInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
			this.stockDiameterInput.Location = new System.Drawing.Point(72, 18);
			this.stockDiameterInput.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.stockDiameterInput.Name = "stockDiameterInput";
			this.stockDiameterInput.Size = new System.Drawing.Size(60, 26);
			this.stockDiameterInput.TabIndex = 10;
			this.stockDiameterInput.ValueChanged += new System.EventHandler(this.stockDiameterInput_ValueChanged);
			// 
			// stockDiameterLabel
			// 
			this.stockDiameterLabel.AutoSize = true;
			this.stockDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stockDiameterLabel.ForeColor = System.Drawing.Color.Black;
			this.stockDiameterLabel.Location = new System.Drawing.Point(1, 23);
			this.stockDiameterLabel.Name = "stockDiameterLabel";
			this.stockDiameterLabel.Size = new System.Drawing.Size(66, 16);
			this.stockDiameterLabel.TabIndex = 1;
			this.stockDiameterLabel.Text = "Diameter:";
			// 
			// tabPanel
			// 
			this.tabPanel.Controls.Add(this.tabSetup);
			this.tabPanel.Controls.Add(this.tabSettings);
			this.tabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabPanel.Location = new System.Drawing.Point(0, 21);
			this.tabPanel.Name = "tabPanel";
			this.tabPanel.SelectedIndex = 0;
			this.tabPanel.Size = new System.Drawing.Size(789, 539);
			this.tabPanel.TabIndex = 16;
			// 
			// tabSetup
			// 
			this.tabSetup.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.tabSetup.Controls.Add(this.chockSizeGroup);
			this.tabSetup.Controls.Add(this.validateDimensionsGroup);
			this.tabSetup.Controls.Add(this.cavaSelectorGroup);
			this.tabSetup.Controls.Add(this.visualizationPanel);
			this.tabSetup.Controls.Add(this.firstSideSelectorGroup);
			this.tabSetup.Controls.Add(this.viewSideSelectorGroup);
			this.tabSetup.Controls.Add(this.gCodeTextBox);
			this.tabSetup.Controls.Add(this.stockValuesSelectorGroup);
			this.tabSetup.Controls.Add(this.generateCode);
			this.tabSetup.Controls.Add(this.fileNameLabel);
			this.tabSetup.Controls.Add(this.exportProgressBar);
			this.tabSetup.Controls.Add(this.fileName);
			this.tabSetup.Controls.Add(this.coordinatesLabel);
			this.tabSetup.Location = new System.Drawing.Point(4, 22);
			this.tabSetup.Name = "tabSetup";
			this.tabSetup.Padding = new System.Windows.Forms.Padding(3);
			this.tabSetup.Size = new System.Drawing.Size(781, 513);
			this.tabSetup.TabIndex = 0;
			this.tabSetup.Text = "Machining Setup";
			// 
			// chockSizeGroup
			// 
			this.chockSizeGroup.Controls.Add(this.label1);
			this.chockSizeGroup.Controls.Add(this.chockSizeInput);
			this.chockSizeGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.chockSizeGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.chockSizeGroup.Location = new System.Drawing.Point(667, 176);
			this.chockSizeGroup.Name = "chockSizeGroup";
			this.chockSizeGroup.Size = new System.Drawing.Size(108, 80);
			this.chockSizeGroup.TabIndex = 24;
			this.chockSizeGroup.TabStop = false;
			this.chockSizeGroup.Text = "Chock size";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(2, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 16);
			this.label1.TabIndex = 23;
			this.label1.Text = "Length :";
			// 
			// chockSizeInput
			// 
			this.chockSizeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chockSizeInput.Location = new System.Drawing.Point(55, 30);
			this.chockSizeInput.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
			this.chockSizeInput.Name = "chockSizeInput";
			this.chockSizeInput.Size = new System.Drawing.Size(47, 26);
			this.chockSizeInput.TabIndex = 17;
			this.chockSizeInput.ValueChanged += new System.EventHandler(this.chockSizeInput_ValueChanged);
			// 
			// validateDimensionsGroup
			// 
			this.validateDimensionsGroup.Controls.Add(this.validateDimensionsLabel);
			this.validateDimensionsGroup.Controls.Add(this.validateDimensionsButton);
			this.validateDimensionsGroup.Controls.Add(this.dieDiameterLabel);
			this.validateDimensionsGroup.Controls.Add(this.dieWidthLabel);
			this.validateDimensionsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.validateDimensionsGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.validateDimensionsGroup.Location = new System.Drawing.Point(520, 6);
			this.validateDimensionsGroup.Name = "validateDimensionsGroup";
			this.validateDimensionsGroup.Size = new System.Drawing.Size(255, 80);
			this.validateDimensionsGroup.TabIndex = 21;
			this.validateDimensionsGroup.TabStop = false;
			this.validateDimensionsGroup.Text = "Validate cad dimensions";
			// 
			// validateDimensionsLabel
			// 
			this.validateDimensionsLabel.AutoSize = true;
			this.validateDimensionsLabel.ForeColor = System.Drawing.Color.Black;
			this.validateDimensionsLabel.Location = new System.Drawing.Point(9, 18);
			this.validateDimensionsLabel.Name = "validateDimensionsLabel";
			this.validateDimensionsLabel.Size = new System.Drawing.Size(225, 16);
			this.validateDimensionsLabel.TabIndex = 21;
			this.validateDimensionsLabel.Text = "Compare file dimensions with design";
			// 
			// validateDimensionsButton
			// 
			this.validateDimensionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.validateDimensionsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.validateDimensionsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.validateDimensionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.validateDimensionsButton.ForeColor = System.Drawing.Color.Black;
			this.validateDimensionsButton.Location = new System.Drawing.Point(199, 43);
			this.validateDimensionsButton.Name = "validateDimensionsButton";
			this.validateDimensionsButton.Size = new System.Drawing.Size(46, 26);
			this.validateDimensionsButton.TabIndex = 21;
			this.validateDimensionsButton.Text = "OK";
			this.validateDimensionsButton.UseVisualStyleBackColor = false;
			this.validateDimensionsButton.Click += new System.EventHandler(this.validateDimensionsButton_Click);
			// 
			// dieDiameterLabel
			// 
			this.dieDiameterLabel.AutoSize = true;
			this.dieDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dieDiameterLabel.ForeColor = System.Drawing.Color.Black;
			this.dieDiameterLabel.Location = new System.Drawing.Point(9, 38);
			this.dieDiameterLabel.Name = "dieDiameterLabel";
			this.dieDiameterLabel.Size = new System.Drawing.Size(79, 16);
			this.dieDiameterLabel.TabIndex = 18;
			this.dieDiameterLabel.Text = "Diameter :";
			// 
			// dieWidthLabel
			// 
			this.dieWidthLabel.AutoSize = true;
			this.dieWidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dieWidthLabel.ForeColor = System.Drawing.Color.Black;
			this.dieWidthLabel.Location = new System.Drawing.Point(33, 54);
			this.dieWidthLabel.Name = "dieWidthLabel";
			this.dieWidthLabel.Size = new System.Drawing.Size(55, 16);
			this.dieWidthLabel.TabIndex = 19;
			this.dieWidthLabel.Text = "Width :";
			// 
			// cavaSelectorGroup
			// 
			this.cavaSelectorGroup.Controls.Add(this.setCavaSelectorGroupSecondSideLabel);
			this.cavaSelectorGroup.Controls.Add(this.setCavaSelectorFirstSideLabel);
			this.cavaSelectorGroup.Controls.Add(this.manualCavaSelectorGroup);
			this.cavaSelectorGroup.Controls.Add(this.autoCavaSelectorGroup);
			this.cavaSelectorGroup.Controls.Add(this.manualCavaButton);
			this.cavaSelectorGroup.Controls.Add(this.autoCavaButton);
			this.cavaSelectorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaSelectorGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.cavaSelectorGroup.Location = new System.Drawing.Point(520, 261);
			this.cavaSelectorGroup.Margin = new System.Windows.Forms.Padding(2);
			this.cavaSelectorGroup.Name = "cavaSelectorGroup";
			this.cavaSelectorGroup.Padding = new System.Windows.Forms.Padding(2);
			this.cavaSelectorGroup.Size = new System.Drawing.Size(255, 119);
			this.cavaSelectorGroup.TabIndex = 20;
			this.cavaSelectorGroup.TabStop = false;
			this.cavaSelectorGroup.Text = "Set cava overlap";
			// 
			// setCavaSelectorGroupSecondSideLabel
			// 
			this.setCavaSelectorGroupSecondSideLabel.AutoSize = true;
			this.setCavaSelectorGroupSecondSideLabel.ForeColor = System.Drawing.Color.Black;
			this.setCavaSelectorGroupSecondSideLabel.Location = new System.Drawing.Point(1, 84);
			this.setCavaSelectorGroupSecondSideLabel.Name = "setCavaSelectorGroupSecondSideLabel";
			this.setCavaSelectorGroupSecondSideLabel.Size = new System.Drawing.Size(84, 16);
			this.setCavaSelectorGroupSecondSideLabel.TabIndex = 28;
			this.setCavaSelectorGroupSecondSideLabel.Text = "Second side";
			// 
			// setCavaSelectorFirstSideLabel
			// 
			this.setCavaSelectorFirstSideLabel.AutoSize = true;
			this.setCavaSelectorFirstSideLabel.ForeColor = System.Drawing.Color.Black;
			this.setCavaSelectorFirstSideLabel.Location = new System.Drawing.Point(23, 55);
			this.setCavaSelectorFirstSideLabel.Name = "setCavaSelectorFirstSideLabel";
			this.setCavaSelectorFirstSideLabel.Size = new System.Drawing.Size(62, 16);
			this.setCavaSelectorFirstSideLabel.TabIndex = 22;
			this.setCavaSelectorFirstSideLabel.Text = "First side";
			// 
			// manualCavaSelectorGroup
			// 
			this.manualCavaSelectorGroup.Controls.Add(this.cavaSecondSideManual);
			this.manualCavaSelectorGroup.Controls.Add(this.cavaFirstSideManual);
			this.manualCavaSelectorGroup.Controls.Add(this.decreaseSecondSideButton);
			this.manualCavaSelectorGroup.Controls.Add(this.increaseSecondSideButton);
			this.manualCavaSelectorGroup.Controls.Add(this.decreaseFirstSideButton);
			this.manualCavaSelectorGroup.Controls.Add(this.increaseFirstSideButton);
			this.manualCavaSelectorGroup.Cursor = System.Windows.Forms.Cursors.Hand;
			this.manualCavaSelectorGroup.Location = new System.Drawing.Point(162, 36);
			this.manualCavaSelectorGroup.Name = "manualCavaSelectorGroup";
			this.manualCavaSelectorGroup.Size = new System.Drawing.Size(87, 78);
			this.manualCavaSelectorGroup.TabIndex = 27;
			this.manualCavaSelectorGroup.TabStop = false;
			// 
			// cavaSecondSideManual
			// 
			this.cavaSecondSideManual.AutoSize = true;
			this.cavaSecondSideManual.Location = new System.Drawing.Point(70, 52);
			this.cavaSecondSideManual.Name = "cavaSecondSideManual";
			this.cavaSecondSideManual.Size = new System.Drawing.Size(15, 14);
			this.cavaSecondSideManual.TabIndex = 5;
			this.cavaSecondSideManual.UseVisualStyleBackColor = true;
			this.cavaSecondSideManual.CheckedChanged += new System.EventHandler(this.cavaSecondSideManual_CheckedChanged);
			// 
			// cavaFirstSideManual
			// 
			this.cavaFirstSideManual.AutoSize = true;
			this.cavaFirstSideManual.Location = new System.Drawing.Point(70, 22);
			this.cavaFirstSideManual.Name = "cavaFirstSideManual";
			this.cavaFirstSideManual.Size = new System.Drawing.Size(15, 14);
			this.cavaFirstSideManual.TabIndex = 4;
			this.cavaFirstSideManual.UseVisualStyleBackColor = true;
			this.cavaFirstSideManual.CheckedChanged += new System.EventHandler(this.cavaFirstSideManual_CheckedChanged);
			// 
			// decreaseSecondSideButton
			// 
			this.decreaseSecondSideButton.BackColor = System.Drawing.Color.Tomato;
			this.decreaseSecondSideButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
			this.decreaseSecondSideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
			this.decreaseSecondSideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.decreaseSecondSideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.decreaseSecondSideButton.ForeColor = System.Drawing.Color.Black;
			this.decreaseSecondSideButton.Location = new System.Drawing.Point(40, 45);
			this.decreaseSecondSideButton.Name = "decreaseSecondSideButton";
			this.decreaseSecondSideButton.Size = new System.Drawing.Size(26, 26);
			this.decreaseSecondSideButton.TabIndex = 3;
			this.decreaseSecondSideButton.Text = "-";
			this.decreaseSecondSideButton.UseVisualStyleBackColor = false;
			this.decreaseSecondSideButton.Click += new System.EventHandler(this.decreaseSecondSideButton_Click);
			// 
			// increaseSecondSideButton
			// 
			this.increaseSecondSideButton.BackColor = System.Drawing.Color.LightGreen;
			this.increaseSecondSideButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
			this.increaseSecondSideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
			this.increaseSecondSideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.increaseSecondSideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.increaseSecondSideButton.ForeColor = System.Drawing.Color.Black;
			this.increaseSecondSideButton.Location = new System.Drawing.Point(9, 45);
			this.increaseSecondSideButton.Name = "increaseSecondSideButton";
			this.increaseSecondSideButton.Size = new System.Drawing.Size(26, 26);
			this.increaseSecondSideButton.TabIndex = 2;
			this.increaseSecondSideButton.Text = "+";
			this.increaseSecondSideButton.UseVisualStyleBackColor = false;
			this.increaseSecondSideButton.Click += new System.EventHandler(this.increaseSecondSideButton_Click);
			// 
			// decreaseFirstSideButton
			// 
			this.decreaseFirstSideButton.BackColor = System.Drawing.Color.Tomato;
			this.decreaseFirstSideButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
			this.decreaseFirstSideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
			this.decreaseFirstSideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.decreaseFirstSideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.decreaseFirstSideButton.ForeColor = System.Drawing.Color.Black;
			this.decreaseFirstSideButton.Location = new System.Drawing.Point(40, 15);
			this.decreaseFirstSideButton.Name = "decreaseFirstSideButton";
			this.decreaseFirstSideButton.Size = new System.Drawing.Size(26, 26);
			this.decreaseFirstSideButton.TabIndex = 1;
			this.decreaseFirstSideButton.Text = "-";
			this.decreaseFirstSideButton.UseVisualStyleBackColor = false;
			this.decreaseFirstSideButton.Click += new System.EventHandler(this.decreaseFirstSideButton_Click);
			// 
			// increaseFirstSideButton
			// 
			this.increaseFirstSideButton.BackColor = System.Drawing.Color.LightGreen;
			this.increaseFirstSideButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
			this.increaseFirstSideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
			this.increaseFirstSideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.increaseFirstSideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.increaseFirstSideButton.ForeColor = System.Drawing.Color.Black;
			this.increaseFirstSideButton.Location = new System.Drawing.Point(9, 15);
			this.increaseFirstSideButton.Name = "increaseFirstSideButton";
			this.increaseFirstSideButton.Size = new System.Drawing.Size(26, 26);
			this.increaseFirstSideButton.TabIndex = 0;
			this.increaseFirstSideButton.Text = "+";
			this.increaseFirstSideButton.UseVisualStyleBackColor = false;
			this.increaseFirstSideButton.Click += new System.EventHandler(this.increaseFirstSideButton_Click);
			// 
			// autoCavaSelectorGroup
			// 
			this.autoCavaSelectorGroup.Controls.Add(this.cavaSecondSideAuto);
			this.autoCavaSelectorGroup.Controls.Add(this.cavaFirstSideAuto);
			this.autoCavaSelectorGroup.Location = new System.Drawing.Point(88, 36);
			this.autoCavaSelectorGroup.Name = "autoCavaSelectorGroup";
			this.autoCavaSelectorGroup.Size = new System.Drawing.Size(60, 78);
			this.autoCavaSelectorGroup.TabIndex = 26;
			this.autoCavaSelectorGroup.TabStop = false;
			// 
			// cavaSecondSideAuto
			// 
			this.cavaSecondSideAuto.Appearance = System.Windows.Forms.Appearance.Button;
			this.cavaSecondSideAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.cavaSecondSideAuto.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaSecondSideAuto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaSecondSideAuto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaSecondSideAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cavaSecondSideAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.cavaSecondSideAuto.ForeColor = System.Drawing.Color.Black;
			this.cavaSecondSideAuto.Location = new System.Drawing.Point(7, 45);
			this.cavaSecondSideAuto.Name = "cavaSecondSideAuto";
			this.cavaSecondSideAuto.Size = new System.Drawing.Size(46, 26);
			this.cavaSecondSideAuto.TabIndex = 1;
			this.cavaSecondSideAuto.TabStop = true;
			this.cavaSecondSideAuto.Text = "Set";
			this.cavaSecondSideAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cavaSecondSideAuto.UseVisualStyleBackColor = false;
			this.cavaSecondSideAuto.CheckedChanged += new System.EventHandler(this.cavaSecondSideButton_CheckedChanged);
			// 
			// cavaFirstSideAuto
			// 
			this.cavaFirstSideAuto.Appearance = System.Windows.Forms.Appearance.Button;
			this.cavaFirstSideAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.cavaFirstSideAuto.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaFirstSideAuto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaFirstSideAuto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaFirstSideAuto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cavaFirstSideAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.cavaFirstSideAuto.ForeColor = System.Drawing.Color.Black;
			this.cavaFirstSideAuto.Location = new System.Drawing.Point(7, 15);
			this.cavaFirstSideAuto.Name = "cavaFirstSideAuto";
			this.cavaFirstSideAuto.Size = new System.Drawing.Size(46, 26);
			this.cavaFirstSideAuto.TabIndex = 0;
			this.cavaFirstSideAuto.TabStop = true;
			this.cavaFirstSideAuto.Text = "Set";
			this.cavaFirstSideAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cavaFirstSideAuto.UseVisualStyleBackColor = false;
			this.cavaFirstSideAuto.CheckedChanged += new System.EventHandler(this.cavaFirstSideButton_CheckedChanged);
			// 
			// manualCavaButton
			// 
			this.manualCavaButton.AutoSize = true;
			this.manualCavaButton.ForeColor = System.Drawing.Color.Black;
			this.manualCavaButton.Location = new System.Drawing.Point(162, 17);
			this.manualCavaButton.Name = "manualCavaButton";
			this.manualCavaButton.Size = new System.Drawing.Size(70, 20);
			this.manualCavaButton.TabIndex = 25;
			this.manualCavaButton.Text = "Manual";
			this.manualCavaButton.UseVisualStyleBackColor = true;
			this.manualCavaButton.CheckedChanged += new System.EventHandler(this.manualCavaButton_CheckedChanged);
			// 
			// autoCavaButton
			// 
			this.autoCavaButton.AutoSize = true;
			this.autoCavaButton.Checked = true;
			this.autoCavaButton.ForeColor = System.Drawing.Color.Black;
			this.autoCavaButton.Location = new System.Drawing.Point(88, 17);
			this.autoCavaButton.Name = "autoCavaButton";
			this.autoCavaButton.Size = new System.Drawing.Size(53, 20);
			this.autoCavaButton.TabIndex = 24;
			this.autoCavaButton.TabStop = true;
			this.autoCavaButton.Text = "Auto";
			this.autoCavaButton.UseVisualStyleBackColor = true;
			this.autoCavaButton.CheckedChanged += new System.EventHandler(this.autoCavaButton_CheckedChanged);
			// 
			// visualizationPanel
			// 
			this.visualizationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
			this.visualizationPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.visualizationPanel.Cursor = System.Windows.Forms.Cursors.Cross;
			this.visualizationPanel.Location = new System.Drawing.Point(6, 3);
			this.visualizationPanel.Name = "visualizationPanel";
			this.visualizationPanel.Size = new System.Drawing.Size(300, 500);
			this.visualizationPanel.TabIndex = 0;
			this.visualizationPanel.TabStop = false;
			this.visualizationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.visualizationPanel_Paint);
			this.visualizationPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.visualizationPanel_MouseMove);
			// 
			// firstSideSelectorGroup
			// 
			this.firstSideSelectorGroup.Controls.Add(this.setSidesButton);
			this.firstSideSelectorGroup.Controls.Add(this.firstSideSelectorLabel);
			this.firstSideSelectorGroup.Controls.Add(this.flippedButton);
			this.firstSideSelectorGroup.Controls.Add(this.asDesignedButton);
			this.firstSideSelectorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.firstSideSelectorGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.firstSideSelectorGroup.Location = new System.Drawing.Point(520, 90);
			this.firstSideSelectorGroup.Name = "firstSideSelectorGroup";
			this.firstSideSelectorGroup.Size = new System.Drawing.Size(255, 80);
			this.firstSideSelectorGroup.TabIndex = 17;
			this.firstSideSelectorGroup.TabStop = false;
			this.firstSideSelectorGroup.Text = "Set first machining side";
			// 
			// setSidesButton
			// 
			this.setSidesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.setSidesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.setSidesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.setSidesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.setSidesButton.ForeColor = System.Drawing.Color.Black;
			this.setSidesButton.Location = new System.Drawing.Point(199, 45);
			this.setSidesButton.Name = "setSidesButton";
			this.setSidesButton.Size = new System.Drawing.Size(46, 26);
			this.setSidesButton.TabIndex = 20;
			this.setSidesButton.Text = "Set";
			this.setSidesButton.UseVisualStyleBackColor = false;
			this.setSidesButton.Click += new System.EventHandler(this.setSidesButton_Click);
			// 
			// firstSideSelectorLabel
			// 
			this.firstSideSelectorLabel.AutoSize = true;
			this.firstSideSelectorLabel.ForeColor = System.Drawing.Color.Black;
			this.firstSideSelectorLabel.Location = new System.Drawing.Point(9, 22);
			this.firstSideSelectorLabel.Name = "firstSideSelectorLabel";
			this.firstSideSelectorLabel.Size = new System.Drawing.Size(145, 16);
			this.firstSideSelectorLabel.TabIndex = 2;
			this.firstSideSelectorLabel.Text = "First machining side is :";
			// 
			// flippedButton
			// 
			this.flippedButton.AutoSize = true;
			this.flippedButton.ForeColor = System.Drawing.Color.Black;
			this.flippedButton.Location = new System.Drawing.Point(116, 48);
			this.flippedButton.Name = "flippedButton";
			this.flippedButton.Size = new System.Drawing.Size(72, 20);
			this.flippedButton.TabIndex = 1;
			this.flippedButton.Text = "Flipped";
			this.flippedButton.UseVisualStyleBackColor = true;
			this.flippedButton.CheckedChanged += new System.EventHandler(this.flippedButton_CheckedChanged);
			// 
			// asDesignedButton
			// 
			this.asDesignedButton.AutoSize = true;
			this.asDesignedButton.ForeColor = System.Drawing.Color.Black;
			this.asDesignedButton.Location = new System.Drawing.Point(12, 48);
			this.asDesignedButton.Name = "asDesignedButton";
			this.asDesignedButton.Size = new System.Drawing.Size(104, 20);
			this.asDesignedButton.TabIndex = 0;
			this.asDesignedButton.Text = "As Designed";
			this.asDesignedButton.UseVisualStyleBackColor = true;
			this.asDesignedButton.CheckedChanged += new System.EventHandler(this.asDesignedButton_CheckedChanged);
			// 
			// tabSettings
			// 
			this.tabSettings.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.tabSettings.Controls.Add(this.cavaCycleGroup);
			this.tabSettings.Controls.Add(this.collarinoCycleGroup);
			this.tabSettings.Controls.Add(this.workplaneOriginGroup);
			this.tabSettings.Controls.Add(this.diametricalCycleGroup);
			this.tabSettings.Controls.Add(this.facingCycleGroup);
			this.tabSettings.Location = new System.Drawing.Point(4, 22);
			this.tabSettings.Name = "tabSettings";
			this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
			this.tabSettings.Size = new System.Drawing.Size(781, 513);
			this.tabSettings.TabIndex = 1;
			this.tabSettings.Text = "Machining Settings";
			// 
			// cavaCycleGroup
			// 
			this.cavaCycleGroup.Controls.Add(this.cavaToolNumberInput);
			this.cavaCycleGroup.Controls.Add(this.cavaSurfaceSpeedInput);
			this.cavaCycleGroup.Controls.Add(this.cavaToolNumberLabel);
			this.cavaCycleGroup.Controls.Add(this.cavaFeedRateInput);
			this.cavaCycleGroup.Controls.Add(this.cavaSpeedLimitInput);
			this.cavaCycleGroup.Controls.Add(this.cavaZAllowanceInput);
			this.cavaCycleGroup.Controls.Add(this.cavaSurfaceSpeedLabel);
			this.cavaCycleGroup.Controls.Add(this.cavaSpeedLimitLabel);
			this.cavaCycleGroup.Controls.Add(this.cavaXAllowanceInput);
			this.cavaCycleGroup.Controls.Add(this.cavaRetractInput);
			this.cavaCycleGroup.Controls.Add(this.cavaDepthOfCutInput);
			this.cavaCycleGroup.Controls.Add(this.cavaFeedRateLabel);
			this.cavaCycleGroup.Controls.Add(this.cavaAllowanceZLabel);
			this.cavaCycleGroup.Controls.Add(this.cavaAllowanceXLabel);
			this.cavaCycleGroup.Controls.Add(this.cavaRetractLabel);
			this.cavaCycleGroup.Controls.Add(this.cavaDepthOfCutLabel);
			this.cavaCycleGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaCycleGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.cavaCycleGroup.Location = new System.Drawing.Point(584, 6);
			this.cavaCycleGroup.Name = "cavaCycleGroup";
			this.cavaCycleGroup.Size = new System.Drawing.Size(185, 323);
			this.cavaCycleGroup.TabIndex = 12;
			this.cavaCycleGroup.TabStop = false;
			this.cavaCycleGroup.Text = "Cava Cycle";
			// 
			// cavaFeedRateInput
			// 
			this.cavaFeedRateInput.DecimalPlaces = 2;
			this.cavaFeedRateInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaFeedRateInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.cavaFeedRateInput.Location = new System.Drawing.Point(109, 140);
			this.cavaFeedRateInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.cavaFeedRateInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.cavaFeedRateInput.Name = "cavaFeedRateInput";
			this.cavaFeedRateInput.Size = new System.Drawing.Size(71, 26);
			this.cavaFeedRateInput.TabIndex = 9;
			this.cavaFeedRateInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.cavaFeedRateInput.ValueChanged += new System.EventHandler(this.cavaFeedRateInput_ValueChanged);
			// 
			// cavaZAllowanceInput
			// 
			this.cavaZAllowanceInput.DecimalPlaces = 2;
			this.cavaZAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaZAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.cavaZAllowanceInput.Location = new System.Drawing.Point(109, 110);
			this.cavaZAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.cavaZAllowanceInput.Name = "cavaZAllowanceInput";
			this.cavaZAllowanceInput.Size = new System.Drawing.Size(71, 26);
			this.cavaZAllowanceInput.TabIndex = 8;
			this.cavaZAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.cavaZAllowanceInput.ValueChanged += new System.EventHandler(this.cavaZAllowanceInput_ValueChanged);
			// 
			// cavaXAllowanceInput
			// 
			this.cavaXAllowanceInput.DecimalPlaces = 2;
			this.cavaXAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaXAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.cavaXAllowanceInput.Location = new System.Drawing.Point(109, 80);
			this.cavaXAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.cavaXAllowanceInput.Name = "cavaXAllowanceInput";
			this.cavaXAllowanceInput.Size = new System.Drawing.Size(71, 26);
			this.cavaXAllowanceInput.TabIndex = 7;
			this.cavaXAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.cavaXAllowanceInput.ValueChanged += new System.EventHandler(this.cavaXAllowanceInput_ValueChanged);
			// 
			// cavaRetractInput
			// 
			this.cavaRetractInput.DecimalPlaces = 2;
			this.cavaRetractInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaRetractInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.cavaRetractInput.Location = new System.Drawing.Point(109, 50);
			this.cavaRetractInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.cavaRetractInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.cavaRetractInput.Name = "cavaRetractInput";
			this.cavaRetractInput.Size = new System.Drawing.Size(71, 26);
			this.cavaRetractInput.TabIndex = 6;
			this.cavaRetractInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.cavaRetractInput.ValueChanged += new System.EventHandler(this.cavaRetractInput_ValueChanged);
			// 
			// cavaDepthOfCutInput
			// 
			this.cavaDepthOfCutInput.DecimalPlaces = 2;
			this.cavaDepthOfCutInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaDepthOfCutInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.cavaDepthOfCutInput.Location = new System.Drawing.Point(109, 20);
			this.cavaDepthOfCutInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.cavaDepthOfCutInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.cavaDepthOfCutInput.Name = "cavaDepthOfCutInput";
			this.cavaDepthOfCutInput.Size = new System.Drawing.Size(71, 26);
			this.cavaDepthOfCutInput.TabIndex = 5;
			this.cavaDepthOfCutInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.cavaDepthOfCutInput.ValueChanged += new System.EventHandler(this.cavaDepthOfCutInput_ValueChanged);
			// 
			// cavaFeedRateLabel
			// 
			this.cavaFeedRateLabel.AutoSize = true;
			this.cavaFeedRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaFeedRateLabel.ForeColor = System.Drawing.Color.Black;
			this.cavaFeedRateLabel.Location = new System.Drawing.Point(25, 145);
			this.cavaFeedRateLabel.Name = "cavaFeedRateLabel";
			this.cavaFeedRateLabel.Size = new System.Drawing.Size(69, 16);
			this.cavaFeedRateLabel.TabIndex = 4;
			this.cavaFeedRateLabel.Text = "Feed rate:";
			// 
			// cavaAllowanceZLabel
			// 
			this.cavaAllowanceZLabel.AutoSize = true;
			this.cavaAllowanceZLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaAllowanceZLabel.ForeColor = System.Drawing.Color.Black;
			this.cavaAllowanceZLabel.Location = new System.Drawing.Point(10, 115);
			this.cavaAllowanceZLabel.Name = "cavaAllowanceZLabel";
			this.cavaAllowanceZLabel.Size = new System.Drawing.Size(84, 16);
			this.cavaAllowanceZLabel.TabIndex = 3;
			this.cavaAllowanceZLabel.Text = "Z Allowance:";
			// 
			// cavaAllowanceXLabel
			// 
			this.cavaAllowanceXLabel.AutoSize = true;
			this.cavaAllowanceXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaAllowanceXLabel.ForeColor = System.Drawing.Color.Black;
			this.cavaAllowanceXLabel.Location = new System.Drawing.Point(10, 85);
			this.cavaAllowanceXLabel.Name = "cavaAllowanceXLabel";
			this.cavaAllowanceXLabel.Size = new System.Drawing.Size(84, 16);
			this.cavaAllowanceXLabel.TabIndex = 2;
			this.cavaAllowanceXLabel.Text = "X Allowance:";
			// 
			// cavaRetractLabel
			// 
			this.cavaRetractLabel.AutoSize = true;
			this.cavaRetractLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaRetractLabel.ForeColor = System.Drawing.Color.Black;
			this.cavaRetractLabel.Location = new System.Drawing.Point(6, 55);
			this.cavaRetractLabel.Name = "cavaRetractLabel";
			this.cavaRetractLabel.Size = new System.Drawing.Size(90, 16);
			this.cavaRetractLabel.TabIndex = 1;
			this.cavaRetractLabel.Text = "Retract value:";
			// 
			// cavaDepthOfCutLabel
			// 
			this.cavaDepthOfCutLabel.AutoSize = true;
			this.cavaDepthOfCutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaDepthOfCutLabel.ForeColor = System.Drawing.Color.Black;
			this.cavaDepthOfCutLabel.Location = new System.Drawing.Point(13, 25);
			this.cavaDepthOfCutLabel.Name = "cavaDepthOfCutLabel";
			this.cavaDepthOfCutLabel.Size = new System.Drawing.Size(81, 16);
			this.cavaDepthOfCutLabel.TabIndex = 0;
			this.cavaDepthOfCutLabel.Text = "Depth of cut:";
			// 
			// collarinoCycleGroup
			// 
			this.collarinoCycleGroup.Controls.Add(this.collarinoToolNumberInput);
			this.collarinoCycleGroup.Controls.Add(this.collarinoToolNumberLabel);
			this.collarinoCycleGroup.Controls.Add(this.collarinoSurfaceSpeedInput);
			this.collarinoCycleGroup.Controls.Add(this.collarinoFeedRateInput);
			this.collarinoCycleGroup.Controls.Add(this.collarinoSpeedLimitInput);
			this.collarinoCycleGroup.Controls.Add(this.collarinoZAllowanceInput);
			this.collarinoCycleGroup.Controls.Add(this.collarinoSurfaceSpeedLabel);
			this.collarinoCycleGroup.Controls.Add(this.collarinoXAllowanceInput);
			this.collarinoCycleGroup.Controls.Add(this.collarinoSpeedLimitLabel);
			this.collarinoCycleGroup.Controls.Add(this.collarinoRetractInput);
			this.collarinoCycleGroup.Controls.Add(this.collarinoDepthOfCutInput);
			this.collarinoCycleGroup.Controls.Add(this.collarinoFeedRateLabel);
			this.collarinoCycleGroup.Controls.Add(this.collarinoAllowanceZLabel);
			this.collarinoCycleGroup.Controls.Add(this.collarinoAllowanceXLabel);
			this.collarinoCycleGroup.Controls.Add(this.collarinoRetractLabel);
			this.collarinoCycleGroup.Controls.Add(this.collarinoDepthOfCutLabel);
			this.collarinoCycleGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoCycleGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.collarinoCycleGroup.Location = new System.Drawing.Point(392, 6);
			this.collarinoCycleGroup.Name = "collarinoCycleGroup";
			this.collarinoCycleGroup.Size = new System.Drawing.Size(185, 323);
			this.collarinoCycleGroup.TabIndex = 11;
			this.collarinoCycleGroup.TabStop = false;
			this.collarinoCycleGroup.Text = "Collarino Cycle";
			// 
			// collarinoFeedRateInput
			// 
			this.collarinoFeedRateInput.DecimalPlaces = 2;
			this.collarinoFeedRateInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoFeedRateInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.collarinoFeedRateInput.Location = new System.Drawing.Point(109, 140);
			this.collarinoFeedRateInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.collarinoFeedRateInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.collarinoFeedRateInput.Name = "collarinoFeedRateInput";
			this.collarinoFeedRateInput.Size = new System.Drawing.Size(71, 26);
			this.collarinoFeedRateInput.TabIndex = 9;
			this.collarinoFeedRateInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.collarinoFeedRateInput.ValueChanged += new System.EventHandler(this.collarinoFeedRateInput_ValueChanged);
			// 
			// collarinoZAllowanceInput
			// 
			this.collarinoZAllowanceInput.DecimalPlaces = 2;
			this.collarinoZAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoZAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.collarinoZAllowanceInput.Location = new System.Drawing.Point(109, 110);
			this.collarinoZAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.collarinoZAllowanceInput.Name = "collarinoZAllowanceInput";
			this.collarinoZAllowanceInput.Size = new System.Drawing.Size(71, 26);
			this.collarinoZAllowanceInput.TabIndex = 8;
			this.collarinoZAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.collarinoZAllowanceInput.ValueChanged += new System.EventHandler(this.collarinoZAllowanceInput_ValueChanged);
			// 
			// collarinoXAllowanceInput
			// 
			this.collarinoXAllowanceInput.DecimalPlaces = 2;
			this.collarinoXAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoXAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.collarinoXAllowanceInput.Location = new System.Drawing.Point(109, 80);
			this.collarinoXAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.collarinoXAllowanceInput.Name = "collarinoXAllowanceInput";
			this.collarinoXAllowanceInput.Size = new System.Drawing.Size(71, 26);
			this.collarinoXAllowanceInput.TabIndex = 7;
			this.collarinoXAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.collarinoXAllowanceInput.ValueChanged += new System.EventHandler(this.collarinoXAllowanceInput_ValueChanged);
			// 
			// collarinoRetractInput
			// 
			this.collarinoRetractInput.DecimalPlaces = 2;
			this.collarinoRetractInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoRetractInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.collarinoRetractInput.Location = new System.Drawing.Point(109, 50);
			this.collarinoRetractInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.collarinoRetractInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.collarinoRetractInput.Name = "collarinoRetractInput";
			this.collarinoRetractInput.Size = new System.Drawing.Size(71, 26);
			this.collarinoRetractInput.TabIndex = 6;
			this.collarinoRetractInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.collarinoRetractInput.ValueChanged += new System.EventHandler(this.collarinoRetractInput_ValueChanged);
			// 
			// collarinoDepthOfCutInput
			// 
			this.collarinoDepthOfCutInput.DecimalPlaces = 2;
			this.collarinoDepthOfCutInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoDepthOfCutInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.collarinoDepthOfCutInput.Location = new System.Drawing.Point(109, 20);
			this.collarinoDepthOfCutInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.collarinoDepthOfCutInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.collarinoDepthOfCutInput.Name = "collarinoDepthOfCutInput";
			this.collarinoDepthOfCutInput.Size = new System.Drawing.Size(71, 26);
			this.collarinoDepthOfCutInput.TabIndex = 5;
			this.collarinoDepthOfCutInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.collarinoDepthOfCutInput.ValueChanged += new System.EventHandler(this.collarinoDepthOfCutInput_ValueChanged);
			// 
			// collarinoFeedRateLabel
			// 
			this.collarinoFeedRateLabel.AutoSize = true;
			this.collarinoFeedRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoFeedRateLabel.ForeColor = System.Drawing.Color.Black;
			this.collarinoFeedRateLabel.Location = new System.Drawing.Point(34, 145);
			this.collarinoFeedRateLabel.Name = "collarinoFeedRateLabel";
			this.collarinoFeedRateLabel.Size = new System.Drawing.Size(69, 16);
			this.collarinoFeedRateLabel.TabIndex = 4;
			this.collarinoFeedRateLabel.Text = "Feed rate:";
			// 
			// collarinoAllowanceZLabel
			// 
			this.collarinoAllowanceZLabel.AutoSize = true;
			this.collarinoAllowanceZLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoAllowanceZLabel.ForeColor = System.Drawing.Color.Black;
			this.collarinoAllowanceZLabel.Location = new System.Drawing.Point(19, 115);
			this.collarinoAllowanceZLabel.Name = "collarinoAllowanceZLabel";
			this.collarinoAllowanceZLabel.Size = new System.Drawing.Size(84, 16);
			this.collarinoAllowanceZLabel.TabIndex = 3;
			this.collarinoAllowanceZLabel.Text = "Z Allowance:";
			// 
			// collarinoAllowanceXLabel
			// 
			this.collarinoAllowanceXLabel.AutoSize = true;
			this.collarinoAllowanceXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoAllowanceXLabel.ForeColor = System.Drawing.Color.Black;
			this.collarinoAllowanceXLabel.Location = new System.Drawing.Point(19, 85);
			this.collarinoAllowanceXLabel.Name = "collarinoAllowanceXLabel";
			this.collarinoAllowanceXLabel.Size = new System.Drawing.Size(84, 16);
			this.collarinoAllowanceXLabel.TabIndex = 2;
			this.collarinoAllowanceXLabel.Text = "X Allowance:";
			// 
			// collarinoRetractLabel
			// 
			this.collarinoRetractLabel.AutoSize = true;
			this.collarinoRetractLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoRetractLabel.ForeColor = System.Drawing.Color.Black;
			this.collarinoRetractLabel.Location = new System.Drawing.Point(13, 55);
			this.collarinoRetractLabel.Name = "collarinoRetractLabel";
			this.collarinoRetractLabel.Size = new System.Drawing.Size(90, 16);
			this.collarinoRetractLabel.TabIndex = 1;
			this.collarinoRetractLabel.Text = "Retract value:";
			// 
			// collarinoDepthOfCutLabel
			// 
			this.collarinoDepthOfCutLabel.AutoSize = true;
			this.collarinoDepthOfCutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoDepthOfCutLabel.ForeColor = System.Drawing.Color.Black;
			this.collarinoDepthOfCutLabel.Location = new System.Drawing.Point(22, 25);
			this.collarinoDepthOfCutLabel.Name = "collarinoDepthOfCutLabel";
			this.collarinoDepthOfCutLabel.Size = new System.Drawing.Size(81, 16);
			this.collarinoDepthOfCutLabel.TabIndex = 0;
			this.collarinoDepthOfCutLabel.Text = "Depth of cut:";
			// 
			// workplaneOriginGroup
			// 
			this.workplaneOriginGroup.Controls.Add(this.workplaneOriginParameterInput);
			this.workplaneOriginGroup.Controls.Add(this.workplaneOriginLabel);
			this.workplaneOriginGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.workplaneOriginGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.workplaneOriginGroup.Location = new System.Drawing.Point(8, 384);
			this.workplaneOriginGroup.Name = "workplaneOriginGroup";
			this.workplaneOriginGroup.Size = new System.Drawing.Size(488, 90);
			this.workplaneOriginGroup.TabIndex = 25;
			this.workplaneOriginGroup.TabStop = false;
			this.workplaneOriginGroup.Text = "Workplane origin";
			// 
			// workplaneOriginParameterInput
			// 
			this.workplaneOriginParameterInput.Location = new System.Drawing.Point(335, 37);
			this.workplaneOriginParameterInput.MaxLength = 18;
			this.workplaneOriginParameterInput.Name = "workplaneOriginParameterInput";
			this.workplaneOriginParameterInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.workplaneOriginParameterInput.Size = new System.Drawing.Size(131, 22);
			this.workplaneOriginParameterInput.TabIndex = 7;
			this.workplaneOriginParameterInput.TextChanged += new System.EventHandler(this.workplaneOriginParameterInput_TextChanged);
			// 
			// workplaneOriginLabel
			// 
			this.workplaneOriginLabel.AutoSize = true;
			this.workplaneOriginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.workplaneOriginLabel.ForeColor = System.Drawing.Color.Black;
			this.workplaneOriginLabel.Location = new System.Drawing.Point(19, 40);
			this.workplaneOriginLabel.Name = "workplaneOriginLabel";
			this.workplaneOriginLabel.Size = new System.Drawing.Size(312, 16);
			this.workplaneOriginLabel.TabIndex = 6;
			this.workplaneOriginLabel.Text = "Workplane origin parameter of machine(ex: #5222) :";
			// 
			// diametricalSpeedLimitLabel
			// 
			this.diametricalSpeedLimitLabel.AutoSize = true;
			this.diametricalSpeedLimitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalSpeedLimitLabel.ForeColor = System.Drawing.Color.Black;
			this.diametricalSpeedLimitLabel.Location = new System.Drawing.Point(24, 204);
			this.diametricalSpeedLimitLabel.Name = "diametricalSpeedLimitLabel";
			this.diametricalSpeedLimitLabel.Size = new System.Drawing.Size(78, 16);
			this.diametricalSpeedLimitLabel.TabIndex = 10;
			this.diametricalSpeedLimitLabel.Text = "Speed limit:";
			// 
			// diametricalSurfaceSpeedLabel
			// 
			this.diametricalSurfaceSpeedLabel.AutoSize = true;
			this.diametricalSurfaceSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalSurfaceSpeedLabel.ForeColor = System.Drawing.Color.Black;
			this.diametricalSurfaceSpeedLabel.Location = new System.Drawing.Point(4, 236);
			this.diametricalSurfaceSpeedLabel.Name = "diametricalSurfaceSpeedLabel";
			this.diametricalSurfaceSpeedLabel.Size = new System.Drawing.Size(99, 16);
			this.diametricalSurfaceSpeedLabel.TabIndex = 11;
			this.diametricalSurfaceSpeedLabel.Text = "Surface speed:";
			// 
			// diametricalSpeedLimitInput
			// 
			this.diametricalSpeedLimitInput.DecimalPlaces = 1;
			this.diametricalSpeedLimitInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalSpeedLimitInput.Location = new System.Drawing.Point(108, 199);
			this.diametricalSpeedLimitInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.diametricalSpeedLimitInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.diametricalSpeedLimitInput.Name = "diametricalSpeedLimitInput";
			this.diametricalSpeedLimitInput.Size = new System.Drawing.Size(71, 26);
			this.diametricalSpeedLimitInput.TabIndex = 10;
			this.diametricalSpeedLimitInput.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.diametricalSpeedLimitInput.ValueChanged += new System.EventHandler(this.diametricalSpeedLimitInput_ValueChanged);
			// 
			// diametricalSurfaceSpeedInput
			// 
			this.diametricalSurfaceSpeedInput.DecimalPlaces = 1;
			this.diametricalSurfaceSpeedInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalSurfaceSpeedInput.Location = new System.Drawing.Point(108, 231);
			this.diametricalSurfaceSpeedInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.diametricalSurfaceSpeedInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.diametricalSurfaceSpeedInput.Name = "diametricalSurfaceSpeedInput";
			this.diametricalSurfaceSpeedInput.Size = new System.Drawing.Size(71, 26);
			this.diametricalSurfaceSpeedInput.TabIndex = 12;
			this.diametricalSurfaceSpeedInput.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.diametricalSurfaceSpeedInput.ValueChanged += new System.EventHandler(this.diametricalSurfaceSpeedInput_ValueChanged);
			// 
			// facingSurfaceSpeedInput
			// 
			this.facingSurfaceSpeedInput.DecimalPlaces = 1;
			this.facingSurfaceSpeedInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingSurfaceSpeedInput.Location = new System.Drawing.Point(108, 231);
			this.facingSurfaceSpeedInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.facingSurfaceSpeedInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.facingSurfaceSpeedInput.Name = "facingSurfaceSpeedInput";
			this.facingSurfaceSpeedInput.Size = new System.Drawing.Size(71, 26);
			this.facingSurfaceSpeedInput.TabIndex = 16;
			this.facingSurfaceSpeedInput.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.facingSurfaceSpeedInput.ValueChanged += new System.EventHandler(this.facingSurfaceSpeedInput_ValueChanged);
			// 
			// facingSpeedLimitInput
			// 
			this.facingSpeedLimitInput.DecimalPlaces = 1;
			this.facingSpeedLimitInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingSpeedLimitInput.Location = new System.Drawing.Point(108, 199);
			this.facingSpeedLimitInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.facingSpeedLimitInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.facingSpeedLimitInput.Name = "facingSpeedLimitInput";
			this.facingSpeedLimitInput.Size = new System.Drawing.Size(71, 26);
			this.facingSpeedLimitInput.TabIndex = 13;
			this.facingSpeedLimitInput.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.facingSpeedLimitInput.ValueChanged += new System.EventHandler(this.facingSpeedLimitInput_ValueChanged);
			// 
			// facingSurfaceSpeedLabel
			// 
			this.facingSurfaceSpeedLabel.AutoSize = true;
			this.facingSurfaceSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingSurfaceSpeedLabel.ForeColor = System.Drawing.Color.Black;
			this.facingSurfaceSpeedLabel.Location = new System.Drawing.Point(4, 236);
			this.facingSurfaceSpeedLabel.Name = "facingSurfaceSpeedLabel";
			this.facingSurfaceSpeedLabel.Size = new System.Drawing.Size(99, 16);
			this.facingSurfaceSpeedLabel.TabIndex = 15;
			this.facingSurfaceSpeedLabel.Text = "Surface speed:";
			// 
			// facingSpeedLimitLabel
			// 
			this.facingSpeedLimitLabel.AutoSize = true;
			this.facingSpeedLimitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingSpeedLimitLabel.ForeColor = System.Drawing.Color.Black;
			this.facingSpeedLimitLabel.Location = new System.Drawing.Point(24, 204);
			this.facingSpeedLimitLabel.Name = "facingSpeedLimitLabel";
			this.facingSpeedLimitLabel.Size = new System.Drawing.Size(78, 16);
			this.facingSpeedLimitLabel.TabIndex = 14;
			this.facingSpeedLimitLabel.Text = "Speed limit:";
			// 
			// collarinoSurfaceSpeedInput
			// 
			this.collarinoSurfaceSpeedInput.DecimalPlaces = 1;
			this.collarinoSurfaceSpeedInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoSurfaceSpeedInput.Location = new System.Drawing.Point(109, 231);
			this.collarinoSurfaceSpeedInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.collarinoSurfaceSpeedInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.collarinoSurfaceSpeedInput.Name = "collarinoSurfaceSpeedInput";
			this.collarinoSurfaceSpeedInput.Size = new System.Drawing.Size(71, 26);
			this.collarinoSurfaceSpeedInput.TabIndex = 20;
			this.collarinoSurfaceSpeedInput.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.collarinoSurfaceSpeedInput.ValueChanged += new System.EventHandler(this.collarinoSurfaceSpeedInput_ValueChanged);
			// 
			// collarinoSpeedLimitInput
			// 
			this.collarinoSpeedLimitInput.DecimalPlaces = 1;
			this.collarinoSpeedLimitInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoSpeedLimitInput.Location = new System.Drawing.Point(109, 199);
			this.collarinoSpeedLimitInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.collarinoSpeedLimitInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.collarinoSpeedLimitInput.Name = "collarinoSpeedLimitInput";
			this.collarinoSpeedLimitInput.Size = new System.Drawing.Size(71, 26);
			this.collarinoSpeedLimitInput.TabIndex = 17;
			this.collarinoSpeedLimitInput.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.collarinoSpeedLimitInput.ValueChanged += new System.EventHandler(this.collarinoSpeedLimitInput_ValueChanged);
			// 
			// collarinoSurfaceSpeedLabel
			// 
			this.collarinoSurfaceSpeedLabel.AutoSize = true;
			this.collarinoSurfaceSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoSurfaceSpeedLabel.ForeColor = System.Drawing.Color.Black;
			this.collarinoSurfaceSpeedLabel.Location = new System.Drawing.Point(5, 236);
			this.collarinoSurfaceSpeedLabel.Name = "collarinoSurfaceSpeedLabel";
			this.collarinoSurfaceSpeedLabel.Size = new System.Drawing.Size(99, 16);
			this.collarinoSurfaceSpeedLabel.TabIndex = 19;
			this.collarinoSurfaceSpeedLabel.Text = "Surface speed:";
			// 
			// collarinoSpeedLimitLabel
			// 
			this.collarinoSpeedLimitLabel.AutoSize = true;
			this.collarinoSpeedLimitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoSpeedLimitLabel.ForeColor = System.Drawing.Color.Black;
			this.collarinoSpeedLimitLabel.Location = new System.Drawing.Point(25, 204);
			this.collarinoSpeedLimitLabel.Name = "collarinoSpeedLimitLabel";
			this.collarinoSpeedLimitLabel.Size = new System.Drawing.Size(78, 16);
			this.collarinoSpeedLimitLabel.TabIndex = 18;
			this.collarinoSpeedLimitLabel.Text = "Speed limit:";
			// 
			// cavaSurfaceSpeedInput
			// 
			this.cavaSurfaceSpeedInput.DecimalPlaces = 1;
			this.cavaSurfaceSpeedInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaSurfaceSpeedInput.Location = new System.Drawing.Point(109, 231);
			this.cavaSurfaceSpeedInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.cavaSurfaceSpeedInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.cavaSurfaceSpeedInput.Name = "cavaSurfaceSpeedInput";
			this.cavaSurfaceSpeedInput.Size = new System.Drawing.Size(71, 26);
			this.cavaSurfaceSpeedInput.TabIndex = 24;
			this.cavaSurfaceSpeedInput.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.cavaSurfaceSpeedInput.ValueChanged += new System.EventHandler(this.cavaSurfaceSpeedInput_ValueChanged);
			// 
			// cavaSpeedLimitInput
			// 
			this.cavaSpeedLimitInput.DecimalPlaces = 1;
			this.cavaSpeedLimitInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaSpeedLimitInput.Location = new System.Drawing.Point(109, 199);
			this.cavaSpeedLimitInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.cavaSpeedLimitInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.cavaSpeedLimitInput.Name = "cavaSpeedLimitInput";
			this.cavaSpeedLimitInput.Size = new System.Drawing.Size(71, 26);
			this.cavaSpeedLimitInput.TabIndex = 21;
			this.cavaSpeedLimitInput.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.cavaSpeedLimitInput.ValueChanged += new System.EventHandler(this.cavaSpeedLimitInput_ValueChanged);
			// 
			// cavaSurfaceSpeedLabel
			// 
			this.cavaSurfaceSpeedLabel.AutoSize = true;
			this.cavaSurfaceSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaSurfaceSpeedLabel.ForeColor = System.Drawing.Color.Black;
			this.cavaSurfaceSpeedLabel.Location = new System.Drawing.Point(5, 236);
			this.cavaSurfaceSpeedLabel.Name = "cavaSurfaceSpeedLabel";
			this.cavaSurfaceSpeedLabel.Size = new System.Drawing.Size(99, 16);
			this.cavaSurfaceSpeedLabel.TabIndex = 23;
			this.cavaSurfaceSpeedLabel.Text = "Surface speed:";
			// 
			// cavaSpeedLimitLabel
			// 
			this.cavaSpeedLimitLabel.AutoSize = true;
			this.cavaSpeedLimitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaSpeedLimitLabel.ForeColor = System.Drawing.Color.Black;
			this.cavaSpeedLimitLabel.Location = new System.Drawing.Point(25, 204);
			this.cavaSpeedLimitLabel.Name = "cavaSpeedLimitLabel";
			this.cavaSpeedLimitLabel.Size = new System.Drawing.Size(78, 16);
			this.cavaSpeedLimitLabel.TabIndex = 22;
			this.cavaSpeedLimitLabel.Text = "Speed limit:";
			// 
			// diametricalToolNumberLabel
			// 
			this.diametricalToolNumberLabel.AutoSize = true;
			this.diametricalToolNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.diametricalToolNumberLabel.ForeColor = System.Drawing.Color.Black;
			this.diametricalToolNumberLabel.Location = new System.Drawing.Point(16, 292);
			this.diametricalToolNumberLabel.Name = "diametricalToolNumberLabel";
			this.diametricalToolNumberLabel.Size = new System.Drawing.Size(87, 16);
			this.diametricalToolNumberLabel.TabIndex = 13;
			this.diametricalToolNumberLabel.Text = "Tool number:";
			// 
			// diametricalToolNumberInput
			// 
			this.diametricalToolNumberInput.Location = new System.Drawing.Point(108, 289);
			this.diametricalToolNumberInput.MaxLength = 8;
			this.diametricalToolNumberInput.Name = "diametricalToolNumberInput";
			this.diametricalToolNumberInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.diametricalToolNumberInput.Size = new System.Drawing.Size(71, 22);
			this.diametricalToolNumberInput.TabIndex = 8;
			this.diametricalToolNumberInput.TextChanged += new System.EventHandler(this.diametricalToolNumberInput_TextChanged);
			// 
			// facingToolNumberInput
			// 
			this.facingToolNumberInput.Location = new System.Drawing.Point(107, 289);
			this.facingToolNumberInput.MaxLength = 8;
			this.facingToolNumberInput.Name = "facingToolNumberInput";
			this.facingToolNumberInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.facingToolNumberInput.Size = new System.Drawing.Size(71, 22);
			this.facingToolNumberInput.TabIndex = 14;
			this.facingToolNumberInput.TextChanged += new System.EventHandler(this.facingToolNumberInput_TextChanged);
			// 
			// facingToolNumberLabel
			// 
			this.facingToolNumberLabel.AutoSize = true;
			this.facingToolNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.facingToolNumberLabel.ForeColor = System.Drawing.Color.Black;
			this.facingToolNumberLabel.Location = new System.Drawing.Point(15, 292);
			this.facingToolNumberLabel.Name = "facingToolNumberLabel";
			this.facingToolNumberLabel.Size = new System.Drawing.Size(87, 16);
			this.facingToolNumberLabel.TabIndex = 15;
			this.facingToolNumberLabel.Text = "Tool number:";
			// 
			// collarinoToolNumberInput
			// 
			this.collarinoToolNumberInput.Location = new System.Drawing.Point(109, 289);
			this.collarinoToolNumberInput.MaxLength = 8;
			this.collarinoToolNumberInput.Name = "collarinoToolNumberInput";
			this.collarinoToolNumberInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.collarinoToolNumberInput.Size = new System.Drawing.Size(71, 22);
			this.collarinoToolNumberInput.TabIndex = 21;
			this.collarinoToolNumberInput.TextChanged += new System.EventHandler(this.collarinoToolNumberInput_TextChanged);
			// 
			// collarinoToolNumberLabel
			// 
			this.collarinoToolNumberLabel.AutoSize = true;
			this.collarinoToolNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.collarinoToolNumberLabel.ForeColor = System.Drawing.Color.Black;
			this.collarinoToolNumberLabel.Location = new System.Drawing.Point(17, 292);
			this.collarinoToolNumberLabel.Name = "collarinoToolNumberLabel";
			this.collarinoToolNumberLabel.Size = new System.Drawing.Size(87, 16);
			this.collarinoToolNumberLabel.TabIndex = 22;
			this.collarinoToolNumberLabel.Text = "Tool number:";
			// 
			// cavaToolNumberInput
			// 
			this.cavaToolNumberInput.Location = new System.Drawing.Point(108, 289);
			this.cavaToolNumberInput.MaxLength = 8;
			this.cavaToolNumberInput.Name = "cavaToolNumberInput";
			this.cavaToolNumberInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cavaToolNumberInput.Size = new System.Drawing.Size(71, 22);
			this.cavaToolNumberInput.TabIndex = 23;
			this.cavaToolNumberInput.TextChanged += new System.EventHandler(this.cavaToolNumberInput_TextChanged);
			// 
			// cavaToolNumberLabel
			// 
			this.cavaToolNumberLabel.AutoSize = true;
			this.cavaToolNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaToolNumberLabel.ForeColor = System.Drawing.Color.Black;
			this.cavaToolNumberLabel.Location = new System.Drawing.Point(16, 292);
			this.cavaToolNumberLabel.Name = "cavaToolNumberLabel";
			this.cavaToolNumberLabel.Size = new System.Drawing.Size(87, 16);
			this.cavaToolNumberLabel.TabIndex = 24;
			this.cavaToolNumberLabel.Text = "Tool number:";
			// 
			// MainApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.ClientSize = new System.Drawing.Size(789, 655);
			this.Controls.Add(this.tabPanel);
			this.Controls.Add(this.copyrightsBanner);
			this.Controls.Add(this.mainAppMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mainAppMenu;
			this.MaximizeBox = false;
			this.Name = "MainApp";
			this.Text = "Alumat Tornio";
			this.Load += new System.EventHandler(this.MainApp_Load);
			this.mainAppMenu.ResumeLayout(false);
			this.mainAppMenu.PerformLayout();
			this.viewSideSelectorGroup.ResumeLayout(false);
			this.viewSideSelectorGroup.PerformLayout();
			this.copyrightsBanner.ResumeLayout(false);
			this.copyrightsBanner.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.banner)).EndInit();
			this.diametricalCycleGroup.ResumeLayout(false);
			this.diametricalCycleGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.diametricalFeedRateInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.diametricalZAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.diametricalXAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.diametricalRetractInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.diametricalDepthOfCutInput)).EndInit();
			this.facingCycleGroup.ResumeLayout(false);
			this.facingCycleGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.facingFeedRateInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.facingZAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.facingXAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.facingRetractInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.facingDepthOfCutInput)).EndInit();
			this.stockValuesSelectorGroup.ResumeLayout(false);
			this.stockValuesSelectorGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.stockWidthInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stockDiameterInput)).EndInit();
			this.tabPanel.ResumeLayout(false);
			this.tabSetup.ResumeLayout(false);
			this.tabSetup.PerformLayout();
			this.chockSizeGroup.ResumeLayout(false);
			this.chockSizeGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.chockSizeInput)).EndInit();
			this.validateDimensionsGroup.ResumeLayout(false);
			this.validateDimensionsGroup.PerformLayout();
			this.cavaSelectorGroup.ResumeLayout(false);
			this.cavaSelectorGroup.PerformLayout();
			this.manualCavaSelectorGroup.ResumeLayout(false);
			this.manualCavaSelectorGroup.PerformLayout();
			this.autoCavaSelectorGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.visualizationPanel)).EndInit();
			this.firstSideSelectorGroup.ResumeLayout(false);
			this.firstSideSelectorGroup.PerformLayout();
			this.tabSettings.ResumeLayout(false);
			this.cavaCycleGroup.ResumeLayout(false);
			this.cavaCycleGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.cavaFeedRateInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaZAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaXAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaRetractInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaDepthOfCutInput)).EndInit();
			this.collarinoCycleGroup.ResumeLayout(false);
			this.collarinoCycleGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.collarinoFeedRateInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoZAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoXAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoRetractInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoDepthOfCutInput)).EndInit();
			this.workplaneOriginGroup.ResumeLayout(false);
			this.workplaneOriginGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.diametricalSpeedLimitInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.diametricalSurfaceSpeedInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.facingSurfaceSpeedInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.facingSpeedLimitInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoSurfaceSpeedInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.collarinoSpeedLimitInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaSurfaceSpeedInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cavaSpeedLimitInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label coordinatesLabel;
		private System.Windows.Forms.MenuStrip mainAppMenu;
		private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
		private System.Windows.Forms.GroupBox viewSideSelectorGroup;
		private System.Windows.Forms.Panel copyrightsBanner;
		private System.Windows.Forms.PictureBox banner;
		private System.Windows.Forms.TextBox copyrights;
		private System.Windows.Forms.ToolStripMenuItem fileDxfMenuItem;
		private System.Windows.Forms.Button generateCode;
		private System.Windows.Forms.ProgressBar exportProgressBar;
		private System.Windows.Forms.GroupBox diametricalCycleGroup;
		private System.Windows.Forms.Label diametricalFeedRateLabel;
		private System.Windows.Forms.Label diametricalAllowanceZLabel;
		private System.Windows.Forms.Label diametricalAllowanceXLabel;
		private System.Windows.Forms.Label diametricalRetractLabel;
		private System.Windows.Forms.Label diametricalDepthOfCutLabel;
		private System.Windows.Forms.NumericUpDown diametricalFeedRateInput;
		private System.Windows.Forms.NumericUpDown diametricalZAllowanceInput;
		private System.Windows.Forms.NumericUpDown diametricalXAllowanceInput;
		private System.Windows.Forms.NumericUpDown diametricalRetractInput;
		private System.Windows.Forms.NumericUpDown diametricalDepthOfCutInput;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeDXFFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeExportFolderToolStripMenuItem;
		private System.Windows.Forms.GroupBox facingCycleGroup;
		private System.Windows.Forms.NumericUpDown facingFeedRateInput;
		private System.Windows.Forms.NumericUpDown facingZAllowanceInput;
		private System.Windows.Forms.NumericUpDown facingXAllowanceInput;
		private System.Windows.Forms.NumericUpDown facingRetractInput;
		private System.Windows.Forms.NumericUpDown facingDepthOfCutInput;
		private System.Windows.Forms.Label facingFeedRateLabel;
		private System.Windows.Forms.Label facingAllowanceZLabel;
		private System.Windows.Forms.Label facingAllowanceXLabel;
		private System.Windows.Forms.Label facingRetractLabel;
		private System.Windows.Forms.Label facingDepthOfCutLabel;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem g71RoughingCycleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem g72FacingCycleToolStripMenuItem;
		private System.Windows.Forms.RichTextBox gCodeTextBox;
		private System.Windows.Forms.Label fileName;
		private System.Windows.Forms.Label fileNameLabel;
		private System.Windows.Forms.ToolStripMenuItem openDXFFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openExportFolderToolStripMenuItem;
		private System.Windows.Forms.GroupBox stockValuesSelectorGroup;
		private System.Windows.Forms.NumericUpDown stockDiameterInput;
		private System.Windows.Forms.Label stockDiameterLabel;
		private System.Windows.Forms.RadioButton drawFirstSideButton;
		private System.Windows.Forms.RadioButton drawSecondSideButton;
		private System.Windows.Forms.TabControl tabPanel;
		private System.Windows.Forms.TabPage tabSetup;
		private System.Windows.Forms.PictureBox visualizationPanel;
		private System.Windows.Forms.TabPage tabSettings;
		private System.Windows.Forms.GroupBox firstSideSelectorGroup;
		private System.Windows.Forms.NumericUpDown stockWidthInput;
		private System.Windows.Forms.Label stockWidthLabel;
		private System.Windows.Forms.Label dieWidthLabel;
		private System.Windows.Forms.Label dieDiameterLabel;
		private System.Windows.Forms.Label firstSideSelectorLabel;
		private System.Windows.Forms.RadioButton flippedButton;
		private System.Windows.Forms.RadioButton asDesignedButton;
		private System.Windows.Forms.Button setSidesButton;
		private System.Windows.Forms.Label viewSideSelectorLabel;
		private System.Windows.Forms.GroupBox cavaSelectorGroup;
		private System.Windows.Forms.GroupBox validateDimensionsGroup;
		private System.Windows.Forms.Label validateDimensionsLabel;
		private System.Windows.Forms.Button validateDimensionsButton;
		private System.Windows.Forms.GroupBox manualCavaSelectorGroup;
		private System.Windows.Forms.GroupBox autoCavaSelectorGroup;
		private System.Windows.Forms.RadioButton manualCavaButton;
		private System.Windows.Forms.RadioButton autoCavaButton;
		private System.Windows.Forms.RadioButton cavaSecondSideAuto;
		private System.Windows.Forms.RadioButton cavaFirstSideAuto;
		private System.Windows.Forms.Label setCavaSelectorGroupSecondSideLabel;
		private System.Windows.Forms.Label setCavaSelectorFirstSideLabel;
		private System.Windows.Forms.Button decreaseSecondSideButton;
		private System.Windows.Forms.Button increaseSecondSideButton;
		private System.Windows.Forms.Button decreaseFirstSideButton;
		private System.Windows.Forms.Button increaseFirstSideButton;
		private System.Windows.Forms.GroupBox workplaneOriginGroup;
		private System.Windows.Forms.TextBox workplaneOriginParameterInput;
		private System.Windows.Forms.Label workplaneOriginLabel;
		private System.Windows.Forms.GroupBox chockSizeGroup;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown chockSizeInput;
		private System.Windows.Forms.GroupBox cavaCycleGroup;
		private System.Windows.Forms.NumericUpDown cavaFeedRateInput;
		private System.Windows.Forms.NumericUpDown cavaZAllowanceInput;
		private System.Windows.Forms.NumericUpDown cavaXAllowanceInput;
		private System.Windows.Forms.NumericUpDown cavaRetractInput;
		private System.Windows.Forms.NumericUpDown cavaDepthOfCutInput;
		private System.Windows.Forms.Label cavaFeedRateLabel;
		private System.Windows.Forms.Label cavaAllowanceZLabel;
		private System.Windows.Forms.Label cavaAllowanceXLabel;
		private System.Windows.Forms.Label cavaRetractLabel;
		private System.Windows.Forms.Label cavaDepthOfCutLabel;
		private System.Windows.Forms.GroupBox collarinoCycleGroup;
		private System.Windows.Forms.NumericUpDown collarinoFeedRateInput;
		private System.Windows.Forms.NumericUpDown collarinoZAllowanceInput;
		private System.Windows.Forms.NumericUpDown collarinoXAllowanceInput;
		private System.Windows.Forms.NumericUpDown collarinoRetractInput;
		private System.Windows.Forms.NumericUpDown collarinoDepthOfCutInput;
		private System.Windows.Forms.Label collarinoFeedRateLabel;
		private System.Windows.Forms.Label collarinoAllowanceZLabel;
		private System.Windows.Forms.Label collarinoAllowanceXLabel;
		private System.Windows.Forms.Label collarinoRetractLabel;
		private System.Windows.Forms.Label collarinoDepthOfCutLabel;
		private System.Windows.Forms.CheckBox cavaSecondSideManual;
		private System.Windows.Forms.CheckBox cavaFirstSideManual;
		private System.Windows.Forms.NumericUpDown diametricalSurfaceSpeedInput;
		private System.Windows.Forms.NumericUpDown diametricalSpeedLimitInput;
		private System.Windows.Forms.Label diametricalSurfaceSpeedLabel;
		private System.Windows.Forms.Label diametricalSpeedLimitLabel;
		private System.Windows.Forms.NumericUpDown facingSurfaceSpeedInput;
		private System.Windows.Forms.NumericUpDown facingSpeedLimitInput;
		private System.Windows.Forms.Label facingSurfaceSpeedLabel;
		private System.Windows.Forms.Label facingSpeedLimitLabel;
		private System.Windows.Forms.NumericUpDown cavaSurfaceSpeedInput;
		private System.Windows.Forms.NumericUpDown cavaSpeedLimitInput;
		private System.Windows.Forms.Label cavaSurfaceSpeedLabel;
		private System.Windows.Forms.Label cavaSpeedLimitLabel;
		private System.Windows.Forms.NumericUpDown collarinoSurfaceSpeedInput;
		private System.Windows.Forms.NumericUpDown collarinoSpeedLimitInput;
		private System.Windows.Forms.Label collarinoSurfaceSpeedLabel;
		private System.Windows.Forms.Label collarinoSpeedLimitLabel;
		private System.Windows.Forms.TextBox diametricalToolNumberInput;
		private System.Windows.Forms.Label diametricalToolNumberLabel;
		private System.Windows.Forms.TextBox facingToolNumberInput;
		private System.Windows.Forms.Label facingToolNumberLabel;
		private System.Windows.Forms.TextBox cavaToolNumberInput;
		private System.Windows.Forms.Label cavaToolNumberLabel;
		private System.Windows.Forms.TextBox collarinoToolNumberInput;
		private System.Windows.Forms.Label collarinoToolNumberLabel;
	}
}