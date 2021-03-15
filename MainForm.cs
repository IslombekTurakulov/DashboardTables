using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace DashboardTables
{
    public partial class MainForm : Form
    {
        //Fields
        private Form _activeForm;

        public MainForm()
        {
            InitializeComponent();
            closeChildForm.Visible = false;
            Text = string.Empty;
            ControlBox = false;
            MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
        }

        List<Courses> _listOfCourses = new List<Courses>();
        /// <summary>
        /// Connecting lib <see href="https://rjcodeadvance.com/iu-moderno-temas-multicolor-aleatorio-resaltar-boton-form-activo-winform-c/">Copy from</see>.
        /// </summary>
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private static extern void ReleaseCapture();

        /// <summary>
        /// Connecting lib <see href="https://rjcodeadvance.com/iu-moderno-temas-multicolor-aleatorio-resaltar-boton-form-activo-winform-c/">Copy from</see>.
        /// </summary>
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private static extern void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);


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
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            closeChildForm.Visible = true;
            // Setting up child form.
            childForm.BringToFront();
            childForm.Show();
        }

        public static bool ContainsAnyCaseInvariant(string haystack, string needle) => haystack.IndexOf(needle, StringComparison.InvariantCultureIgnoreCase) != -1;

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void logoButton_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void exitButton_Click(object sender, EventArgs e)=> Application.Exit();

        /// <summary>
        /// Window state changer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimizeButton_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        /// <summary>
        /// Window state changer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maximizeWindowBtn_Click(object sender, EventArgs e) => WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;

        /// <summary>
        /// Exit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitBarButton_Click(object sender, EventArgs e) => Application.Exit();

        private void graphButton_Click(object sender, EventArgs e) => OpenChildForm(new Information(), sender);

        private void closeChildForm_Click(object sender, EventArgs e)
        {
            _activeForm?.Close();
        }

        private void tablesButton_Click(object sender, EventArgs e) => OpenChildForm(new FileIndexForm(), sender);

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            if (_activeForm != null)
                _activeForm?.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Information inf = new Information();
            inf.Show();
        }
    }
}

