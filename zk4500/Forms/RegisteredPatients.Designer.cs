
namespace zk4500.Forms
{
    partial class RegisteredPatients
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.registeredPatientsGridView = new System.Windows.Forms.DataGridView();
            this.searchRichTextBox = new System.Windows.Forms.TextBox();
            this.lbl_PatientFilter = new System.Windows.Forms.Label();
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.btn_CaptureFingerprint = new System.Windows.Forms.Button();
            this.btn_FilterRegisteredPatients = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.registeredPatientsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // registeredPatientsGridView
            // 
            this.registeredPatientsGridView.AllowUserToOrderColumns = true;
            this.registeredPatientsGridView.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.registeredPatientsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.registeredPatientsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.registeredPatientsGridView.DefaultCellStyle = dataGridViewCellStyle10;
            this.registeredPatientsGridView.GridColor = System.Drawing.SystemColors.Control;
            this.registeredPatientsGridView.Location = new System.Drawing.Point(52, 116);
            this.registeredPatientsGridView.Name = "registeredPatientsGridView";
            this.registeredPatientsGridView.RowHeadersWidth = 51;
            this.registeredPatientsGridView.RowTemplate.Height = 24;
            this.registeredPatientsGridView.Size = new System.Drawing.Size(1040, 447);
            this.registeredPatientsGridView.TabIndex = 0;
            // 
            // searchRichTextBox
            // 
            this.searchRichTextBox.Font = new System.Drawing.Font("Ebrima", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchRichTextBox.Location = new System.Drawing.Point(551, 74);
            this.searchRichTextBox.Name = "searchRichTextBox";
            this.searchRichTextBox.Size = new System.Drawing.Size(403, 25);
            this.searchRichTextBox.TabIndex = 1;
            // 
            // lbl_PatientFilter
            // 
            this.lbl_PatientFilter.Font = new System.Drawing.Font("Ebrima", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PatientFilter.Location = new System.Drawing.Point(48, 65);
            this.lbl_PatientFilter.Name = "lbl_PatientFilter";
            this.lbl_PatientFilter.Size = new System.Drawing.Size(82, 38);
            this.lbl_PatientFilter.TabIndex = 2;
            this.lbl_PatientFilter.Text = "Filter By";
            this.lbl_PatientFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_PatientFilter.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxFilter.Font = new System.Drawing.Font("Ebrima", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFilter.FormattingEnabled = true;
            this.comboBoxFilter.ItemHeight = 17;
            this.comboBoxFilter.Location = new System.Drawing.Point(148, 74);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(370, 25);
            this.comboBoxFilter.TabIndex = 3;
            // 
            // btn_CaptureFingerprint
            // 
            this.btn_CaptureFingerprint.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_CaptureFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_CaptureFingerprint.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CaptureFingerprint.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_CaptureFingerprint.Location = new System.Drawing.Point(52, 581);
            this.btn_CaptureFingerprint.Name = "btn_CaptureFingerprint";
            this.btn_CaptureFingerprint.Size = new System.Drawing.Size(160, 36);
            this.btn_CaptureFingerprint.TabIndex = 4;
            this.btn_CaptureFingerprint.Text = "Capture Fingerprint";
            this.btn_CaptureFingerprint.UseVisualStyleBackColor = false;
            this.btn_CaptureFingerprint.Click += new System.EventHandler(this.btn_CaptureFingerprint_Click);
            // 
            // btn_FilterRegisteredPatients
            // 
            this.btn_FilterRegisteredPatients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_FilterRegisteredPatients.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_FilterRegisteredPatients.FlatAppearance.BorderSize = 0;
            this.btn_FilterRegisteredPatients.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_FilterRegisteredPatients.Font = new System.Drawing.Font("Ebrima", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FilterRegisteredPatients.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_FilterRegisteredPatients.Location = new System.Drawing.Point(970, 64);
            this.btn_FilterRegisteredPatients.Name = "btn_FilterRegisteredPatients";
            this.btn_FilterRegisteredPatients.Size = new System.Drawing.Size(122, 35);
            this.btn_FilterRegisteredPatients.TabIndex = 5;
            this.btn_FilterRegisteredPatients.Text = "Search";
            this.btn_FilterRegisteredPatients.UseVisualStyleBackColor = false;
            this.btn_FilterRegisteredPatients.Click += new System.EventHandler(this.btn_FilterRegisteredPatients_Click);
            // 
            // RegisteredPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1145, 641);
            this.Controls.Add(this.btn_FilterRegisteredPatients);
            this.Controls.Add(this.btn_CaptureFingerprint);
            this.Controls.Add(this.comboBoxFilter);
            this.Controls.Add(this.lbl_PatientFilter);
            this.Controls.Add(this.searchRichTextBox);
            this.Controls.Add(this.registeredPatientsGridView);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RegisteredPatients";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registered Patients";
            this.Load += new System.EventHandler(this.RegisteredPatients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.registeredPatientsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView registeredPatientsGridView;
        private System.Windows.Forms.TextBox searchRichTextBox;
        private System.Windows.Forms.Label lbl_PatientFilter;
        private System.Windows.Forms.ComboBox comboBoxFilter;
        private System.Windows.Forms.Button btn_CaptureFingerprint;
        private System.Windows.Forms.Button btn_FilterRegisteredPatients;
    }
}