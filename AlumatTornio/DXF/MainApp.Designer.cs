
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
			this.g71Settings = new System.Windows.Forms.GroupBox();
			this.g71FeedRateInput = new System.Windows.Forms.NumericUpDown();
			this.g71ZAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.g71XAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.g71RetractInput = new System.Windows.Forms.NumericUpDown();
			this.g71DepthOfCutInput = new System.Windows.Forms.NumericUpDown();
			this.g71FeedRateLabel = new System.Windows.Forms.Label();
			this.g71AllowanceZLabel = new System.Windows.Forms.Label();
			this.g71AllowanceXLabel = new System.Windows.Forms.Label();
			this.g71RetractLabel = new System.Windows.Forms.Label();
			this.g71DepthOfCutLabel = new System.Windows.Forms.Label();
			this.g72Settings = new System.Windows.Forms.GroupBox();
			this.g72FeedRateInput = new System.Windows.Forms.NumericUpDown();
			this.g72ZAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.g72XAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.g72RetractInput = new System.Windows.Forms.NumericUpDown();
			this.g72DepthOfCutInput = new System.Windows.Forms.NumericUpDown();
			this.g72FeedRateLabel = new System.Windows.Forms.Label();
			this.g72AllowanceZLabel = new System.Windows.Forms.Label();
			this.g72AllowanceXLabel = new System.Windows.Forms.Label();
			this.g72RetractLabel = new System.Windows.Forms.Label();
			this.g72DepthOfCutLabel = new System.Windows.Forms.Label();
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
			this.decreaseSecondSideButton = new System.Windows.Forms.Button();
			this.increaseSecondSideButton = new System.Windows.Forms.Button();
			this.decreaseFirstSideButton = new System.Windows.Forms.Button();
			this.increaseFirstSideButton = new System.Windows.Forms.Button();
			this.autoCavaSelectorGroup = new System.Windows.Forms.GroupBox();
			this.cavaSecondSideButton = new System.Windows.Forms.RadioButton();
			this.cavaFirstSideButton = new System.Windows.Forms.RadioButton();
			this.manualCavaButton = new System.Windows.Forms.RadioButton();
			this.autoCavaButton = new System.Windows.Forms.RadioButton();
			this.visualizationPanel = new System.Windows.Forms.PictureBox();
			this.firstSideSelectorGroup = new System.Windows.Forms.GroupBox();
			this.setSidesButton = new System.Windows.Forms.Button();
			this.firstSideSelectorLabel = new System.Windows.Forms.Label();
			this.flippedButton = new System.Windows.Forms.RadioButton();
			this.asDesignedButton = new System.Windows.Forms.RadioButton();
			this.tabSettings = new System.Windows.Forms.TabPage();
			this.workplaneOriginGroup = new System.Windows.Forms.GroupBox();
			this.workplaneOriginParameterInput = new System.Windows.Forms.TextBox();
			this.workplaneOriginLabel = new System.Windows.Forms.Label();
			this.spindleSpeedGroup = new System.Windows.Forms.GroupBox();
			this.constantSurfaceSpeedInput = new System.Windows.Forms.NumericUpDown();
			this.constantSurfaceSpeedLabel = new System.Windows.Forms.Label();
			this.spindleSpeedLimitInput = new System.Windows.Forms.NumericUpDown();
			this.speedLimitLabel = new System.Windows.Forms.Label();
			this.mainAppMenu.SuspendLayout();
			this.viewSideSelectorGroup.SuspendLayout();
			this.copyrightsBanner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.banner)).BeginInit();
			this.g71Settings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.g71FeedRateInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.g71ZAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.g71XAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.g71RetractInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.g71DepthOfCutInput)).BeginInit();
			this.g72Settings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.g72FeedRateInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.g72ZAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.g72XAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.g72RetractInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.g72DepthOfCutInput)).BeginInit();
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
			this.workplaneOriginGroup.SuspendLayout();
			this.spindleSpeedGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.constantSurfaceSpeedInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.spindleSpeedLimitInput)).BeginInit();
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
			this.fileDxfMenuItem.Size = new System.Drawing.Size(180, 22);
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
			// g71Settings
			// 
			this.g71Settings.Controls.Add(this.g71FeedRateInput);
			this.g71Settings.Controls.Add(this.g71ZAllowanceInput);
			this.g71Settings.Controls.Add(this.g71XAllowanceInput);
			this.g71Settings.Controls.Add(this.g71RetractInput);
			this.g71Settings.Controls.Add(this.g71DepthOfCutInput);
			this.g71Settings.Controls.Add(this.g71FeedRateLabel);
			this.g71Settings.Controls.Add(this.g71AllowanceZLabel);
			this.g71Settings.Controls.Add(this.g71AllowanceXLabel);
			this.g71Settings.Controls.Add(this.g71RetractLabel);
			this.g71Settings.Controls.Add(this.g71DepthOfCutLabel);
			this.g71Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71Settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.g71Settings.Location = new System.Drawing.Point(8, 6);
			this.g71Settings.Name = "g71Settings";
			this.g71Settings.Size = new System.Drawing.Size(163, 174);
			this.g71Settings.TabIndex = 7;
			this.g71Settings.TabStop = false;
			this.g71Settings.Text = "G71 Roughing Cycle";
			// 
			// g71FeedRateInput
			// 
			this.g71FeedRateInput.DecimalPlaces = 2;
			this.g71FeedRateInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71FeedRateInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g71FeedRateInput.Location = new System.Drawing.Point(100, 140);
			this.g71FeedRateInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.g71FeedRateInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.g71FeedRateInput.Name = "g71FeedRateInput";
			this.g71FeedRateInput.Size = new System.Drawing.Size(53, 26);
			this.g71FeedRateInput.TabIndex = 9;
			this.g71FeedRateInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g71FeedRateInput.ValueChanged += new System.EventHandler(this.g71FeedRateInput_ValueChanged);
			// 
			// g71ZAllowanceInput
			// 
			this.g71ZAllowanceInput.DecimalPlaces = 2;
			this.g71ZAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71ZAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g71ZAllowanceInput.Location = new System.Drawing.Point(100, 110);
			this.g71ZAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.g71ZAllowanceInput.Name = "g71ZAllowanceInput";
			this.g71ZAllowanceInput.Size = new System.Drawing.Size(53, 26);
			this.g71ZAllowanceInput.TabIndex = 8;
			this.g71ZAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g71ZAllowanceInput.ValueChanged += new System.EventHandler(this.g71ZAllowanceInput_ValueChanged);
			// 
			// g71XAllowanceInput
			// 
			this.g71XAllowanceInput.DecimalPlaces = 2;
			this.g71XAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71XAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g71XAllowanceInput.Location = new System.Drawing.Point(100, 80);
			this.g71XAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.g71XAllowanceInput.Name = "g71XAllowanceInput";
			this.g71XAllowanceInput.Size = new System.Drawing.Size(53, 26);
			this.g71XAllowanceInput.TabIndex = 7;
			this.g71XAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g71XAllowanceInput.ValueChanged += new System.EventHandler(this.g71XAllowanceInput_ValueChanged);
			// 
			// g71RetractInput
			// 
			this.g71RetractInput.DecimalPlaces = 2;
			this.g71RetractInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71RetractInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g71RetractInput.Location = new System.Drawing.Point(100, 50);
			this.g71RetractInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.g71RetractInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.g71RetractInput.Name = "g71RetractInput";
			this.g71RetractInput.Size = new System.Drawing.Size(53, 26);
			this.g71RetractInput.TabIndex = 6;
			this.g71RetractInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g71RetractInput.ValueChanged += new System.EventHandler(this.g71RetractInput_ValueChanged);
			// 
			// g71DepthOfCutInput
			// 
			this.g71DepthOfCutInput.DecimalPlaces = 2;
			this.g71DepthOfCutInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71DepthOfCutInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g71DepthOfCutInput.Location = new System.Drawing.Point(100, 20);
			this.g71DepthOfCutInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.g71DepthOfCutInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.g71DepthOfCutInput.Name = "g71DepthOfCutInput";
			this.g71DepthOfCutInput.Size = new System.Drawing.Size(53, 26);
			this.g71DepthOfCutInput.TabIndex = 5;
			this.g71DepthOfCutInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g71DepthOfCutInput.ValueChanged += new System.EventHandler(this.g71DepthOfCutInput_ValueChanged);
			// 
			// g71FeedRateLabel
			// 
			this.g71FeedRateLabel.AutoSize = true;
			this.g71FeedRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71FeedRateLabel.ForeColor = System.Drawing.Color.Black;
			this.g71FeedRateLabel.Location = new System.Drawing.Point(25, 145);
			this.g71FeedRateLabel.Name = "g71FeedRateLabel";
			this.g71FeedRateLabel.Size = new System.Drawing.Size(69, 16);
			this.g71FeedRateLabel.TabIndex = 4;
			this.g71FeedRateLabel.Text = "Feed rate:";
			// 
			// g71AllowanceZLabel
			// 
			this.g71AllowanceZLabel.AutoSize = true;
			this.g71AllowanceZLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71AllowanceZLabel.ForeColor = System.Drawing.Color.Black;
			this.g71AllowanceZLabel.Location = new System.Drawing.Point(10, 115);
			this.g71AllowanceZLabel.Name = "g71AllowanceZLabel";
			this.g71AllowanceZLabel.Size = new System.Drawing.Size(84, 16);
			this.g71AllowanceZLabel.TabIndex = 3;
			this.g71AllowanceZLabel.Text = "Z Allowance:";
			// 
			// g71AllowanceXLabel
			// 
			this.g71AllowanceXLabel.AutoSize = true;
			this.g71AllowanceXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71AllowanceXLabel.ForeColor = System.Drawing.Color.Black;
			this.g71AllowanceXLabel.Location = new System.Drawing.Point(10, 85);
			this.g71AllowanceXLabel.Name = "g71AllowanceXLabel";
			this.g71AllowanceXLabel.Size = new System.Drawing.Size(84, 16);
			this.g71AllowanceXLabel.TabIndex = 2;
			this.g71AllowanceXLabel.Text = "X Allowance:";
			// 
			// g71RetractLabel
			// 
			this.g71RetractLabel.AutoSize = true;
			this.g71RetractLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71RetractLabel.ForeColor = System.Drawing.Color.Black;
			this.g71RetractLabel.Location = new System.Drawing.Point(4, 55);
			this.g71RetractLabel.Name = "g71RetractLabel";
			this.g71RetractLabel.Size = new System.Drawing.Size(90, 16);
			this.g71RetractLabel.TabIndex = 1;
			this.g71RetractLabel.Text = "Retract value:";
			// 
			// g71DepthOfCutLabel
			// 
			this.g71DepthOfCutLabel.AutoSize = true;
			this.g71DepthOfCutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71DepthOfCutLabel.ForeColor = System.Drawing.Color.Black;
			this.g71DepthOfCutLabel.Location = new System.Drawing.Point(13, 25);
			this.g71DepthOfCutLabel.Name = "g71DepthOfCutLabel";
			this.g71DepthOfCutLabel.Size = new System.Drawing.Size(81, 16);
			this.g71DepthOfCutLabel.TabIndex = 0;
			this.g71DepthOfCutLabel.Text = "Depth of cut:";
			// 
			// g72Settings
			// 
			this.g72Settings.Controls.Add(this.g72FeedRateInput);
			this.g72Settings.Controls.Add(this.g72ZAllowanceInput);
			this.g72Settings.Controls.Add(this.g72XAllowanceInput);
			this.g72Settings.Controls.Add(this.g72RetractInput);
			this.g72Settings.Controls.Add(this.g72DepthOfCutInput);
			this.g72Settings.Controls.Add(this.g72FeedRateLabel);
			this.g72Settings.Controls.Add(this.g72AllowanceZLabel);
			this.g72Settings.Controls.Add(this.g72AllowanceXLabel);
			this.g72Settings.Controls.Add(this.g72RetractLabel);
			this.g72Settings.Controls.Add(this.g72DepthOfCutLabel);
			this.g72Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72Settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.g72Settings.Location = new System.Drawing.Point(177, 6);
			this.g72Settings.Name = "g72Settings";
			this.g72Settings.Size = new System.Drawing.Size(163, 174);
			this.g72Settings.TabIndex = 10;
			this.g72Settings.TabStop = false;
			this.g72Settings.Text = "G72 Facing Cycle";
			// 
			// g72FeedRateInput
			// 
			this.g72FeedRateInput.DecimalPlaces = 2;
			this.g72FeedRateInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72FeedRateInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g72FeedRateInput.Location = new System.Drawing.Point(100, 140);
			this.g72FeedRateInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.g72FeedRateInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.g72FeedRateInput.Name = "g72FeedRateInput";
			this.g72FeedRateInput.Size = new System.Drawing.Size(53, 26);
			this.g72FeedRateInput.TabIndex = 9;
			this.g72FeedRateInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g72FeedRateInput.ValueChanged += new System.EventHandler(this.g72FeedRateInput_ValueChanged);
			// 
			// g72ZAllowanceInput
			// 
			this.g72ZAllowanceInput.DecimalPlaces = 2;
			this.g72ZAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72ZAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g72ZAllowanceInput.Location = new System.Drawing.Point(100, 110);
			this.g72ZAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.g72ZAllowanceInput.Name = "g72ZAllowanceInput";
			this.g72ZAllowanceInput.Size = new System.Drawing.Size(53, 26);
			this.g72ZAllowanceInput.TabIndex = 8;
			this.g72ZAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g72ZAllowanceInput.ValueChanged += new System.EventHandler(this.g72ZAllowanceInput_ValueChanged);
			// 
			// g72XAllowanceInput
			// 
			this.g72XAllowanceInput.DecimalPlaces = 2;
			this.g72XAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72XAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g72XAllowanceInput.Location = new System.Drawing.Point(100, 80);
			this.g72XAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.g72XAllowanceInput.Name = "g72XAllowanceInput";
			this.g72XAllowanceInput.Size = new System.Drawing.Size(53, 26);
			this.g72XAllowanceInput.TabIndex = 7;
			this.g72XAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g72XAllowanceInput.ValueChanged += new System.EventHandler(this.g72XAllowanceInput_ValueChanged);
			// 
			// g72RetractInput
			// 
			this.g72RetractInput.DecimalPlaces = 2;
			this.g72RetractInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72RetractInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g72RetractInput.Location = new System.Drawing.Point(100, 50);
			this.g72RetractInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.g72RetractInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.g72RetractInput.Name = "g72RetractInput";
			this.g72RetractInput.Size = new System.Drawing.Size(53, 26);
			this.g72RetractInput.TabIndex = 6;
			this.g72RetractInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g72RetractInput.ValueChanged += new System.EventHandler(this.g72RetractInput_ValueChanged);
			// 
			// g72DepthOfCutInput
			// 
			this.g72DepthOfCutInput.DecimalPlaces = 2;
			this.g72DepthOfCutInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72DepthOfCutInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g72DepthOfCutInput.Location = new System.Drawing.Point(100, 20);
			this.g72DepthOfCutInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.g72DepthOfCutInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
			this.g72DepthOfCutInput.Name = "g72DepthOfCutInput";
			this.g72DepthOfCutInput.Size = new System.Drawing.Size(53, 26);
			this.g72DepthOfCutInput.TabIndex = 5;
			this.g72DepthOfCutInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.g72DepthOfCutInput.ValueChanged += new System.EventHandler(this.g72DepthOfCutInput_ValueChanged);
			// 
			// g72FeedRateLabel
			// 
			this.g72FeedRateLabel.AutoSize = true;
			this.g72FeedRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72FeedRateLabel.ForeColor = System.Drawing.Color.Black;
			this.g72FeedRateLabel.Location = new System.Drawing.Point(25, 145);
			this.g72FeedRateLabel.Name = "g72FeedRateLabel";
			this.g72FeedRateLabel.Size = new System.Drawing.Size(69, 16);
			this.g72FeedRateLabel.TabIndex = 4;
			this.g72FeedRateLabel.Text = "Feed rate:";
			// 
			// g72AllowanceZLabel
			// 
			this.g72AllowanceZLabel.AutoSize = true;
			this.g72AllowanceZLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72AllowanceZLabel.ForeColor = System.Drawing.Color.Black;
			this.g72AllowanceZLabel.Location = new System.Drawing.Point(10, 115);
			this.g72AllowanceZLabel.Name = "g72AllowanceZLabel";
			this.g72AllowanceZLabel.Size = new System.Drawing.Size(84, 16);
			this.g72AllowanceZLabel.TabIndex = 3;
			this.g72AllowanceZLabel.Text = "Z Allowance:";
			// 
			// g72AllowanceXLabel
			// 
			this.g72AllowanceXLabel.AutoSize = true;
			this.g72AllowanceXLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72AllowanceXLabel.ForeColor = System.Drawing.Color.Black;
			this.g72AllowanceXLabel.Location = new System.Drawing.Point(10, 85);
			this.g72AllowanceXLabel.Name = "g72AllowanceXLabel";
			this.g72AllowanceXLabel.Size = new System.Drawing.Size(84, 16);
			this.g72AllowanceXLabel.TabIndex = 2;
			this.g72AllowanceXLabel.Text = "X Allowance:";
			// 
			// g72RetractLabel
			// 
			this.g72RetractLabel.AutoSize = true;
			this.g72RetractLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72RetractLabel.ForeColor = System.Drawing.Color.Black;
			this.g72RetractLabel.Location = new System.Drawing.Point(6, 55);
			this.g72RetractLabel.Name = "g72RetractLabel";
			this.g72RetractLabel.Size = new System.Drawing.Size(90, 16);
			this.g72RetractLabel.TabIndex = 1;
			this.g72RetractLabel.Text = "Retract value:";
			// 
			// g72DepthOfCutLabel
			// 
			this.g72DepthOfCutLabel.AutoSize = true;
			this.g72DepthOfCutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72DepthOfCutLabel.ForeColor = System.Drawing.Color.Black;
			this.g72DepthOfCutLabel.Location = new System.Drawing.Point(13, 25);
			this.g72DepthOfCutLabel.Name = "g72DepthOfCutLabel";
			this.g72DepthOfCutLabel.Size = new System.Drawing.Size(81, 16);
			this.g72DepthOfCutLabel.TabIndex = 0;
			this.g72DepthOfCutLabel.Text = "Depth of cut:";
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
			this.cavaSelectorGroup.Text = "Set cava";
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
			// decreaseSecondSideButton
			// 
			this.decreaseSecondSideButton.BackColor = System.Drawing.Color.Tomato;
			this.decreaseSecondSideButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.OrangeRed;
			this.decreaseSecondSideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.OrangeRed;
			this.decreaseSecondSideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.decreaseSecondSideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.decreaseSecondSideButton.ForeColor = System.Drawing.Color.Black;
			this.decreaseSecondSideButton.Location = new System.Drawing.Point(52, 45);
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
			this.decreaseFirstSideButton.Location = new System.Drawing.Point(52, 15);
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
			this.autoCavaSelectorGroup.Controls.Add(this.cavaSecondSideButton);
			this.autoCavaSelectorGroup.Controls.Add(this.cavaFirstSideButton);
			this.autoCavaSelectorGroup.Location = new System.Drawing.Point(88, 36);
			this.autoCavaSelectorGroup.Name = "autoCavaSelectorGroup";
			this.autoCavaSelectorGroup.Size = new System.Drawing.Size(60, 78);
			this.autoCavaSelectorGroup.TabIndex = 26;
			this.autoCavaSelectorGroup.TabStop = false;
			// 
			// cavaSecondSideButton
			// 
			this.cavaSecondSideButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.cavaSecondSideButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.cavaSecondSideButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaSecondSideButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaSecondSideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaSecondSideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cavaSecondSideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.cavaSecondSideButton.ForeColor = System.Drawing.Color.Black;
			this.cavaSecondSideButton.Location = new System.Drawing.Point(7, 45);
			this.cavaSecondSideButton.Name = "cavaSecondSideButton";
			this.cavaSecondSideButton.Size = new System.Drawing.Size(46, 26);
			this.cavaSecondSideButton.TabIndex = 1;
			this.cavaSecondSideButton.TabStop = true;
			this.cavaSecondSideButton.Text = "Set";
			this.cavaSecondSideButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cavaSecondSideButton.UseVisualStyleBackColor = false;
			this.cavaSecondSideButton.CheckedChanged += new System.EventHandler(this.cavaSecondSideButton_CheckedChanged);
			// 
			// cavaFirstSideButton
			// 
			this.cavaFirstSideButton.Appearance = System.Windows.Forms.Appearance.Button;
			this.cavaFirstSideButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.cavaFirstSideButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaFirstSideButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaFirstSideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(0)))));
			this.cavaFirstSideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cavaFirstSideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.cavaFirstSideButton.ForeColor = System.Drawing.Color.Black;
			this.cavaFirstSideButton.Location = new System.Drawing.Point(7, 15);
			this.cavaFirstSideButton.Name = "cavaFirstSideButton";
			this.cavaFirstSideButton.Size = new System.Drawing.Size(46, 26);
			this.cavaFirstSideButton.TabIndex = 0;
			this.cavaFirstSideButton.TabStop = true;
			this.cavaFirstSideButton.Text = "Set";
			this.cavaFirstSideButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cavaFirstSideButton.UseVisualStyleBackColor = false;
			this.cavaFirstSideButton.CheckedChanged += new System.EventHandler(this.cavaFirstSideButton_CheckedChanged);
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
			this.tabSettings.Controls.Add(this.workplaneOriginGroup);
			this.tabSettings.Controls.Add(this.spindleSpeedGroup);
			this.tabSettings.Controls.Add(this.g71Settings);
			this.tabSettings.Controls.Add(this.g72Settings);
			this.tabSettings.Location = new System.Drawing.Point(4, 22);
			this.tabSettings.Name = "tabSettings";
			this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
			this.tabSettings.Size = new System.Drawing.Size(781, 513);
			this.tabSettings.TabIndex = 1;
			this.tabSettings.Text = "Machining Settings";
			// 
			// workplaneOriginGroup
			// 
			this.workplaneOriginGroup.Controls.Add(this.workplaneOriginParameterInput);
			this.workplaneOriginGroup.Controls.Add(this.workplaneOriginLabel);
			this.workplaneOriginGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.workplaneOriginGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.workplaneOriginGroup.Location = new System.Drawing.Point(352, 103);
			this.workplaneOriginGroup.Name = "workplaneOriginGroup";
			this.workplaneOriginGroup.Size = new System.Drawing.Size(420, 77);
			this.workplaneOriginGroup.TabIndex = 25;
			this.workplaneOriginGroup.TabStop = false;
			this.workplaneOriginGroup.Text = "Workplane origin";
			// 
			// workplaneOriginParameterInput
			// 
			this.workplaneOriginParameterInput.Location = new System.Drawing.Point(272, 31);
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
			this.workplaneOriginLabel.Location = new System.Drawing.Point(19, 34);
			this.workplaneOriginLabel.Name = "workplaneOriginLabel";
			this.workplaneOriginLabel.Size = new System.Drawing.Size(247, 16);
			this.workplaneOriginLabel.TabIndex = 6;
			this.workplaneOriginLabel.Text = "Workplane origin parameter (ex: #5222) :";
			// 
			// spindleSpeedGroup
			// 
			this.spindleSpeedGroup.Controls.Add(this.constantSurfaceSpeedInput);
			this.spindleSpeedGroup.Controls.Add(this.constantSurfaceSpeedLabel);
			this.spindleSpeedGroup.Controls.Add(this.spindleSpeedLimitInput);
			this.spindleSpeedGroup.Controls.Add(this.speedLimitLabel);
			this.spindleSpeedGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.spindleSpeedGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.spindleSpeedGroup.Location = new System.Drawing.Point(352, 7);
			this.spindleSpeedGroup.Name = "spindleSpeedGroup";
			this.spindleSpeedGroup.Size = new System.Drawing.Size(261, 90);
			this.spindleSpeedGroup.TabIndex = 24;
			this.spindleSpeedGroup.TabStop = false;
			this.spindleSpeedGroup.Text = "Spindle speed";
			// 
			// constantSurfaceSpeedInput
			// 
			this.constantSurfaceSpeedInput.DecimalPlaces = 1;
			this.constantSurfaceSpeedInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.constantSurfaceSpeedInput.Location = new System.Drawing.Point(180, 54);
			this.constantSurfaceSpeedInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.constantSurfaceSpeedInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.constantSurfaceSpeedInput.Name = "constantSurfaceSpeedInput";
			this.constantSurfaceSpeedInput.Size = new System.Drawing.Size(71, 26);
			this.constantSurfaceSpeedInput.TabIndex = 9;
			this.constantSurfaceSpeedInput.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
			this.constantSurfaceSpeedInput.ValueChanged += new System.EventHandler(this.constantSurfaceSpeedInput_ValueChanged);
			// 
			// constantSurfaceSpeedLabel
			// 
			this.constantSurfaceSpeedLabel.AutoSize = true;
			this.constantSurfaceSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.constantSurfaceSpeedLabel.ForeColor = System.Drawing.Color.Black;
			this.constantSurfaceSpeedLabel.Location = new System.Drawing.Point(19, 59);
			this.constantSurfaceSpeedLabel.Name = "constantSurfaceSpeedLabel";
			this.constantSurfaceSpeedLabel.Size = new System.Drawing.Size(155, 16);
			this.constantSurfaceSpeedLabel.TabIndex = 8;
			this.constantSurfaceSpeedLabel.Text = "Constant surface speed :";
			// 
			// spindleSpeedLimitInput
			// 
			this.spindleSpeedLimitInput.DecimalPlaces = 1;
			this.spindleSpeedLimitInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.spindleSpeedLimitInput.Location = new System.Drawing.Point(180, 19);
			this.spindleSpeedLimitInput.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.spindleSpeedLimitInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.spindleSpeedLimitInput.Name = "spindleSpeedLimitInput";
			this.spindleSpeedLimitInput.Size = new System.Drawing.Size(71, 26);
			this.spindleSpeedLimitInput.TabIndex = 7;
			this.spindleSpeedLimitInput.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.spindleSpeedLimitInput.ValueChanged += new System.EventHandler(this.spindleSpeedLimitInput_ValueChanged);
			// 
			// speedLimitLabel
			// 
			this.speedLimitLabel.AutoSize = true;
			this.speedLimitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.speedLimitLabel.ForeColor = System.Drawing.Color.Black;
			this.speedLimitLabel.Location = new System.Drawing.Point(42, 24);
			this.speedLimitLabel.Name = "speedLimitLabel";
			this.speedLimitLabel.Size = new System.Drawing.Size(128, 16);
			this.speedLimitLabel.TabIndex = 6;
			this.speedLimitLabel.Text = "Spindle speed limit :";
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
			this.g71Settings.ResumeLayout(false);
			this.g71Settings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.g71FeedRateInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.g71ZAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.g71XAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.g71RetractInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.g71DepthOfCutInput)).EndInit();
			this.g72Settings.ResumeLayout(false);
			this.g72Settings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.g72FeedRateInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.g72ZAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.g72XAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.g72RetractInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.g72DepthOfCutInput)).EndInit();
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
			this.autoCavaSelectorGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.visualizationPanel)).EndInit();
			this.firstSideSelectorGroup.ResumeLayout(false);
			this.firstSideSelectorGroup.PerformLayout();
			this.tabSettings.ResumeLayout(false);
			this.workplaneOriginGroup.ResumeLayout(false);
			this.workplaneOriginGroup.PerformLayout();
			this.spindleSpeedGroup.ResumeLayout(false);
			this.spindleSpeedGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.constantSurfaceSpeedInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.spindleSpeedLimitInput)).EndInit();
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
		private System.Windows.Forms.GroupBox g71Settings;
		private System.Windows.Forms.Label g71FeedRateLabel;
		private System.Windows.Forms.Label g71AllowanceZLabel;
		private System.Windows.Forms.Label g71AllowanceXLabel;
		private System.Windows.Forms.Label g71RetractLabel;
		private System.Windows.Forms.Label g71DepthOfCutLabel;
		private System.Windows.Forms.NumericUpDown g71FeedRateInput;
		private System.Windows.Forms.NumericUpDown g71ZAllowanceInput;
		private System.Windows.Forms.NumericUpDown g71XAllowanceInput;
		private System.Windows.Forms.NumericUpDown g71RetractInput;
		private System.Windows.Forms.NumericUpDown g71DepthOfCutInput;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeDXFFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeExportFolderToolStripMenuItem;
		private System.Windows.Forms.GroupBox g72Settings;
		private System.Windows.Forms.NumericUpDown g72FeedRateInput;
		private System.Windows.Forms.NumericUpDown g72ZAllowanceInput;
		private System.Windows.Forms.NumericUpDown g72XAllowanceInput;
		private System.Windows.Forms.NumericUpDown g72RetractInput;
		private System.Windows.Forms.NumericUpDown g72DepthOfCutInput;
		private System.Windows.Forms.Label g72FeedRateLabel;
		private System.Windows.Forms.Label g72AllowanceZLabel;
		private System.Windows.Forms.Label g72AllowanceXLabel;
		private System.Windows.Forms.Label g72RetractLabel;
		private System.Windows.Forms.Label g72DepthOfCutLabel;
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
		private System.Windows.Forms.RadioButton cavaSecondSideButton;
		private System.Windows.Forms.RadioButton cavaFirstSideButton;
		private System.Windows.Forms.Label setCavaSelectorGroupSecondSideLabel;
		private System.Windows.Forms.Label setCavaSelectorFirstSideLabel;
		private System.Windows.Forms.Button decreaseSecondSideButton;
		private System.Windows.Forms.Button increaseSecondSideButton;
		private System.Windows.Forms.Button decreaseFirstSideButton;
		private System.Windows.Forms.Button increaseFirstSideButton;
		private System.Windows.Forms.GroupBox spindleSpeedGroup;
		private System.Windows.Forms.NumericUpDown constantSurfaceSpeedInput;
		private System.Windows.Forms.Label constantSurfaceSpeedLabel;
		private System.Windows.Forms.NumericUpDown spindleSpeedLimitInput;
		private System.Windows.Forms.Label speedLimitLabel;
		private System.Windows.Forms.GroupBox workplaneOriginGroup;
		private System.Windows.Forms.TextBox workplaneOriginParameterInput;
		private System.Windows.Forms.Label workplaneOriginLabel;
		private System.Windows.Forms.GroupBox chockSizeGroup;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown chockSizeInput;
	}
}