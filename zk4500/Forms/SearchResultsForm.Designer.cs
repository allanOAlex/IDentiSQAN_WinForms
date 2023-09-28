
namespace zk4500.Forms
{
    partial class SearchResultsForm
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
            this.searchResults_flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Capture = new System.Windows.Forms.Button();
            this.btn_SaveFingerPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchResults_flowLayoutPanel1
            // 
            this.searchResults_flowLayoutPanel1.AutoScroll = true;
            this.searchResults_flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.searchResults_flowLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.searchResults_flowLayoutPanel1.Name = "searchResults_flowLayoutPanel1";
            this.searchResults_flowLayoutPanel1.Size = new System.Drawing.Size(914, 604);
            this.searchResults_flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_SaveFingerPrint);
            this.panel1.Controls.Add(this.btn_Capture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(923, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 604);
            this.panel1.TabIndex = 0;
            // 
            // btn_Capture
            // 
            this.btn_Capture.Location = new System.Drawing.Point(15, 12);
            this.btn_Capture.Name = "btn_Capture";
            this.btn_Capture.Size = new System.Drawing.Size(173, 53);
            this.btn_Capture.TabIndex = 0;
            this.btn_Capture.Text = "Capture Fingerprint";
            this.btn_Capture.UseVisualStyleBackColor = true;
            // 
            // btn_SaveFingerPrint
            // 
            this.btn_SaveFingerPrint.Location = new System.Drawing.Point(15, 99);
            this.btn_SaveFingerPrint.Name = "btn_SaveFingerPrint";
            this.btn_SaveFingerPrint.Size = new System.Drawing.Size(173, 53);
            this.btn_SaveFingerPrint.TabIndex = 1;
            this.btn_SaveFingerPrint.Text = "Save Fingerprint";
            this.btn_SaveFingerPrint.UseVisualStyleBackColor = true;
            // 
            // SearchResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 604);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchResults_flowLayoutPanel1);
            this.Name = "SearchResultsForm";
            this.Text = "SearchResultsForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel searchResults_flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_SaveFingerPrint;
        private System.Windows.Forms.Button btn_Capture;
    }
}