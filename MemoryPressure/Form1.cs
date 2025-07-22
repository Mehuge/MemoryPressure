// Form1.cs
// This file contains the main logic for the user interface and memory management.
// Version 11: Keeps memory in RAM by periodically "touching" it, avoiding VirtualLock.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime.InteropServices; // Required for P/Invoke (DllImport)
using System.ComponentModel;

namespace MemoryPressure
{
    public partial class Form1 : Form
    {
        #region WinAPI Declarations
        // This structure will be filled in by the GlobalMemoryStatusEx function
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

        // List to hold our allocated managed memory blocks.
        private List<byte[]> memoryBlocks;

        // Timer for adjusting memory usage to meet the target.
        private Timer memoryTimer;
        // **NEW**: Timer to periodically access memory to keep it in RAM.
        private Timer keepAliveTimer;

        private bool isRunning = false;
        private bool isAdjusting = false;
        private readonly ulong totalMemoryMB;
        private const int BlockSizeMB = 10;
        private const int PageSize = 4096;

        public Form1()
        {
            InitializeComponent();

            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(memStatus))
            {
                totalMemoryMB = memStatus.ullTotalPhys / (1024 * 1024);
            }

            memoryBlocks = new List<byte[]>();

            // Timer for making adjustments
            memoryTimer = new Timer();
            memoryTimer.Interval = 100;
            memoryTimer.Tick += MemoryTimer_Tick;

            // **NEW**: Timer for keeping allocated memory "hot"
            keepAliveTimer = new Timer();
            keepAliveTimer.Interval = 1000; // Touch memory every second
            keepAliveTimer.Tick += KeepAliveTimer_Tick;
        }

        /// <summary>
        /// **NEW**: Periodically accesses each page of allocated memory to prevent the OS
        /// from swapping it to disk.
        /// </summary>
        private void KeepAliveTimer_Tick(object sender, EventArgs e)
        {
            if (memoryBlocks == null || memoryBlocks.Count == 0) return;

            // This loop is the core of the new strategy. By writing to each page,
            // we signal to the OS that this memory is actively in use.
            for (int b = 0; b < memoryBlocks.Count; b++)
            {
                var block = memoryBlocks[b];
                for (int i = 0; i < block.Length; i += PageSize)
                {
                    block[i] = 1; // "Touch" the memory page.
                }
            }
        }

        private async void MemoryTimer_Tick(object sender, EventArgs e)
        {
            if (isAdjusting) return;

            MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();
            if (!GlobalMemoryStatusEx(memStatus)) return;

            uint currentMemoryUsage = memStatus.dwMemoryLoad;
            lblCurrentMemory.Text = $"Current Physical Memory: {currentMemoryUsage}%";
            UpdateStatsLabels();

            int targetMemoryPercentage = (int)numTargetMemory.Value;
            float percentDifference = targetMemoryPercentage - currentMemoryUsage;
            const float threshold = 0.5f;

            if (Math.Abs(percentDifference) > threshold)
            {
                isAdjusting = true;
                try
                {
                    int blocksToAdjust = 1;
                    if (Math.Abs(percentDifference) > 5.0f)
                    {
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

        /// <summary>
        /// Allocates managed memory blocks and touches them to page them into RAM.
        /// </summary>
        private void AllocateMemory(int blockCount)
        {
            for (int i = 0; i < blockCount; i++)
            {
                try
                {
                    byte[] block = new byte[BlockSizeMB * 1024 * 1024];

                    // Initial "touch" to ensure the memory is paged into physical RAM upon allocation.
                    // The keepAliveTimer will handle keeping it there.
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
                        MessageBox.Show("OutOfMemoryException! The system could not provide more memory. Ensure the app is compiled for x64.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                    return;
                }
            }
        }

        /// <summary>
        /// Frees managed memory blocks.
        /// </summary>
        private void FreeMemory(int blockCount)
        {
            int blocksToRemove = Math.Min(blockCount, memoryBlocks.Count);
            if (blocksToRemove > 0)
            {
                memoryBlocks.RemoveRange(memoryBlocks.Count - blocksToRemove, blocksToRemove);
                GC.Collect();
            }
        }

        private void UpdateStatsLabels()
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
            // numTargetMemory.Enabled = false;
            // chkHoldMemory.Enabled = false;
            memoryTimer.Start();
            keepAliveTimer.Start(); // **NEW**: Start the keep-alive timer.
        }

        private void StopMemoryManagement()
        {
            isRunning = false;
            btnStartStop.Text = "Start";
            // numTargetMemory.Enabled = true;
            // chkHoldMemory.Enabled = true;
            memoryTimer.Stop();
            keepAliveTimer.Stop(); // **NEW**: Stop the keep-alive timer.

            // Free all allocated memory.
            memoryBlocks.Clear();
            GC.Collect();

            lblCurrentMemory.Text = "Current Physical Memory: --%";
            UpdateStatsLabels();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCurrentMemory.Text = "Current Physical Memory: --%";

            lblTotalRamValue.Text = $"{totalMemoryMB:N0} MB";
            UpdateStatsLabels();

            if (!Environment.Is64BitProcess)
            {
                MessageBox.Show("This application is running as a 32-bit process. It will be limited to ~2GB of memory and will not work correctly.\n\nPlease change the project's build settings to target x64.", "Configuration Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
