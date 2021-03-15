using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace DashboardTables
{
    public partial class TableData : Form
    {
        // Fields.
        private string _filePath;
        private string _graphFilePath = "data.txt";
        private string _newFile;

        public TableData()
        {
            InitializeComponent();
            secondComboBox.IsAccessible = false;
        }

        private void StudentsData_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Reads the csv file https://joshclose.github.io/CsvHelper/examples/reading/
        /// </summary>
        /// <param name="filePath">File path</param>
        /// <returns>DataTable</returns>
        private static DataTable ReadCsvFile(string filePath)
        {
            var dataTable = new DataTable("Data");
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File not found!");
            // Setting up csv configuration for reading.
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
                MissingFieldFound = null,
                TrimOptions = TrimOptions.Trim
            };
            // Creating streams to read the file.
            using var sr = new StreamReader(filePath);
            using var csv = new CsvReader(sr, config);
            using var dr = new CsvDataReader(csv);
            dataTable.Load(dr);

            // For loop check for empty columns.
            for (int i = 1; i <= dataTable.Rows.Count; i++)
            {
                for (int j = 1; j <= dataTable.Columns.Count; j++)
                {
                    if (dataTable.Rows[i - 1].ItemArray[1].ToString() == String.Empty ||
                        dataTable.Rows[i - 1].ItemArray[2].ToString() == String.Empty)
                    {
                        dataTable.Rows.RemoveAt(i - 1);
                    }
                }
            }

            return dataTable;
        }
        /// <summary>
        /// Method of opening files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFile_Click(object sender, EventArgs e)
        {
            try
            {
                using var ofd = new OpenFileDialog()
                {
                    Filter = @"CSV|*.csv", 
                    ValidateNames = true,
                    Multiselect = false,
                    CheckPathExists = true, 
                    Title = @"Select CSV file", 
                    AddExtension = true
                };
                if (ofd.ShowDialog() != DialogResult.OK) return;
                // Connecting to datagridview source.
                courseDataGrid.DataSource = ReadCsvFile(ofd.FileName);
                // Initializing variables.
                _filePath = ofd.SafeFileName;
                fileNameLabel.Text = ofd.SafeFileName;
                firstColumnComboBox.Items.Clear();
                // Checking the url of file.
                switch (ofd.SafeFileName)
                {
                    case "coursea_data.csv":
                        for (int i = 0; i < courseDataGrid.ColumnCount - 1; i++)
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

        /// <summary>
        /// If combo-box of first textbox changed, then we enable the second one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Adding information of chosen columns to the new csv file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addGraphButton_Click(object sender, EventArgs e)
        {
            try
            {
                var fs = new FileStream(_graphFilePath, FileMode.Append, FileAccess.Write);
                using (StreamWriter tr = new StreamWriter(fs))
                {
                    // Checking fields.
                    if (graphComboBox.Text == string.Empty)
                        throw new ArgumentException("Выберите график!");
                    // Creating new graph.
                    SaveGraphTable();
                    if (secondComboBox.Text == string.Empty)
                        throw new ArgumentException("Выберите столбец!");
                    // Writing data to "data.txt".
                    tr.WriteLine($@"{_newFile}|{graphComboBox.Text}");

                    tr.Flush();
                    tr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Saves the graph from DataGridView.
        /// </summary>
        private void SaveGraphTable()
        {
            try
            {
                // Checking field.
                if (_filePath == String.Empty)
                    throw new ArgumentException("Выберите таблицу!");

                var fs = new FileStream($"New {_filePath}", FileMode.OpenOrCreate, FileAccess.Write);
                using (StreamWriter tr = new StreamWriter(fs))
                {
                    // For loop.
                    for (int i = 1; i <= courseDataGrid.Columns.Count; i++)
                    {
                        // If this column name contains in this file, then we write it to the new file.
                        if (firstColumnComboBox.Text == courseDataGrid.Columns[i - 1].Name ||
                            secondComboBox.Text == courseDataGrid.Columns[i - 1].Name)
                        {
                            if (i == courseDataGrid.Columns.Count)
                                tr.WriteAsync(courseDataGrid.Columns[i - 1].Name);
                            else
                                tr.WriteAsync(courseDataGrid.Columns[i - 1].Name + "|");
                        }
                    }

                    tr.Write(Environment.NewLine);
                    // For loop.
                    for (int i = 1; i <= courseDataGrid.Rows.Count; i++)
                    {
                        for (int j = 1; j <= courseDataGrid.Columns.Count; j++)
                        {
                            // If this column name contains in this file, then we write it to the new file.
                            if (firstColumnComboBox.Text == courseDataGrid.Columns[j - 1].Name ||
                                secondComboBox.Text == courseDataGrid.Columns[j - 1].Name)
                            {
                                if (courseDataGrid.Rows[i - 1].Cells[2].Value.ToString() == String.Empty ||
                                    courseDataGrid.Rows[i - 1].Cells[courseDataGrid.Columns.Count - 1].Value.ToString() == String.Empty)
                                {
                                    break;
                                }

                                // If column is max of count , we parse it.
                                if (j == courseDataGrid.Columns.Count)
                                {
                                    // Checking.
                                    if (!double.TryParse(courseDataGrid.Rows[i - 1].Cells[j - 1].Value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture,
                                        out double num))
                                        throw new ArgumentException("Коллона не является числовым значением!");
                                    tr.Write(num);
                                }
                                else
                                {
                                    // Checking.
                                    if (!double.TryParse(courseDataGrid.Rows[i - 1].Cells[j - 1].Value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture,
                                        out double num))
                                        throw new ArgumentException("Коллона не является числовым значением!");

                                    tr.Write(num + "|");
                                }
                            }
                        }
                        // If datagrid doesn't contain empty tables, we write it. 
                        if (courseDataGrid.Rows[i - 1].Cells[1].Value.ToString() != String.Empty)
                            tr.WriteLine();
                    }
                }
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.FileName = fs.Name;
                _newFile = $@"{openFileDialog.FileName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Clearing the graph data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// If combo-box changed , then we enable the graph button choice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphComboBox_SelectedIndexChanged(object sender, EventArgs e) => addGraphButton.Enabled = true;

        /// <summary>
        /// If combo-box changed , then we enable the graph choice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void secondComboBox_SelectedIndexChanged(object sender, EventArgs e) => graphComboBox.Enabled = true;
    }
}
