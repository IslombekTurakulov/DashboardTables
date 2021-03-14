
namespace DashboardTables
{
    partial class TableData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.courseDataGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.clearGraphFile = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.chooseColumnPanel = new System.Windows.Forms.Panel();
            this.countComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.graphChoosePanel = new System.Windows.Forms.Panel();
            this.addGraphButton = new System.Windows.Forms.Button();
            this.secondComboBox = new System.Windows.Forms.ComboBox();
            this.secondLabel = new System.Windows.Forms.Label();
            this.graphComboBox = new System.Windows.Forms.ComboBox();
            this.graphLabel = new System.Windows.Forms.Label();
            this.firstColumnComboBox = new System.Windows.Forms.ComboBox();
            this.columnChooserLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.tablePanel.SuspendLayout();
            this.chooseColumnPanel.SuspendLayout();
            this.graphChoosePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // courseDataGrid
            // 
            this.courseDataGrid.AllowUserToAddRows = false;
            this.courseDataGrid.AllowUserToDeleteRows = false;
            this.courseDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.courseDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.courseDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(98)))), ((int)(((byte)(117)))));
            this.courseDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.courseDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.courseDataGrid.Location = new System.Drawing.Point(0, 0);
            this.courseDataGrid.Name = "courseDataGrid";
            this.courseDataGrid.ReadOnly = true;
            this.courseDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.courseDataGrid.Size = new System.Drawing.Size(875, 565);
            this.courseDataGrid.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(215)))), ((int)(((byte)(148)))));
            this.panel1.Controls.Add(this.fileNameLabel);
            this.panel1.Controls.Add(this.clearGraphFile);
            this.panel1.Controls.Add(this.exportButton);
            this.panel1.Controls.Add(this.openFile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 35);
            this.panel1.TabIndex = 1;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNameLabel.Location = new System.Drawing.Point(417, 7);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(91, 22);
            this.fileNameLabel.TabIndex = 3;
            this.fileNameLabel.Text = "File Name";
            // 
            // clearGraphFile
            // 
            this.clearGraphFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.clearGraphFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearGraphFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearGraphFile.Location = new System.Drawing.Point(753, 0);
            this.clearGraphFile.Name = "clearGraphFile";
            this.clearGraphFile.Size = new System.Drawing.Size(122, 35);
            this.clearGraphFile.TabIndex = 2;
            this.clearGraphFile.Text = "Clear Graph Data";
            this.clearGraphFile.UseVisualStyleBackColor = true;
            this.clearGraphFile.Click += new System.EventHandler(this.clearGraphFile_Click);
            // 
            // exportButton
            // 
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exportButton.Location = new System.Drawing.Point(96, 0);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(108, 35);
            this.exportButton.TabIndex = 1;
            this.exportButton.Text = "Export CSV File";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // openFile
            // 
            this.openFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openFile.Location = new System.Drawing.Point(0, 0);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(98, 35);
            this.openFile.TabIndex = 0;
            this.openFile.Text = "Open CSV File";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // tablePanel
            // 
            this.tablePanel.Controls.Add(this.courseDataGrid);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Location = new System.Drawing.Point(0, 35);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Size = new System.Drawing.Size(875, 565);
            this.tablePanel.TabIndex = 2;
            // 
            // chooseColumnPanel
            // 
            this.chooseColumnPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(215)))), ((int)(((byte)(148)))));
            this.chooseColumnPanel.Controls.Add(this.countComboBox);
            this.chooseColumnPanel.Controls.Add(this.label1);
            this.chooseColumnPanel.Controls.Add(this.graphChoosePanel);
            this.chooseColumnPanel.Controls.Add(this.secondComboBox);
            this.chooseColumnPanel.Controls.Add(this.secondLabel);
            this.chooseColumnPanel.Controls.Add(this.graphComboBox);
            this.chooseColumnPanel.Controls.Add(this.graphLabel);
            this.chooseColumnPanel.Controls.Add(this.firstColumnComboBox);
            this.chooseColumnPanel.Controls.Add(this.columnChooserLabel);
            this.chooseColumnPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chooseColumnPanel.Location = new System.Drawing.Point(0, 470);
            this.chooseColumnPanel.Name = "chooseColumnPanel";
            this.chooseColumnPanel.Size = new System.Drawing.Size(875, 130);
            this.chooseColumnPanel.TabIndex = 3;
            // 
            // countComboBox
            // 
            this.countComboBox.AccessibleDescription = "Amount of Columns";
            this.countComboBox.AccessibleName = "Count";
            this.countComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.countComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countComboBox.FormatString = "N0";
            this.countComboBox.FormattingEnabled = true;
            this.countComboBox.Items.AddRange(new object[] {
            "1",
            "2"});
            this.countComboBox.Location = new System.Drawing.Point(29, 67);
            this.countComboBox.Name = "countComboBox";
            this.countComboBox.Size = new System.Drawing.Size(104, 21);
            this.countComboBox.TabIndex = 10;
            this.countComboBox.SelectedIndexChanged += new System.EventHandler(this.countComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(37, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Columns:";
            // 
            // graphChoosePanel
            // 
            this.graphChoosePanel.Controls.Add(this.addGraphButton);
            this.graphChoosePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.graphChoosePanel.Location = new System.Drawing.Point(753, 0);
            this.graphChoosePanel.Name = "graphChoosePanel";
            this.graphChoosePanel.Size = new System.Drawing.Size(122, 130);
            this.graphChoosePanel.TabIndex = 8;
            // 
            // addGraphButton
            // 
            this.addGraphButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(205)))), ((int)(((byte)(121)))));
            this.addGraphButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addGraphButton.Enabled = false;
            this.addGraphButton.FlatAppearance.BorderSize = 0;
            this.addGraphButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addGraphButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addGraphButton.Location = new System.Drawing.Point(0, 0);
            this.addGraphButton.Name = "addGraphButton";
            this.addGraphButton.Size = new System.Drawing.Size(122, 130);
            this.addGraphButton.TabIndex = 3;
            this.addGraphButton.Text = "Add Graph Data";
            this.addGraphButton.UseVisualStyleBackColor = false;
            this.addGraphButton.Click += new System.EventHandler(this.addGraphButton_Click);
            // 
            // secondComboBox
            // 
            this.secondComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.secondComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.secondComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.secondComboBox.Enabled = false;
            this.secondComboBox.FormattingEnabled = true;
            this.secondComboBox.Location = new System.Drawing.Point(364, 66);
            this.secondComboBox.Name = "secondComboBox";
            this.secondComboBox.Size = new System.Drawing.Size(134, 21);
            this.secondComboBox.TabIndex = 5;
            // 
            // secondLabel
            // 
            this.secondLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.secondLabel.AutoSize = true;
            this.secondLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.secondLabel.Location = new System.Drawing.Point(349, 37);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(159, 50);
            this.secondLabel.TabIndex = 4;
            this.secondLabel.Text = "Second Column:\r\n\r\n";
            // 
            // graphComboBox
            // 
            this.graphComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.graphComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.graphComboBox.Enabled = false;
            this.graphComboBox.FormattingEnabled = true;
            this.graphComboBox.Items.AddRange(new object[] {
            "Chart",
            "Pie Chart"});
            this.graphComboBox.Location = new System.Drawing.Point(591, 65);
            this.graphComboBox.Name = "graphComboBox";
            this.graphComboBox.Size = new System.Drawing.Size(141, 21);
            this.graphComboBox.TabIndex = 3;
            this.graphComboBox.SelectedIndexChanged += new System.EventHandler(this.graphComboBox_SelectedIndexChanged);
            // 
            // graphLabel
            // 
            this.graphLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.graphLabel.AutoSize = true;
            this.graphLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.graphLabel.Location = new System.Drawing.Point(586, 37);
            this.graphLabel.Name = "graphLabel";
            this.graphLabel.Size = new System.Drawing.Size(146, 25);
            this.graphLabel.TabIndex = 2;
            this.graphLabel.Text = "Choose Graph:";
            // 
            // firstColumnComboBox
            // 
            this.firstColumnComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.firstColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.firstColumnComboBox.Enabled = false;
            this.firstColumnComboBox.FormattingEnabled = true;
            this.firstColumnComboBox.Location = new System.Drawing.Point(188, 66);
            this.firstColumnComboBox.Name = "firstColumnComboBox";
            this.firstColumnComboBox.Size = new System.Drawing.Size(121, 21);
            this.firstColumnComboBox.TabIndex = 1;
            this.firstColumnComboBox.SelectedIndexChanged += new System.EventHandler(this.columnChooseComboBox_SelectedIndexChanged);
            // 
            // columnChooserLabel
            // 
            this.columnChooserLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.columnChooserLabel.AutoSize = true;
            this.columnChooserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.columnChooserLabel.Location = new System.Drawing.Point(181, 37);
            this.columnChooserLabel.Name = "columnChooserLabel";
            this.columnChooserLabel.Size = new System.Drawing.Size(128, 50);
            this.columnChooserLabel.TabIndex = 0;
            this.columnChooserLabel.Text = "First Column:\r\n\r\n";
            // 
            // StudentsData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 600);
            this.Controls.Add(this.chooseColumnPanel);
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.panel1);
            this.Name = "StudentsData";
            this.Text = "StudentsData";
            this.Load += new System.EventHandler(this.StudentsData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.courseDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tablePanel.ResumeLayout(false);
            this.chooseColumnPanel.ResumeLayout(false);
            this.chooseColumnPanel.PerformLayout();
            this.graphChoosePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView courseDataGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Panel tablePanel;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Panel chooseColumnPanel;
        private System.Windows.Forms.ComboBox graphComboBox;
        private System.Windows.Forms.Label graphLabel;
        private System.Windows.Forms.ComboBox firstColumnComboBox;
        private System.Windows.Forms.Label columnChooserLabel;
        private System.Windows.Forms.ComboBox secondComboBox;
        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.Panel graphChoosePanel;
        private System.Windows.Forms.Button addGraphButton;
        private System.Windows.Forms.Button clearGraphFile;
        private System.Windows.Forms.ComboBox countComboBox;
        private System.Windows.Forms.Label label1;
        private string filePathLabel;
        private System.Windows.Forms.Label fileNameLabel;
    }
}