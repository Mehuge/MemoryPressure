// Form1.cs
// This file contains the main logic for the user interface and memory management.
// Version 15: Added detailed stats and ability to switch to an overlay mode.

using System;
using System.Collections.Generic;
using System.Drawing;
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
        private bool isRunning = false;
        private bool isAdjusting = false;
        private const int BlockSizeMB = 10;
        private const int PageSize = 4096;

        // **NEW**: Instance of the overlay form.
        private OverlayForm overlayForm;

        public Form1()
        {
            InitializeComponent();
            
            memoryBlocks = new List<byte[]>();

            memoryTimer = new Timer { Interval = 100 };
            memoryTimer.Tick += MemoryTimer_Tick;

            keepAliveTimer = new Timer { Interval = 1000 };
            keepAliveTimer.Tick += KeepAliveTimer_Tick;

            // **NEW**: Initialize the overlay form, passing a reference to this main form.
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

        private async void MemoryTimer_Tick(object sender, EventArgs e)
        {
            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            if (!GlobalMemoryStatusEx(memStatus)) return;

            // **UPDATED**: Always update all detailed stats.
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

        // **NEW**: Helper function to format byte values into MB or GB.
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

        // **NEW**: Central method to update all memory stat labels on both forms.
        private void UpdateDetailedStats(MEMORYSTATUSEX memStatus)
        {
            ulong usedPhys = memStatus.ullTotalPhys - memStatus.ullAvailPhys;
            ulong usedPage = memStatus.ullTotalPageFile - memStatus.ullAvailPageFile;

            string percentText = $"{memStatus.dwMemoryLoad}%";
            string usedRamText = $"{FormatBytes(usedPhys)} / {FormatBytes(memStatus.ullTotalPhys)}";

            // Update main form labels
            lblCurrentMemory.Text = $"Current Physical Memory: {percentText}";
            lblTotalRamValue.Text = FormatBytes(memStatus.ullTotalPhys);
            lblUsedRamValue.Text = FormatBytes(usedPhys);
            lblAvailableRamValue.Text = FormatBytes(memStatus.ullAvailPhys);
            lblUsedPageFileValue.Text = FormatBytes(usedPage);
            lblTotalPageFileValue.Text = FormatBytes(memStatus.ullTotalPageFile);

            // Update overlay form if it's visible
            if (overlayForm.Visible)
            {
                overlayForm.UpdateStats(percentText, usedRamText);
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
            btnStartStop.Text = "Stop";
            keepAliveTimer.Start();
        }

        private void StopMemoryManagement()
        {
            isRunning = false;
            btnStartStop.Text = "Start";
            keepAliveTimer.Stop();
            FreeMemory(memoryBlocks.Count);
            UpdateAppStatsLabels();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Memory Pressure";
            memoryTimer.Start();

            if (!Environment.Is64BitProcess)
            {
                MessageBox.Show("This application is running as a 32-bit process and will not work correctly.", "Configuration Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // **NEW**: Method to switch to overlay mode.
        private void btnSwitchMode_Click(object sender, EventArgs e)
        {
            this.Hide();
            overlayForm.Show();
        }

        // **NEW**: Public method so the overlay form can show the main form again.
        public void ShowMainWindow()
        {
            overlayForm.Hide();
            this.Show();
        }
    }
}
