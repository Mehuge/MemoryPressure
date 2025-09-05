// GraphForm.cs
// This file contains the logic for the new graph window.
// CORRECTED: Implements stable data averaging for large datasets.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
                var pageFileSeries = chartMemory.Series["Page File Usage (%)"];
                var faultsSeries = chartMemory.Series["Page Faults/sec"];
                var pagesInSeries = chartMemory.Series["Pages Input/sec"];
                var pagesOutSeries = chartMemory.Series["Pages Output/sec"];

                var visibleMetrics = Properties.Settings.Default.VisibleMetrics;
                memSeries.Enabled = visibleMetrics.Contains("Physical Memory (%)");
                commitSeries.Enabled = visibleMetrics.Contains("Committed Memory (%)");
                pageFileSeries.Enabled = visibleMetrics.Contains("Page File Usage (%)");
                faultsSeries.Enabled = visibleMetrics.Contains("Page Faults/sec");
                pagesInSeries.Enabled = visibleMetrics.Contains("Pages Input/sec");
                pagesOutSeries.Enabled = visibleMetrics.Contains("Pages Output/sec");

                memSeries.Points.Clear();
                commitSeries.Points.Clear();
                pageFileSeries.Points.Clear();
                faultsSeries.Points.Clear();
                pagesInSeries.Points.Clear();
                pagesOutSeries.Points.Clear();

                var dataToProcess = data; // Form1 is already handling the "last N samples"

                // --- DATA THINNING (AVERAGING) LOGIC ---
                const int displayLimit = 500;
                List<MemoryDataPoint> dataToShow;

                if (dataToProcess.Count > displayLimit)
                {
                    var averagedData = new List<MemoryDataPoint>();
                    int step = (int)Math.Ceiling((double)dataToProcess.Count / displayLimit);

                    for (int i = 0; i < dataToProcess.Count; i += step)
                    {
                        var chunk = dataToProcess.Skip(i).Take(step).ToList();
                        if (chunk.Any())
                        {
                            var avgPoint = new MemoryDataPoint
                            {
                                Timestamp = chunk.First().Timestamp,
                                MemoryLoad = (uint)chunk.Average(p => p.MemoryLoad),
                                CommittedMemoryPercentage = (uint)chunk.Average(p => p.CommittedMemoryPercentage),
                                PageFileUsagePercentage = (uint)chunk.Average(p => p.PageFileUsagePercentage),
                                PageFaultsPerSec = chunk.Average(p => p.PageFaultsPerSec),
                                PagesInputPerSec = chunk.Average(p => p.PagesInputPerSec),
                                PagesOutputPerSec = chunk.Average(p => p.PagesOutputPerSec),
                                TopProcess = chunk.First().TopProcess
                            };
                            averagedData.Add(avgPoint);
                        }
                    }
                    dataToShow = averagedData;
                }
                else
                {
                    dataToShow = dataToProcess;
                }
                // --- END DATA THINNING ---

                foreach (var point in dataToShow)
                {
                    memSeries.Points.AddXY(point.Timestamp, point.MemoryLoad);
                    commitSeries.Points.AddXY(point.Timestamp, point.CommittedMemoryPercentage);
                    pageFileSeries.Points.AddXY(point.Timestamp, point.PageFileUsagePercentage);
                    faultsSeries.Points.AddXY(point.Timestamp, point.PageFaultsPerSec);
                    pagesInSeries.Points.AddXY(point.Timestamp, point.PagesInputPerSec);
                    pagesOutSeries.Points.AddXY(point.Timestamp, point.PagesOutputPerSec);
                }

                memSeries.MarkerStyle = dataToShow.Count < 100 ? MarkerStyle.Circle : MarkerStyle.None;
                memSeries.MarkerSize = 5;

                chartMemory.Invalidate();
            });
        }

        private void ConfigureChartAppearance()
        {
            chartMemory.Series.Clear();

            var memSeries = new Series("Physical Memory (%)") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 3, Color = Color.LimeGreen };
            var commitSeries = new Series("Committed Memory (%)") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 2, Color = Color.Yellow, BorderDashStyle = ChartDashStyle.Dash };
            var pageFileSeries = new Series("Page File Usage (%)") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 2, Color = Color.SkyBlue, BorderDashStyle = ChartDashStyle.Dot };
            var faultsSeries = new Series("Page Faults/sec") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 2, Color = Color.OrangeRed, YAxisType = AxisType.Secondary };
            var pagesInSeries = new Series("Pages Input/sec") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 1, Color = Color.Cyan, YAxisType = AxisType.Secondary };
            var pagesOutSeries = new Series("Pages Output/sec") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 1, Color = Color.Magenta, YAxisType = AxisType.Secondary };

            chartMemory.Series.Add(memSeries);
            chartMemory.Series.Add(commitSeries);
            chartMemory.Series.Add(pageFileSeries);
            chartMemory.Series.Add(faultsSeries);
            chartMemory.Series.Add(pagesInSeries);
            chartMemory.Series.Add(pagesOutSeries);

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

        private void GraphForm_Load(object sender, EventArgs e)
        {
            if (IsOnScreen(Properties.Settings.Default.GraphFormLocation))
            {
                this.Location = Properties.Settings.Default.GraphFormLocation;
                this.Size = Properties.Settings.Default.GraphFormSize;
            }
        }

        private bool IsOnScreen(Point location)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.WorkingArea.Contains(location))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

