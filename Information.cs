using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Media;
using CsvHelper;
using CsvHelper.Configuration;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using CartesianChart = LiveCharts.WinForms.CartesianChart;
using PieChart = LiveCharts.WinForms.PieChart;
using Point = System.Windows.Point;

namespace DashboardTables
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        private DataTable CsvTable(string filePath)
        {
            try
            {
                DataTable dt = new DataTable();
                using StreamReader sr = new StreamReader(filePath);
                string[] headers = sr.ReadLine()?.Split('|');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine()?.Split('|');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows?[i];
                    }
                    dt.Rows.Add(dr);
                    if (dt.Rows.Count > 50)
                        break;
                }

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;

        }

        private void Information_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists("data.txt"))
                    throw new ArgumentException("Add graph!");

                var fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
                var sr = new StreamReader(fs, Encoding.UTF8);

                while (sr.Peek() > -1)
                {
                    var axisX = new List<double>();
                    var axisY = new List<double>();
                    var dataArray = sr.ReadLine()?.Split('|');
                    if (dataArray[0] == String.Empty)
                        continue;
                    DataTable dt = CsvTable(dataArray?[0]);
                    OpenFileDialog openFileDialog = new OpenFileDialog { FileName = dataArray?[0] };
                    var tabPage = new TabPage { Text = openFileDialog.SafeFileName };
                    if (dataArray[1] == "Chart")
                    {
                        var cartesianChart = new CartesianChart
                        {
                            Dock = DockStyle.Fill,
                            Zoom = ZoomingOptions.X,
                            LegendLocation = LegendLocation.Right
                        };
                        var gradientBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0, 0),
                            EndPoint = new Point(0, 1)
                        };
                        gradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(33, 148, 241), 0));
                        gradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                if (double.TryParse(dt.Rows[i].ItemArray[0].ToString(),
                                    NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                                    axisX.Add(num);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                if (double.TryParse(dt.Rows[i].ItemArray[1].ToString(),
                                    NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                                    axisY.Add(num);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }

                        var observablePoint = new ChartValues<ObservablePoint>();
                        observablePoint.AddRange(axisX.Select((t, i) =>
                            new ObservablePoint(t, axisY[i])).ToList());

                        cartesianChart.Series =
                            new SeriesCollection(Mappers.Xy<ObservablePoint>()
                                .X(point => Math.Log10(point.X))
                                .Y(point => point.Y))
                            {
                                new LineSeries()
                                {
                                    Title = $"{dt.Columns[0].ColumnName} => {dt.Columns[1].ColumnName}",
                                    Values = observablePoint,
                                    DataLabels = true,
                                    Fill = gradientBrush,
                                    StrokeThickness = 1,
                                }
                            };
                        // Добавляем параметры  в вкладку.
                        tabPage.Controls.Add(cartesianChart);
                    }
                    else
                    {
                       var cartesianChart = new CartesianChart
                        {
                            Dock = DockStyle.Fill,
                            Zoom = ZoomingOptions.Xy,
                        };
                        var gradientBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0, 0),
                            EndPoint = new Point(0, 1)
                        };
                        gradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(33, 148, 241), 0));
                        gradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                if (double.TryParse(dt.Rows[i].ItemArray[0].ToString(),
                                    NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                                    axisX.Add(num);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                if (double.TryParse(dt.Rows[i].ItemArray[1].ToString(),
                                    NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                                    axisY.Add(num);
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }

                        if (axisX.Count == 0 || axisY.Count == 0 || axisX.Count != axisY.Count)
                            throw new ArgumentException("Not enough data to build the graph!");
                        axisX.Sort();
                        axisY.Sort();
                        var observablePoint = new ChartValues<ObservablePoint>();
                        observablePoint.AddRange(axisX.Select((t, i) =>
                            new ObservablePoint(t, axisY[i])).ToList());

                        cartesianChart.Series =
                            new SeriesCollection(Mappers.Xy<ObservablePoint>()
                                .X(point => Math.Log10(point.X))
                                .Y(point => point.Y))
                            {
                                new ColumnSeries()
                                {
                                    Title = $"{dt.Columns[0].ColumnName} -> {dt.Columns[1].ColumnName}",
                                    Values = observablePoint,
                                    DataLabels = true,
                                    Fill = gradientBrush,
                                    StrokeThickness = 1,
                                }
                            };
                        // Добавляем параметры  в вкладку.
                        tabPage.Controls.Add(cartesianChart);
                    }

                    graphTabControl.SelectedTab = tabPage;
                    graphTabControl.TabPages.Add(tabPage);

                    var graphChart = graphTabControl.TabPages[graphTabControl.SelectedIndex].Controls[0];
                    graphChart.Select();
                }
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private CartesianChart SelectedTab()
        {
            CartesianChart cartesian = null;
            TabPage tabpage = graphTabControl.SelectedTab;
            foreach (var c in tabpage.Controls)
                if (c is CartesianChart box)
                    cartesian = box;
            return cartesian;
        }

        private void ClearZoom()
        {
            //to clear the current zoom/pan just set the axis limits to double.NaN
            TabPage tabPage = graphTabControl.SelectedTab;

            SelectedTab().AxisX[0].MinValue = double.NaN;
            SelectedTab().AxisX[0].MaxValue = double.NaN;
            SelectedTab().AxisY[0].MinValue = double.NaN;
            SelectedTab().AxisY[0].MaxValue = double.NaN;
        }
    }
}
