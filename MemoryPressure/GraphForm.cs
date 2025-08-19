// GraphForm.cs
// This file contains the logic for the new graph window.
// It uses the DataVisualization charting control to display recorded data.

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
            // Ensure the chart exists and is ready.
            if (chartMemory == null) return;

            // Clear any previous data.
            chartMemory.Series.Clear();

            // Create a new series for our memory data.
            var series = new Series("Physical Memory")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 2,
                Color = Color.LimeGreen,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 5
            };

            // Add the data points to the series.
            foreach (var point in data)
            {
                series.Points.AddXY(point.Item1, point.Item2);
            }

            // Add the series to the chart.
            chartMemory.Series.Add(series);

            // Configure the chart axes and appearance.
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

            // Refresh the chart and show the form.
            chartMemory.Invalidate();
            this.Show();
            this.Activate();
        }

        // **NEW**: This method is called for real-time updates.
        public void UpdateGraph(List<Tuple<DateTime, uint>> data)
        {
            // Use Invoke to ensure thread safety when updating the UI from a timer.
            this.Invoke((MethodInvoker)delegate
            {
                if (chartMemory.Series.Count > 0)
                {
                    var series = chartMemory.Series["Physical Memory"];
                    series.Points.Clear();
                    foreach (var point in data)
                    {
                        series.Points.AddXY(point.Item1, point.Item2);
                    }
                    chartMemory.Invalidate();
                }
            });
        }
    }
}
