using System;
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
                var dt = new DataTable();
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                    MissingFieldFound = null,
                    Delimiter = "|",
                    TrimOptions = TrimOptions.Trim
                };

                using var sr = new StreamReader(filePath);
                using var csv = new CsvReader(sr, config);
                using var dr = new CsvDataReader(csv);

                dt.Load(dr);

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
                CartesianChart cartesianChart = new CartesianChart
                {
                    Dock = DockStyle.Fill
                };
                PieChart pieChart = new PieChart
                {
                    Dock = DockStyle.Fill
                };
                while (sr.Peek() > -1)
                {
                    string[] dataArray = sr.ReadLine()?.Split('|');
                    dataGridView.DataSource = CsvTable(dataArray?[0]);
                    TabPage tabPage = new TabPage
                    {
                        Text = dataArray?[0]
                    };

                    if (dataArray[1].Contains("Chart"))
                    {
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            cartesianChart.Series.Add( new ColumnSeries()
                           {
                               Title = dataGridView.Columns[1].Name,
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

                        // Добавляем параметры  в вкладку
                        tabPage.Controls.Add(pieChart);
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
