
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
			this.View = new System.Windows.Forms.PictureBox();
			this.coordinatesLabel = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.loadDXFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.visualizeSelector = new System.Windows.Forms.GroupBox();
			this.machiningVisualizeCheckBox = new System.Windows.Forms.CheckBox();
			this.dieVisualizeCheckBox = new System.Windows.Forms.CheckBox();
			this.axesVisualizeCheckBox = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.visualizeSelector.SuspendLayout();
			this.SuspendLayout();
			// 
			// View
			// 
			this.View.BackColor = System.Drawing.SystemColors.WindowText;
			this.View.Location = new System.Drawing.Point(24, 52);
			this.View.Margin = new System.Windows.Forms.Padding(6);
			this.View.Name = "View";
			this.View.Size = new System.Drawing.Size(500, 962);
			this.View.TabIndex = 0;
			this.View.TabStop = false;
			this.View.Paint += new System.Windows.Forms.PaintEventHandler(this.View_Paint);
			this.View.MouseMove += new System.Windows.Forms.MouseEventHandler(this.View_MouseMove);
			// 
			// coordinatesLabel
			// 
			this.coordinatesLabel.AutoSize = true;
			this.coordinatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.coordinatesLabel.Location = new System.Drawing.Point(24, 1027);
			this.coordinatesLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.coordinatesLabel.Name = "coordinatesLabel";
			this.coordinatesLabel.Size = new System.Drawing.Size(320, 37);
			this.coordinatesLabel.TabIndex = 1;
			this.coordinatesLabel.Text = "Coordinates Reader";
			// 
			// menuStrip1
			// 
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDXFToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1264, 48);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// loadDXFToolStripMenuItem
			// 
			this.loadDXFToolStripMenuItem.Name = "loadDXFToolStripMenuItem";
			this.loadDXFToolStripMenuItem.Size = new System.Drawing.Size(135, 36);
			this.loadDXFToolStripMenuItem.Text = "Load DXF";
			this.loadDXFToolStripMenuItem.Click += new System.EventHandler(this.loadDXFToolStripMenuItem_Click);
			// 
			// visualizeSelector
			// 
			this.visualizeSelector.Controls.Add(this.machiningVisualizeCheckBox);
			this.visualizeSelector.Controls.Add(this.dieVisualizeCheckBox);
			this.visualizeSelector.Controls.Add(this.axesVisualizeCheckBox);
			this.visualizeSelector.Location = new System.Drawing.Point(552, 52);
			this.visualizeSelector.Name = "visualizeSelector";
			this.visualizeSelector.Size = new System.Drawing.Size(292, 246);
			this.visualizeSelector.TabIndex = 3;
			this.visualizeSelector.TabStop = false;
			this.visualizeSelector.Text = "Visualize";
			// 
			// machiningVisualizeCheckBox
			// 
			this.machiningVisualizeCheckBox.AutoSize = true;
			this.machiningVisualizeCheckBox.Checked = true;
			this.machiningVisualizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.machiningVisualizeCheckBox.Location = new System.Drawing.Point(30, 169);
			this.machiningVisualizeCheckBox.Name = "machiningVisualizeCheckBox";
			this.machiningVisualizeCheckBox.Size = new System.Drawing.Size(205, 29);
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
			this.dieVisualizeCheckBox.Location = new System.Drawing.Point(30, 109);
			this.dieVisualizeCheckBox.Name = "dieVisualizeCheckBox";
			this.dieVisualizeCheckBox.Size = new System.Drawing.Size(76, 29);
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
			this.axesVisualizeCheckBox.Location = new System.Drawing.Point(30, 51);
			this.axesVisualizeCheckBox.Name = "axesVisualizeCheckBox";
			this.axesVisualizeCheckBox.Size = new System.Drawing.Size(92, 29);
			this.axesVisualizeCheckBox.TabIndex = 0;
			this.axesVisualizeCheckBox.Text = "Axes";
			this.axesVisualizeCheckBox.UseVisualStyleBackColor = true;
			this.axesVisualizeCheckBox.CheckedChanged += new System.EventHandler(this.axesVisualizeCheckBox_CheckedChanged);
			// 
			// MainApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 1069);
			this.Controls.Add(this.visualizeSelector);
			this.Controls.Add(this.coordinatesLabel);
			this.Controls.Add(this.View);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(6);
			this.MaximizeBox = false;
			this.Name = "MainApp";
			this.Text = "MainApp";
			((System.ComponentModel.ISupportInitialize)(this.View)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.visualizeSelector.ResumeLayout(false);
			this.visualizeSelector.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox View;
		private System.Windows.Forms.Label coordinatesLabel;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem loadDXFToolStripMenuItem;
		private System.Windows.Forms.GroupBox visualizeSelector;
		private System.Windows.Forms.CheckBox machiningVisualizeCheckBox;
		private System.Windows.Forms.CheckBox dieVisualizeCheckBox;
		private System.Windows.Forms.CheckBox axesVisualizeCheckBox;
	}
}