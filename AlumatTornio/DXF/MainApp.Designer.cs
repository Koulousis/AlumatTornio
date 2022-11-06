
namespace DXF
{
	partial class MainApp
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
			this.View = new System.Windows.Forms.PictureBox();
			this.coordinatesLabel = new System.Windows.Forms.Label();
			this.mainAppMenu = new System.Windows.Forms.MenuStrip();
			this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fileDxfMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tornituraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeDXFFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.changeExportFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.g71RoughingCycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.g72FacingCycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.visualizeSelector = new System.Windows.Forms.GroupBox();
			this.profileVisualizeCheckBox = new System.Windows.Forms.CheckBox();
			this.dieVisualizeCheckBox = new System.Windows.Forms.CheckBox();
			this.axesVisualizeCheckBox = new System.Windows.Forms.CheckBox();
			this.copyrightsBanner = new System.Windows.Forms.Panel();
			this.copyrights = new System.Windows.Forms.TextBox();
			this.banner = new System.Windows.Forms.PictureBox();
			this.exportGCode = new System.Windows.Forms.Button();
			this.exportProgressBar = new System.Windows.Forms.ProgressBar();
			this.g71Settings = new System.Windows.Forms.GroupBox();
			this.feedRateInput = new System.Windows.Forms.NumericUpDown();
			this.zAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.xAllowanceInput = new System.Windows.Forms.NumericUpDown();
			this.retractValueInput = new System.Windows.Forms.NumericUpDown();
			this.depthOfCutInput = new System.Windows.Forms.NumericUpDown();
			this.feedRateLabel = new System.Windows.Forms.Label();
			this.zAllowanceLabel = new System.Windows.Forms.Label();
			this.xAllowanceLabel = new System.Windows.Forms.Label();
			this.retractValueLabel = new System.Windows.Forms.Label();
			this.depthOfCutLabel = new System.Windows.Forms.Label();
			this.g72Settings = new System.Windows.Forms.GroupBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.gCodeTextBox = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
			this.mainAppMenu.SuspendLayout();
			this.visualizeSelector.SuspendLayout();
			this.copyrightsBanner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.banner)).BeginInit();
			this.g71Settings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.feedRateInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.zAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.retractValueInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.depthOfCutInput)).BeginInit();
			this.g72Settings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
			this.SuspendLayout();
			// 
			// View
			// 
			this.View.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
			this.View.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.View.Cursor = System.Windows.Forms.Cursors.Cross;
			this.View.Location = new System.Drawing.Point(12, 27);
			this.View.Name = "View";
			this.View.Size = new System.Drawing.Size(250, 500);
			this.View.TabIndex = 0;
			this.View.TabStop = false;
			this.View.Paint += new System.Windows.Forms.PaintEventHandler(this.View_Paint);
			this.View.MouseMove += new System.Windows.Forms.MouseEventHandler(this.View_MouseMove);
			// 
			// coordinatesLabel
			// 
			this.coordinatesLabel.AutoSize = true;
			this.coordinatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.coordinatesLabel.Location = new System.Drawing.Point(268, 507);
			this.coordinatesLabel.Name = "coordinatesLabel";
			this.coordinatesLabel.Size = new System.Drawing.Size(152, 20);
			this.coordinatesLabel.TabIndex = 1;
			this.coordinatesLabel.Text = "Coordinates Reader";
			// 
			// mainAppMenu
			// 
			this.mainAppMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.mainAppMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.settingsToolStripMenuItem,
            this.infoToolStripMenuItem});
			this.mainAppMenu.Location = new System.Drawing.Point(0, 0);
			this.mainAppMenu.Name = "mainAppMenu";
			this.mainAppMenu.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
			this.mainAppMenu.Size = new System.Drawing.Size(632, 24);
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
            this.changeExportFolderToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
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
			// visualizeSelector
			// 
			this.visualizeSelector.Controls.Add(this.profileVisualizeCheckBox);
			this.visualizeSelector.Controls.Add(this.dieVisualizeCheckBox);
			this.visualizeSelector.Controls.Add(this.axesVisualizeCheckBox);
			this.visualizeSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.visualizeSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.visualizeSelector.Location = new System.Drawing.Point(267, 393);
			this.visualizeSelector.Margin = new System.Windows.Forms.Padding(2);
			this.visualizeSelector.Name = "visualizeSelector";
			this.visualizeSelector.Padding = new System.Windows.Forms.Padding(2);
			this.visualizeSelector.Size = new System.Drawing.Size(163, 110);
			this.visualizeSelector.TabIndex = 3;
			this.visualizeSelector.TabStop = false;
			this.visualizeSelector.Text = "Visualize";
			// 
			// profileVisualizeCheckBox
			// 
			this.profileVisualizeCheckBox.AutoSize = true;
			this.profileVisualizeCheckBox.Checked = true;
			this.profileVisualizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.profileVisualizeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.profileVisualizeCheckBox.ForeColor = System.Drawing.Color.Black;
			this.profileVisualizeCheckBox.Location = new System.Drawing.Point(10, 81);
			this.profileVisualizeCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.profileVisualizeCheckBox.Name = "profileVisualizeCheckBox";
			this.profileVisualizeCheckBox.Size = new System.Drawing.Size(65, 20);
			this.profileVisualizeCheckBox.TabIndex = 2;
			this.profileVisualizeCheckBox.Text = "Profile";
			this.profileVisualizeCheckBox.UseVisualStyleBackColor = true;
			this.profileVisualizeCheckBox.CheckedChanged += new System.EventHandler(this.profileVisualizeCheckBox_CheckedChanged);
			// 
			// dieVisualizeCheckBox
			// 
			this.dieVisualizeCheckBox.AutoSize = true;
			this.dieVisualizeCheckBox.Checked = true;
			this.dieVisualizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.dieVisualizeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dieVisualizeCheckBox.ForeColor = System.Drawing.Color.Black;
			this.dieVisualizeCheckBox.Location = new System.Drawing.Point(10, 52);
			this.dieVisualizeCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.dieVisualizeCheckBox.Name = "dieVisualizeCheckBox";
			this.dieVisualizeCheckBox.Size = new System.Drawing.Size(48, 20);
			this.dieVisualizeCheckBox.TabIndex = 1;
			this.dieVisualizeCheckBox.Text = "Die";
			this.dieVisualizeCheckBox.UseVisualStyleBackColor = true;
			this.dieVisualizeCheckBox.CheckedChanged += new System.EventHandler(this.dieVisualizeCheckBox_CheckedChanged);
			// 
			// axesVisualizeCheckBox
			// 
			this.axesVisualizeCheckBox.AutoSize = true;
			this.axesVisualizeCheckBox.Checked = true;
			this.axesVisualizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.axesVisualizeCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.axesVisualizeCheckBox.ForeColor = System.Drawing.Color.Black;
			this.axesVisualizeCheckBox.Location = new System.Drawing.Point(10, 22);
			this.axesVisualizeCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.axesVisualizeCheckBox.Name = "axesVisualizeCheckBox";
			this.axesVisualizeCheckBox.Size = new System.Drawing.Size(57, 20);
			this.axesVisualizeCheckBox.TabIndex = 0;
			this.axesVisualizeCheckBox.Text = "Axes";
			this.axesVisualizeCheckBox.UseVisualStyleBackColor = true;
			this.axesVisualizeCheckBox.CheckedChanged += new System.EventHandler(this.axesVisualizeCheckBox_CheckedChanged);
			// 
			// copyrightsBanner
			// 
			this.copyrightsBanner.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.copyrightsBanner.Controls.Add(this.copyrights);
			this.copyrightsBanner.Controls.Add(this.banner);
			this.copyrightsBanner.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.copyrightsBanner.Location = new System.Drawing.Point(0, 533);
			this.copyrightsBanner.Name = "copyrightsBanner";
			this.copyrightsBanner.Size = new System.Drawing.Size(632, 95);
			this.copyrightsBanner.TabIndex = 4;
			// 
			// copyrights
			// 
			this.copyrights.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.copyrights.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.copyrights.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.copyrights.Location = new System.Drawing.Point(227, 78);
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
			this.banner.Size = new System.Drawing.Size(632, 74);
			this.banner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.banner.TabIndex = 0;
			this.banner.TabStop = false;
			// 
			// exportGCode
			// 
			this.exportGCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.exportGCode.Location = new System.Drawing.Point(457, 399);
			this.exportGCode.Name = "exportGCode";
			this.exportGCode.Size = new System.Drawing.Size(163, 74);
			this.exportGCode.TabIndex = 5;
			this.exportGCode.Text = "Generate G Code";
			this.exportGCode.UseVisualStyleBackColor = true;
			this.exportGCode.Click += new System.EventHandler(this.exportGCode_Click);
			// 
			// exportProgressBar
			// 
			this.exportProgressBar.Location = new System.Drawing.Point(457, 479);
			this.exportProgressBar.Name = "exportProgressBar";
			this.exportProgressBar.Size = new System.Drawing.Size(163, 24);
			this.exportProgressBar.TabIndex = 6;
			// 
			// g71Settings
			// 
			this.g71Settings.Controls.Add(this.feedRateInput);
			this.g71Settings.Controls.Add(this.zAllowanceInput);
			this.g71Settings.Controls.Add(this.xAllowanceInput);
			this.g71Settings.Controls.Add(this.retractValueInput);
			this.g71Settings.Controls.Add(this.depthOfCutInput);
			this.g71Settings.Controls.Add(this.feedRateLabel);
			this.g71Settings.Controls.Add(this.zAllowanceLabel);
			this.g71Settings.Controls.Add(this.xAllowanceLabel);
			this.g71Settings.Controls.Add(this.retractValueLabel);
			this.g71Settings.Controls.Add(this.depthOfCutLabel);
			this.g71Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g71Settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.g71Settings.Location = new System.Drawing.Point(267, 27);
			this.g71Settings.Name = "g71Settings";
			this.g71Settings.Size = new System.Drawing.Size(163, 174);
			this.g71Settings.TabIndex = 7;
			this.g71Settings.TabStop = false;
			this.g71Settings.Text = "G71 Roughing Cycle";
			// 
			// feedRateInput
			// 
			this.feedRateInput.DecimalPlaces = 2;
			this.feedRateInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.feedRateInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.feedRateInput.Location = new System.Drawing.Point(100, 140);
			this.feedRateInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.feedRateInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.feedRateInput.Name = "feedRateInput";
			this.feedRateInput.Size = new System.Drawing.Size(53, 26);
			this.feedRateInput.TabIndex = 9;
			this.feedRateInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.feedRateInput.ValueChanged += new System.EventHandler(this.feedRateInput_ValueChanged);
			// 
			// zAllowanceInput
			// 
			this.zAllowanceInput.DecimalPlaces = 2;
			this.zAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.zAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.zAllowanceInput.Location = new System.Drawing.Point(100, 110);
			this.zAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.zAllowanceInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.zAllowanceInput.Name = "zAllowanceInput";
			this.zAllowanceInput.Size = new System.Drawing.Size(53, 26);
			this.zAllowanceInput.TabIndex = 8;
			this.zAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.zAllowanceInput.ValueChanged += new System.EventHandler(this.zAllowanceInput_ValueChanged);
			// 
			// xAllowanceInput
			// 
			this.xAllowanceInput.DecimalPlaces = 2;
			this.xAllowanceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xAllowanceInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.xAllowanceInput.Location = new System.Drawing.Point(100, 80);
			this.xAllowanceInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.xAllowanceInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.xAllowanceInput.Name = "xAllowanceInput";
			this.xAllowanceInput.Size = new System.Drawing.Size(53, 26);
			this.xAllowanceInput.TabIndex = 7;
			this.xAllowanceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.xAllowanceInput.ValueChanged += new System.EventHandler(this.xAllowanceInput_ValueChanged);
			// 
			// retractValueInput
			// 
			this.retractValueInput.DecimalPlaces = 2;
			this.retractValueInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.retractValueInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.retractValueInput.Location = new System.Drawing.Point(100, 50);
			this.retractValueInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.retractValueInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.retractValueInput.Name = "retractValueInput";
			this.retractValueInput.Size = new System.Drawing.Size(53, 26);
			this.retractValueInput.TabIndex = 6;
			this.retractValueInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.retractValueInput.ValueChanged += new System.EventHandler(this.retractValueInput_ValueChanged);
			// 
			// depthOfCutInput
			// 
			this.depthOfCutInput.DecimalPlaces = 2;
			this.depthOfCutInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.depthOfCutInput.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.depthOfCutInput.Location = new System.Drawing.Point(100, 20);
			this.depthOfCutInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.depthOfCutInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.depthOfCutInput.Name = "depthOfCutInput";
			this.depthOfCutInput.Size = new System.Drawing.Size(53, 26);
			this.depthOfCutInput.TabIndex = 5;
			this.depthOfCutInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.depthOfCutInput.ValueChanged += new System.EventHandler(this.depthOfCutInput_ValueChanged);
			// 
			// feedRateLabel
			// 
			this.feedRateLabel.AutoSize = true;
			this.feedRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.feedRateLabel.ForeColor = System.Drawing.Color.Black;
			this.feedRateLabel.Location = new System.Drawing.Point(25, 145);
			this.feedRateLabel.Name = "feedRateLabel";
			this.feedRateLabel.Size = new System.Drawing.Size(69, 16);
			this.feedRateLabel.TabIndex = 4;
			this.feedRateLabel.Text = "Feed rate:";
			// 
			// zAllowanceLabel
			// 
			this.zAllowanceLabel.AutoSize = true;
			this.zAllowanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.zAllowanceLabel.ForeColor = System.Drawing.Color.Black;
			this.zAllowanceLabel.Location = new System.Drawing.Point(10, 115);
			this.zAllowanceLabel.Name = "zAllowanceLabel";
			this.zAllowanceLabel.Size = new System.Drawing.Size(84, 16);
			this.zAllowanceLabel.TabIndex = 3;
			this.zAllowanceLabel.Text = "Z Allowance:";
			// 
			// xAllowanceLabel
			// 
			this.xAllowanceLabel.AutoSize = true;
			this.xAllowanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xAllowanceLabel.ForeColor = System.Drawing.Color.Black;
			this.xAllowanceLabel.Location = new System.Drawing.Point(10, 85);
			this.xAllowanceLabel.Name = "xAllowanceLabel";
			this.xAllowanceLabel.Size = new System.Drawing.Size(84, 16);
			this.xAllowanceLabel.TabIndex = 2;
			this.xAllowanceLabel.Text = "X Allowance:";
			// 
			// retractValueLabel
			// 
			this.retractValueLabel.AutoSize = true;
			this.retractValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.retractValueLabel.ForeColor = System.Drawing.Color.Black;
			this.retractValueLabel.Location = new System.Drawing.Point(4, 55);
			this.retractValueLabel.Name = "retractValueLabel";
			this.retractValueLabel.Size = new System.Drawing.Size(90, 16);
			this.retractValueLabel.TabIndex = 1;
			this.retractValueLabel.Text = "Retract value:";
			// 
			// depthOfCutLabel
			// 
			this.depthOfCutLabel.AutoSize = true;
			this.depthOfCutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.depthOfCutLabel.ForeColor = System.Drawing.Color.Black;
			this.depthOfCutLabel.Location = new System.Drawing.Point(13, 25);
			this.depthOfCutLabel.Name = "depthOfCutLabel";
			this.depthOfCutLabel.Size = new System.Drawing.Size(81, 16);
			this.depthOfCutLabel.TabIndex = 0;
			this.depthOfCutLabel.Text = "Depth of cut:";
			// 
			// g72Settings
			// 
			this.g72Settings.Controls.Add(this.numericUpDown1);
			this.g72Settings.Controls.Add(this.numericUpDown2);
			this.g72Settings.Controls.Add(this.numericUpDown3);
			this.g72Settings.Controls.Add(this.numericUpDown4);
			this.g72Settings.Controls.Add(this.numericUpDown5);
			this.g72Settings.Controls.Add(this.label1);
			this.g72Settings.Controls.Add(this.label2);
			this.g72Settings.Controls.Add(this.label3);
			this.g72Settings.Controls.Add(this.label4);
			this.g72Settings.Controls.Add(this.label5);
			this.g72Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.g72Settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.g72Settings.Location = new System.Drawing.Point(267, 210);
			this.g72Settings.Name = "g72Settings";
			this.g72Settings.Size = new System.Drawing.Size(163, 174);
			this.g72Settings.TabIndex = 10;
			this.g72Settings.TabStop = false;
			this.g72Settings.Text = "G72 Facing Cycle";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 2;
			this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown1.Location = new System.Drawing.Point(100, 140);
			this.numericUpDown1.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(53, 26);
			this.numericUpDown1.TabIndex = 9;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.DecimalPlaces = 2;
			this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDown2.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown2.Location = new System.Drawing.Point(100, 110);
			this.numericUpDown2.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(53, 26);
			this.numericUpDown2.TabIndex = 8;
			this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.DecimalPlaces = 2;
			this.numericUpDown3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDown3.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown3.Location = new System.Drawing.Point(100, 80);
			this.numericUpDown3.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(53, 26);
			this.numericUpDown3.TabIndex = 7;
			this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			// 
			// numericUpDown4
			// 
			this.numericUpDown4.DecimalPlaces = 2;
			this.numericUpDown4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDown4.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown4.Location = new System.Drawing.Point(100, 50);
			this.numericUpDown4.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size(53, 26);
			this.numericUpDown4.TabIndex = 6;
			this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			// 
			// numericUpDown5
			// 
			this.numericUpDown5.DecimalPlaces = 2;
			this.numericUpDown5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDown5.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown5.Location = new System.Drawing.Point(100, 20);
			this.numericUpDown5.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numericUpDown5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown5.Name = "numericUpDown5";
			this.numericUpDown5.Size = new System.Drawing.Size(53, 26);
			this.numericUpDown5.TabIndex = 5;
			this.numericUpDown5.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(25, 145);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Feed rate:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(10, 115);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Z Allowance:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(10, 85);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "X Allowance:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(6, 55);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 16);
			this.label4.TabIndex = 1;
			this.label4.Text = "Retract value:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(13, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(81, 16);
			this.label5.TabIndex = 0;
			this.label5.Text = "Depth of cut:";
			// 
			// gCodeTextBox
			// 
			this.gCodeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
			this.gCodeTextBox.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.gCodeTextBox.Location = new System.Drawing.Point(457, 33);
			this.gCodeTextBox.Name = "gCodeTextBox";
			this.gCodeTextBox.ReadOnly = true;
			this.gCodeTextBox.Size = new System.Drawing.Size(163, 351);
			this.gCodeTextBox.TabIndex = 11;
			this.gCodeTextBox.Text = "";
			// 
			// MainApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.ClientSize = new System.Drawing.Size(632, 628);
			this.Controls.Add(this.gCodeTextBox);
			this.Controls.Add(this.g72Settings);
			this.Controls.Add(this.g71Settings);
			this.Controls.Add(this.exportProgressBar);
			this.Controls.Add(this.exportGCode);
			this.Controls.Add(this.copyrightsBanner);
			this.Controls.Add(this.visualizeSelector);
			this.Controls.Add(this.coordinatesLabel);
			this.Controls.Add(this.View);
			this.Controls.Add(this.mainAppMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mainAppMenu;
			this.MaximizeBox = false;
			this.Name = "MainApp";
			this.Text = "Alumat Tornio";
			this.Load += new System.EventHandler(this.MainApp_Load);
			((System.ComponentModel.ISupportInitialize)(this.View)).EndInit();
			this.mainAppMenu.ResumeLayout(false);
			this.mainAppMenu.PerformLayout();
			this.visualizeSelector.ResumeLayout(false);
			this.visualizeSelector.PerformLayout();
			this.copyrightsBanner.ResumeLayout(false);
			this.copyrightsBanner.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.banner)).EndInit();
			this.g71Settings.ResumeLayout(false);
			this.g71Settings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.feedRateInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.zAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.retractValueInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.depthOfCutInput)).EndInit();
			this.g72Settings.ResumeLayout(false);
			this.g72Settings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox View;
		private System.Windows.Forms.Label coordinatesLabel;
		private System.Windows.Forms.MenuStrip mainAppMenu;
		private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
		private System.Windows.Forms.GroupBox visualizeSelector;
		private System.Windows.Forms.CheckBox dieVisualizeCheckBox;
		private System.Windows.Forms.CheckBox axesVisualizeCheckBox;
		private System.Windows.Forms.Panel copyrightsBanner;
		private System.Windows.Forms.PictureBox banner;
		private System.Windows.Forms.TextBox copyrights;
		private System.Windows.Forms.ToolStripMenuItem fileDxfMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tornituraToolStripMenuItem;
		private System.Windows.Forms.CheckBox profileVisualizeCheckBox;
		private System.Windows.Forms.Button exportGCode;
		private System.Windows.Forms.ProgressBar exportProgressBar;
		private System.Windows.Forms.GroupBox g71Settings;
		private System.Windows.Forms.Label feedRateLabel;
		private System.Windows.Forms.Label zAllowanceLabel;
		private System.Windows.Forms.Label xAllowanceLabel;
		private System.Windows.Forms.Label retractValueLabel;
		private System.Windows.Forms.Label depthOfCutLabel;
		private System.Windows.Forms.NumericUpDown feedRateInput;
		private System.Windows.Forms.NumericUpDown zAllowanceInput;
		private System.Windows.Forms.NumericUpDown xAllowanceInput;
		private System.Windows.Forms.NumericUpDown retractValueInput;
		private System.Windows.Forms.NumericUpDown depthOfCutInput;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeDXFFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem changeExportFolderToolStripMenuItem;
		private System.Windows.Forms.GroupBox g72Settings;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.NumericUpDown numericUpDown2;
		private System.Windows.Forms.NumericUpDown numericUpDown3;
		private System.Windows.Forms.NumericUpDown numericUpDown4;
		private System.Windows.Forms.NumericUpDown numericUpDown5;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem g71RoughingCycleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem g72FacingCycleToolStripMenuItem;
		private System.Windows.Forms.RichTextBox gCodeTextBox;
	}
}