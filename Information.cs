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

        Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

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
                var sr = new StreamReader(fs, Encoding.Default);

                while (sr.Peek() > -1)
                {
                    var AxisX = new List<double>();
                    var AxisY = new List<double>();
                    var dataArray = sr.ReadLine()?.Split('|');
                    DataTable dt = CsvTable(dataArray?[0]);
                    OpenFileDialog openFileDialog = new OpenFileDialog { FileName = dataArray?[0] };
                    var tabPage = new TabPage { Text = openFileDialog.SafeFileName };
                    if (dataArray != null && dataArray[1].Contains("Chart"))
                    {
                        var cartesianChart = new CartesianChart { Dock = DockStyle.Fill };
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                AxisX.Add(double.Parse(dt.Rows[i].ItemArray[0].ToString()));
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
                                AxisY.Add(double.Parse(dt.Rows[i].ItemArray[1].ToString()));
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }

                        var observablePoint = new ChartValues<ObservablePoint>();
                        observablePoint.AddRange(AxisX.Select((t, i) => 
                            new ObservablePoint(t, AxisY[i])).ToList());

                        cartesianChart.Series = 
                            new SeriesCollection(Mappers.Xy<ObservablePoint>()
                            .X(point => Math.Log10(point.X))
                            .Y(point => point.Y))
                        {
                            new LineSeries()
                            {
                                Title = $"{dt.Columns[0].ColumnName} -> {dt.Columns[1].ColumnName}",
                                Values = observablePoint
                            }
                        };
                        // Добавляем параметры  в вкладку.
                        tabPage.Controls.Add(cartesianChart);
                    }
                    else
                    {
                        var pieChart = new PieChart() { Dock = DockStyle.Fill };
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                AxisX.Add(double.Parse(dt.Rows[i].ItemArray[0].ToString()));
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
                                AxisY.Add(double.Parse(dt.Rows[i].ItemArray[1].ToString()));
                            }
                            catch (Exception)
                            {
                                // ignored
                            }
                        }
                        var observablePoint = new ChartValues<ObservablePoint>();
                        observablePoint.AddRange(AxisX.Select((t, i) => new ObservablePoint(t, AxisY[i])).ToList());
                        pieChart.Series = new SeriesCollection(Mappers.Xy<ObservablePoint>()
                            .X(point => Math.Log10(point.X))
                            .Y(point => point.Y))
                        {
                            new PieSeries()
                            {
                                Title = $"{dt.Columns[0].ColumnName} -> {dt.Columns[1].ColumnName}",
                                Values = observablePoint
                            }
                        };
                        // Добавляем параметры  в вкладку.
                        tabPage.Controls.Add(pieChart);
                    }
                    graphTabControl.SelectedTab = tabPage;
                    graphTabControl.TabPages.Add(tabPage);

                    var graphChart = graphTabControl.TabPages[graphTabControl.SelectedIndex].Controls[0];
                    graphChart.Select();
                    fs.Flush();
                }
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
