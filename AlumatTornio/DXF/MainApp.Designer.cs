
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
			this.depthOfCutLabel = new System.Windows.Forms.Label();
			this.retractValueLabel = new System.Windows.Forms.Label();
			this.xAllowanceLabel = new System.Windows.Forms.Label();
			this.zAllowanceLabel = new System.Windows.Forms.Label();
			this.feedRateLabel = new System.Windows.Forms.Label();
			MainApp.depthOfCutInput = new System.Windows.Forms.NumericUpDown();
			MainApp.retractValueInput = new System.Windows.Forms.NumericUpDown();
			MainApp.xAllowanceInput = new System.Windows.Forms.NumericUpDown();
			MainApp.zAllowanceValue = new System.Windows.Forms.NumericUpDown();
			MainApp.feedRateInput = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
			this.mainAppMenu.SuspendLayout();
			this.visualizeSelector.SuspendLayout();
			this.copyrightsBanner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.banner)).BeginInit();
			this.g71Settings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(MainApp.depthOfCutInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(MainApp.retractValueInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(MainApp.xAllowanceInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(MainApp.zAllowanceValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(MainApp.feedRateInput)).BeginInit();
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
            this.fileMenuItem});
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
			// visualizeSelector
			// 
			this.visualizeSelector.Controls.Add(this.profileVisualizeCheckBox);
			this.visualizeSelector.Controls.Add(this.dieVisualizeCheckBox);
			this.visualizeSelector.Controls.Add(this.axesVisualizeCheckBox);
			this.visualizeSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.visualizeSelector.Location = new System.Drawing.Point(267, 404);
			this.visualizeSelector.Margin = new System.Windows.Forms.Padding(2);
			this.visualizeSelector.Name = "visualizeSelector";
			this.visualizeSelector.Padding = new System.Windows.Forms.Padding(2);
			this.visualizeSelector.Size = new System.Drawing.Size(153, 99);
			this.visualizeSelector.TabIndex = 3;
			this.visualizeSelector.TabStop = false;
			this.visualizeSelector.Text = "Visualize";
			// 
			// profileVisualizeCheckBox
			// 
			this.profileVisualizeCheckBox.AutoSize = true;
			this.profileVisualizeCheckBox.Checked = true;
			this.profileVisualizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.profileVisualizeCheckBox.ForeColor = System.Drawing.Color.Black;
			this.profileVisualizeCheckBox.Location = new System.Drawing.Point(10, 78);
			this.profileVisualizeCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.profileVisualizeCheckBox.Name = "profileVisualizeCheckBox";
			this.profileVisualizeCheckBox.Size = new System.Drawing.Size(55, 17);
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
			this.dieVisualizeCheckBox.ForeColor = System.Drawing.Color.Black;
			this.dieVisualizeCheckBox.Location = new System.Drawing.Point(10, 47);
			this.dieVisualizeCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.dieVisualizeCheckBox.Name = "dieVisualizeCheckBox";
			this.dieVisualizeCheckBox.Size = new System.Drawing.Size(42, 17);
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
			this.axesVisualizeCheckBox.ForeColor = System.Drawing.Color.Black;
			this.axesVisualizeCheckBox.Location = new System.Drawing.Point(10, 17);
			this.axesVisualizeCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.axesVisualizeCheckBox.Name = "axesVisualizeCheckBox";
			this.axesVisualizeCheckBox.Size = new System.Drawing.Size(49, 17);
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
			this.exportGCode.Location = new System.Drawing.Point(426, 410);
			this.exportGCode.Name = "exportGCode";
			this.exportGCode.Size = new System.Drawing.Size(194, 93);
			this.exportGCode.TabIndex = 5;
			this.exportGCode.Text = "Export G Code";
			this.exportGCode.UseVisualStyleBackColor = true;
			this.exportGCode.Click += new System.EventHandler(this.exportGCode_Click);
			// 
			// exportProgressBar
			// 
			this.exportProgressBar.Location = new System.Drawing.Point(426, 507);
			this.exportProgressBar.Name = "exportProgressBar";
			this.exportProgressBar.Size = new System.Drawing.Size(194, 20);
			this.exportProgressBar.TabIndex = 6;
			// 
			// g71Settings
			// 
			this.g71Settings.Controls.Add(MainApp.feedRateInput);
			this.g71Settings.Controls.Add(MainApp.zAllowanceValue);
			this.g71Settings.Controls.Add(MainApp.xAllowanceInput);
			this.g71Settings.Controls.Add(MainApp.retractValueInput);
			this.g71Settings.Controls.Add(MainApp.depthOfCutInput);
			this.g71Settings.Controls.Add(this.feedRateLabel);
			this.g71Settings.Controls.Add(this.zAllowanceLabel);
			this.g71Settings.Controls.Add(this.xAllowanceLabel);
			this.g71Settings.Controls.Add(this.retractValueLabel);
			this.g71Settings.Controls.Add(this.depthOfCutLabel);
			this.g71Settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.g71Settings.Location = new System.Drawing.Point(267, 27);
			this.g71Settings.Name = "g71Settings";
			this.g71Settings.Size = new System.Drawing.Size(153, 172);
			this.g71Settings.TabIndex = 7;
			this.g71Settings.TabStop = false;
			this.g71Settings.Text = "G71 Roughing Cycle";
			// 
			// depthOfCutLabel
			// 
			this.depthOfCutLabel.AutoSize = true;
			this.depthOfCutLabel.ForeColor = System.Drawing.Color.Black;
			this.depthOfCutLabel.Location = new System.Drawing.Point(15, 20);
			this.depthOfCutLabel.Name = "depthOfCutLabel";
			this.depthOfCutLabel.Size = new System.Drawing.Size(66, 13);
			this.depthOfCutLabel.TabIndex = 0;
			this.depthOfCutLabel.Text = "Depth of cut";
			// 
			// retractValueLabel
			// 
			this.retractValueLabel.AutoSize = true;
			this.retractValueLabel.ForeColor = System.Drawing.Color.Black;
			this.retractValueLabel.Location = new System.Drawing.Point(10, 50);
			this.retractValueLabel.Name = "retractValueLabel";
			this.retractValueLabel.Size = new System.Drawing.Size(71, 13);
			this.retractValueLabel.TabIndex = 1;
			this.retractValueLabel.Text = "Retract value";
			// 
			// xAllowanceLabel
			// 
			this.xAllowanceLabel.AutoSize = true;
			this.xAllowanceLabel.ForeColor = System.Drawing.Color.Black;
			this.xAllowanceLabel.Location = new System.Drawing.Point(15, 80);
			this.xAllowanceLabel.Name = "xAllowanceLabel";
			this.xAllowanceLabel.Size = new System.Drawing.Size(66, 13);
			this.xAllowanceLabel.TabIndex = 2;
			this.xAllowanceLabel.Text = "X Allowance";
			// 
			// zAllowanceLabel
			// 
			this.zAllowanceLabel.AutoSize = true;
			this.zAllowanceLabel.ForeColor = System.Drawing.Color.Black;
			this.zAllowanceLabel.Location = new System.Drawing.Point(15, 110);
			this.zAllowanceLabel.Name = "zAllowanceLabel";
			this.zAllowanceLabel.Size = new System.Drawing.Size(66, 13);
			this.zAllowanceLabel.TabIndex = 3;
			this.zAllowanceLabel.Text = "Z Allowance";
			// 
			// feedRateLabel
			// 
			this.feedRateLabel.AutoSize = true;
			this.feedRateLabel.ForeColor = System.Drawing.Color.Black;
			this.feedRateLabel.Location = new System.Drawing.Point(29, 140);
			this.feedRateLabel.Name = "feedRateLabel";
			this.feedRateLabel.Size = new System.Drawing.Size(52, 13);
			this.feedRateLabel.TabIndex = 4;
			this.feedRateLabel.Text = "Feed rate";
			// 
			// depthOfCutInput
			// 
			MainApp.depthOfCutInput.DecimalPlaces = 1;
			MainApp.depthOfCutInput.Increment = new decimal(new int[] {1, 0, 0, 65536});
			MainApp.depthOfCutInput.Location = new System.Drawing.Point(87, 18);
			MainApp.depthOfCutInput.Maximum = new decimal(new int[] {3, 0, 0, 0});
			MainApp.depthOfCutInput.Name = "depthOfCutInput";
			MainApp.depthOfCutInput.Size = new System.Drawing.Size(48, 20);
			MainApp.depthOfCutInput.TabIndex = 8;
			// 
			// retractValueInput
			// 
			MainApp.retractValueInput.DecimalPlaces = 1;
			MainApp.retractValueInput.Increment = new decimal(new int[] {1, 0, 0, 65536});
			MainApp.retractValueInput.Location = new System.Drawing.Point(87, 48);
			MainApp.retractValueInput.Maximum = new decimal(new int[] {3, 0, 0, 0});
			MainApp.retractValueInput.Name = "retractValueInput";
			MainApp.retractValueInput.Size = new System.Drawing.Size(48, 20);
			MainApp.retractValueInput.TabIndex = 9;
			// 
			// xAllowanceInput
			// 
			MainApp.xAllowanceInput.DecimalPlaces = 1;
			MainApp.xAllowanceInput.Increment = new decimal(new int[] {1, 0, 0, 65536});
			MainApp.xAllowanceInput.Location = new System.Drawing.Point(87, 78);
			MainApp.xAllowanceInput.Maximum = new decimal(new int[] {3, 0, 0, 0});
			MainApp.xAllowanceInput.Name = "xAllowanceInput";
			MainApp.xAllowanceInput.Size = new System.Drawing.Size(48, 20);
			MainApp.xAllowanceInput.TabIndex = 10;
			// 
			// zAllowanceValue
			// 
			MainApp.zAllowanceValue.DecimalPlaces = 1;
			MainApp.zAllowanceValue.Increment = new decimal(new int[] {1, 0, 0, 65536});
			MainApp.zAllowanceValue.Location = new System.Drawing.Point(87, 108);
			MainApp.zAllowanceValue.Maximum = new decimal(new int[] {3, 0, 0, 0});
			MainApp.zAllowanceValue.Name = "zAllowanceValue";
			MainApp.zAllowanceValue.Size = new System.Drawing.Size(48, 20);
			MainApp.zAllowanceValue.TabIndex = 11;
			// 
			// feedRateInput
			// 
			MainApp.feedRateInput.DecimalPlaces = 1;
			MainApp.feedRateInput.Increment = new decimal(new int[] {1, 0, 0, 65536});
			MainApp.feedRateInput.Location = new System.Drawing.Point(87, 138);
			MainApp.feedRateInput.Maximum = new decimal(new int[] {3, 0, 0, 0});
			MainApp.feedRateInput.Name = "feedRateInput";
			MainApp.feedRateInput.Size = new System.Drawing.Size(48, 20);
			MainApp.feedRateInput.TabIndex = 12;
			// 
			// MainApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.ClientSize = new System.Drawing.Size(632, 628);
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
			this.Text = "MainApp";
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
			((System.ComponentModel.ISupportInitialize)(MainApp.depthOfCutInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(MainApp.retractValueInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(MainApp.xAllowanceInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(MainApp.zAllowanceValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(MainApp.feedRateInput)).EndInit();
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
		public static System.Windows.Forms.NumericUpDown feedRateInput;
		public static System.Windows.Forms.NumericUpDown zAllowanceValue;
		public static System.Windows.Forms.NumericUpDown xAllowanceInput;
		public static System.Windows.Forms.NumericUpDown retractValueInput;
		public static System.Windows.Forms.NumericUpDown depthOfCutInput;
		private System.Windows.Forms.Label feedRateLabel;
		private System.Windows.Forms.Label zAllowanceLabel;
		private System.Windows.Forms.Label xAllowanceLabel;
		private System.Windows.Forms.Label retractValueLabel;
		private System.Windows.Forms.Label depthOfCutLabel;
	}
}