namespace zk4500
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnVerify = new System.Windows.Forms.Button();
            this.prompt = new System.Windows.Forms.Label();
            this.fpicture = new System.Windows.Forms.PictureBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.registeredPatientsGridView = new System.Windows.Forms.DataGridView();
            this.labelFilterText = new System.Windows.Forms.Label();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.searchRichTextBox = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            this.menuStripForm1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItemForm1 = new System.Windows.Forms.ToolStripMenuItem();
            this.goBackToolStripMenuItemForm1 = new System.Windows.Forms.ToolStripMenuItem();
            this.captureFingerprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userFingerprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientFingerprintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labeMainCaption = new System.Windows.Forms.Label();
            this.labelPoweredByForm1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fpicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registeredPatientsGridView)).BeginInit();
            this.menuStripForm1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVerify
            // 
            this.btnVerify.BackColor = System.Drawing.Color.SteelBlue;
            this.btnVerify.Enabled = false;
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVerify.Location = new System.Drawing.Point(564, 593);
            this.btnVerify.Margin = new System.Windows.Forms.Padding(4);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(111, 45);
            this.btnVerify.TabIndex = 2;
            this.btnVerify.Text = "&Verify";
            this.btnVerify.UseVisualStyleBackColor = false;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // prompt
            // 
            this.prompt.AutoSize = true;
            this.prompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(70)))), ((int)(((byte)(97)))));
            this.prompt.Location = new System.Drawing.Point(416, 470);
            this.prompt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prompt.Name = "prompt";
            this.prompt.Size = new System.Drawing.Size(93, 24);
            this.prompt.TabIndex = 3;
            this.prompt.Text = "Ready ...";
            this.prompt.Click += new System.EventHandler(this.prompt_Click);
            // 
            // fpicture
            // 
            this.fpicture.BackColor = System.Drawing.SystemColors.Window;
            this.fpicture.Location = new System.Drawing.Point(39, 421);
            this.fpicture.Margin = new System.Windows.Forms.Padding(4);
            this.fpicture.Name = "fpicture";
            this.fpicture.Size = new System.Drawing.Size(268, 283);
            this.fpicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.fpicture.TabIndex = 21;
            this.fpicture.TabStop = false;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(91)))), ((int)(((byte)(97)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRegister.Location = new System.Drawing.Point(420, 593);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(111, 45);
            this.btnRegister.TabIndex = 22;
            this.btnRegister.Text = "&Capture";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClear.Location = new System.Drawing.Point(420, 659);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(255, 45);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // registeredPatientsGridView
            // 
            this.registeredPatientsGridView.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.registeredPatientsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registeredPatientsGridView.Location = new System.Drawing.Point(39, 216);
            this.registeredPatientsGridView.Name = "registeredPatientsGridView";
            this.registeredPatientsGridView.RowHeadersWidth = 51;
            this.registeredPatientsGridView.RowTemplate.Height = 24;
            this.registeredPatientsGridView.Size = new System.Drawing.Size(1144, 190);
            this.registeredPatientsGridView.TabIndex = 24;
            // 
            // labelFilterText
            // 
            this.labelFilterText.AutoSize = true;
            this.labelFilterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFilterText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(44)))), ((int)(((byte)(57)))));
            this.labelFilterText.Location = new System.Drawing.Point(45, 138);
            this.labelFilterText.Name = "labelFilterText";
            this.labelFilterText.Size = new System.Drawing.Size(101, 26);
            this.labelFilterText.TabIndex = 25;
            this.labelFilterText.Text = "Filter By";
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.Location = new System.Drawing.Point(162, 138);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(222, 23);
            this.comboBoxFilter.TabIndex = 26;
            // 
            // searchRichTextBox
            // 
            this.searchRichTextBox.Location = new System.Drawing.Point(402, 138);
            this.searchRichTextBox.Name = "searchRichTextBox";
            this.searchRichTextBox.Size = new System.Drawing.Size(274, 22);
            this.searchRichTextBox.TabIndex = 27;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSearch.Location = new System.Drawing.Point(776, 127);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 33);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(31)))), ((int)(((byte)(93)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExit.Location = new System.Drawing.Point(1093, 127);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 33);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "Refresh";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(44)))), ((int)(((byte)(57)))));
            this.label1.Location = new System.Drawing.Point(46, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Patients";
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMessage.ForeColor = System.Drawing.Color.Sienna;
            this.labelMessage.Location = new System.Drawing.Point(417, 421);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(102, 20);
            this.labelMessage.TabIndex = 31;
            this.labelMessage.Text = "pleaseWait";
            // 
            // menuStripForm1
            // 
            this.menuStripForm1.AutoSize = false;
            this.menuStripForm1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripForm1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItemForm1,
            this.goBackToolStripMenuItemForm1,
            this.captureFingerprintToolStripMenuItem,
            this.loginToolStripMenuItem});
            this.menuStripForm1.Location = new System.Drawing.Point(0, 0);
            this.menuStripForm1.Name = "menuStripForm1";
            this.menuStripForm1.Size = new System.Drawing.Size(1224, 52);
            this.menuStripForm1.TabIndex = 33;
            this.menuStripForm1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItemForm1
            // 
            this.exitToolStripMenuItemForm1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItemForm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.exitToolStripMenuItemForm1.Name = "exitToolStripMenuItemForm1";
            this.exitToolStripMenuItemForm1.Size = new System.Drawing.Size(53, 48);
            this.exitToolStripMenuItemForm1.Text = "Exit";
            this.exitToolStripMenuItemForm1.Click += new System.EventHandler(this.exitToolStripMenuItemForm1_Click);
            // 
            // goBackToolStripMenuItemForm1
            // 
            this.goBackToolStripMenuItemForm1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackToolStripMenuItemForm1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.goBackToolStripMenuItemForm1.Name = "goBackToolStripMenuItemForm1";
            this.goBackToolStripMenuItemForm1.Size = new System.Drawing.Size(90, 48);
            this.goBackToolStripMenuItemForm1.Text = "Minimize";
            this.goBackToolStripMenuItemForm1.Click += new System.EventHandler(this.goBackToolStripMenuItemForm1_Click);
            // 
            // captureFingerprintToolStripMenuItem
            // 
            this.captureFingerprintToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userFingerprintToolStripMenuItem,
            this.patientFingerprintToolStripMenuItem});
            this.captureFingerprintToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureFingerprintToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.captureFingerprintToolStripMenuItem.Name = "captureFingerprintToolStripMenuItem";
            this.captureFingerprintToolStripMenuItem.Size = new System.Drawing.Size(178, 48);
            this.captureFingerprintToolStripMenuItem.Text = "Capture Fingerprint";
            // 
            // userFingerprintToolStripMenuItem
            // 
            this.userFingerprintToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userFingerprintToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.userFingerprintToolStripMenuItem.Name = "userFingerprintToolStripMenuItem";
            this.userFingerprintToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.userFingerprintToolStripMenuItem.Text = "User Fingerprint";
            this.userFingerprintToolStripMenuItem.Click += new System.EventHandler(this.userFingerprintToolStripMenuItem_Click);
            // 
            // patientFingerprintToolStripMenuItem
            // 
            this.patientFingerprintToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientFingerprintToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.patientFingerprintToolStripMenuItem.Name = "patientFingerprintToolStripMenuItem";
            this.patientFingerprintToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.patientFingerprintToolStripMenuItem.Text = "Patient Fingerprint";
            this.patientFingerprintToolStripMenuItem.Click += new System.EventHandler(this.patientFingerprintToolStripMenuItem_Click);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginToolStripMenuItem.ForeColor = System.Drawing.Color.Sienna;
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(67, 48);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // labeMainCaption
            // 
            this.labeMainCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(158)))), ((int)(((byte)(162)))));
            this.labeMainCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.labeMainCaption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labeMainCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeMainCaption.ForeColor = System.Drawing.Color.Linen;
            this.labeMainCaption.Location = new System.Drawing.Point(0, 52);
            this.labeMainCaption.Name = "labeMainCaption";
            this.labeMainCaption.Size = new System.Drawing.Size(1224, 57);
            this.labeMainCaption.TabIndex = 34;
            this.labeMainCaption.Text = "Pro-Med Biometrics";
            this.labeMainCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPoweredByForm1
            // 
            this.labelPoweredByForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(44)))), ((int)(((byte)(57)))));
            this.labelPoweredByForm1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelPoweredByForm1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelPoweredByForm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoweredByForm1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelPoweredByForm1.Location = new System.Drawing.Point(0, 726);
            this.labelPoweredByForm1.Name = "labelPoweredByForm1";
            this.labelPoweredByForm1.Size = new System.Drawing.Size(1224, 40);
            this.labelPoweredByForm1.TabIndex = 35;
            this.labelPoweredByForm1.Text = "PoweredBy IDentiSQAN";
            this.labelPoweredByForm1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(238)))), ((int)(((byte)(237)))));
            this.ClientSize = new System.Drawing.Size(1224, 766);
            this.ControlBox = false;
            this.Controls.Add(this.labelPoweredByForm1);
            this.Controls.Add(this.labeMainCaption);
            this.Controls.Add(this.menuStripForm1);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.searchRichTextBox);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.labelFilterText);
            this.Controls.Add(this.registeredPatientsGridView);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.fpicture);
            this.Controls.Add(this.prompt);
            this.Controls.Add(this.btnVerify);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pro-Med Biometrics. Powered by IDentiSQAN";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fpicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registeredPatientsGridView)).EndInit();
            this.menuStripForm1.ResumeLayout(false);
            this.menuStripForm1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Label prompt;
        private System.Windows.Forms.PictureBox fpicture;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView registeredPatientsGridView;
        private System.Windows.Forms.Label labelFilterText;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.TextBox searchRichTextBox;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.MenuStrip menuStripForm1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItemForm1;
        private System.Windows.Forms.ToolStripMenuItem goBackToolStripMenuItemForm1;
        private System.Windows.Forms.Label labeMainCaption;
        private System.Windows.Forms.Label labelPoweredByForm1;
        private System.Windows.Forms.ToolStripMenuItem captureFingerprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userFingerprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientFingerprintToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
    }
}

