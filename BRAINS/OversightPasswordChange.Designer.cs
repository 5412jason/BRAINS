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
            this.label2 = new System.Windows.Forms.Label();
            this.OversightPasswordChangeNewTextBox = new System.Windows.Forms.TextBox();
            this.oversightPasswordChangeDialogCancel = new System.Windows.Forms.Button();
            this.confirmPassword = new System.Windows.Forms.TextBox();
            this.confirmPass = new System.Windows.Forms.Label();
            this.changePassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // OversightPasswordChangeNewTextBox
            // 
            this.OversightPasswordChangeNewTextBox.Location = new System.Drawing.Point(110, 55);
            this.OversightPasswordChangeNewTextBox.Name = "OversightPasswordChangeNewTextBox";
            this.OversightPasswordChangeNewTextBox.Size = new System.Drawing.Size(227, 20);
            this.OversightPasswordChangeNewTextBox.TabIndex = 3;
            this.OversightPasswordChangeNewTextBox.UseSystemPasswordChar = true;
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
            this.confirmPassword.UseSystemPasswordChar = true;
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
            // changePassword
            // 
            this.changePassword.Location = new System.Drawing.Point(157, 155);
            this.changePassword.Name = "changePassword";
            this.changePassword.Size = new System.Drawing.Size(75, 23);
            this.changePassword.TabIndex = 8;
            this.changePassword.Text = "Change";
            this.changePassword.UseVisualStyleBackColor = true;
            this.changePassword.Click += new System.EventHandler(this.changePassword_Click);
            // 
            // OversightPasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 280);
            this.Controls.Add(this.changePassword);
            this.Controls.Add(this.confirmPass);
            this.Controls.Add(this.confirmPassword);
            this.Controls.Add(this.oversightPasswordChangeDialogCancel);
            this.Controls.Add(this.OversightPasswordChangeNewTextBox);
            this.Controls.Add(this.label2);
            this.Name = "OversightPasswordChange";
            this.Text = "OversightPasswordChange";
            this.Load += new System.EventHandler(this.OversightPasswordChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox OversightPasswordChangeNewTextBox;
        private System.Windows.Forms.Button oversightPasswordChangeDialogCancel;
        private System.Windows.Forms.TextBox confirmPassword;
        private System.Windows.Forms.Label confirmPass;
        private System.Windows.Forms.Button changePassword;
    }
}