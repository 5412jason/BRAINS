namespace BRAINS
{
    partial class OversightAccountsUsernameChange
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.oversightAccountsUsernameChangeOK = new System.Windows.Forms.Button();
            this.oversightAccountsUsernameChangeCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(66, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "New:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(66, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(195, 20);
            this.textBox2.TabIndex = 3;
            // 
            // oversightAccountsUsernameChangeOK
            // 
            this.oversightAccountsUsernameChangeOK.Location = new System.Drawing.Point(120, 117);
            this.oversightAccountsUsernameChangeOK.Name = "oversightAccountsUsernameChangeOK";
            this.oversightAccountsUsernameChangeOK.Size = new System.Drawing.Size(75, 27);
            this.oversightAccountsUsernameChangeOK.TabIndex = 4;
            this.oversightAccountsUsernameChangeOK.Text = "OK";
            this.oversightAccountsUsernameChangeOK.UseVisualStyleBackColor = true;
            this.oversightAccountsUsernameChangeOK.Click += new System.EventHandler(this.oversightAccountsUsernameChangeOK_Click);
            // 
            // oversightAccountsUsernameChangeCancel
            // 
            this.oversightAccountsUsernameChangeCancel.Location = new System.Drawing.Point(214, 117);
            this.oversightAccountsUsernameChangeCancel.Name = "oversightAccountsUsernameChangeCancel";
            this.oversightAccountsUsernameChangeCancel.Size = new System.Drawing.Size(75, 27);
            this.oversightAccountsUsernameChangeCancel.TabIndex = 5;
            this.oversightAccountsUsernameChangeCancel.Text = "Cancel";
            this.oversightAccountsUsernameChangeCancel.UseVisualStyleBackColor = true;
            this.oversightAccountsUsernameChangeCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // OversightAccountsUsernameChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 164);
            this.Controls.Add(this.oversightAccountsUsernameChangeCancel);
            this.Controls.Add(this.oversightAccountsUsernameChangeOK);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "OversightAccountsUsernameChange";
            this.Text = "OversightAccountsUsernameChange";
            this.Load += new System.EventHandler(this.OversightAccountsUsernameChange_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button oversightAccountsUsernameChangeOK;
        private System.Windows.Forms.Button oversightAccountsUsernameChangeCancel;
    }
}