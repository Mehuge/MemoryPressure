// GraphForm.cs
// This file contains the logic for the new graph window.
// Updated to include data thinning for better performance and visuals with large datasets.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MemoryPressure
{
    public partial class GraphForm : Form
    {
        public GraphForm()
        {
            InitializeComponent();
        }

        // This method is called the first time the graph is shown.
        public void ShowGraph(List<Tuple<DateTime, uint>> data)
        {
            if (chartMemory == null) return;
            chartMemory.Series.Clear();

            var series = new Series("Physical Memory")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 2,
                Color = Color.LimeGreen
            };

            chartMemory.Series.Add(series);
            ConfigureChartAppearance();

            // Initial data load
            UpdateGraph(data);

            this.Show();
            this.Activate();
        }

        // This method is now used for both initial load and real-time updates.
        public void UpdateGraph(List<Tuple<DateTime, uint>> data)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            // Use Invoke to ensure thread safety when updating the UI from a timer.
            this.Invoke((MethodInvoker)delegate
            {
                if (chartMemory.Series.Count == 0) return;

                var series = chartMemory.Series["Physical Memory"];
                series.Points.Clear();

                // **NEW**: Data thinning logic
                const int maxPointsToShow = 500;
                int dataCount = data.Count;

                if (dataCount <= maxPointsToShow)
                {
                    // If we have a reasonable number of points, show them all.
                    foreach (var point in data)
                    {
                        series.Points.AddXY(point.Item1, point.Item2);
                    }
                }
                else
                {
                    // If we have too many points, calculate a step to skip samples.
                    int step = dataCount / maxPointsToShow;
                    for (int i = 0; i < dataCount; i += step)
                    {
                        series.Points.AddXY(data[i].Item1, data[i].Item2);
                    }
                }

                // **NEW**: Only show markers if the point count is low to avoid clutter.
                series.MarkerStyle = dataCount < 100 ? MarkerStyle.Circle : MarkerStyle.None;
                series.MarkerSize = 5;

                chartMemory.Invalidate();
            });
        }

        private void ConfigureChartAppearance()
        {
            var chartArea = chartMemory.ChartAreas[0];
            chartArea.BackColor = Color.FromArgb(20, 20, 20);

            chartArea.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea.AxisX.Title = "Time";
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
            chartArea.AxisX.LineColor = Color.Gray;
            chartArea.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea.AxisX.TitleForeColor = Color.White;

            chartArea.AxisY.Title = "Memory Usage (%)";
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 100;
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
            chartArea.AxisY.LineColor = Color.Gray;
            chartArea.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea.AxisY.TitleForeColor = Color.White;

            chartMemory.Legends[0].Enabled = false;
        }
    }
}
