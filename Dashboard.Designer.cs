namespace LoginSignup
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            this.Panel = new Siticone.UI.WinForms.SiticonePanel();
            this.siticoneLabel1 = new Siticone.UI.WinForms.SiticoneLabel();
            this.ToggleSwitch1 = new Siticone.UI.WinForms.SiticoneToggleSwitch();
            this.Theme = new Siticone.UI.WinForms.SiticoneLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.siticoneButton1 = new Siticone.UI.WinForms.SiticoneButton();
            this.Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.siticoneLabel1);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel.Location = new System.Drawing.Point(0, 0);
            this.Panel.Name = "Panel";
            this.Panel.ShadowDecoration.Parent = this.Panel;
            this.Panel.Size = new System.Drawing.Size(1408, 28);
            this.Panel.TabIndex = 4;
            this.Panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // siticoneLabel1
            // 
            this.siticoneLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.siticoneLabel1.BackColor = System.Drawing.Color.Transparent;
            this.siticoneLabel1.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.siticoneLabel1.Location = new System.Drawing.Point(31, 4);
            this.siticoneLabel1.Name = "siticoneLabel1";
            this.siticoneLabel1.Size = new System.Drawing.Size(109, 21);
            this.siticoneLabel1.TabIndex = 7;
            this.siticoneLabel1.Text = "Inventory System";
            // 
            // ToggleSwitch1
            // 
            this.ToggleSwitch1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ToggleSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.ToggleSwitch1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ToggleSwitch1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(55)))), ((int)(((byte)(56)))));
            this.ToggleSwitch1.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.ToggleSwitch1.CheckedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ToggleSwitch1.CheckedState.Parent = this.ToggleSwitch1;
            this.ToggleSwitch1.Location = new System.Drawing.Point(12, 698);
            this.ToggleSwitch1.Name = "ToggleSwitch1";
            this.ToggleSwitch1.ShadowDecoration.Parent = this.ToggleSwitch1;
            this.ToggleSwitch1.Size = new System.Drawing.Size(43, 23);
            this.ToggleSwitch1.TabIndex = 6;
            this.ToggleSwitch1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ToggleSwitch1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.ToggleSwitch1.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.ToggleSwitch1.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.ToggleSwitch1.UncheckedState.Parent = this.ToggleSwitch1;
            this.ToggleSwitch1.CheckedChanged += new System.EventHandler(this.ToggleSwitch1_CheckedChanged);
            // 
            // Theme
            // 
            this.Theme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Theme.BackColor = System.Drawing.Color.Transparent;
            this.Theme.Font = new System.Drawing.Font("Comfortaa", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Theme.Location = new System.Drawing.Point(16, 720);
            this.Theme.Name = "Theme";
            this.Theme.Size = new System.Drawing.Size(35, 21);
            this.Theme.TabIndex = 5;
            this.Theme.Text = "Light ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(39)))), ((int)(((byte)(53)))));
            this.panel1.Controls.Add(this.siticoneButton1);
            this.panel1.Controls.Add(this.ToggleSwitch1);
            this.panel1.Controls.Add(this.Theme);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 749);
            this.panel1.TabIndex = 7;
            // 
            // siticoneButton1
            // 
            this.siticoneButton1.CheckedState.Parent = this.siticoneButton1;
            this.siticoneButton1.CustomImages.Parent = this.siticoneButton1;
            this.siticoneButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.siticoneButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.siticoneButton1.ForeColor = System.Drawing.Color.White;
            this.siticoneButton1.HoveredState.Parent = this.siticoneButton1;
            this.siticoneButton1.Location = new System.Drawing.Point(0, 544);
            this.siticoneButton1.Name = "siticoneButton1";
            this.siticoneButton1.ShadowDecoration.Parent = this.siticoneButton1;
            this.siticoneButton1.Size = new System.Drawing.Size(266, 45);
            this.siticoneButton1.TabIndex = 7;
            this.siticoneButton1.Text = "Settings";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1408, 777);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResizeBegin += new System.EventHandler(this.Dashboard_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Dashboard_ResizeEnd);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Dashboard_DragEnter);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Siticone.UI.WinForms.SiticonePanel Panel;
        private Siticone.UI.WinForms.SiticoneToggleSwitch ToggleSwitch1;
        private Siticone.UI.WinForms.SiticoneLabel Theme;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private Siticone.UI.WinForms.SiticoneLabel siticoneLabel1;
        private Siticone.UI.WinForms.SiticoneButton siticoneButton1;
    }
}