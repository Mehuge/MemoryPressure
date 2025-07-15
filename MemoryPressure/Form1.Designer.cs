// Form1.Designer.cs
// This file contains the auto-generated code for the form's UI components.
// Updated to include the "Hold Memory" checkbox.

namespace MemoryPressure
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTargetMemory = new System.Windows.Forms.Label();
            this.numTargetMemory = new System.Windows.Forms.NumericUpDown();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.lblCurrentMemory = new System.Windows.Forms.Label();
            this.gbStats = new System.Windows.Forms.GroupBox();
            this.lblAppMemValue = new System.Windows.Forms.Label();
            this.lblAppMemLabel = new System.Windows.Forms.Label();
            this.lblAppBlocksValue = new System.Windows.Forms.Label();
            this.lblAppBlocksLabel = new System.Windows.Forms.Label();
            this.lblTotalRamValue = new System.Windows.Forms.Label();
            this.lblTotalRamLabel = new System.Windows.Forms.Label();
            this.chkHoldMemory = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetMemory)).BeginInit();
            this.gbStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTargetMemory
            // 
            this.lblTargetMemory.AutoSize = true;
            this.lblTargetMemory.BackColor = System.Drawing.Color.Transparent;
            this.lblTargetMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetMemory.ForeColor = System.Drawing.Color.White;
            this.lblTargetMemory.Location = new System.Drawing.Point(22, 24);
            this.lblTargetMemory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTargetMemory.Name = "lblTargetMemory";
            this.lblTargetMemory.Size = new System.Drawing.Size(236, 20);
            this.lblTargetMemory.TabIndex = 0;
            this.lblTargetMemory.Text = "Target Memory Usage (%):";
            // 
            // numTargetMemory
            // 
            this.numTargetMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTargetMemory.Location = new System.Drawing.Point(234, 22);
            this.numTargetMemory.Margin = new System.Windows.Forms.Padding(2);
            this.numTargetMemory.Name = "numTargetMemory";
            this.numTargetMemory.Size = new System.Drawing.Size(90, 26);
            this.numTargetMemory.TabIndex = 1;
            this.numTargetMemory.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // btnStartStop
            // 
            this.btnStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStop.Location = new System.Drawing.Point(50, 230);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(237, 32);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // lblCurrentMemory
            // 
            this.lblCurrentMemory.AutoSize = true;
            this.lblCurrentMemory.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentMemory.ForeColor = System.Drawing.Color.White;
            this.lblCurrentMemory.Location = new System.Drawing.Point(22, 61);
            this.lblCurrentMemory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentMemory.Name = "lblCurrentMemory";
            this.lblCurrentMemory.Size = new System.Drawing.Size(302, 25);
            this.lblCurrentMemory.TabIndex = 3;
            this.lblCurrentMemory.Text = "Current Physical Memory: --%";
            // 
            // gbStats
            // 
            this.gbStats.BackColor = System.Drawing.Color.Transparent;
            this.gbStats.Controls.Add(this.lblAppMemValue);
            this.gbStats.Controls.Add(this.lblAppMemLabel);
            this.gbStats.Controls.Add(this.lblAppBlocksValue);
            this.gbStats.Controls.Add(this.lblAppBlocksLabel);
            this.gbStats.Controls.Add(this.lblTotalRamValue);
            this.gbStats.Controls.Add(this.lblTotalRamLabel);
            this.gbStats.ForeColor = System.Drawing.Color.White;
            this.gbStats.Location = new System.Drawing.Point(50, 93);
            this.gbStats.Margin = new System.Windows.Forms.Padding(2);
            this.gbStats.Name = "gbStats";
            this.gbStats.Padding = new System.Windows.Forms.Padding(2);
            this.gbStats.Size = new System.Drawing.Size(237, 98);
            this.gbStats.TabIndex = 4;
            this.gbStats.TabStop = false;
            this.gbStats.Text = "System && App Statistics";
            // 
            // lblAppMemValue
            // 
            this.lblAppMemValue.AutoSize = true;
            this.lblAppMemValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppMemValue.Location = new System.Drawing.Point(142, 69);
            this.lblAppMemValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppMemValue.Name = "lblAppMemValue";
            this.lblAppMemValue.Size = new System.Drawing.Size(47, 18);
            this.lblAppMemValue.TabIndex = 5;
            this.lblAppMemValue.Text = "0 MB";
            // 
            // lblAppMemLabel
            // 
            this.lblAppMemLabel.AutoSize = true;
            this.lblAppMemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppMemLabel.Location = new System.Drawing.Point(11, 69);
            this.lblAppMemLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppMemLabel.Name = "lblAppMemLabel";
            this.lblAppMemLabel.Size = new System.Drawing.Size(160, 18);
            this.lblAppMemLabel.TabIndex = 4;
            this.lblAppMemLabel.Text = "App Allocated Memory:";
            // 
            // lblAppBlocksValue
            // 
            this.lblAppBlocksValue.AutoSize = true;
            this.lblAppBlocksValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppBlocksValue.Location = new System.Drawing.Point(142, 47);
            this.lblAppBlocksValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppBlocksValue.Name = "lblAppBlocksValue";
            this.lblAppBlocksValue.Size = new System.Drawing.Size(17, 18);
            this.lblAppBlocksValue.TabIndex = 3;
            this.lblAppBlocksValue.Text = "0";
            // 
            // lblAppBlocksLabel
            // 
            this.lblAppBlocksLabel.AutoSize = true;
            this.lblAppBlocksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppBlocksLabel.Location = new System.Drawing.Point(11, 47);
            this.lblAppBlocksLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppBlocksLabel.Name = "lblAppBlocksLabel";
            this.lblAppBlocksLabel.Size = new System.Drawing.Size(151, 18);
            this.lblAppBlocksLabel.TabIndex = 2;
            this.lblAppBlocksLabel.Text = "App Allocated Blocks:";
            // 
            // lblTotalRamValue
            // 
            this.lblTotalRamValue.AutoSize = true;
            this.lblTotalRamValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRamValue.Location = new System.Drawing.Point(142, 25);
            this.lblTotalRamValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRamValue.Name = "lblTotalRamValue";
            this.lblTotalRamValue.Size = new System.Drawing.Size(50, 18);
            this.lblTotalRamValue.TabIndex = 1;
            this.lblTotalRamValue.Text = "-- MB";
            // 
            // lblTotalRamLabel
            // 
            this.lblTotalRamLabel.AutoSize = true;
            this.lblTotalRamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRamLabel.Location = new System.Drawing.Point(11, 25);
            this.lblTotalRamLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRamLabel.Name = "lblTotalRamLabel";
            this.lblTotalRamLabel.Size = new System.Drawing.Size(136, 18);
            this.lblTotalRamLabel.TabIndex = 0;
            this.lblTotalRamLabel.Text = "Total System RAM:";
            // 
            // chkHoldMemory
            // 
            this.chkHoldMemory.AutoSize = true;
            this.chkHoldMemory.BackColor = System.Drawing.Color.Transparent;
            this.chkHoldMemory.ForeColor = System.Drawing.Color.White;
            this.chkHoldMemory.Location = new System.Drawing.Point(54, 199);
            this.chkHoldMemory.Margin = new System.Windows.Forms.Padding(2);
            this.chkHoldMemory.Name = "chkHoldMemory";
            this.chkHoldMemory.Size = new System.Drawing.Size(255, 19);
            this.chkHoldMemory.TabIndex = 2;
            this.chkHoldMemory.Text = "Hold memory above target (don\'t release)";
            this.chkHoldMemory.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(337, 308);
            this.Controls.Add(this.chkHoldMemory);
            this.Controls.Add(this.gbStats);
            this.Controls.Add(this.lblCurrentMemory);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.numTargetMemory);
            this.Controls.Add(this.lblTargetMemory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Memory Pressure";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTargetMemory)).EndInit();
            this.gbStats.ResumeLayout(false);
            this.gbStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTargetMemory;
        private System.Windows.Forms.NumericUpDown numTargetMemory;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblCurrentMemory;
        private System.Windows.Forms.GroupBox gbStats;
        private System.Windows.Forms.Label lblAppMemValue;
        private System.Windows.Forms.Label lblAppMemLabel;
        private System.Windows.Forms.Label lblAppBlocksValue;
        private System.Windows.Forms.Label lblAppBlocksLabel;
        private System.Windows.Forms.Label lblTotalRamValue;
        private System.Windows.Forms.Label lblTotalRamLabel;
        private System.Windows.Forms.CheckBox chkHoldMemory;
    }
}
