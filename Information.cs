using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
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

        Func<ChartPoint, string> labelPoint = chartPoint =>
            string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

        private DataTable CsvTable(string filePath)
        {
            try
            {
                var dataTable = new DataTable("Data");
                using var cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"" +
                                                   Path.GetDirectoryName(filePath) +
                                                   "\";Extended Properties='text;HDR=yes;FMT=Delimited(|)';");
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
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            cartesianChart.Series.Add( new ColumnSeries()
                           {
                               Title = dataGridView.Columns[i].Name,
                               Values = new ChartValues<double>
                                   {double.Parse(dataGridView.Rows[i].Cells[1].Value.ToString())},
                               DataLabels = false,
                               LabelPoint = labelPoint
                           });
                        }
                        // Добавляем параметры  в вкладку
                        tabPage.Controls.Add(cartesianChart);
                    }
                    else
                    {
                        PieChart pieChart = new PieChart();
                       
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
