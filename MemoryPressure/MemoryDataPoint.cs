// MemoryDataPoint.cs
// This file defines the data structure for a single snapshot of memory metrics.
// Moving this to its own file makes it accessible to the entire project.

using System;

namespace MemoryPressure
{
    public class MemoryDataPoint
    {
        public DateTime Timestamp { get; set; }
        public uint MemoryLoad { get; set; }
        public float PageFaultsPerSec { get; set; }
        public float PagesInputPerSec { get; set; }
        public float PagesOutputPerSec { get; set; }
        public string TopProcess { get; set; }
    }
}
