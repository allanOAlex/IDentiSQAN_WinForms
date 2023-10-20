namespace zk4500.Helpers.DialogHelpers
{
    partial class CustomDialog
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
            this.labelDialogueMessage = new System.Windows.Forms.Label();
            this.labelDialogueCaption = new System.Windows.Forms.Label();
            this.btnDismissDialog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDialogueMessage
            // 
            this.labelDialogueMessage.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDialogueMessage.Location = new System.Drawing.Point(12, 26);
            this.labelDialogueMessage.Name = "labelDialogueMessage";
            this.labelDialogueMessage.Size = new System.Drawing.Size(370, 23);
            this.labelDialogueMessage.TabIndex = 0;
            this.labelDialogueMessage.Text = "DialogueMessage";
            this.labelDialogueMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDialogueCaption
            // 
            this.labelDialogueCaption.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDialogueCaption.Location = new System.Drawing.Point(12, 58);
            this.labelDialogueCaption.Name = "labelDialogueCaption";
            this.labelDialogueCaption.Size = new System.Drawing.Size(400, 23);
            this.labelDialogueCaption.TabIndex = 1;
            this.labelDialogueCaption.Text = "DialogueCaption";
            this.labelDialogueCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDismissDialog
            // 
            this.btnDismissDialog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.btnDismissDialog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDismissDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDismissDialog.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDismissDialog.Location = new System.Drawing.Point(336, 107);
            this.btnDismissDialog.Name = "btnDismissDialog";
            this.btnDismissDialog.Size = new System.Drawing.Size(76, 33);
            this.btnDismissDialog.TabIndex = 29;
            this.btnDismissDialog.Text = "Ok";
            this.btnDismissDialog.UseVisualStyleBackColor = false;
            this.btnDismissDialog.Click += new System.EventHandler(this.btnDismissDialog_Click);
            // 
            // CustomDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 163);
            this.Controls.Add(this.btnDismissDialog);
            this.Controls.Add(this.labelDialogueCaption);
            this.Controls.Add(this.labelDialogueMessage);
            this.Name = "CustomDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CustomDialog";
            this.Load += new System.EventHandler(this.CustomDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelDialogueMessage;
        private System.Windows.Forms.Label labelDialogueCaption;
        private System.Windows.Forms.Button btnDismissDialog;
    }
}