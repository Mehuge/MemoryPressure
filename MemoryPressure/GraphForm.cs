// GraphForm.cs
// This file contains the logic for the new graph window.
// CORRECTED: Now a simple renderer; all data processing is handled by Form1.

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

        public void UpdateGraph(List<MemoryDataPoint> processedData)
        {
            if (this.IsDisposed || !this.IsHandleCreated || chartMemory.IsDisposed) return;

            this.Invoke((MethodInvoker)delegate
            {
                if (chartMemory.Series.Count == 0) return;

                var memSeries = chartMemory.Series["Physical Memory (%)"];
                var commitSeries = chartMemory.Series["Committed Memory (%)"];
                var pageFileSeries = chartMemory.Series["Page File Usage (%)"];
                var faultsSeries = chartMemory.Series["Page Faults/sec"];
                var pagesInSeries = chartMemory.Series["Pages Input/sec"];
                var pagesOutSeries = chartMemory.Series["Pages Output/sec"];

                var savedMetrics = Properties.Settings.Default.VisibleMetrics;
                if (savedMetrics == null) // First-run scenario
                {
                    memSeries.Enabled = true;
                    commitSeries.Enabled = true;
                    pageFileSeries.Enabled = true;
                    faultsSeries.Enabled = true;
                    pagesInSeries.Enabled = true;
                    pagesOutSeries.Enabled = true;
                }
                else
                {
                    var visibleMetrics = new HashSet<string>(savedMetrics.Cast<string>());
                    memSeries.Enabled = visibleMetrics.Contains("Physical Memory (%)");
                    commitSeries.Enabled = visibleMetrics.Contains("Committed Memory (%)");
                    pageFileSeries.Enabled = visibleMetrics.Contains("Page File Usage (%)");
                    faultsSeries.Enabled = visibleMetrics.Contains("Page Faults/sec");
                    pagesInSeries.Enabled = visibleMetrics.Contains("Pages Input/sec");
                    pagesOutSeries.Enabled = visibleMetrics.Contains("Pages Output/sec");
                }

                memSeries.Points.Clear();
                commitSeries.Points.Clear();
                pageFileSeries.Points.Clear();
                faultsSeries.Points.Clear();
                pagesInSeries.Points.Clear();
                pagesOutSeries.Points.Clear();

                foreach (var point in processedData)
                {
                    memSeries.Points.AddXY(point.Timestamp, point.MemoryLoad);
                    commitSeries.Points.AddXY(point.Timestamp, point.CommittedMemoryPercentage);
                    pageFileSeries.Points.AddXY(point.Timestamp, point.PageFileUsagePercentage);
                    faultsSeries.Points.AddXY(point.Timestamp, point.PageFaultsPerSec);
                    pagesInSeries.Points.AddXY(point.Timestamp, point.PagesInputPerSec);
                    pagesOutSeries.Points.AddXY(point.Timestamp, point.PagesOutputPerSec);
                }

                memSeries.MarkerStyle = processedData.Count < 100 ? MarkerStyle.Circle : MarkerStyle.None;

                chartMemory.Invalidate();
            });
        }

        private void ConfigureChartAppearance()
        {
            chartMemory.Series.Clear();

            var seriesList = new List<Series>
            {
                new Series("Physical Memory (%)") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 3, Color = Color.LimeGreen },
                new Series("Committed Memory (%)") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 2, Color = Color.Yellow, BorderDashStyle = ChartDashStyle.Dash },
                new Series("Page File Usage (%)") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 2, Color = Color.SkyBlue, BorderDashStyle = ChartDashStyle.Dot },
                new Series("Page Faults/sec") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 2, Color = Color.OrangeRed, YAxisType = AxisType.Secondary },
                new Series("Pages Input/sec") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 1, Color = Color.Cyan, YAxisType = AxisType.Secondary },
                new Series("Pages Output/sec") { ChartType = SeriesChartType.Line, XValueType = ChartValueType.DateTime, BorderWidth = 1, Color = Color.Magenta, YAxisType = AxisType.Secondary }
            };

            foreach (var s in seriesList)
            {
                s.MarkerSize = 5;
                chartMemory.Series.Add(s);
            }

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

