using Siticone.UI.WinForms.Suite;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace LoginSignup
{
    public partial class LoginAndSignup: Form
    {
        SqlCommand cmd;
        SqlConnection con;

        int pw;
        bool hided;

        public LoginAndSignup()
        {
            InitializeComponent();
            getIni();
            PlaceholderLoader();


            pw = Panel.Width;
            hided = false;
        }

        private void CreateAccountDatabase()
        {
            try
            {
                string connectionString = "Data Source=EMMAN\\SQLEXPRESS;Initial Catalog=DB_System;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM tb_user WHERE Email = @Email", con))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", NewEmailTextBox.Text);
                        con.Open();

                        int emailExists = (int)checkCmd.ExecuteScalar();
                        if (emailExists > 0)
                        {
                            MessageBox.Show("This email is already registered. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        con.Close();
                    }

                    string hashedPassword = HashPassword(NewPasswordTextBox.Text);
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO tb_user (Username, Email, Password) VALUES (@Username, @Email, @Password)", con))
                    {
                        cmd.Parameters.AddWithValue("@Username", NewUsernameTextBox.Text);
                        cmd.Parameters.AddWithValue("@Email", NewEmailTextBox.Text);
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearField();
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"An error occurred while accessing the database: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoginAccountDatabase()
        {
            string connectionString = "Data Source=EMMAN\\SQLEXPRESS;Initial Catalog=DB_System;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string hashedPassword = HashPassword(PasswordTextBox.Text);
                string query = "SELECT   COUNT(*) FROM tb_user WHERE Username=@Username AND Password=@Password";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", UsernameTextBox.Text);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    con.Open();
                    int userExists = (int)cmd.ExecuteScalar();

                    if (userExists > 0)
                    {
                        MessageBox.Show("Login successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearField();
            
                        this.Hide(); // Hide the login form
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show(); // Show the dashboard form    

                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void PlaceholderLoader()
        {
            UsernameTextBox.Text = "Username";
            UsernameTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            PasswordTextBox.Text = "Password";
            PasswordTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            NewUsernameTextBox.Text = "Username";
            NewUsernameTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            NewEmailTextBox.Text = "Email";
            NewEmailTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            NewPasswordTextBox.Text = "Password";
            NewPasswordTextBox.ForeColor = Color.FromArgb(125, 137, 149);
        }
        private void ClearField()
        {
            UsernameTextBox.Text = "Username";
            PasswordTextBox.Text = "Password";
            PasswordTextBox.UseSystemPasswordChar = false;
            ShowPassword.Checked = false;

            NewUsernameTextBox.Text = "Username";
            NewEmailTextBox.Text = "Email";
            NewPasswordTextBox.Text = "Password";
            NewPasswordTextBox.UseSystemPasswordChar = false;   
            ShowPassword2.Checked = false;
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

        private void Form1_Load(object sender, EventArgs e)
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
        private void getIni ()
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
                this.LoginLabel.ForeColor = Color.FromArgb(128, 128, 128);
                this.LoginButton.FillColor = Color.FromArgb(53, 55, 56);
                this.UsernameTextBox.FillColor = Color.FromArgb(53, 55, 56);
                this.PasswordTextBox.FillColor = Color.FromArgb(53, 55, 56);
                this.ExitButton.ForeColor = Color.FromArgb(128, 128, 128);
                this.label1.ForeColor = Color.FromArgb(128, 128, 128);
                this.label2.ForeColor = Color.FromArgb(128, 128, 128);

                //Sign Up
                this.SignUpLabel.ForeColor = Color.FromArgb(128, 128, 128);
                this.NewUsernameTextBox.FillColor = Color.FromArgb(53, 55, 56);
                this.NewEmailTextBox.FillColor = Color.FromArgb(53, 55, 56);
                this.NewPasswordTextBox.FillColor = Color.FromArgb(53, 55, 56);
                this.SignUpButton.FillColor = Color.FromArgb(53, 55, 56);
            }
            else
            {
                set.writeIni("SECTION", "key", "light");
                this.BackColor = Color.White;
                this.ForeColor = Color.FromArgb(32, 33, 36);
                Theme.Text = "Light";

                this.LoginButton.FillColor = Color.FromArgb(94, 148, 255);
                this.UsernameTextBox.FillColor = Color.White;
                this.PasswordTextBox.FillColor = Color.White;
                this.label1.ForeColor = Color.FromArgb(0, 0, 0);

                //Sign Up

                this.SignUpButton.FillColor = Color.FromArgb(94, 148, 255);
                this.NewUsernameTextBox.FillColor = Color.White;
                this.NewEmailTextBox.FillColor = Color.White;
                this.NewPasswordTextBox.FillColor = Color.White;
                this.label2.ForeColor = Color.FromArgb(0, 0, 0);
            }
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void linkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            FrameLabel.Text = "Create Account";
            panelSignUp.BringToFront();
            panelLogin.SendToBack();
            ClearField();
        }
        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrameLabel.Text = "Log in";
            panelLogin.BringToFront();
            panelSignUp.SendToBack();
            ClearField();
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
        private void LoginAndSignup_DragEnter(object sender, DragEventArgs e)
        {
            this.Opacity = 0.5;
        }
        private void LoginAndSignup_ResizeEnd(object sender, EventArgs e)
        {
            this.Opacity = 1;   
        }
        private void LoginAndSignup_ResizeBegin(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
        }
        private void SignUpButton_Click(object sender, EventArgs e)
        {
            if (NewUsernameTextBox.Text == "Username")
            {
                MessageBox.Show("Please enter your username");
                return;
            }
           
            if (NewEmailTextBox.Text == "Email")
            {
                MessageBox.Show("Please enter your email");
                return;
            }
            if (NewPasswordTextBox.Text == "Password")
            {
                MessageBox.Show("Please enter your password");
                return;
            }

            CreateAccountDatabase();

        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "Username")
            {
                MessageBox.Show("Please enter your username");
                return;
            }
            if (PasswordTextBox.Text == "Password")
            {
                MessageBox.Show("Please enter your password");
                return;
            }

            LoginAccountDatabase();
        }
        private void UsernameTextBox_Enter(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "Username")
            {
                UsernameTextBox.Text = "";
                UsernameTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
        private void UsernameTextBox_Leave(object sender, EventArgs e)
        {
            if (UsernameTextBox.Text == "")
            {
                UsernameTextBox.Text = "Username";
                UsernameTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
        private void PasswordTextBox_Enter(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "Password")
            {
                PasswordTextBox.Text = "";
                PasswordTextBox.UseSystemPasswordChar = true;
                PasswordTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
        private void PasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (PasswordTextBox.Text == "")
            {
                PasswordTextBox.Text = "Password";
                PasswordTextBox.UseSystemPasswordChar = false;
                PasswordTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
        private void NewUsernameTextBox_Enter(object sender, EventArgs e)
        {
            if (NewUsernameTextBox.Text == "Username")
            {
                NewUsernameTextBox.Text = "";
                NewUsernameTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
        private void NewUsernameTextBox_Leave(object sender, EventArgs e)
        {
            if (NewUsernameTextBox.Text == "")
            {
                NewUsernameTextBox.Text = "Username";
                NewUsernameTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
        private void NewEmailTextBox_Enter(object sender, EventArgs e)
        {
            if (NewEmailTextBox.Text == "Email")
            {
                NewEmailTextBox.Text = "";
                NewEmailTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
        private void NewEmailTextBox_Leave(object sender, EventArgs e)
        {
            if (NewEmailTextBox.Text == "")
            {
                NewEmailTextBox.Text = "Email";
                NewEmailTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
        private void NewPasswordTextBox_Enter(object sender, EventArgs e)
        {
            if (NewPasswordTextBox.Text == "Password")
            {
                NewPasswordTextBox.Text = "";
                NewPasswordTextBox.UseSystemPasswordChar = true;
                NewPasswordTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
        private void NewPasswordTextBox_Leave(object sender, EventArgs e)
        {
            if (NewPasswordTextBox.Text == "")
            {
                NewPasswordTextBox.Text = "Password";
                NewPasswordTextBox.UseSystemPasswordChar = false;
                NewPasswordTextBox.ForeColor = Color.FromArgb(125, 137, 149);
            }
        }
        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword.Checked == true)
            {
                PasswordTextBox.UseSystemPasswordChar = false;
            } else
            {
                PasswordTextBox.UseSystemPasswordChar = true;
            }
        }
        private void ShowPassword2_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword2.Checked)
            {
                NewPasswordTextBox.UseSystemPasswordChar = false;
            } else
            {
                NewPasswordTextBox.UseSystemPasswordChar = true;
            }
        }
    }
}