using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LoginSignup
{
    public partial class Dashboard : Form
    {
        int pw;
        bool hided;
        public Dashboard()
        {
            InitializeComponent();
            getIni();

            pw = Panel.Width;
            hided = false;
        }
        private void IncreaseOpacity(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.01;
            }
            if (this.Opacity == 1)
            {
                timer1.Stop();
            }
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 18;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 272, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);


            path.CloseFigure();

            Region = new Region(path);

            this.Opacity = 01;
            timer1.Interval = 10;
            timer1.Tick += (IncreaseOpacity);
            timer1.Start();
        }
        private void getIni()
        {
            Settings get = new Settings();
            get.readIni();
            if (get.theme == "dark")
            {
                ToggleSwitch1.Checked = true;
                Theme.Text = "Dark";
                this.Theme.ForeColor = Color.FromArgb(54, 66, 60);
                this.BackColor = Color.FromArgb(32, 33, 36);
                this.ForeColor = Color.White;
            }
            else
            {
                ToggleSwitch1.Checked = false;
                Theme.Text = "Light";
                this.BackColor = Color.White;
                this.ForeColor = Color.FromArgb(32, 33, 36);
            }
        }
        private void ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            Settings set = new Settings();
            if (ToggleSwitch1.Checked == true)
            {

                set.writeIni("SECTION", "key", "dark");
                this.BackColor = Color.FromArgb(32, 33, 36);
                this.ForeColor = Color.White;
                Theme.Text = "Dark";

            }
            else
            {
                set.writeIni("SECTION", "key", "light");
                this.BackColor = Color.White;
                this.ForeColor = Color.FromArgb(32, 33, 36);

                Theme.Text = "Light";
            }
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]

        private extern static int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void ExitButtonDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginAndSignup loginsignup = new LoginAndSignup();
            loginsignup.Close();
        }

        private void Dashboard_DragEnter(object sender, DragEventArgs e)
        {
            this.Opacity = 0.5;
        }

        private void Dashboard_ResizeBegin(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
        }

        private void Dashboard_ResizeEnd(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }


    }
}
