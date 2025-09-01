// SettingsForm.Designer.cs
// This file contains the auto-generated code for the settings form's UI components.
// Updated to include the "Overlay on Startup" checkbox.

namespace MemoryPressure
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.numMaxSamples = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numSampleInterval = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.clbMetrics = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRecordOnStartup = new System.Windows.Forms.CheckBox();
            this.chkGraphOnStartup = new System.Windows.Forms.CheckBox();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.trackOverlayOpacity = new System.Windows.Forms.TrackBar();
            this.lblOpacityValue = new System.Windows.Forms.Label();
            this.chkOverlayOnStartup = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOverlayOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max Samples to Show in Graph:";
            // 
            // numMaxSamples
            // 
            this.numMaxSamples.Location = new System.Drawing.Point(174, 11);
            this.numMaxSamples.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMaxSamples.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMaxSamples.Name = "numMaxSamples";
            this.numMaxSamples.Size = new System.Drawing.Size(120, 20);
            this.numMaxSamples.TabIndex = 1;
            this.numMaxSamples.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sample Interval (seconds):";
            // 
            // numSampleInterval
            // 
            this.numSampleInterval.Location = new System.Drawing.Point(174, 41);
            this.numSampleInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numSampleInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSampleInterval.Name = "numSampleInterval";
            this.numSampleInterval.Size = new System.Drawing.Size(120, 20);
            this.numSampleInterval.TabIndex = 3;
            this.numSampleInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Metrics to Show in Graph:";
            // 
            // clbMetrics
            // 
            this.clbMetrics.FormattingEnabled = true;
            this.clbMetrics.Location = new System.Drawing.Point(16, 89);
            this.clbMetrics.Name = "clbMetrics";
            this.clbMetrics.Size = new System.Drawing.Size(278, 94);
            this.clbMetrics.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Startup Options:";
            // 
            // chkRecordOnStartup
            // 
            this.chkRecordOnStartup.AutoSize = true;
            this.chkRecordOnStartup.Location = new System.Drawing.Point(16, 253);
            this.chkRecordOnStartup.Name = "chkRecordOnStartup";
            this.chkRecordOnStartup.Size = new System.Drawing.Size(128, 19);
            this.chkRecordOnStartup.TabIndex = 7;
            this.chkRecordOnStartup.Text = "Record on Startup";
            this.chkRecordOnStartup.UseVisualStyleBackColor = true;
            // 
            // chkGraphOnStartup
            // 
            this.chkGraphOnStartup.AutoSize = true;
            this.chkGraphOnStartup.Location = new System.Drawing.Point(16, 276);
            this.chkGraphOnStartup.Name = "chkGraphOnStartup";
            this.chkGraphOnStartup.Size = new System.Drawing.Size(156, 19);
            this.chkGraphOnStartup.TabIndex = 8;
            this.chkGraphOnStartup.Text = "Show Graph on Startup";
            this.chkGraphOnStartup.UseVisualStyleBackColor = true;
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(16, 322);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(132, 19);
            this.chkStartWithWindows.TabIndex = 9;
            this.chkStartWithWindows.Text = "Start with Windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(138, 355);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(219, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Overlay Opacity:";
            // 
            // trackOverlayOpacity
            // 
            this.trackOverlayOpacity.Location = new System.Drawing.Point(106, 189);
            this.trackOverlayOpacity.Maximum = 100;
            this.trackOverlayOpacity.Minimum = 20;
            this.trackOverlayOpacity.Name = "trackOverlayOpacity";
            this.trackOverlayOpacity.Size = new System.Drawing.Size(143, 56);
            this.trackOverlayOpacity.TabIndex = 13;
            this.trackOverlayOpacity.TickFrequency = 10;
            this.trackOverlayOpacity.Value = 75;
            this.trackOverlayOpacity.Scroll += new System.EventHandler(this.trackOverlayOpacity_Scroll);
            // 
            // lblOpacityValue
            // 
            this.lblOpacityValue.AutoSize = true;
            this.lblOpacityValue.Location = new System.Drawing.Point(255, 195);
            this.lblOpacityValue.Name = "lblOpacityValue";
            this.lblOpacityValue.Size = new System.Drawing.Size(32, 15);
            this.lblOpacityValue.TabIndex = 14;
            this.lblOpacityValue.Text = "75%";
            // 
            // chkOverlayOnStartup
            // 
            this.chkOverlayOnStartup.AutoSize = true;
            this.chkOverlayOnStartup.Location = new System.Drawing.Point(16, 299);
            this.chkOverlayOnStartup.Name = "chkOverlayOnStartup";
            this.chkOverlayOnStartup.Size = new System.Drawing.Size(162, 19);
            this.chkOverlayOnStartup.TabIndex = 15;
            this.chkOverlayOnStartup.Text = "Show Overlay on Startup";
            this.chkOverlayOnStartup.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(309, 390);
            this.Controls.Add(this.chkOverlayOnStartup);
            this.Controls.Add(this.lblOpacityValue);
            this.Controls.Add(this.trackOverlayOpacity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkStartWithWindows);
            this.Controls.Add(this.chkGraphOnStartup);
            this.Controls.Add(this.chkRecordOnStartup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clbMetrics);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numSampleInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numMaxSamples);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSampleInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOverlayOpacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMaxSamples;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSampleInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox clbMetrics;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRecordOnStartup;
        private System.Windows.Forms.CheckBox chkGraphOnStartup;
        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trackOverlayOpacity;
        private System.Windows.Forms.Label lblOpacityValue;
        private System.Windows.Forms.CheckBox chkOverlayOnStartup;
    }
}
