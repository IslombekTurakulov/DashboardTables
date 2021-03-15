using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using CartesianChart = LiveCharts.WinForms.CartesianChart;
using Color = System.Windows.Media.Color;
using PieChart = LiveCharts.WinForms.PieChart;
using Point = System.Windows.Point;
using SeriesCollection = LiveCharts.SeriesCollection;

namespace DashboardTables
{
    public partial class Information : Form
    {
        private int counterScreen = 0;
        public Information()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Reading new csv table.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private DataTable CsvTable(string filePath)
        {
            try
            {
                DataTable dt = new DataTable();
                using StreamReader sr = new StreamReader(filePath);
                // Reading the first Column
                string[] headers = sr.ReadLine()?.Split('|');
                // Through foreach loop adding it to datatable.
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    // Reading the rows.
                    string[] rows = sr.ReadLine()?.Split('|');
                    DataRow dr = dt.NewRow();
                    //
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows?[i];
                    }
                    dt.Rows.Add(dr);
                    if (dt.Rows.Count > 40)
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

        /// <summary>
        /// Checking the Median.
        /// </summary>
        /// <param name="xs"></param>
        /// <returns></returns>
        private double MedianAxisXy(double[] xs)
        {
            var ys = xs.OrderBy(x => x).ToList();
            double mid = (ys.Count - 1) / 2.0;
            return (ys[(int)(mid)] + ys[(int)(mid + 0.5)]) / 2;
        }

        /// <summary>
        /// Checking dispression.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private double DispresionAxisXy(List<double> t)
        {
            double m = t.Average();
            return t.Sum(a => Math.Pow(a - m, 2) / t.Count);
        }

        /// <summary>
        /// Checking the variances.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        private double GAverage(List<double> t) => Math.Sqrt(DispresionAxisXy(t));

        /// <summary>
        /// The big initializing data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Information_Load(object sender, EventArgs e)
        {
            try
            {
                // Checking the existance of file.
                if (!File.Exists("data.txt"))
                    throw new ArgumentException("Add graph!");

                var fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
                var sr = new StreamReader(fs, Encoding.UTF8);

                while (sr.Peek() > -1)
                {
                    // We set the limit of tabpages to reduce the memory capacity.
                    if (graphTabControl.TabPages.Count >= 10)
                    {
                        MessageBox.Show("Max tabs is 10!");
                        break;
                    }
                    // Creating two list for X and Y coords.
                    var axisX = new List<double>();
                    var axisY = new List<double>();
                    // Taking the info from file "data.txt".
                    var dataArray = sr.ReadLine()?.Split('|');
                    // If the first index is Empty, check the next.
                    if (dataArray[0] == String.Empty)
                        continue;
                    // Initializing the new datatable
                    DataTable dt = CsvTable(dataArray?[0]);
                    OpenFileDialog openFileDialog = new OpenFileDialog { FileName = dataArray?[0] };
                    // Creating the new tabpage.
                    var tabPage = new TabPage
                    {
                        Text = openFileDialog.SafeFileName,
                        AccessibleDescription = dataArray[1]
                    };
                    // Parsing the digits.
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
                    // Check, if data is Chart.
                    if (dataArray[1] == "Chart")
                    {
                        // Creating new object CartesianChart.
                        var cartesianChart = new CartesianChart
                        {
                            Dock = DockStyle.Fill,
                            Zoom = ZoomingOptions.X,
                            LegendLocation = LegendLocation.Right
                        };
                        // For color.
                        var gradientBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0, 0),
                            EndPoint = new Point(0, 1)
                        };
                        gradientBrush.GradientStops.Add(new GradientStop(Color.FromRgb(33, 148, 241), 0));
                        gradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));

                        // Sorting lists.
                        axisX.Sort();
                        axisY.Sort();
                        // Choosing points.
                        var observablePoint = new ChartValues<ObservablePoint>();
                        observablePoint.AddRange(axisX.Select((t, i) =>
                            new ObservablePoint(t, axisY[i])).ToList());
                        // It needs to calculate the avg, median,sa and dispress
                        GetInfo(axisX, axisY);
                        // Adding new Series.
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
                        // Creating new panel.
                        Panel panel = new Panel();
                        panel = barPanel;
                        // Adding to control.
                        tabPage.Controls.Add(panel);
                        cartesianChart.DataClick += CartesianChart_DataClick;
                        // Добавляем параметры  в вкладку.
                        tabPage.Controls.Add(cartesianChart);
                    }
                    else
                    {
                        // Creating new object PieChart.
                        var pieChart = new PieChart
                        {
                            Dock = DockStyle.Fill
                        };
                        // Sorting the lists.
                        axisX.Sort();
                        // Adding chart.
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            pieChart.Series.Add(
                                new PieSeries()
                                {
                                    Title = $"{dt.Columns[1].ColumnName}",
                                    Values = new ChartValues<double>() { axisX[i] },
                                    DataLabels = true,
                                }
                                );
                        }
                        // Adding second Chart
                        var secondColumn = new CartesianChart() { Dock = DockStyle.Right, };

                        // Initializing it.
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (i == 30)
                                break;
                            secondColumn.Series.Add(
                                new ColumnSeries()
                                {
                                    Title = $"{dt.Columns[0].ColumnName}",
                                    Values = new ChartValues<double>() { axisX[i] },
                                    DataLabels = true,
                                    Width = 5,
                                    Height = 10
                                }
                            );
                        }
                        // Adding to panels.
                        var firstPanel = new Panel()
                        {
                            Dock = DockStyle.Right,
                            Size = new Size(500, 500),
                        };
                        var secondPanel = new Panel()
                        {
                            Dock = DockStyle.Left,
                            AutoSize = true,
                            AutoSizeMode = AutoSizeMode.GrowOnly
                        };
                        // And Adding all of these to tabpage control
                        // + connecting events.
                        firstPanel.Controls.Add(pieChart);
                        secondPanel.Controls.Add(secondColumn);
                        pieChart.DataClick += PieChart_DataClick;
                        secondColumn.DataClick += ColumnChart_DataClick;

                        // Adding parameters.
                        tabPage.Controls.Add(firstPanel);
                        tabPage.Controls.Add(secondPanel);
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


        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            try
            {
                using var colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    ((PieSeries)chartPoint.SeriesView).Fill =
                        new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R,
                            colorDialog.Color.G, colorDialog.Color.B));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CartesianChart_DataClick(object sender, ChartPoint chartPoint)
        {
            try
            {
                using var colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    ((LineSeries)chartPoint.SeriesView).Fill =
                        new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R,
                            colorDialog.Color.G, colorDialog.Color.B));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void ColumnChart_DataClick(object sender, ChartPoint chartPoint)
        {
            try
            {
                using var colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    ((ColumnSeries)chartPoint.SeriesView).Fill =
                        new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R,
                            colorDialog.Color.G, colorDialog.Color.B));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void GetInfo(List<double> axisX, List<double> axisY)
        {
            avgAxisXLabel.Text = "Average: " + (int)axisX.Average();
            avgAxisYLabel.Text = "Average: " + (int)Math.Round(axisY.Average());
            medianAxisYLabel.Text = "MedianAxisXY: " + (int)Math.Round(MedianAxisXy(axisY.ToArray()));
            medianLabel.Text = "MedianAxisXY: " + (int)MedianAxisXy(axisX.ToArray());
            dispresionAxisYLabel.Text = "Dispresion: " + (int)Math.Round(DispresionAxisXy(axisY));
            dispresionLabel.Text = "Dispresion: " + (int)DispresionAxisXy(axisX);
            axisXSa.Text = "SA: " + (int)GAverage(axisX);
            axisYSa.Text = "SA: " + (int)Math.Round(GAverage(axisY));
        }

        private void saveChartBtn_Click(object sender, EventArgs e)
        {

            try
            {
                var chart = graphTabControl.SelectedTab;

                using (var bmp = new Bitmap(chart.Width, chart.Height))
                {
                    SaveFileDialog sfd = new SaveFileDialog()
                    {
                        Filter = "JPG File (*.jpg)|*.jpg|PNG File (*.png)|*.png",
                        AddExtension = true,
                        Title = "Please save your graph!",
                        FileName = "myNewScreenGraph"
                    };
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        chart.DrawToBitmap(bmp, new Rectangle(0, 0, chart.Width, chart.Height));
                        bmp.Save(sfd.FileName);
                    }
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
