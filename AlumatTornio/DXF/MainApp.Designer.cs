
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
			this.tornituraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.xStockWidthLabel = new System.Windows.Forms.Label();
			this.stockDiameterInput = new System.Windows.Forms.NumericUpDown();
			this.xStockDiameterLabel = new System.Windows.Forms.Label();
			this.tabPanel = new System.Windows.Forms.TabControl();
			this.tabSetup = new System.Windows.Forms.TabPage();
			this.dieWidthLabel = new System.Windows.Forms.Label();
			this.dieDiameterLabel = new System.Windows.Forms.Label();
			this.visualizationPanel = new System.Windows.Forms.PictureBox();
			this.firstSideSelectorGroup = new System.Windows.Forms.GroupBox();
			this.setFirstSideSelectionButton = new System.Windows.Forms.Button();
			this.firstSideSelectorLabel = new System.Windows.Forms.Label();
			this.flippedButton = new System.Windows.Forms.RadioButton();
			this.asDesignedButton = new System.Windows.Forms.RadioButton();
			this.tabSettings = new System.Windows.Forms.TabPage();
			this.cavaSelectorGroup = new System.Windows.Forms.GroupBox();
			this.cavaSelectorLabel = new System.Windows.Forms.Label();
			this.cavaFirstSideCheckBox = new System.Windows.Forms.CheckBox();
			this.cavaSecondSideCheckBox = new System.Windows.Forms.CheckBox();
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
			((System.ComponentModel.ISupportInitialize)(this.visualizationPanel)).BeginInit();
			this.firstSideSelectorGroup.SuspendLayout();
			this.tabSettings.SuspendLayout();
			this.cavaSelectorGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// coordinatesLabel
			// 
			this.coordinatesLabel.AutoSize = true;
			this.coordinatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.coordinatesLabel.Location = new System.Drawing.Point(312, 464);
			this.coordinatesLabel.Name = "coordinatesLabel";
			this.coordinatesLabel.Size = new System.Drawing.Size(152, 20);
			this.coordinatesLabel.TabIndex = 1;
			this.coordinatesLabel.Text = "Coordinates Reader";
			// 
			// mainAppMenu
			// 
			this.mainAppMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.mainAppMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.mainAppMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
			this.mainAppMenu.Location = new System.Drawing.Point(0, 0);
			this.mainAppMenu.Name = "mainAppMenu";
			this.mainAppMenu.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
			this.mainAppMenu.Size = new System.Drawing.Size(795, 24);
			this.mainAppMenu.TabIndex = 2;
			this.mainAppMenu.Text = "menuStrip1";
			// 
			// fileMenuItem
			// 
			this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileDxfMenuItem,
            this.tornituraToolStripMenuItem});
			this.fileMenuItem.Name = "fileMenuItem";
			this.fileMenuItem.Size = new System.Drawing.Size(37, 22);
			this.fileMenuItem.Text = "File";
			// 
			// fileDxfMenuItem
			// 
			this.fileDxfMenuItem.Name = "fileDxfMenuItem";
			this.fileDxfMenuItem.Size = new System.Drawing.Size(121, 22);
			this.fileDxfMenuItem.Text = "DXF";
			this.fileDxfMenuItem.Click += new System.EventHandler(this.fileDxfMenuItem_Click);
			// 
			// tornituraToolStripMenuItem
			// 
			this.tornituraToolStripMenuItem.Name = "tornituraToolStripMenuItem";
			this.tornituraToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.tornituraToolStripMenuItem.Text = "Tornitura";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeDXFFolderToolStripMenuItem,
            this.changeExportFolderToolStripMenuItem,
            this.openDXFFolderToolStripMenuItem,
            this.openExportFolderToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
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
			this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 22);
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
			this.viewSideSelectorGroup.Location = new System.Drawing.Point(316, 103);
			this.viewSideSelectorGroup.Margin = new System.Windows.Forms.Padding(2);
			this.viewSideSelectorGroup.Name = "viewSideSelectorGroup";
			this.viewSideSelectorGroup.Padding = new System.Windows.Forms.Padding(2);
			this.viewSideSelectorGroup.Size = new System.Drawing.Size(255, 80);
			this.viewSideSelectorGroup.TabIndex = 3;
			this.viewSideSelectorGroup.TabStop = false;
			this.viewSideSelectorGroup.Text = "Draw and Print";
			// 
			// viewSideSelectorLabel
			// 
			this.viewSideSelectorLabel.AutoSize = true;
			this.viewSideSelectorLabel.ForeColor = System.Drawing.Color.Black;
			this.viewSideSelectorLabel.Location = new System.Drawing.Point(9, 22);
			this.viewSideSelectorLabel.Name = "viewSideSelectorLabel";
			this.viewSideSelectorLabel.Size = new System.Drawing.Size(202, 16);
			this.viewSideSelectorLabel.TabIndex = 21;
			this.viewSideSelectorLabel.Text = "Select the side to draw and print :";
			// 
			// drawSecondSideButton
			// 
			this.drawSecondSideButton.AutoSize = true;
			this.drawSecondSideButton.ForeColor = System.Drawing.Color.Black;
			this.drawSecondSideButton.Location = new System.Drawing.Point(116, 46);
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
			this.drawFirstSideButton.CheckedChanged += new System.EventHandler(this.firstSide_CheckedChanged);
			// 
			// copyrightsBanner
			// 
			this.copyrightsBanner.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.copyrightsBanner.Controls.Add(this.copyrights);
			this.copyrightsBanner.Controls.Add(this.banner);
			this.copyrightsBanner.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.copyrightsBanner.Location = new System.Drawing.Point(0, 560);
			this.copyrightsBanner.Name = "copyrightsBanner";
			this.copyrightsBanner.Size = new System.Drawing.Size(795, 95);
			this.copyrightsBanner.TabIndex = 4;
			// 
			// copyrights
			// 
			this.copyrights.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.copyrights.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.copyrights.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.copyrights.Location = new System.Drawing.Point(288, 79);
			this.copyrights.Name = "copyrights";
			this.copyrights.Size = new System.Drawing.Size(193, 13);
			this.copyrights.TabIndex = 1;
			this.copyrights.Text = "© Alumat Srl 2022. All Rights Reserved";
			// 
			// banner
			// 
			this.banner.BackColor = System.Drawing.SystemColors.Window;
			this.banner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.banner.Dock = System.Windows.Forms.DockStyle.Top;
			this.banner.Image = ((System.Drawing.Image)(resources.GetObject("banner.Image")));
			this.banner.Location = new System.Drawing.Point(0, 0);
			this.banner.Name = "banner";
			this.banner.Size = new System.Drawing.Size(795, 74);
			this.banner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.banner.TabIndex = 0;
			this.banner.TabStop = false;
			// 
			// generateCode
			// 
			this.generateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.generateCode.Location = new System.Drawing.Point(316, 409);
			this.generateCode.Name = "generateCode";
			this.generateCode.Size = new System.Drawing.Size(255, 34);
			this.generateCode.TabIndex = 5;
			this.generateCode.Text = "Generate G Code";
			this.generateCode.UseVisualStyleBackColor = true;
			this.generateCode.Click += new System.EventHandler(this.exportGCode_Click);
			// 
			// exportProgressBar
			// 
			this.exportProgressBar.Location = new System.Drawing.Point(316, 449);
			this.exportProgressBar.Name = "exportProgressBar";
			this.exportProgressBar.Size = new System.Drawing.Size(255, 12);
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
            65536});
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
			this.g71ZAllowanceInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
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
			this.g71XAllowanceInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
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
            65536});
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
            65536});
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
            65536});
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
			this.g72ZAllowanceInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
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
			this.g72XAllowanceInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
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
            65536});
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
            65536});
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
			this.gCodeTextBox.Location = new System.Drawing.Point(581, 3);
			this.gCodeTextBox.Name = "gCodeTextBox";
			this.gCodeTextBox.ReadOnly = true;
			this.gCodeTextBox.Size = new System.Drawing.Size(198, 458);
			this.gCodeTextBox.TabIndex = 11;
			this.gCodeTextBox.Text = "";
			// 
			// fileName
			// 
			this.fileName.AutoSize = true;
			this.fileName.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.fileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.fileName.Location = new System.Drawing.Point(346, 484);
			this.fileName.Name = "fileName";
			this.fileName.Size = new System.Drawing.Size(98, 20);
			this.fileName.TabIndex = 12;
			this.fileName.Text = "Not selected";
			// 
			// fileNameLabel
			// 
			this.fileNameLabel.AutoSize = true;
			this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fileNameLabel.Location = new System.Drawing.Point(312, 484);
			this.fileNameLabel.Name = "fileNameLabel";
			this.fileNameLabel.Size = new System.Drawing.Size(38, 20);
			this.fileNameLabel.TabIndex = 13;
			this.fileNameLabel.Text = "File:";
			// 
			// stockValuesSelectorGroup
			// 
			this.stockValuesSelectorGroup.Controls.Add(this.stockWidthInput);
			this.stockValuesSelectorGroup.Controls.Add(this.xStockWidthLabel);
			this.stockValuesSelectorGroup.Controls.Add(this.stockDiameterInput);
			this.stockValuesSelectorGroup.Controls.Add(this.xStockDiameterLabel);
			this.stockValuesSelectorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stockValuesSelectorGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.stockValuesSelectorGroup.Location = new System.Drawing.Point(316, 318);
			this.stockValuesSelectorGroup.Name = "stockValuesSelectorGroup";
			this.stockValuesSelectorGroup.Size = new System.Drawing.Size(255, 85);
			this.stockValuesSelectorGroup.TabIndex = 14;
			this.stockValuesSelectorGroup.TabStop = false;
			this.stockValuesSelectorGroup.Text = "Stock";
			// 
			// stockWidthInput
			// 
			this.stockWidthInput.DecimalPlaces = 1;
			this.stockWidthInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.stockWidthInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.stockWidthInput.Location = new System.Drawing.Point(130, 46);
			this.stockWidthInput.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.stockWidthInput.Name = "stockWidthInput";
			this.stockWidthInput.Size = new System.Drawing.Size(81, 26);
			this.stockWidthInput.TabIndex = 15;
			this.stockWidthInput.ValueChanged += new System.EventHandler(this.stockWidthInput_ValueChanged);
			// 
			// xStockWidthLabel
			// 
			this.xStockWidthLabel.AutoSize = true;
			this.xStockWidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xStockWidthLabel.ForeColor = System.Drawing.Color.Black;
			this.xStockWidthLabel.Location = new System.Drawing.Point(6, 51);
			this.xStockWidthLabel.Name = "xStockWidthLabel";
			this.xStockWidthLabel.Size = new System.Drawing.Size(82, 16);
			this.xStockWidthLabel.TabIndex = 14;
			this.xStockWidthLabel.Text = "Stock Width:";
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
			this.stockDiameterInput.Location = new System.Drawing.Point(130, 18);
			this.stockDiameterInput.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.stockDiameterInput.Name = "stockDiameterInput";
			this.stockDiameterInput.Size = new System.Drawing.Size(81, 26);
			this.stockDiameterInput.TabIndex = 10;
			this.stockDiameterInput.ValueChanged += new System.EventHandler(this.stockDiameterInput_ValueChanged);
			// 
			// xStockDiameterLabel
			// 
			this.xStockDiameterLabel.AutoSize = true;
			this.xStockDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xStockDiameterLabel.ForeColor = System.Drawing.Color.Black;
			this.xStockDiameterLabel.Location = new System.Drawing.Point(6, 23);
			this.xStockDiameterLabel.Name = "xStockDiameterLabel";
			this.xStockDiameterLabel.Size = new System.Drawing.Size(103, 16);
			this.xStockDiameterLabel.TabIndex = 1;
			this.xStockDiameterLabel.Text = "Stock Diameter:";
			// 
			// tabPanel
			// 
			this.tabPanel.Controls.Add(this.tabSetup);
			this.tabPanel.Controls.Add(this.tabSettings);
			this.tabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabPanel.Location = new System.Drawing.Point(0, 24);
			this.tabPanel.Name = "tabPanel";
			this.tabPanel.SelectedIndex = 0;
			this.tabPanel.Size = new System.Drawing.Size(795, 536);
			this.tabPanel.TabIndex = 16;
			// 
			// tabSetup
			// 
			this.tabSetup.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.tabSetup.Controls.Add(this.cavaSelectorGroup);
			this.tabSetup.Controls.Add(this.dieWidthLabel);
			this.tabSetup.Controls.Add(this.dieDiameterLabel);
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
			this.tabSetup.Size = new System.Drawing.Size(787, 510);
			this.tabSetup.TabIndex = 0;
			this.tabSetup.Text = "Machining Setup";
			// 
			// dieWidthLabel
			// 
			this.dieWidthLabel.AutoSize = true;
			this.dieWidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dieWidthLabel.Location = new System.Drawing.Point(582, 484);
			this.dieWidthLabel.Name = "dieWidthLabel";
			this.dieWidthLabel.Size = new System.Drawing.Size(82, 20);
			this.dieWidthLabel.TabIndex = 19;
			this.dieWidthLabel.Text = "Die Width:";
			// 
			// dieDiameterLabel
			// 
			this.dieDiameterLabel.AutoSize = true;
			this.dieDiameterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dieDiameterLabel.Location = new System.Drawing.Point(582, 464);
			this.dieDiameterLabel.Name = "dieDiameterLabel";
			this.dieDiameterLabel.Size = new System.Drawing.Size(106, 20);
			this.dieDiameterLabel.TabIndex = 18;
			this.dieDiameterLabel.Text = "Die Diameter:";
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
			this.firstSideSelectorGroup.Controls.Add(this.setFirstSideSelectionButton);
			this.firstSideSelectorGroup.Controls.Add(this.firstSideSelectorLabel);
			this.firstSideSelectorGroup.Controls.Add(this.flippedButton);
			this.firstSideSelectorGroup.Controls.Add(this.asDesignedButton);
			this.firstSideSelectorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.firstSideSelectorGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.firstSideSelectorGroup.Location = new System.Drawing.Point(316, 6);
			this.firstSideSelectorGroup.Name = "firstSideSelectorGroup";
			this.firstSideSelectorGroup.Size = new System.Drawing.Size(255, 80);
			this.firstSideSelectorGroup.TabIndex = 17;
			this.firstSideSelectorGroup.TabStop = false;
			this.firstSideSelectorGroup.Text = "Set first machining side";
			// 
			// setFirstSideSelectionButton
			// 
			this.setFirstSideSelectionButton.ForeColor = System.Drawing.Color.Black;
			this.setFirstSideSelectionButton.Location = new System.Drawing.Point(192, 46);
			this.setFirstSideSelectionButton.Name = "setFirstSideSelectionButton";
			this.setFirstSideSelectionButton.Size = new System.Drawing.Size(57, 23);
			this.setFirstSideSelectionButton.TabIndex = 20;
			this.setFirstSideSelectionButton.Text = "Set";
			this.setFirstSideSelectionButton.UseVisualStyleBackColor = true;
			this.setFirstSideSelectionButton.Click += new System.EventHandler(this.setFirstSideSelectionButton_Click);
			// 
			// firstSideSelectorLabel
			// 
			this.firstSideSelectorLabel.AutoSize = true;
			this.firstSideSelectorLabel.ForeColor = System.Drawing.Color.Black;
			this.firstSideSelectorLabel.Location = new System.Drawing.Point(9, 22);
			this.firstSideSelectorLabel.Name = "firstSideSelectorLabel";
			this.firstSideSelectorLabel.Size = new System.Drawing.Size(189, 16);
			this.firstSideSelectorLabel.TabIndex = 2;
			this.firstSideSelectorLabel.Text = "Select the first machining side :";
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
			this.tabSettings.Controls.Add(this.g71Settings);
			this.tabSettings.Controls.Add(this.g72Settings);
			this.tabSettings.Location = new System.Drawing.Point(4, 22);
			this.tabSettings.Name = "tabSettings";
			this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
			this.tabSettings.Size = new System.Drawing.Size(787, 510);
			this.tabSettings.TabIndex = 1;
			this.tabSettings.Text = "Machining Settings";
			// 
			// cavaSelectorGroup
			// 
			this.cavaSelectorGroup.Controls.Add(this.cavaSecondSideCheckBox);
			this.cavaSelectorGroup.Controls.Add(this.cavaFirstSideCheckBox);
			this.cavaSelectorGroup.Controls.Add(this.cavaSelectorLabel);
			this.cavaSelectorGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cavaSelectorGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.cavaSelectorGroup.Location = new System.Drawing.Point(316, 202);
			this.cavaSelectorGroup.Margin = new System.Windows.Forms.Padding(2);
			this.cavaSelectorGroup.Name = "cavaSelectorGroup";
			this.cavaSelectorGroup.Padding = new System.Windows.Forms.Padding(2);
			this.cavaSelectorGroup.Size = new System.Drawing.Size(255, 96);
			this.cavaSelectorGroup.TabIndex = 20;
			this.cavaSelectorGroup.TabStop = false;
			this.cavaSelectorGroup.Text = "Set cava";
			// 
			// cavaSelectorLabel
			// 
			this.cavaSelectorLabel.AutoSize = true;
			this.cavaSelectorLabel.ForeColor = System.Drawing.Color.Black;
			this.cavaSelectorLabel.Location = new System.Drawing.Point(9, 22);
			this.cavaSelectorLabel.Name = "cavaSelectorLabel";
			this.cavaSelectorLabel.Size = new System.Drawing.Size(221, 16);
			this.cavaSelectorLabel.TabIndex = 21;
			this.cavaSelectorLabel.Text = "Select where to apply cava overlap:";
			// 
			// cavaFirstSideCheckBox
			// 
			this.cavaFirstSideCheckBox.AutoSize = true;
			this.cavaFirstSideCheckBox.ForeColor = System.Drawing.Color.Black;
			this.cavaFirstSideCheckBox.Location = new System.Drawing.Point(12, 44);
			this.cavaFirstSideCheckBox.Name = "cavaFirstSideCheckBox";
			this.cavaFirstSideCheckBox.Size = new System.Drawing.Size(165, 20);
			this.cavaFirstSideCheckBox.TabIndex = 22;
			this.cavaFirstSideCheckBox.Text = "Apply cava on first side";
			this.cavaFirstSideCheckBox.UseVisualStyleBackColor = true;
			// 
			// cavaSecondSideCheckBox
			// 
			this.cavaSecondSideCheckBox.AutoSize = true;
			this.cavaSecondSideCheckBox.ForeColor = System.Drawing.Color.Black;
			this.cavaSecondSideCheckBox.Location = new System.Drawing.Point(12, 65);
			this.cavaSecondSideCheckBox.Name = "cavaSecondSideCheckBox";
			this.cavaSecondSideCheckBox.Size = new System.Drawing.Size(190, 20);
			this.cavaSecondSideCheckBox.TabIndex = 23;
			this.cavaSecondSideCheckBox.Text = "Apply cava on second side";
			this.cavaSecondSideCheckBox.UseVisualStyleBackColor = true;
			// 
			// MainApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.ClientSize = new System.Drawing.Size(795, 655);
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
			((System.ComponentModel.ISupportInitialize)(this.visualizationPanel)).EndInit();
			this.firstSideSelectorGroup.ResumeLayout(false);
			this.firstSideSelectorGroup.PerformLayout();
			this.tabSettings.ResumeLayout(false);
			this.cavaSelectorGroup.ResumeLayout(false);
			this.cavaSelectorGroup.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem tornituraToolStripMenuItem;
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
		private System.Windows.Forms.Label xStockDiameterLabel;
		private System.Windows.Forms.RadioButton drawFirstSideButton;
		private System.Windows.Forms.RadioButton drawSecondSideButton;
		private System.Windows.Forms.TabControl tabPanel;
		private System.Windows.Forms.TabPage tabSetup;
		private System.Windows.Forms.PictureBox visualizationPanel;
		private System.Windows.Forms.TabPage tabSettings;
		private System.Windows.Forms.GroupBox firstSideSelectorGroup;
		private System.Windows.Forms.NumericUpDown stockWidthInput;
		private System.Windows.Forms.Label xStockWidthLabel;
		private System.Windows.Forms.Label dieWidthLabel;
		private System.Windows.Forms.Label dieDiameterLabel;
		private System.Windows.Forms.Label firstSideSelectorLabel;
		private System.Windows.Forms.RadioButton flippedButton;
		private System.Windows.Forms.RadioButton asDesignedButton;
		private System.Windows.Forms.Button setFirstSideSelectionButton;
		private System.Windows.Forms.Label viewSideSelectorLabel;
		private System.Windows.Forms.GroupBox cavaSelectorGroup;
		private System.Windows.Forms.Label cavaSelectorLabel;
		private System.Windows.Forms.CheckBox cavaSecondSideCheckBox;
		private System.Windows.Forms.CheckBox cavaFirstSideCheckBox;
	}
}