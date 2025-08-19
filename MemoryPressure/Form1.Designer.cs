// Form1.Designer.cs
// This file contains the auto-generated code for the form's UI components.
// Updated to include new buttons for recording and graphing.

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
            this.lblTotalPageFileValue = new System.Windows.Forms.Label();
            this.lblUsedPageFileValue = new System.Windows.Forms.Label();
            this.lblTotalPageFileLabel = new System.Windows.Forms.Label();
            this.lblUsedPageFileLabel = new System.Windows.Forms.Label();
            this.lblAvailableRamValue = new System.Windows.Forms.Label();
            this.lblAvailableRamLabel = new System.Windows.Forms.Label();
            this.lblUsedRamValue = new System.Windows.Forms.Label();
            this.lblUsedRamLabel = new System.Windows.Forms.Label();
            this.lblTotalRamValue = new System.Windows.Forms.Label();
            this.lblTotalRamLabel = new System.Windows.Forms.Label();
            this.chkHoldMemory = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAppMemValue = new System.Windows.Forms.Label();
            this.lblAppMemLabel = new System.Windows.Forms.Label();
            this.lblAppBlocksValue = new System.Windows.Forms.Label();
            this.lblAppBlocksLabel = new System.Windows.Forms.Label();
            this.btnSwitchMode = new System.Windows.Forms.Button();
            this.gbTopProcesses = new System.Windows.Forms.GroupBox();
            this.lvTopProcesses = new System.Windows.Forms.ListView();
            this.colProcess = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMemory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnShowGraph = new System.Windows.Forms.Button();
            this.btnSaveData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTargetMemory)).BeginInit();
            this.gbStats.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbTopProcesses.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTargetMemory
            // 
            this.lblTargetMemory.AutoSize = true;
            this.lblTargetMemory.BackColor = System.Drawing.Color.Transparent;
            this.lblTargetMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTargetMemory.ForeColor = System.Drawing.Color.White;
            this.lblTargetMemory.Location = new System.Drawing.Point(23, 24);
            this.lblTargetMemory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTargetMemory.Name = "lblTargetMemory";
            this.lblTargetMemory.Size = new System.Drawing.Size(212, 20);
            this.lblTargetMemory.TabIndex = 0;
            this.lblTargetMemory.Text = "Target Memory Usage (%):";
            // 
            // numTargetMemory
            // 
            this.numTargetMemory.BackColor = System.Drawing.Color.Black;
            this.numTargetMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTargetMemory.ForeColor = System.Drawing.Color.White;
            this.numTargetMemory.Location = new System.Drawing.Point(204, 23);
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
            this.btnStartStop.Location = new System.Drawing.Point(26, 531);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(268, 32);
            this.btnStartStop.TabIndex = 3;
            this.btnStartStop.Text = "Start Applying Pressure";
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
            this.gbStats.Controls.Add(this.lblTotalPageFileValue);
            this.gbStats.Controls.Add(this.lblUsedPageFileValue);
            this.gbStats.Controls.Add(this.lblTotalPageFileLabel);
            this.gbStats.Controls.Add(this.lblUsedPageFileLabel);
            this.gbStats.Controls.Add(this.lblAvailableRamValue);
            this.gbStats.Controls.Add(this.lblAvailableRamLabel);
            this.gbStats.Controls.Add(this.lblUsedRamValue);
            this.gbStats.Controls.Add(this.lblUsedRamLabel);
            this.gbStats.Controls.Add(this.lblTotalRamValue);
            this.gbStats.Controls.Add(this.lblTotalRamLabel);
            this.gbStats.ForeColor = System.Drawing.Color.White;
            this.gbStats.Location = new System.Drawing.Point(26, 93);
            this.gbStats.Margin = new System.Windows.Forms.Padding(2);
            this.gbStats.Name = "gbStats";
            this.gbStats.Padding = new System.Windows.Forms.Padding(2);
            this.gbStats.Size = new System.Drawing.Size(268, 140);
            this.gbStats.TabIndex = 4;
            this.gbStats.TabStop = false;
            this.gbStats.Text = "System Memory";
            // 
            // lblTotalPageFileValue
            // 
            this.lblTotalPageFileValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPageFileValue.Location = new System.Drawing.Point(142, 110);
            this.lblTotalPageFileValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPageFileValue.Name = "lblTotalPageFileValue";
            this.lblTotalPageFileValue.Size = new System.Drawing.Size(122, 15);
            this.lblTotalPageFileValue.TabIndex = 9;
            this.lblTotalPageFileValue.Text = "-- GB";
            this.lblTotalPageFileValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsedPageFileValue
            // 
            this.lblUsedPageFileValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedPageFileValue.Location = new System.Drawing.Point(142, 92);
            this.lblUsedPageFileValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsedPageFileValue.Name = "lblUsedPageFileValue";
            this.lblUsedPageFileValue.Size = new System.Drawing.Size(122, 15);
            this.lblUsedPageFileValue.TabIndex = 8;
            this.lblUsedPageFileValue.Text = "-- GB";
            this.lblUsedPageFileValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalPageFileLabel
            // 
            this.lblTotalPageFileLabel.AutoSize = true;
            this.lblTotalPageFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPageFileLabel.Location = new System.Drawing.Point(11, 110);
            this.lblTotalPageFileLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPageFileLabel.Name = "lblTotalPageFileLabel";
            this.lblTotalPageFileLabel.Size = new System.Drawing.Size(110, 18);
            this.lblTotalPageFileLabel.TabIndex = 7;
            this.lblTotalPageFileLabel.Text = "Total Page File:";
            // 
            // lblUsedPageFileLabel
            // 
            this.lblUsedPageFileLabel.AutoSize = true;
            this.lblUsedPageFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedPageFileLabel.Location = new System.Drawing.Point(11, 92);
            this.lblUsedPageFileLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsedPageFileLabel.Name = "lblUsedPageFileLabel";
            this.lblUsedPageFileLabel.Size = new System.Drawing.Size(112, 18);
            this.lblUsedPageFileLabel.TabIndex = 6;
            this.lblUsedPageFileLabel.Text = "Used Page File:";
            // 
            // lblAvailableRamValue
            // 
            this.lblAvailableRamValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableRamValue.Location = new System.Drawing.Point(142, 68);
            this.lblAvailableRamValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAvailableRamValue.Name = "lblAvailableRamValue";
            this.lblAvailableRamValue.Size = new System.Drawing.Size(122, 15);
            this.lblAvailableRamValue.TabIndex = 5;
            this.lblAvailableRamValue.Text = "-- GB";
            this.lblAvailableRamValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAvailableRamLabel
            // 
            this.lblAvailableRamLabel.AutoSize = true;
            this.lblAvailableRamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableRamLabel.Location = new System.Drawing.Point(11, 68);
            this.lblAvailableRamLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAvailableRamLabel.Name = "lblAvailableRamLabel";
            this.lblAvailableRamLabel.Size = new System.Drawing.Size(106, 18);
            this.lblAvailableRamLabel.TabIndex = 4;
            this.lblAvailableRamLabel.Text = "Available RAM:";
            // 
            // lblUsedRamValue
            // 
            this.lblUsedRamValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedRamValue.Location = new System.Drawing.Point(142, 47);
            this.lblUsedRamValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsedRamValue.Name = "lblUsedRamValue";
            this.lblUsedRamValue.Size = new System.Drawing.Size(122, 15);
            this.lblUsedRamValue.TabIndex = 3;
            this.lblUsedRamValue.Text = "-- GB";
            this.lblUsedRamValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsedRamLabel
            // 
            this.lblUsedRamLabel.AutoSize = true;
            this.lblUsedRamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsedRamLabel.Location = new System.Drawing.Point(11, 47);
            this.lblUsedRamLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsedRamLabel.Name = "lblUsedRamLabel";
            this.lblUsedRamLabel.Size = new System.Drawing.Size(84, 18);
            this.lblUsedRamLabel.TabIndex = 2;
            this.lblUsedRamLabel.Text = "Used RAM:";
            // 
            // lblTotalRamValue
            // 
            this.lblTotalRamValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRamValue.Location = new System.Drawing.Point(142, 25);
            this.lblTotalRamValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRamValue.Name = "lblTotalRamValue";
            this.lblTotalRamValue.Size = new System.Drawing.Size(122, 15);
            this.lblTotalRamValue.TabIndex = 1;
            this.lblTotalRamValue.Text = "-- GB";
            this.lblTotalRamValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalRamLabel
            // 
            this.lblTotalRamLabel.AutoSize = true;
            this.lblTotalRamLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRamLabel.Location = new System.Drawing.Point(11, 25);
            this.lblTotalRamLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRamLabel.Name = "lblTotalRamLabel";
            this.lblTotalRamLabel.Size = new System.Drawing.Size(82, 18);
            this.lblTotalRamLabel.TabIndex = 0;
            this.lblTotalRamLabel.Text = "Total RAM:";
            // 
            // chkHoldMemory
            // 
            this.chkHoldMemory.AutoSize = true;
            this.chkHoldMemory.BackColor = System.Drawing.Color.Transparent;
            this.chkHoldMemory.ForeColor = System.Drawing.Color.White;
            this.chkHoldMemory.Location = new System.Drawing.Point(26, 502);
            this.chkHoldMemory.Margin = new System.Windows.Forms.Padding(2);
            this.chkHoldMemory.Name = "chkHoldMemory";
            this.chkHoldMemory.Size = new System.Drawing.Size(255, 19);
            this.chkHoldMemory.TabIndex = 2;
            this.chkHoldMemory.Text = "Hold memory above target (don\'t release)";
            this.chkHoldMemory.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblAppMemValue);
            this.groupBox1.Controls.Add(this.lblAppMemLabel);
            this.groupBox1.Controls.Add(this.lblAppBlocksValue);
            this.groupBox1.Controls.Add(this.lblAppBlocksLabel);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(26, 238);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 55);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "This App\'s Allocation";
            // 
            // lblAppMemValue
            // 
            this.lblAppMemValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppMemValue.Location = new System.Drawing.Point(142, 34);
            this.lblAppMemValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppMemValue.Name = "lblAppMemValue";
            this.lblAppMemValue.Size = new System.Drawing.Size(122, 15);
            this.lblAppMemValue.TabIndex = 9;
            this.lblAppMemValue.Text = "0 MB";
            this.lblAppMemValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAppMemLabel
            // 
            this.lblAppMemLabel.AutoSize = true;
            this.lblAppMemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppMemLabel.Location = new System.Drawing.Point(11, 34);
            this.lblAppMemLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppMemLabel.Name = "lblAppMemLabel";
            this.lblAppMemLabel.Size = new System.Drawing.Size(82, 18);
            this.lblAppMemLabel.TabIndex = 8;
            this.lblAppMemLabel.Text = "Total Size: ";
            // 
            // lblAppBlocksValue
            // 
            this.lblAppBlocksValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppBlocksValue.Location = new System.Drawing.Point(142, 16);
            this.lblAppBlocksValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppBlocksValue.Name = "lblAppBlocksValue";
            this.lblAppBlocksValue.Size = new System.Drawing.Size(122, 15);
            this.lblAppBlocksValue.TabIndex = 7;
            this.lblAppBlocksValue.Text = "0";
            this.lblAppBlocksValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAppBlocksLabel
            // 
            this.lblAppBlocksLabel.AutoSize = true;
            this.lblAppBlocksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppBlocksLabel.Location = new System.Drawing.Point(11, 16);
            this.lblAppBlocksLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAppBlocksLabel.Name = "lblAppBlocksLabel";
            this.lblAppBlocksLabel.Size = new System.Drawing.Size(58, 18);
            this.lblAppBlocksLabel.TabIndex = 6;
            this.lblAppBlocksLabel.Text = "Blocks:";
            // 
            // btnSwitchMode
            // 
            this.btnSwitchMode.Location = new System.Drawing.Point(26, 642);
            this.btnSwitchMode.Name = "btnSwitchMode";
            this.btnSwitchMode.Size = new System.Drawing.Size(268, 23);
            this.btnSwitchMode.TabIndex = 6;
            this.btnSwitchMode.Text = "Switch to Overlay Mode";
            this.btnSwitchMode.UseVisualStyleBackColor = true;
            this.btnSwitchMode.Click += new System.EventHandler(this.btnSwitchMode_Click);
            // 
            // gbTopProcesses
            // 
            this.gbTopProcesses.BackColor = System.Drawing.Color.Transparent;
            this.gbTopProcesses.Controls.Add(this.lvTopProcesses);
            this.gbTopProcesses.ForeColor = System.Drawing.Color.White;
            this.gbTopProcesses.Location = new System.Drawing.Point(26, 299);
            this.gbTopProcesses.Name = "gbTopProcesses";
            this.gbTopProcesses.Size = new System.Drawing.Size(268, 198);
            this.gbTopProcesses.TabIndex = 7;
            this.gbTopProcesses.TabStop = false;
            this.gbTopProcesses.Text = "Top 10 Processes";
            // 
            // lvTopProcesses
            // 
            this.lvTopProcesses.BackColor = System.Drawing.Color.Black;
            this.lvTopProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvTopProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProcess,
            this.colMemory});
            this.lvTopProcesses.ForeColor = System.Drawing.Color.White;
            this.lvTopProcesses.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvTopProcesses.HideSelection = false;
            this.lvTopProcesses.Location = new System.Drawing.Point(6, 19);
            this.lvTopProcesses.Name = "lvTopProcesses";
            this.lvTopProcesses.OwnerDraw = true;
            this.lvTopProcesses.Size = new System.Drawing.Size(256, 173);
            this.lvTopProcesses.TabIndex = 0;
            this.lvTopProcesses.UseCompatibleStateImageBehavior = false;
            this.lvTopProcesses.View = System.Windows.Forms.View.Details;
            this.lvTopProcesses.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lvTopProcesses_DrawItem);
            this.lvTopProcesses.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvTopProcesses_DrawSubItem);
            // 
            // colProcess
            // 
            this.colProcess.Text = "Process";
            this.colProcess.Width = 160;
            // 
            // colMemory
            // 
            this.colMemory.Text = "Memory";
            this.colMemory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colMemory.Width = 75;
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(26, 568);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(131, 23);
            this.btnRecord.TabIndex = 8;
            this.btnRecord.Text = "Start Recording";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnShowGraph
            // 
            this.btnShowGraph.Location = new System.Drawing.Point(163, 568);
            this.btnShowGraph.Name = "btnShowGraph";
            this.btnShowGraph.Size = new System.Drawing.Size(131, 23);
            this.btnShowGraph.TabIndex = 9;
            this.btnShowGraph.Text = "Show Graph";
            this.btnShowGraph.UseVisualStyleBackColor = true;
            this.btnShowGraph.Click += new System.EventHandler(this.btnShowGraph_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(26, 597);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(268, 23);
            this.btnSaveData.TabIndex = 10;
            this.btnSaveData.Text = "Save Data to CSV";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::MemoryPressure.Properties.Resources.memory_presure;
            this.ClientSize = new System.Drawing.Size(320, 677);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.btnShowGraph);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.gbTopProcesses);
            this.Controls.Add(this.btnSwitchMode);
            this.Controls.Add(this.groupBox1);
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
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numTargetMemory)).EndInit();
            this.gbStats.ResumeLayout(false);
            this.gbStats.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbTopProcesses.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTargetMemory;
        private System.Windows.Forms.NumericUpDown numTargetMemory;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Label lblCurrentMemory;
        private System.Windows.Forms.GroupBox gbStats;
        private System.Windows.Forms.Label lblTotalRamValue;
        private System.Windows.Forms.Label lblTotalRamLabel;
        private System.Windows.Forms.CheckBox chkHoldMemory;
        private System.Windows.Forms.Label lblUsedRamValue;
        private System.Windows.Forms.Label lblUsedRamLabel;
        private System.Windows.Forms.Label lblAvailableRamValue;
        private System.Windows.Forms.Label lblAvailableRamLabel;
        private System.Windows.Forms.Label lblTotalPageFileValue;
        private System.Windows.Forms.Label lblUsedPageFileValue;
        private System.Windows.Forms.Label lblTotalPageFileLabel;
        private System.Windows.Forms.Label lblUsedPageFileLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAppMemValue;
        private System.Windows.Forms.Label lblAppMemLabel;
        private System.Windows.Forms.Label lblAppBlocksValue;
        private System.Windows.Forms.Label lblAppBlocksLabel;
        private System.Windows.Forms.Button btnSwitchMode;
        private System.Windows.Forms.GroupBox gbTopProcesses;
        private System.Windows.Forms.ListView lvTopProcesses;
        private System.Windows.Forms.ColumnHeader colProcess;
        private System.Windows.Forms.ColumnHeader colMemory;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.Button btnShowGraph;
        private System.Windows.Forms.Button btnSaveData;
    }
}
