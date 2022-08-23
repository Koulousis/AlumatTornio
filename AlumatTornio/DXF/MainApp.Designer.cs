
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
			this.coordinates = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.loadDXFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// View
			// 
			this.View.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.View.BackColor = System.Drawing.SystemColors.Window;
			this.View.Location = new System.Drawing.Point(24, 52);
			this.View.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.View.Name = "View";
			this.View.Size = new System.Drawing.Size(1528, 765);
			this.View.TabIndex = 0;
			this.View.TabStop = false;
			this.View.SizeChanged += new System.EventHandler(this.View_SizeChanged);
			this.View.Paint += new System.Windows.Forms.PaintEventHandler(this.View_Paint);
			this.View.MouseMove += new System.Windows.Forms.MouseEventHandler(this.View_MouseMove);
			// 
			// coordinates
			// 
			this.coordinates.AutoSize = true;
			this.coordinates.Location = new System.Drawing.Point(24, 823);
			this.coordinates.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.coordinates.Name = "coordinates";
			this.coordinates.Size = new System.Drawing.Size(204, 25);
			this.coordinates.TabIndex = 1;
			this.coordinates.Text = "Coordinates Reader";
			// 
			// menuStrip1
			// 
			this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadDXFToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
			this.menuStrip1.Size = new System.Drawing.Size(1576, 40);
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
			// MainApp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1576, 873);
			this.Controls.Add(this.coordinates);
			this.Controls.Add(this.View);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			this.Name = "MainApp";
			this.Text = "MainApp";
			((System.ComponentModel.ISupportInitialize)(this.View)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox View;
		private System.Windows.Forms.Label coordinates;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem loadDXFToolStripMenuItem;
	}
}