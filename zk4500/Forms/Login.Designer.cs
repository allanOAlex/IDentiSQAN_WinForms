namespace zk4500.Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.fingerBox = new System.Windows.Forms.PictureBox();
            this.labelPromt = new System.Windows.Forms.Label();
            this.labelLoginCaption = new System.Windows.Forms.Label();
            this.labelPoweredBy = new System.Windows.Forms.Label();
            this.menuStripLogin = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goBackToolStripMenuItemLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.maskedTextBoxPassword = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.fingerBox)).BeginInit();
            this.menuStripLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(169, 179);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(221, 28);
            this.textBoxUsername.TabIndex = 1;
            // 
            // labelUsername
            // 
            this.labelUsername.BackColor = System.Drawing.Color.Transparent;
            this.labelUsername.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelUsername.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(44)))), ((int)(((byte)(57)))));
            this.labelUsername.Location = new System.Drawing.Point(166, 144);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(113, 31);
            this.labelUsername.TabIndex = 3;
            this.labelUsername.Text = "Username";
            this.labelUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPassword
            // 
            this.labelPassword.BackColor = System.Drawing.Color.Transparent;
            this.labelPassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelPassword.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(44)))), ((int)(((byte)(57)))));
            this.labelPassword.Location = new System.Drawing.Point(166, 219);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(113, 33);
            this.labelPassword.TabIndex = 5;
            this.labelPassword.Text = "Password";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelPassword.Click += new System.EventHandler(this.labelPassword_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(44)))), ((int)(((byte)(109)))));
            this.buttonLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(44)))), ((int)(((byte)(109)))));
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLogin.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonLogin.Location = new System.Drawing.Point(168, 388);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(220, 47);
            this.buttonLogin.TabIndex = 6;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // fingerBox
            // 
            this.fingerBox.BackColor = System.Drawing.SystemColors.Window;
            this.fingerBox.Location = new System.Drawing.Point(532, 144);
            this.fingerBox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.fingerBox.Name = "fingerBox";
            this.fingerBox.Size = new System.Drawing.Size(307, 291);
            this.fingerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.fingerBox.TabIndex = 8;
            this.fingerBox.TabStop = false;
            // 
            // labelPromt
            // 
            this.labelPromt.BackColor = System.Drawing.Color.Transparent;
            this.labelPromt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelPromt.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPromt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(44)))), ((int)(((byte)(57)))));
            this.labelPromt.Location = new System.Drawing.Point(529, 466);
            this.labelPromt.Name = "labelPromt";
            this.labelPromt.Size = new System.Drawing.Size(475, 40);
            this.labelPromt.TabIndex = 9;
            this.labelPromt.Text = "Ready ...";
            this.labelPromt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLoginCaption
            // 
            this.labelLoginCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(158)))), ((int)(((byte)(162)))));
            this.labelLoginCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLoginCaption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelLoginCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(44)))), ((int)(((byte)(57)))));
            this.labelLoginCaption.Location = new System.Drawing.Point(0, 52);
            this.labelLoginCaption.Name = "labelLoginCaption";
            this.labelLoginCaption.Size = new System.Drawing.Size(1016, 57);
            this.labelLoginCaption.TabIndex = 8;
            this.labelLoginCaption.Text = "LoginCaption";
            this.labelLoginCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLoginCaption.Click += new System.EventHandler(this.labelLoginCaption_Click);
            // 
            // labelPoweredBy
            // 
            this.labelPoweredBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(44)))), ((int)(((byte)(57)))));
            this.labelPoweredBy.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelPoweredBy.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelPoweredBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoweredBy.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelPoweredBy.Location = new System.Drawing.Point(0, 554);
            this.labelPoweredBy.Name = "labelPoweredBy";
            this.labelPoweredBy.Size = new System.Drawing.Size(1016, 40);
            this.labelPoweredBy.TabIndex = 10;
            this.labelPoweredBy.Text = "PoweredBy IDentiSQAN";
            this.labelPoweredBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStripLogin
            // 
            this.menuStripLogin.AutoSize = false;
            this.menuStripLogin.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripLogin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.goBackToolStripMenuItemLogin});
            this.menuStripLogin.Location = new System.Drawing.Point(0, 0);
            this.menuStripLogin.Name = "menuStripLogin";
            this.menuStripLogin.Size = new System.Drawing.Size(1016, 52);
            this.menuStripLogin.TabIndex = 11;
            this.menuStripLogin.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(53, 48);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // goBackToolStripMenuItemLogin
            // 
            this.goBackToolStripMenuItemLogin.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackToolStripMenuItemLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.goBackToolStripMenuItemLogin.Name = "goBackToolStripMenuItemLogin";
            this.goBackToolStripMenuItemLogin.Size = new System.Drawing.Size(90, 48);
            this.goBackToolStripMenuItemLogin.Text = "Go Back";
            this.goBackToolStripMenuItemLogin.Click += new System.EventHandler(this.goBackToolStripMenuItemLogin_Click);
            // 
            // maskedTextBoxPassword
            // 
            this.maskedTextBoxPassword.Location = new System.Drawing.Point(169, 255);
            this.maskedTextBoxPassword.Name = "maskedTextBoxPassword";
            this.maskedTextBoxPassword.Size = new System.Drawing.Size(219, 28);
            this.maskedTextBoxPassword.TabIndex = 12;
            this.maskedTextBoxPassword.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(238)))), ((int)(((byte)(237)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1016, 594);
            this.Controls.Add(this.maskedTextBoxPassword);
            this.Controls.Add(this.labelPoweredBy);
            this.Controls.Add(this.labelLoginCaption);
            this.Controls.Add(this.labelPromt);
            this.Controls.Add(this.fingerBox);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.menuStripLogin);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripLogin;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pro-Med";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fingerBox)).EndInit();
            this.menuStripLogin.ResumeLayout(false);
            this.menuStripLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.PictureBox fingerBox;
        private System.Windows.Forms.Label labelPromt;
        private System.Windows.Forms.Label labelLoginCaption;
        private System.Windows.Forms.Label labelPoweredBy;
        private System.Windows.Forms.MenuStrip menuStripLogin;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPassword;
        private System.Windows.Forms.ToolStripMenuItem goBackToolStripMenuItemLogin;
    }
}