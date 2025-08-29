// GraphForm.cs
// This file contains the logic for the new graph window.
// Updated to display page file usage percentage.

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

        public void ShowGraph(List<MemoryDataPoint> data)
        {
            if (chartMemory == null) return;
            chartMemory.Series.Clear();

            var memSeries = new Series("Physical Memory (%)")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 3,
                Color = Color.LimeGreen,
            };

            var commitSeries = new Series("Committed Memory (%)")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 2,
                Color = Color.Yellow,
                BorderDashStyle = ChartDashStyle.Dash
            };

            // **NEW**: Series for page file usage.
            var pageFileSeries = new Series("Page File Usage (%)")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 2,
                Color = Color.SkyBlue,
                BorderDashStyle = ChartDashStyle.Dot
            };

            var faultsSeries = new Series("Page Faults/sec")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 2,
                Color = Color.OrangeRed,
                YAxisType = AxisType.Secondary
            };

            var pagesInSeries = new Series("Pages Input/sec")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 1,
                Color = Color.Cyan,
                YAxisType = AxisType.Secondary
            };

            var pagesOutSeries = new Series("Pages Output/sec")
            {
                ChartType = SeriesChartType.Line,
                XValueType = ChartValueType.DateTime,
                BorderWidth = 1,
                Color = Color.Magenta,
                YAxisType = AxisType.Secondary
            };

            chartMemory.Series.Add(memSeries);
            chartMemory.Series.Add(commitSeries);
            chartMemory.Series.Add(pageFileSeries); // **NEW**
            chartMemory.Series.Add(faultsSeries);
            chartMemory.Series.Add(pagesInSeries);
            chartMemory.Series.Add(pagesOutSeries);

            ConfigureChartAppearance();
            UpdateGraph(data);

            this.Show();
            this.Activate();
        }

        public void UpdateGraph(List<MemoryDataPoint> data)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.Invoke((MethodInvoker)delegate
            {
                if (chartMemory.Series.Count == 0) return;

                var memSeries = chartMemory.Series["Physical Memory (%)"];
                var commitSeries = chartMemory.Series["Committed Memory (%)"];
                var pageFileSeries = chartMemory.Series["Page File Usage (%)"]; // **NEW**
                var faultsSeries = chartMemory.Series["Page Faults/sec"];
                var pagesInSeries = chartMemory.Series["Pages Input/sec"];
                var pagesOutSeries = chartMemory.Series["Pages Output/sec"];

                memSeries.Points.Clear();
                commitSeries.Points.Clear();
                pageFileSeries.Points.Clear(); // **NEW**
                faultsSeries.Points.Clear();
                pagesInSeries.Points.Clear();
                pagesOutSeries.Points.Clear();

                const int maxPointsToShow = 500;
                int dataCount = data.Count;

                List<MemoryDataPoint> dataToShow;

                if (dataCount <= maxPointsToShow)
                {
                    dataToShow = data;
                }
                else
                {
                    dataToShow = new List<MemoryDataPoint>();
                    int step = dataCount / maxPointsToShow;
                    for (int i = 0; i < dataCount; i += step)
                    {
                        dataToShow.Add(data[i]);
                    }
                }

                foreach (var point in dataToShow)
                {
                    memSeries.Points.AddXY(point.Timestamp, point.MemoryLoad);
                    commitSeries.Points.AddXY(point.Timestamp, point.CommittedMemoryPercentage);
                    pageFileSeries.Points.AddXY(point.Timestamp, point.PageFileUsagePercentage); // **NEW**
                    faultsSeries.Points.AddXY(point.Timestamp, point.PageFaultsPerSec);
                    pagesInSeries.Points.AddXY(point.Timestamp, point.PagesInputPerSec);
                    pagesOutSeries.Points.AddXY(point.Timestamp, point.PagesOutputPerSec);
                }

                memSeries.MarkerStyle = dataCount < 100 ? MarkerStyle.Circle : MarkerStyle.None;
                memSeries.MarkerSize = 5;

                chartMemory.Invalidate();
            });
        }

        private void ConfigureChartAppearance()
        {
            var chartArea = chartMemory.ChartAreas[0];
            chartArea.BackColor = Color.FromArgb(20, 20, 20);

            chartArea.AxisY.Title = "Memory Usage (%)";
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 100;
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
            chartArea.AxisY.LineColor = Color.Gray;
            chartArea.AxisY.LabelStyle.ForeColor = Color.White;
            chartArea.AxisY.TitleForeColor = Color.White;

            chartArea.AxisY2.Enabled = AxisEnabled.True;
            chartArea.AxisY2.Title = "Page Activity / sec";
            chartArea.AxisY2.MajorGrid.Enabled = false;
            chartArea.AxisY2.LineColor = Color.Gray;
            chartArea.AxisY2.LabelStyle.ForeColor = Color.White;
            chartArea.AxisY2.TitleForeColor = Color.White;

            chartArea.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea.AxisX.Title = "Time";
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
            chartArea.AxisX.LineColor = Color.Gray;
            chartArea.AxisX.LabelStyle.ForeColor = Color.White;
            chartArea.AxisX.TitleForeColor = Color.White;

            var legend = chartMemory.Legends[0];
            legend.BackColor = Color.Transparent;
            legend.ForeColor = Color.White;
            legend.Docking = Docking.Top;
            legend.Alignment = StringAlignment.Center;
            legend.LegendStyle = LegendStyle.Row;
        }
    }
}
