using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DashboardTables
{
    public partial class FileIndexForm : Form
    {
        // Создаём список с информацией путей.
        private readonly List<string> _openedFilesList = new List<string>();
        private Form _activeForm;

        public FileIndexForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Open child form in panel <see href="https://rjcodeadvance.com/iu-moderno-temas-multicolor-aleatorio-resaltar-boton-form-activo-winform-c/">Copy from</see>.
        /// </summary>
        /// <param name="childForm"></param>
        /// <param name="btnSender"></param>
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (_activeForm != null)
                _activeForm.Close();
            // Initializing buttons.
            _activeForm = childForm;
            // Setting up child form.
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            // panelDesktop settings.
            tabsPanel.Controls.Add(childForm);
            tabsPanel.Tag = childForm;
            // Setting up child form.
            childForm.BringToFront();
            childForm.Show();
        }


        private void dashboardButton_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableData(), sender);
        }
    }
}
