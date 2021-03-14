
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
            this.graphTabControl = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // barPanel
            // 
            this.barPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(215)))), ((int)(((byte)(148)))));
            this.barPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.barPanel.Location = new System.Drawing.Point(0, 0);
            this.barPanel.Name = "barPanel";
            this.barPanel.Size = new System.Drawing.Size(800, 42);
            this.barPanel.TabIndex = 0;
            // 
            // graphTabControl
            // 
            this.graphTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphTabControl.Location = new System.Drawing.Point(0, 42);
            this.graphTabControl.Name = "graphTabControl";
            this.graphTabControl.SelectedIndex = 0;
            this.graphTabControl.Size = new System.Drawing.Size(800, 408);
            this.graphTabControl.TabIndex = 1;
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.graphTabControl);
            this.Controls.Add(this.barPanel);
            this.Name = "Information";
            this.Text = "Information";
            this.Load += new System.EventHandler(this.Information_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel barPanel;
        private System.Windows.Forms.TabControl graphTabControl;
    }
}