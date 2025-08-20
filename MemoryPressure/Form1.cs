// Form1.cs
// This file contains the main logic for the user interface and memory management.
// Version 25: Removed the local MemoryDataPoint class definition.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MemoryPressure
{
    public partial class Form1 : Form
    {
        #region WinAPI Declarations
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private class MEMORYSTATUSEX
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public ulong ullTotalPhys;
            public ulong ullAvailPhys;
            public ulong ullTotalPageFile;
            public ulong ullAvailPageFile;
            public ulong ullTotalVirtual;
            public ulong ullAvailVirtual;
            public ulong ullAvailExtendedVirtual;
            public MEMORYSTATUSEX()
            {
                this.dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
            }
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);
        #endregion

        private List<byte[]> memoryBlocks;
        private Timer memoryTimer;
        private Timer keepAliveTimer;
        private Timer processListTimer;
        private Timer recordingTimer;

        private PerformanceCounter pageFaultsCounter;
        private PerformanceCounter pagesInputCounter;
        private PerformanceCounter pagesOutputCounter;

        private bool isRunning = false;
        private bool isAdjusting = false;
        private bool isRecording = false;
        private const int BlockSizeMB = 10;
        private const int PageSize = 4096;
        private OverlayForm overlayForm;
        private GraphForm graphForm;
        private List<MemoryDataPoint> recordedData;

        public Form1()
        {
            InitializeComponent();

            memoryBlocks = new List<byte[]>();
            recordedData = new List<MemoryDataPoint>();

            memoryTimer = new Timer { Interval = 100 };
            memoryTimer.Tick += MemoryTimer_Tick;

            keepAliveTimer = new Timer { Interval = 1000 };
            keepAliveTimer.Tick += KeepAliveTimer_Tick;

            processListTimer = new Timer { Interval = 1000 };
            processListTimer.Tick += ProcessListTimer_Tick;

            recordingTimer = new Timer { Interval = 5000 };
            recordingTimer.Tick += RecordingTimer_Tick;

            try
            {
                pageFaultsCounter = new PerformanceCounter("Memory", "Page Faults/sec");
                pagesInputCounter = new PerformanceCounter("Memory", "Pages Input/sec");
                pagesOutputCounter = new PerformanceCounter("Memory", "Pages Output/sec");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to initialize performance counters. Some graphing features may not work.\n\nError: {ex.Message}", "Performance Counter Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            overlayForm = new OverlayForm(this);
        }

        private void KeepAliveTimer_Tick(object sender, EventArgs e)
        {
            if (memoryBlocks == null || memoryBlocks.Count == 0) return;

            for (int i = 0; i < memoryBlocks.Count; i++)
            {
                byte[] block = memoryBlocks[i];
                if (block != null)
                {
                    for (int j = 0; j < block.Length; j += PageSize)
                    {
                        block[j] = 1;
                    }
                }
            }
        }

        private void ProcessListTimer_Tick(object sender, EventArgs e)
        {
            UpdateProcessList();
        }

        private void RecordingTimer_Tick(object sender, EventArgs e)
        {
            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(memStatus))
            {
                var dataPoint = new MemoryDataPoint
                {
                    Timestamp = DateTime.Now,
                    MemoryLoad = memStatus.dwMemoryLoad,
                    PageFaultsPerSec = pageFaultsCounter?.NextValue() ?? 0,
                    PagesInputPerSec = pagesInputCounter?.NextValue() ?? 0,
                    PagesOutputPerSec = pagesOutputCounter?.NextValue() ?? 0,
                    TopProcess = GetTopProcessName()
                };

                recordedData.Add(dataPoint);

                if (graphForm != null && !graphForm.IsDisposed && graphForm.Visible)
                {
                    graphForm.UpdateGraph(recordedData);
                }
            }
        }

        private string GetTopProcessName()
        {
            try
            {
                return Process.GetProcesses().OrderByDescending(p => p.WorkingSet64).FirstOrDefault()?.ProcessName ?? "N/A";
            }
            catch { return "N/A"; }
        }

        private async void MemoryTimer_Tick(object sender, EventArgs e)
        {
            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            if (!GlobalMemoryStatusEx(memStatus)) return;

            UpdateDetailedStats(memStatus);
            UpdateAppStatsLabels();

            if (!isRunning || isAdjusting) return;

            int targetMemoryPercentage = (int)numTargetMemory.Value;
            float percentDifference = targetMemoryPercentage - memStatus.dwMemoryLoad;
            const float threshold = 0.5f;

            if (Math.Abs(percentDifference) > threshold)
            {
                isAdjusting = true;
                try
                {
                    int blocksToAdjust = 1;
                    if (Math.Abs(percentDifference) > 5.0f)
                    {
                        ulong totalMemoryMB = memStatus.ullTotalPhys / (1024 * 1024);
                        float memoryToAdjustMB = (float)(Math.Abs(percentDifference) / 100.0 * totalMemoryMB);
                        blocksToAdjust = Math.Max(1, (int)(memoryToAdjustMB / BlockSizeMB / 4));
                    }

                    if (percentDifference > 0)
                    {
                        await Task.Run(() => AllocateMemory(blocksToAdjust));
                    }
                    else if (!chkHoldMemory.Checked)
                    {
                        FreeMemory(blocksToAdjust);
                    }
                }
                finally
                {
                    isAdjusting = false;
                }
            }
        }

        private void UpdateProcessList()
        {
            try
            {
                var topProcesses = Process.GetProcesses()
                                          .OrderByDescending(p => p.WorkingSet64)
                                          .Take(10)
                                          .ToList();

                lvTopProcesses.BeginUpdate();
                lvTopProcesses.Items.Clear();

                foreach (var process in topProcesses)
                {
                    string memoryUsage = $"{process.WorkingSet64 / (1024 * 1024):N0} MB";
                    ListViewItem item = new ListViewItem(process.ProcessName);
                    item.SubItems.Add(memoryUsage);
                    lvTopProcesses.Items.Add(item);
                }
                lvTopProcesses.EndUpdate();
            }
            catch (Exception)
            {
                // Ignore exceptions
            }
        }

        private string FormatBytes(ulong bytes)
        {
            double gb = bytes / (1024.0 * 1024.0 * 1024.0);
            if (gb >= 1.0)
            {
                return $"{gb:F2} GB";
            }
            double mb = bytes / (1024.0 * 1024.0);
            return $"{mb:F2} MB";
        }

        private void UpdateDetailedStats(MEMORYSTATUSEX memStatus)
        {
            ulong usedPhys = memStatus.ullTotalPhys - memStatus.ullAvailPhys;
            ulong usedPage = memStatus.ullTotalPageFile - memStatus.ullAvailPageFile;

            string percentText = $"{memStatus.dwMemoryLoad}%";
            string usedRamText = $"{FormatBytes(usedPhys)} / {FormatBytes(memStatus.ullTotalPhys)}";

            lblCurrentMemory.Text = $"Current Physical Memory: {percentText}";
            lblTotalRamValue.Text = FormatBytes(memStatus.ullTotalPhys);
            lblUsedRamValue.Text = FormatBytes(usedPhys);
            lblAvailableRamValue.Text = FormatBytes(memStatus.ullAvailPhys);
            lblUsedPageFileValue.Text = FormatBytes(usedPage);
            lblTotalPageFileValue.Text = FormatBytes(memStatus.ullTotalPageFile);

            if (overlayForm.Visible)
            {
                string topProcessName = "";
                string topProcessMemory = "";
                try
                {
                    var topProcess = Process.GetProcesses().OrderByDescending(p => p.WorkingSet64).FirstOrDefault();
                    if (topProcess != null)
                    {
                        topProcessName = topProcess.ProcessName;
                        topProcessMemory = $"{topProcess.WorkingSet64 / (1024 * 1024):N0} MB";
                    }
                }
                catch { /* Ignore errors */ }

                overlayForm.UpdateStats(percentText, usedRamText, topProcessName, topProcessMemory);
            }
        }

        private void AllocateMemory(int blockCount)
        {
            for (int i = 0; i < blockCount; i++)
            {
                try
                {
                    byte[] block = new byte[BlockSizeMB * 1024 * 1024];
                    for (int j = 0; j < block.Length; j += PageSize)
                    {
                        block[j] = 1;
                    }
                    memoryBlocks.Add(block);
                }
                catch (OutOfMemoryException)
                {
                    this.Invoke((MethodInvoker)delegate {
                        StopMemoryManagement();
                        MessageBox.Show("OutOfMemoryException! The system could not provide more memory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                    return;
                }
            }
        }

        private void FreeMemory(int blockCount)
        {
            int blocksToRemove = Math.Min(blockCount, memoryBlocks.Count);
            if (blocksToRemove > 0)
            {
                memoryBlocks.RemoveRange(memoryBlocks.Count - blocksToRemove, blocksToRemove);
                GC.Collect();
            }
        }

        private void UpdateAppStatsLabels()
        {
            long appAllocatedMB = (long)memoryBlocks.Count * BlockSizeMB;
            int appBlocks = memoryBlocks.Count;

            lblAppBlocksValue.Text = appBlocks.ToString("N0");
            lblAppMemValue.Text = $"{appAllocatedMB:N0} MB";
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                StopMemoryManagement();
            }
            else
            {
                StartMemoryManagement();
            }
        }

        private void StartMemoryManagement()
        {
            isRunning = true;
            btnStartStop.Text = "Stop Applying Pressure";
            keepAliveTimer.Start();
        }

        private void StopMemoryManagement()
        {
            isRunning = false;
            btnStartStop.Text = "Start Applying Pressure";
            keepAliveTimer.Stop();
            FreeMemory(memoryBlocks.Count);
            UpdateAppStatsLabels();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Memory Pressure";
            UpdateListViewBackground();
            memoryTimer.Start();
            processListTimer.Start();

            if (!Environment.Is64BitProcess)
            {
                MessageBox.Show("This application is running as a 32-bit process and will not work correctly.", "Configuration Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSwitchMode_Click(object sender, EventArgs e)
        {
            this.Hide();
            overlayForm.Show();
        }

        public void ShowMainWindow()
        {
            overlayForm.Hide();
            this.Show();
        }

        #region New Button Handlers
        private void btnRecord_Click(object sender, EventArgs e)
        {
            isRecording = !isRecording;

            if (isRecording)
            {
                recordedData.Clear();
                recordingTimer.Start();
                btnRecord.Text = "Stop Recording";
                btnRecord.BackColor = Color.Red;
                btnRecord.ForeColor = Color.White;
            }
            else
            {
                recordingTimer.Stop();
                btnRecord.Text = "Start Recording";
                btnRecord.BackColor = SystemColors.Control;
                btnRecord.ForeColor = SystemColors.ControlText;
            }
        }

        private void btnShowGraph_Click(object sender, EventArgs e)
        {
            if (graphForm == null || graphForm.IsDisposed)
            {
                graphForm = new GraphForm();
            }

            graphForm.ShowGraph(recordedData);
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (recordedData.Count == 0)
            {
                MessageBox.Show("No data has been recorded to save.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.Title = "Save Recorded Memory Data";
                sfd.FileName = $"MemoryPressure_Log_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(sfd.FileName))
                        {
                            writer.WriteLine("Timestamp,PhysicalMemoryUsagePercentage,PageFaultsPerSec,PagesInputPerSec,PagesOutputPerSec,TopProcess");
                            foreach (var dataPoint in recordedData)
                            {
                                writer.WriteLine($"{dataPoint.Timestamp:yyyy-MM-dd HH:mm:ss},{dataPoint.MemoryLoad},{dataPoint.PageFaultsPerSec},{dataPoint.PagesInputPerSec},{dataPoint.PagesOutputPerSec},{dataPoint.TopProcess}");
                            }
                        }
                        MessageBox.Show("Data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to save data. Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion

        #region ListView Custom Drawing & Transparency
        private void UpdateListViewBackground()
        {
            if (this.BackgroundImage == null) return;

            Bitmap bmp = new Bitmap(lvTopProcesses.Width, lvTopProcesses.Height);
            Rectangle targetRect = lvTopProcesses.RectangleToScreen(lvTopProcesses.ClientRectangle);
            Point targetPoint = this.PointToClient(targetRect.Location);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(this.BackgroundImage,
                            new Rectangle(0, 0, bmp.Width, bmp.Height),
                            new Rectangle(targetPoint.X, targetPoint.Y, bmp.Width, bmp.Height),
                            GraphicsUnit.Pixel);
            }

            lvTopProcesses.BackgroundImage = bmp;
            lvTopProcesses.BackgroundImageTiled = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdateListViewBackground();
        }

        private void lvTopProcesses_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(100, 50, 100, 200)))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }
        }

        private void lvTopProcesses_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis;

            if (e.ColumnIndex == 1)
            {
                flags = TextFormatFlags.Right | TextFormatFlags.VerticalCenter;
            }

            TextRenderer.DrawText(e.Graphics, e.SubItem.Text, e.SubItem.Font, e.Bounds, e.SubItem.ForeColor, flags);
        }
        #endregion
    }
}
