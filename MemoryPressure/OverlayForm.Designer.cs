// OverlayForm.Designer.cs
// This file contains the auto-generated code for the overlay form's UI components.

namespace MemoryPressure
{
    partial class OverlayForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverlayForm));
            this.lblOverlayPercent = new System.Windows.Forms.Label();
            this.lblOverlayUsedRam = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showMainWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOverlayPercent
            // 
            this.lblOverlayPercent.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblOverlayPercent.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverlayPercent.ForeColor = System.Drawing.Color.Lime;
            this.lblOverlayPercent.Location = new System.Drawing.Point(0, 0);
            this.lblOverlayPercent.Name = "lblOverlayPercent";
            this.lblOverlayPercent.Size = new System.Drawing.Size(284, 45);
            this.lblOverlayPercent.TabIndex = 0;
            this.lblOverlayPercent.Text = "---%";
            this.lblOverlayPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOverlayPercent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseDown);
            this.lblOverlayPercent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseMove);
            this.lblOverlayPercent.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseUp);
            // 
            // lblOverlayUsedRam
            // 
            this.lblOverlayUsedRam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOverlayUsedRam.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverlayUsedRam.ForeColor = System.Drawing.Color.White;
            this.lblOverlayUsedRam.Location = new System.Drawing.Point(0, 45);
            this.lblOverlayUsedRam.Name = "lblOverlayUsedRam";
            this.lblOverlayUsedRam.Size = new System.Drawing.Size(284, 36);
            this.lblOverlayUsedRam.TabIndex = 1;
            this.lblOverlayUsedRam.Text = "-- GB / -- GB";
            this.lblOverlayUsedRam.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblOverlayUsedRam.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseDown);
            this.lblOverlayUsedRam.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseMove);
            this.lblOverlayUsedRam.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMainWindowToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 52);
            // 
            // showMainWindowToolStripMenuItem
            // 
            this.showMainWindowToolStripMenuItem.Name = "showMainWindowToolStripMenuItem";
            this.showMainWindowToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.showMainWindowToolStripMenuItem.Text = "Show Main Window";
            this.showMainWindowToolStripMenuItem.Click += new System.EventHandler(this.showMainWindowToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // OverlayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 81);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lblOverlayUsedRam);
            this.Controls.Add(this.lblOverlayPercent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OverlayForm";
            this.Text = "Memory Overlay";
            this.Load += new System.EventHandler(this.OverlayForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OverlayForm_MouseUp);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblOverlayPercent;
        private System.Windows.Forms.Label lblOverlayUsedRam;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showMainWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}
