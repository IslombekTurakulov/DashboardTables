using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using LiveCharts;
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
                var dataTable = new DataTable("Data");
                using var cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"" +
                                                   Path.GetDirectoryName(filePath) +
                                                   "\";Extended Properties='text;HDR=yes;FMT=Delimited(,)';");
                using var cmd =
                    new OleDbCommand($"select *from [{new FileInfo(filePath).Name}]", cn);
                cn.Open();
                using var adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dataTable);

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;

        }
        private ChartValues<double> GetData(DataGridView dataGridView)
        {
            var values = new ChartValues<double>();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                values.Add(double.Parse(dataGridView.Rows[i].Cells[2].Value.ToString()));
            }
 
            return values;
        }

        private ChartValues<string> OneGetData (DataGridView dataGridView)
        {
            var values = new ChartValues<string>();

            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                values.Add(dataGridView.Rows[i].Cells[1].Value.ToString());
            }
            return values;
        }

        private void Information_Load(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists("data.txt"))
                    throw new ArgumentException("Create graph!");
                var fs = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
                var sr = new StreamReader(fs, Encoding.Default);
                while (sr.Peek() > -1)
                {
                    string[] dataArray = sr.ReadLine()?.Split('|');
                    DataGridView dataGridView = new DataGridView();
                    dataGridView.DataSource = CsvTable(dataArray?[0]);
                    if (dataArray[1].Contains("Chart"))
                    {
                        CartesianChart cartesianChart = new CartesianChart();
                        var gradientBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0, 0),
                            EndPoint = new Point(0, 1)
                        };

                        gradientBrush.GradientStops.Add(new GradientStop(System.Windows.Media.Color.FromRgb(33, 148, 241), 0));
                        gradientBrush.GradientStops.Add(new GradientStop(Colors.Transparent, 1));
                        cartesianChart.AxisY.Add(new Axis
                        {
                            LabelFormatter = val => val.ToString("C")
                        });
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
                    }
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
