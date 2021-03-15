
namespace DashboardTables
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.exitButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dashboardButton = new System.Windows.Forms.Button();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.logoButton = new System.Windows.Forms.Button();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.activityPanel = new System.Windows.Forms.Panel();
            this.exitBarButton = new System.Windows.Forms.Button();
            this.maximizeBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.dashboardManager = new System.Windows.Forms.Label();
            this.closeChildForm = new System.Windows.Forms.Button();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.logoImage = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.sidebarPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.activityPanel.SuspendLayout();
            this.panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoImage)).BeginInit();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(139)))), ((int)(((byte)(235)))));
            this.sidebarPanel.Controls.Add(this.button1);
            this.sidebarPanel.Controls.Add(this.exitButton);
            this.sidebarPanel.Controls.Add(this.button4);
            this.sidebarPanel.Controls.Add(this.button3);
            this.sidebarPanel.Controls.Add(this.dashboardButton);
            this.sidebarPanel.Controls.Add(this.logoPanel);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(151, 660);
            this.sidebarPanel.TabIndex = 1;
            // 
            // exitButton
            // 
            this.exitButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(111)))), ((int)(((byte)(166)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.ForeColor = System.Drawing.Color.Black;
            this.exitButton.Image = global::DashboardTables.Properties.Resources.change_power_options;
            this.exitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exitButton.Location = new System.Drawing.Point(0, 612);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(151, 48);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Image = global::DashboardTables.Properties.Resources.addressbookadd;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(0, 155);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(151, 49);
            this.button4.TabIndex = 3;
            this.button4.Text = "Tables";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.tablesButton_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Image = global::DashboardTables.Properties.Resources.datasearch;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(0, 103);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(151, 52);
            this.button3.TabIndex = 2;
            this.button3.Text = "Graphs";
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.graphButton_Click);
            // 
            // dashboardButton
            // 
            this.dashboardButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboardButton.FlatAppearance.BorderSize = 0;
            this.dashboardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dashboardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dashboardButton.ForeColor = System.Drawing.Color.Black;
            this.dashboardButton.Image = ((System.Drawing.Image)(resources.GetObject("dashboardButton.Image")));
            this.dashboardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.dashboardButton.Location = new System.Drawing.Point(0, 51);
            this.dashboardButton.Name = "dashboardButton";
            this.dashboardButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dashboardButton.Size = new System.Drawing.Size(151, 52);
            this.dashboardButton.TabIndex = 1;
            this.dashboardButton.Text = "Home";
            this.dashboardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.dashboardButton.UseVisualStyleBackColor = true;
            this.dashboardButton.Click += new System.EventHandler(this.dashboardButton_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.BackColor = System.Drawing.Color.White;
            this.logoPanel.Controls.Add(this.logoButton);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(151, 51);
            this.logoPanel.TabIndex = 0;
            // 
            // logoButton
            // 
            this.logoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(109)))), ((int)(((byte)(229)))));
            this.logoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(111)))), ((int)(((byte)(166)))));
            this.logoButton.FlatAppearance.BorderSize = 0;
            this.logoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoButton.ForeColor = System.Drawing.Color.White;
            this.logoButton.Location = new System.Drawing.Point(0, 0);
            this.logoButton.Name = "logoButton";
            this.logoButton.Size = new System.Drawing.Size(151, 51);
            this.logoButton.TabIndex = 3;
            this.logoButton.Text = "Dashboard Manager";
            this.logoButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.logoButton.UseVisualStyleBackColor = false;
            this.logoButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.logoButton_MouseDown);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(139)))), ((int)(((byte)(235)))));
            this.headerPanel.Controls.Add(this.activityPanel);
            this.headerPanel.Controls.Add(this.dashboardManager);
            this.headerPanel.Controls.Add(this.closeChildForm);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(151, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1089, 51);
            this.headerPanel.TabIndex = 2;
            this.headerPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headerPanel_MouseDown);
            // 
            // activityPanel
            // 
            this.activityPanel.Controls.Add(this.exitBarButton);
            this.activityPanel.Controls.Add(this.maximizeBtn);
            this.activityPanel.Controls.Add(this.minimizeBtn);
            this.activityPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.activityPanel.Location = new System.Drawing.Point(997, 0);
            this.activityPanel.Name = "activityPanel";
            this.activityPanel.Size = new System.Drawing.Size(92, 51);
            this.activityPanel.TabIndex = 5;
            // 
            // exitBarButton
            // 
            this.exitBarButton.FlatAppearance.BorderSize = 0;
            this.exitBarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBarButton.Image = global::DashboardTables.Properties.Resources.exit_circle2;
            this.exitBarButton.Location = new System.Drawing.Point(66, 4);
            this.exitBarButton.Name = "exitBarButton";
            this.exitBarButton.Size = new System.Drawing.Size(19, 23);
            this.exitBarButton.TabIndex = 2;
            this.exitBarButton.UseVisualStyleBackColor = true;
            this.exitBarButton.Click += new System.EventHandler(this.exitBarButton_Click);
            // 
            // maximizeBtn
            // 
            this.maximizeBtn.FlatAppearance.BorderSize = 0;
            this.maximizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeBtn.Image = global::DashboardTables.Properties.Resources.roll_circle;
            this.maximizeBtn.Location = new System.Drawing.Point(41, 4);
            this.maximizeBtn.Name = "maximizeBtn";
            this.maximizeBtn.Size = new System.Drawing.Size(19, 23);
            this.maximizeBtn.TabIndex = 1;
            this.maximizeBtn.UseVisualStyleBackColor = true;
            this.maximizeBtn.Click += new System.EventHandler(this.maximizeWindowBtn_Click);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.Image = global::DashboardTables.Properties.Resources.hide_circle;
            this.minimizeBtn.Location = new System.Drawing.Point(16, 4);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(19, 23);
            this.minimizeBtn.TabIndex = 0;
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // dashboardManager
            // 
            this.dashboardManager.AutoSize = true;
            this.dashboardManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dashboardManager.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dashboardManager.Location = new System.Drawing.Point(52, 15);
            this.dashboardManager.Name = "dashboardManager";
            this.dashboardManager.Size = new System.Drawing.Size(0, 20);
            this.dashboardManager.TabIndex = 4;
            // 
            // closeChildForm
            // 
            this.closeChildForm.FlatAppearance.BorderSize = 0;
            this.closeChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeChildForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeChildForm.ForeColor = System.Drawing.Color.White;
            this.closeChildForm.Image = global::DashboardTables.Properties.Resources.left_arrow_key;
            this.closeChildForm.Location = new System.Drawing.Point(0, 7);
            this.closeChildForm.Name = "closeChildForm";
            this.closeChildForm.Size = new System.Drawing.Size(36, 38);
            this.closeChildForm.TabIndex = 3;
            this.closeChildForm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.closeChildForm.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.closeChildForm.UseVisualStyleBackColor = true;
            this.closeChildForm.Click += new System.EventHandler(this.closeChildForm_Click);
            // 
            // panelDesktop
            // 
            this.panelDesktop.Controls.Add(this.logoImage);
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(151, 51);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1089, 609);
            this.panelDesktop.TabIndex = 3;
            // 
            // logoImage
            // 
            this.logoImage.BackColor = System.Drawing.SystemColors.Control;
            this.logoImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoImage.Image = global::DashboardTables.Properties.Resources._2017_04_25_ENG;
            this.logoImage.Location = new System.Drawing.Point(0, 0);
            this.logoImage.Name = "logoImage";
            this.logoImage.Size = new System.Drawing.Size(1089, 609);
            this.logoImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoImage.TabIndex = 0;
            this.logoImage.TabStop = false;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::DashboardTables.Properties.Resources.documentedit;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 52);
            this.button1.TabIndex = 6;
            this.button1.Text = "Open in Window Graph";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 660);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.sidebarPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.sidebarPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.activityPanel.ResumeLayout(false);
            this.panelDesktop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel sidebarPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.Button dashboardButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button closeChildForm;
        private System.Windows.Forms.Label dashboardManager;
        private System.Windows.Forms.Panel activityPanel;
        private System.Windows.Forms.Button exitBarButton;
        private System.Windows.Forms.Button maximizeBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Button logoButton;
        private System.Windows.Forms.PictureBox logoImage;
        private System.Windows.Forms.Button button1;
    }
}

