// MemoryDataPoint.cs
// This file defines the data structure for a single snapshot of memory metrics.
// Updated to include page file usage percentage.

using System;

namespace MemoryPressure
{
    public class MemoryDataPoint
    {
        public DateTime Timestamp { get; set; }
        public uint MemoryLoad { get; set; }
        public uint CommittedMemoryPercentage { get; set; }
        public uint PageFileUsagePercentage { get; set; } // **NEW**
        public float PageFaultsPerSec { get; set; }
        public float PagesInputPerSec { get; set; }
        public float PagesOutputPerSec { get; set; }
        public string TopProcess { get; set; }
    }
}
