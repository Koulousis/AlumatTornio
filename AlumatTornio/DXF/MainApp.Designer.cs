
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
			this.scansVisualizeCheckBox = new System.Windows.Forms.CheckBox();
			this.machiningVisualizeCheckBox = new System.Windows.Forms.CheckBox();
			this.dieVisualizeCheckBox = new System.Windows.Forms.CheckBox();
			this.axesVisualizeCheckBox = new System.Windows.Forms.CheckBox();
			this.copyrightsBanner = new System.Windows.Forms.Panel();
			this.copyrights = new System.Windows.Forms.TextBox();
			this.banner = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
			this.mainAppMenu.SuspendLayout();
			this.visualizeSelector.SuspendLayout();
			this.copyrightsBanner.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.banner)).BeginInit();
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
			this.visualizeSelector.Controls.Add(this.scansVisualizeCheckBox);
			this.visualizeSelector.Controls.Add(this.machiningVisualizeCheckBox);
			this.visualizeSelector.Controls.Add(this.dieVisualizeCheckBox);
			this.visualizeSelector.Controls.Add(this.axesVisualizeCheckBox);
			this.visualizeSelector.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
			this.visualizeSelector.Location = new System.Drawing.Point(267, 353);
			this.visualizeSelector.Margin = new System.Windows.Forms.Padding(2);
			this.visualizeSelector.Name = "visualizeSelector";
			this.visualizeSelector.Padding = new System.Windows.Forms.Padding(2);
			this.visualizeSelector.Size = new System.Drawing.Size(146, 150);
			this.visualizeSelector.TabIndex = 3;
			this.visualizeSelector.TabStop = false;
			this.visualizeSelector.Text = "Visualize";
			// 
			// scansVisualizeCheckBox
			// 
			this.scansVisualizeCheckBox.AutoSize = true;
			this.scansVisualizeCheckBox.ForeColor = System.Drawing.Color.Black;
			this.scansVisualizeCheckBox.Location = new System.Drawing.Point(15, 118);
			this.scansVisualizeCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.scansVisualizeCheckBox.Name = "scansVisualizeCheckBox";
			this.scansVisualizeCheckBox.Size = new System.Drawing.Size(108, 17);
			this.scansVisualizeCheckBox.TabIndex = 3;
			this.scansVisualizeCheckBox.Text = "Machining Scans";
			this.scansVisualizeCheckBox.UseVisualStyleBackColor = true;
			this.scansVisualizeCheckBox.CheckedChanged += new System.EventHandler(this.scansVisualizeCheckBox_CheckedChanged);
			// 
			// machiningVisualizeCheckBox
			// 
			this.machiningVisualizeCheckBox.AutoSize = true;
			this.machiningVisualizeCheckBox.ForeColor = System.Drawing.Color.Black;
			this.machiningVisualizeCheckBox.Location = new System.Drawing.Point(15, 88);
			this.machiningVisualizeCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.machiningVisualizeCheckBox.Name = "machiningVisualizeCheckBox";
			this.machiningVisualizeCheckBox.Size = new System.Drawing.Size(105, 17);
			this.machiningVisualizeCheckBox.TabIndex = 2;
			this.machiningVisualizeCheckBox.Text = "Machining Areas";
			this.machiningVisualizeCheckBox.UseVisualStyleBackColor = true;
			this.machiningVisualizeCheckBox.CheckedChanged += new System.EventHandler(this.machiningVisualizeCheckBox_CheckedChanged);
			// 
			// dieVisualizeCheckBox
			// 
			this.dieVisualizeCheckBox.AutoSize = true;
			this.dieVisualizeCheckBox.Checked = true;
			this.dieVisualizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.dieVisualizeCheckBox.ForeColor = System.Drawing.Color.Black;
			this.dieVisualizeCheckBox.Location = new System.Drawing.Point(15, 57);
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
			this.axesVisualizeCheckBox.Location = new System.Drawing.Point(15, 27);
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
			// MainApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.WindowFrame;
			this.ClientSize = new System.Drawing.Size(632, 628);
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
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox View;
		private System.Windows.Forms.Label coordinatesLabel;
		private System.Windows.Forms.MenuStrip mainAppMenu;
		private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
		private System.Windows.Forms.GroupBox visualizeSelector;
		private System.Windows.Forms.CheckBox machiningVisualizeCheckBox;
		private System.Windows.Forms.CheckBox dieVisualizeCheckBox;
		private System.Windows.Forms.CheckBox axesVisualizeCheckBox;
		private System.Windows.Forms.CheckBox scansVisualizeCheckBox;
		private System.Windows.Forms.Panel copyrightsBanner;
		private System.Windows.Forms.PictureBox banner;
		private System.Windows.Forms.TextBox copyrights;
		private System.Windows.Forms.ToolStripMenuItem fileDxfMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tornituraToolStripMenuItem;
	}
}