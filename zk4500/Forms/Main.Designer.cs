namespace zk4500.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItemMain = new System.Windows.Forms.ToolStripMenuItem();
            this.labelPoweredByMain = new System.Windows.Forms.Label();
            this.labeMainCaption = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(44)))), ((int)(((byte)(109)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Location = new System.Drawing.Point(482, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 50);
            this.button3.TabIndex = 2;
            this.button3.Text = "Enter";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(238)))), ((int)(((byte)(237)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItemMain});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1143, 63);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStripMain";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // exitToolStripMenuItemMain
            // 
            this.exitToolStripMenuItemMain.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItemMain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.exitToolStripMenuItemMain.Name = "exitToolStripMenuItemMain";
            this.exitToolStripMenuItemMain.Size = new System.Drawing.Size(50, 59);
            this.exitToolStripMenuItemMain.Text = "Exit";
            this.exitToolStripMenuItemMain.Click += new System.EventHandler(this.exitToolStripMenuItemMain_Click);
            // 
            // labelPoweredByMain
            // 
            this.labelPoweredByMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(44)))), ((int)(((byte)(57)))));
            this.labelPoweredByMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelPoweredByMain.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelPoweredByMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoweredByMain.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelPoweredByMain.Location = new System.Drawing.Point(0, 502);
            this.labelPoweredByMain.Name = "labelPoweredByMain";
            this.labelPoweredByMain.Size = new System.Drawing.Size(1143, 40);
            this.labelPoweredByMain.TabIndex = 13;
            this.labelPoweredByMain.Text = "PoweredBy IDentiSQAN";
            this.labelPoweredByMain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPoweredByMain.Click += new System.EventHandler(this.labelPoweredByMain_Click);
            // 
            // labeMainCaption
            // 
            this.labeMainCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(158)))), ((int)(((byte)(162)))));
            this.labeMainCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.labeMainCaption.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labeMainCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeMainCaption.ForeColor = System.Drawing.Color.Linen;
            this.labeMainCaption.Location = new System.Drawing.Point(0, 63);
            this.labeMainCaption.Name = "labeMainCaption";
            this.labeMainCaption.Size = new System.Drawing.Size(1143, 57);
            this.labeMainCaption.TabIndex = 14;
            this.labeMainCaption.Text = "Pro-Med Biometrics";
            this.labeMainCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(238)))), ((int)(((byte)(237)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1143, 542);
            this.Controls.Add(this.labeMainCaption);
            this.Controls.Add(this.labelPoweredByMain);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItemMain;
        private System.Windows.Forms.Label labelPoweredByMain;
        private System.Windows.Forms.Label labeMainCaption;
    }
}