using System;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Media;
using CsvHelper;
using LiveCharts;
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
                StreamReader sr = new StreamReader(filePath);
                string[] headers = sr.ReadLine().Split('|'); 
                DataTable dt = new DataTable();
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
                DataGridView dataGridView = new DataGridView();
                while (sr.Peek() > -1)
                {
                    string[] dataArray = sr.ReadLine()?.Split('|');
                    TabPage tabPage = new TabPage
                    {
                        Name = dataArray?[0]
                    };
                    dataGridView.DataSource = CsvTable(dataArray?[0]);

                    if (dataArray[1].Contains("Chart"))
                    {
                        CartesianChart cartesianChart = new CartesianChart()
                        {
                            Dock = DockStyle.Fill
                        };
                        cartesianChart.AxisY.Add(new Axis
                        {
                            LabelFormatter = val => val.ToString("C")
                        });
                        var gradientBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0, 0),
                            EndPoint = new Point(0, 1)
                        };

                        gradientBrush.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromRgb(33, 148, 241), 0));
                        gradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));
                        if (int.Parse(dataArray[2]) == 1)
                        {
                            cartesianChart.Series.Add(new LineSeries
                            {
                                Values = OneGetData(dataGridView),
                                Fill = gradientBrush,
                                StrokeThickness = 1,
                                PointGeometry = null
                            });
 
                            cartesianChart.Zoom = ZoomingOptions.X;

                            for (int i = 0; i < dataGridView.Rows.Count; i++)
                            {
                                cartesianChart.AxisX.Add(new Axis
                                {
                                    LabelFormatter = val => dataGridView.Rows[i].Cells[1].Value.ToString()
                                });
                            }
                        }
                        else
                        {

                            cartesianChart.Series.Add(new LineSeries
                            {
                                Values = GetData(dataGridView),
                                Fill = gradientBrush,
                                StrokeThickness = 1,
                                PointGeometry = null
                            });
 
                            cartesianChart.Zoom = ZoomingOptions.X;

                            for (int i = 0; i < dataGridView.Rows.Count; i++)
                            {
                                cartesianChart.AxisX.Add(new Axis
                                {
                                    LabelFormatter = val => dataGridView.Rows[i].Cells[1].Value.ToString()
                                });
                            }
                        }
                        // Добавляем параметры  в вкладку
                        tabPage.Controls.Add(cartesianChart);
                    }
                    else
                    {
                        PieChart pieChart = new PieChart();
                        if (int.Parse(dataArray[2]) == 1)
                        {

                        }
                        else
                        {
                            
                        }
                        // Добавляем параметры  в вкладку
                        tabPage.Controls.Add(pieChart);
                    }
                    graphTabControl.SelectedTab = tabPage;
                    graphTabControl.TabPages.Add(tabPage);

                    var graphChart = graphTabControl.TabPages[graphTabControl.SelectedIndex].Controls[0];
                    graphChart.Select();
                }
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
