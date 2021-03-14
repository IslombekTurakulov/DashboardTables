using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace DashboardTables
{
    public partial class TableData : Form
    {
        private string _filePath;
        private string _graphFilePath = "data.txt";
        private string newFile;
        public TableData()
        {
            InitializeComponent();
            secondComboBox.IsAccessible = false;
        }

        private void StudentsData_Load(object sender, EventArgs e)
        {
        }

        private static DataTable ReadCsvFile(string filePath)
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


        private void openFile_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog()
                { Filter = @"CSV|*.csv", ValidateNames = true, Multiselect = false, CheckPathExists = true, Title = "Select csv file", AddExtension = true };
                if (ofd.ShowDialog() != DialogResult.OK) return;
                courseDataGrid.DataSource = ReadCsvFile(ofd.FileName);
                _filePath = ofd.SafeFileName;
                fileNameLabel.Text = ofd.SafeFileName;
                firstColumnComboBox.Items.Clear();
                switch (ofd.SafeFileName)
                {
                    case "coursea_data.csv":
                        for (int i = 0; i < courseDataGrid.ColumnCount - 1; i++)
                            firstColumnComboBox.Items.Add(courseDataGrid.Columns[i].Name);
                        break;
                    case "Оценки студентов.csv":
                        for (int i = 0; i < courseDataGrid.ColumnCount; i++)
                            firstColumnComboBox.Items.Add(courseDataGrid.Columns[i].Name);
                        break;
                    case "Рестораны.csv":
                        for (int i = 0; i < courseDataGrid.ColumnCount; i++)
                            firstColumnComboBox.Items.Add(courseDataGrid.Columns[i].Name);
                        break;
                    default:
                        for (int i = 0; i < courseDataGrid.ColumnCount; i++)
                            firstColumnComboBox.Items.Add(courseDataGrid.Columns[i].Name);
                        break;

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void columnChooseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            secondComboBox.IsAccessible = true;
            secondComboBox.Items.Clear();
            foreach (var item in firstColumnComboBox.Items)
            {
                // Проверяет , не повторяется ли имя в списке, если повторяется, то выбирает случайный элемент.
                if (firstColumnComboBox.Text.Contains(item.ToString())) continue;
                secondComboBox.Items.Add(item);
            }
        }

        private void addGraphButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_filePath == null)
                    throw new ArgumentException("Выберите таблицу!");

                SaveGraphTable();

                if (graphComboBox.Text == string.Empty)
                    throw new ArgumentException("Выберите график!");

                var choose = int.Parse(countComboBox.Text);
               
                var columns = string.Empty;
                switch (choose)
                {
                    case 1:
                        columns += $"{choose}|{firstColumnComboBox.Text}";
                        break;
                    case 2:
                        if (secondComboBox.Text == string.Empty)
                            throw new ArgumentException("Выберите столбец!");
                        columns += $"{choose}|{firstColumnComboBox.Text}|{secondComboBox.Text}";
                        break;
                }
                File.WriteAllText(_graphFilePath,$"{newFile}|{graphComboBox.Text}|{columns}" + Environment.NewLine);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveGraphTable()
        {
            try
            {
                var fs = new FileStream($"New {_filePath}", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter tr = new StreamWriter(fs);
                for (int i = 1; i <= courseDataGrid.Columns.Count; i++)
                {
                    if (firstColumnComboBox.Text == courseDataGrid.Columns[i - 1].Name ||
                        secondComboBox.Text == courseDataGrid.Columns[i - 1].Name)
                    {
                        if (i == courseDataGrid.Columns.Count)
                        {
                            tr.WriteAsync(courseDataGrid.Columns[i - 1].Name);
                        }
                        else
                        {
                            if (int.Parse(countComboBox.Text) == 1)
                                tr.WriteAsync(courseDataGrid.Columns[i - 1].Name);
                            else
                                tr.WriteAsync(courseDataGrid.Columns[i - 1].Name + "|");
                        }
                    }
                }

                tr.Write(Environment.NewLine);
                for (int i = 1; i <= courseDataGrid.Rows.Count; i++)
                {
                    for (int j = 1; j <= courseDataGrid.Columns.Count; j++)
                    {
                        if (firstColumnComboBox.Text == courseDataGrid.Columns[j - 1].Name ||
                            secondComboBox.Text == courseDataGrid.Columns[j - 1].Name)
                        {
                            if (courseDataGrid.Rows[i - 1].Cells[2].Value.ToString() == String.Empty)
                            {
                                break;
                            }

                            if (j == courseDataGrid.Columns.Count)
                                tr.Write(courseDataGrid.Rows[i - 1].Cells[j - 1].Value);
                            else
                            {
                                if (int.Parse(countComboBox.Text) == 1)
                                    tr.Write(courseDataGrid.Rows[i - 1].Cells[j - 1].Value);
                                else
                                    tr.Write(courseDataGrid.Rows[i - 1].Cells[j - 1].Value + "|");
                            }
                        }
                    }
                    if (courseDataGrid.Rows[i - 1].Cells[2].Value.ToString() != String.Empty)
                        tr.WriteLine();
                }
                newFile = $"New {_filePath}";
                tr.Flush();
                tr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void countComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var choose = int.Parse(countComboBox.Text);
            switch (choose)
            {
                case 1:
                    firstColumnComboBox.Enabled = true;
                    secondComboBox.Enabled = false;
                    break;
                case 2:
                    firstColumnComboBox.Enabled = true;
                    secondComboBox.Enabled = true;
                    break;
            }
            graphComboBox.Enabled = true;
        }

        private void clearGraphFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(_graphFilePath))
                {
                    File.Delete(_graphFilePath);
                    MessageBox.Show("Успешно очищено!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                var fs = new FileStream($"New {_filePath}", FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter tr = new StreamWriter(fs);
                for (var i = 1; i <= courseDataGrid.Columns.Count; i++)
                {
                    if (firstColumnComboBox.Text == courseDataGrid.Columns[i - 1].Name ||
                        secondComboBox.Text == courseDataGrid.Columns[i - 1].Name)
                    {
                        if (i == courseDataGrid.Columns.Count)
                        {
                            tr.WriteAsync(courseDataGrid.Columns[i - 1].Name);
                        }
                        else
                        {
                            if (int.Parse(countComboBox.Text) == 1)
                                tr.WriteAsync(courseDataGrid.Columns[i - 1].Name);
                            else
                                tr.WriteAsync(courseDataGrid.Columns[i - 1].Name + "|");
                        }
                    }
                }

                tr.Write(Environment.NewLine);
                for (var i = 1; i <= courseDataGrid.Rows.Count; i++)
                {
                    for (var j = 1; j <= courseDataGrid.Columns.Count; j++)
                    {
                        if (firstColumnComboBox.Text == courseDataGrid.Columns[j - 1].Name ||
                            secondComboBox.Text == courseDataGrid.Columns[j - 1].Name)
                        {
                            if (courseDataGrid.Rows[i - 1].Cells[2].Value.ToString() == String.Empty)
                            {
                                break;
                            }

                            if (j == courseDataGrid.Columns.Count)
                                tr.Write(courseDataGrid.Rows[i - 1].Cells[j - 1].Value);
                            else
                            {
                                if (int.Parse(countComboBox.Text) == 1)
                                    tr.Write(courseDataGrid.Rows[i - 1].Cells[j - 1].Value + Environment.NewLine);
                                else
                                    tr.Write(courseDataGrid.Rows[i - 1].Cells[j - 1].Value + "|");
                            }
                        }
                    }

                    if (courseDataGrid.Rows[i - 1].Cells[2].Value.ToString() != String.Empty)
                        tr.Write(Environment.NewLine);
                }
                tr.Flush();
                tr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void graphComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            addGraphButton.Enabled = true;
        }

    }
}
