// SettingsForm.cs
// This file contains the logic for the new settings window.
// Updated to include the "Overlay on Startup" option.

using Microsoft.Win32;
using System;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace MemoryPressure
{
    public partial class SettingsForm : Form
    {
        private const string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            numMaxSamples.Value = Properties.Settings.Default.MaxSamplesToShow;
            numSampleInterval.Value = Properties.Settings.Default.SampleIntervalSeconds;
            chkRecordOnStartup.Checked = Properties.Settings.Default.RecordOnStartup;
            chkGraphOnStartup.Checked = Properties.Settings.Default.GraphOnStartup;
            chkStartWithWindows.Checked = Properties.Settings.Default.StartWithWindows;
            chkOverlayOnStartup.Checked = Properties.Settings.Default.OverlayOnStartup; // **NEW**
            trackOverlayOpacity.Value = (int)(Properties.Settings.Default.OverlayOpacity * 100);
            lblOpacityValue.Text = $"{trackOverlayOpacity.Value}%";

            clbMetrics.Items.Add("Physical Memory (%)", IsMetricVisible("Physical Memory (%)"));
            clbMetrics.Items.Add("Committed Memory (%)", IsMetricVisible("Committed Memory (%)"));
            clbMetrics.Items.Add("Page File Usage (%)", IsMetricVisible("Page File Usage (%)"));
            clbMetrics.Items.Add("Page Faults/sec", IsMetricVisible("Page Faults/sec"));
            clbMetrics.Items.Add("Pages Input/sec", IsMetricVisible("Pages Input/sec"));
            clbMetrics.Items.Add("Pages Output/sec", IsMetricVisible("Pages Output/sec"));
        }

        private bool IsMetricVisible(string metricName)
        {
            if (Properties.Settings.Default.VisibleMetrics == null)
            {
                return true;
            }
            return Properties.Settings.Default.VisibleMetrics.Contains(metricName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.MaxSamplesToShow = (int)numMaxSamples.Value;
            Properties.Settings.Default.SampleIntervalSeconds = (int)numSampleInterval.Value;
            Properties.Settings.Default.RecordOnStartup = chkRecordOnStartup.Checked;
            Properties.Settings.Default.GraphOnStartup = chkGraphOnStartup.Checked;
            Properties.Settings.Default.OverlayOnStartup = chkOverlayOnStartup.Checked; // **NEW**
            Properties.Settings.Default.OverlayOpacity = trackOverlayOpacity.Value / 100.0;

            var visibleMetrics = new StringCollection();
            for (int i = 0; i < clbMetrics.Items.Count; i++)
            {
                if (clbMetrics.GetItemChecked(i))
                {
                    visibleMetrics.Add(clbMetrics.Items[i].ToString());
                }
            }
            Properties.Settings.Default.VisibleMetrics = visibleMetrics;

            SetStartWithWindows(chkStartWithWindows.Checked);
            Properties.Settings.Default.StartWithWindows = chkStartWithWindows.Checked;

            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SetStartWithWindows(bool start)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKey, true);
                if (start)
                {
                    key.SetValue(Application.ProductName, Application.ExecutablePath);
                }
                else
                {
                    key.DeleteValue(Application.ProductName, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update registry for 'Start with Windows' setting.\n\nError: {ex.Message}", "Registry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void trackOverlayOpacity_Scroll(object sender, EventArgs e)
        {
            lblOpacityValue.Text = $"{trackOverlayOpacity.Value}%";
        }
    }
}
