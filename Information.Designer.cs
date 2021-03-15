
namespace DashboardTables
{
    partial class Information
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
            this.barPanel = new System.Windows.Forms.Panel();
            this.axisYGroup = new System.Windows.Forms.GroupBox();
            this.axisYSa = new System.Windows.Forms.Label();
            this.dispresionAxisYLabel = new System.Windows.Forms.Label();
            this.medianAxisYLabel = new System.Windows.Forms.Label();
            this.avgAxisYLabel = new System.Windows.Forms.Label();
            this.axisXGroup = new System.Windows.Forms.GroupBox();
            this.axisXSa = new System.Windows.Forms.Label();
            this.dispresionLabel = new System.Windows.Forms.Label();
            this.medianLabel = new System.Windows.Forms.Label();
            this.avgAxisXLabel = new System.Windows.Forms.Label();
            this.graphTabControl = new System.Windows.Forms.TabControl();
            this.topBarSave = new System.Windows.Forms.Panel();
            this.saveChartButton1 = new System.Windows.Forms.Button();
            this.barPanel.SuspendLayout();
            this.axisYGroup.SuspendLayout();
            this.axisXGroup.SuspendLayout();
            this.topBarSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // barPanel
            // 
            this.barPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(215)))), ((int)(((byte)(148)))));
            this.barPanel.Controls.Add(this.axisYGroup);
            this.barPanel.Controls.Add(this.axisXGroup);
            this.barPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barPanel.Location = new System.Drawing.Point(0, 398);
            this.barPanel.Name = "barPanel";
            this.barPanel.Size = new System.Drawing.Size(935, 94);
            this.barPanel.TabIndex = 0;
            // 
            // axisYGroup
            // 
            this.axisYGroup.Controls.Add(this.axisYSa);
            this.axisYGroup.Controls.Add(this.dispresionAxisYLabel);
            this.axisYGroup.Controls.Add(this.medianAxisYLabel);
            this.axisYGroup.Controls.Add(this.avgAxisYLabel);
            this.axisYGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisYGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.axisYGroup.Location = new System.Drawing.Point(467, 0);
            this.axisYGroup.Name = "axisYGroup";
            this.axisYGroup.Size = new System.Drawing.Size(468, 94);
            this.axisYGroup.TabIndex = 2;
            this.axisYGroup.TabStop = false;
            this.axisYGroup.Text = "AxisX";
            // 
            // axisYSa
            // 
            this.axisYSa.AutoSize = true;
            this.axisYSa.Location = new System.Drawing.Point(219, 57);
            this.axisYSa.Name = "axisYSa";
            this.axisYSa.Size = new System.Drawing.Size(30, 17);
            this.axisYSa.TabIndex = 6;
            this.axisYSa.Text = "SA:";
            // 
            // dispresionAxisYLabel
            // 
            this.dispresionAxisYLabel.AutoSize = true;
            this.dispresionAxisYLabel.Location = new System.Drawing.Point(200, 26);
            this.dispresionAxisYLabel.Name = "dispresionAxisYLabel";
            this.dispresionAxisYLabel.Size = new System.Drawing.Size(79, 17);
            this.dispresionAxisYLabel.TabIndex = 5;
            this.dispresionAxisYLabel.Text = "Dispresion:";
            // 
            // medianAxisYLabel
            // 
            this.medianAxisYLabel.AutoSize = true;
            this.medianAxisYLabel.Location = new System.Drawing.Point(27, 57);
            this.medianAxisYLabel.Name = "medianAxisYLabel";
            this.medianAxisYLabel.Size = new System.Drawing.Size(101, 17);
            this.medianAxisYLabel.TabIndex = 4;
            this.medianAxisYLabel.Text = "MedianAxisXY:";
            // 
            // avgAxisYLabel
            // 
            this.avgAxisYLabel.AutoSize = true;
            this.avgAxisYLabel.Location = new System.Drawing.Point(27, 26);
            this.avgAxisYLabel.Name = "avgAxisYLabel";
            this.avgAxisYLabel.Size = new System.Drawing.Size(65, 17);
            this.avgAxisYLabel.TabIndex = 3;
            this.avgAxisYLabel.Text = "Average:";
            // 
            // axisXGroup
            // 
            this.axisXGroup.Controls.Add(this.axisXSa);
            this.axisXGroup.Controls.Add(this.dispresionLabel);
            this.axisXGroup.Controls.Add(this.medianLabel);
            this.axisXGroup.Controls.Add(this.avgAxisXLabel);
            this.axisXGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.axisXGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.axisXGroup.Location = new System.Drawing.Point(0, 0);
            this.axisXGroup.Name = "axisXGroup";
            this.axisXGroup.Size = new System.Drawing.Size(467, 94);
            this.axisXGroup.TabIndex = 1;
            this.axisXGroup.TabStop = false;
            this.axisXGroup.Text = "AxisX";
            // 
            // axisXSa
            // 
            this.axisXSa.AutoSize = true;
            this.axisXSa.Location = new System.Drawing.Point(184, 57);
            this.axisXSa.Name = "axisXSa";
            this.axisXSa.Size = new System.Drawing.Size(30, 17);
            this.axisXSa.TabIndex = 3;
            this.axisXSa.Text = "SA:";
            // 
            // dispresionLabel
            // 
            this.dispresionLabel.AutoSize = true;
            this.dispresionLabel.Location = new System.Drawing.Point(184, 26);
            this.dispresionLabel.Name = "dispresionLabel";
            this.dispresionLabel.Size = new System.Drawing.Size(79, 17);
            this.dispresionLabel.TabIndex = 2;
            this.dispresionLabel.Text = "Dispresion:";
            // 
            // medianLabel
            // 
            this.medianLabel.AutoSize = true;
            this.medianLabel.Location = new System.Drawing.Point(13, 57);
            this.medianLabel.Name = "medianLabel";
            this.medianLabel.Size = new System.Drawing.Size(101, 17);
            this.medianLabel.TabIndex = 1;
            this.medianLabel.Text = "MedianAxisXY:";
            // 
            // avgAxisXLabel
            // 
            this.avgAxisXLabel.AutoSize = true;
            this.avgAxisXLabel.Location = new System.Drawing.Point(13, 26);
            this.avgAxisXLabel.Name = "avgAxisXLabel";
            this.avgAxisXLabel.Size = new System.Drawing.Size(65, 17);
            this.avgAxisXLabel.TabIndex = 0;
            this.avgAxisXLabel.Text = "Average:";
            // 
            // graphTabControl
            // 
            this.graphTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTabControl.Location = new System.Drawing.Point(0, 27);
            this.graphTabControl.Name = "graphTabControl";
            this.graphTabControl.SelectedIndex = 0;
            this.graphTabControl.Size = new System.Drawing.Size(935, 371);
            this.graphTabControl.TabIndex = 1;
            // 
            // topBarSave
            // 
            this.topBarSave.Controls.Add(this.saveChartButton1);
            this.topBarSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarSave.Location = new System.Drawing.Point(0, 0);
            this.topBarSave.Name = "topBarSave";
            this.topBarSave.Size = new System.Drawing.Size(935, 27);
            this.topBarSave.TabIndex = 2;
            // 
            // saveChartButton1
            // 
            this.saveChartButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(127)))), ((int)(((byte)(103)))));
            this.saveChartButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.saveChartButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveChartButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveChartButton1.Location = new System.Drawing.Point(821, 0);
            this.saveChartButton1.Name = "saveChartButton1";
            this.saveChartButton1.Size = new System.Drawing.Size(114, 27);
            this.saveChartButton1.TabIndex = 4;
            this.saveChartButton1.Text = "Save chart";
            this.saveChartButton1.UseVisualStyleBackColor = false;
            this.saveChartButton1.Click += new System.EventHandler(this.saveChartBtn_Click);
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 492);
            this.Controls.Add(this.graphTabControl);
            this.Controls.Add(this.topBarSave);
            this.Controls.Add(this.barPanel);
            this.Name = "Information";
            this.ShowIcon = false;
            this.Text = "Information";
            this.Load += new System.EventHandler(this.Information_Load);
            this.barPanel.ResumeLayout(false);
            this.axisYGroup.ResumeLayout(false);
            this.axisYGroup.PerformLayout();
            this.axisXGroup.ResumeLayout(false);
            this.axisXGroup.PerformLayout();
            this.topBarSave.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel barPanel;
        private System.Windows.Forms.TabControl graphTabControl;
        private System.Windows.Forms.GroupBox axisYGroup;
        private System.Windows.Forms.Label dispresionAxisYLabel;
        private System.Windows.Forms.Label medianAxisYLabel;
        private System.Windows.Forms.Label avgAxisYLabel;
        private System.Windows.Forms.GroupBox axisXGroup;
        private System.Windows.Forms.Label axisXSa;
        private System.Windows.Forms.Label dispresionLabel;
        private System.Windows.Forms.Label medianLabel;
        private System.Windows.Forms.Label avgAxisXLabel;
        private System.Windows.Forms.Label axisYSa;
        private System.Windows.Forms.Panel topBarSave;
        private System.Windows.Forms.Button saveChartButton1;
    }
}