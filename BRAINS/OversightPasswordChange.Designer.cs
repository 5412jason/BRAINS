namespace BRAINS
{
    partial class OversightPasswordChange
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OversightPasswordChangeCurrentTextBox = new System.Windows.Forms.TextBox();
            this.OversightPasswordChangeNewTextBox = new System.Windows.Forms.TextBox();
            this.oversightPasswordChangeDialogOK = new System.Windows.Forms.Button();
            this.oversightPasswordChangeDialogCancel = new System.Windows.Forms.Button();
            this.confirmPassword = new System.Windows.Forms.TextBox();
            this.confirmPass = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "New:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // OversightPasswordChangeCurrentTextBox
            // 
            this.OversightPasswordChangeCurrentTextBox.Location = new System.Drawing.Point(64, 20);
            this.OversightPasswordChangeCurrentTextBox.Name = "OversightPasswordChangeCurrentTextBox";
            this.OversightPasswordChangeCurrentTextBox.Size = new System.Drawing.Size(227, 20);
            this.OversightPasswordChangeCurrentTextBox.TabIndex = 2;
            this.OversightPasswordChangeCurrentTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // OversightPasswordChangeNewTextBox
            // 
            this.OversightPasswordChangeNewTextBox.Location = new System.Drawing.Point(64, 55);
            this.OversightPasswordChangeNewTextBox.Name = "OversightPasswordChangeNewTextBox";
            this.OversightPasswordChangeNewTextBox.Size = new System.Drawing.Size(227, 20);
            this.OversightPasswordChangeNewTextBox.TabIndex = 3;
            this.OversightPasswordChangeNewTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // oversightPasswordChangeDialogOK
            // 
            this.oversightPasswordChangeDialogOK.Location = new System.Drawing.Point(177, 155);
            this.oversightPasswordChangeDialogOK.Name = "oversightPasswordChangeDialogOK";
            this.oversightPasswordChangeDialogOK.Size = new System.Drawing.Size(75, 23);
            this.oversightPasswordChangeDialogOK.TabIndex = 4;
            this.oversightPasswordChangeDialogOK.Text = "OK";
            this.oversightPasswordChangeDialogOK.UseVisualStyleBackColor = true;
            this.oversightPasswordChangeDialogOK.Click += new System.EventHandler(this.oversightPasswordChangeDialogOK_Click);
            // 
            // oversightPasswordChangeDialogCancel
            // 
            this.oversightPasswordChangeDialogCancel.Location = new System.Drawing.Point(262, 155);
            this.oversightPasswordChangeDialogCancel.Name = "oversightPasswordChangeDialogCancel";
            this.oversightPasswordChangeDialogCancel.Size = new System.Drawing.Size(75, 23);
            this.oversightPasswordChangeDialogCancel.TabIndex = 5;
            this.oversightPasswordChangeDialogCancel.Text = "Cancel";
            this.oversightPasswordChangeDialogCancel.UseVisualStyleBackColor = true;
            this.oversightPasswordChangeDialogCancel.Click += new System.EventHandler(this.oversightPasswordChangeDialogCancel_Click);
            // 
            // confirmPassword
            // 
            this.confirmPassword.Location = new System.Drawing.Point(110, 91);
            this.confirmPassword.Name = "confirmPassword";
            this.confirmPassword.Size = new System.Drawing.Size(227, 20);
            this.confirmPassword.TabIndex = 6;
            // 
            // confirmPass
            // 
            this.confirmPass.AutoSize = true;
            this.confirmPass.Location = new System.Drawing.Point(10, 94);
            this.confirmPass.Name = "confirmPass";
            this.confirmPass.Size = new System.Drawing.Size(94, 13);
            this.confirmPass.TabIndex = 7;
            this.confirmPass.Text = "Confirm Password:";
            // 
            // OversightPasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 280);
            this.Controls.Add(this.confirmPass);
            this.Controls.Add(this.confirmPassword);
            this.Controls.Add(this.oversightPasswordChangeDialogCancel);
            this.Controls.Add(this.oversightPasswordChangeDialogOK);
            this.Controls.Add(this.OversightPasswordChangeNewTextBox);
            this.Controls.Add(this.OversightPasswordChangeCurrentTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OversightPasswordChange";
            this.Text = "OversightPasswordChange";
            this.Load += new System.EventHandler(this.OversightPasswordChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OversightPasswordChangeCurrentTextBox;
        private System.Windows.Forms.TextBox OversightPasswordChangeNewTextBox;
        private System.Windows.Forms.Button oversightPasswordChangeDialogOK;
        private System.Windows.Forms.Button oversightPasswordChangeDialogCancel;
        private System.Windows.Forms.TextBox confirmPassword;
        private System.Windows.Forms.Label confirmPass;
    }
}