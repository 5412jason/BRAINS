namespace BRAINS
{
    partial class NewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUser));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.newUsername = new System.Windows.Forms.TextBox();
            this.newUserPassword = new System.Windows.Forms.TextBox();
            this.confirmNewUserPassword = new System.Windows.Forms.TextBox();
            this.newUserOK = new System.Windows.Forms.Button();
            this.newUserCancel = new System.Windows.Forms.Button();
            this.departmentAssign = new System.Windows.Forms.ComboBox();
            this.permissionsBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Department Assignment:";
            // 
            // newUsername
            // 
            this.newUsername.Location = new System.Drawing.Point(142, 6);
            this.newUsername.Name = "newUsername";
            this.newUsername.Size = new System.Drawing.Size(224, 20);
            this.newUsername.TabIndex = 4;
            // 
            // newUserPassword
            // 
            this.newUserPassword.Location = new System.Drawing.Point(142, 33);
            this.newUserPassword.Name = "newUserPassword";
            this.newUserPassword.Size = new System.Drawing.Size(224, 20);
            this.newUserPassword.TabIndex = 5;
            this.newUserPassword.UseSystemPasswordChar = true;
            // 
            // confirmNewUserPassword
            // 
            this.confirmNewUserPassword.Location = new System.Drawing.Point(142, 60);
            this.confirmNewUserPassword.Name = "confirmNewUserPassword";
            this.confirmNewUserPassword.Size = new System.Drawing.Size(224, 20);
            this.confirmNewUserPassword.TabIndex = 6;
            this.confirmNewUserPassword.UseSystemPasswordChar = true;
            // 
            // newUserOK
            // 
            this.newUserOK.Location = new System.Drawing.Point(202, 160);
            this.newUserOK.Name = "newUserOK";
            this.newUserOK.Size = new System.Drawing.Size(75, 23);
            this.newUserOK.TabIndex = 8;
            this.newUserOK.Text = "OK";
            this.newUserOK.UseVisualStyleBackColor = true;
            this.newUserOK.Click += new System.EventHandler(this.NewUserOK_Click);
            // 
            // newUserCancel
            // 
            this.newUserCancel.Location = new System.Drawing.Point(283, 160);
            this.newUserCancel.Name = "newUserCancel";
            this.newUserCancel.Size = new System.Drawing.Size(83, 23);
            this.newUserCancel.TabIndex = 9;
            this.newUserCancel.Text = "Cancel";
            this.newUserCancel.UseVisualStyleBackColor = true;
            this.newUserCancel.Click += new System.EventHandler(this.newUserCancel_Click);
            // 
            // departmentAssign
            // 
            this.departmentAssign.FormattingEnabled = true;
            this.departmentAssign.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.departmentAssign.Location = new System.Drawing.Point(142, 87);
            this.departmentAssign.Name = "departmentAssign";
            this.departmentAssign.Size = new System.Drawing.Size(224, 21);
            this.departmentAssign.TabIndex = 7;
            // 
            // permissionsBox
            // 
            this.permissionsBox.FormattingEnabled = true;
            this.permissionsBox.Items.AddRange(new object[] {
            "1",
            "0"});
            this.permissionsBox.Location = new System.Drawing.Point(142, 117);
            this.permissionsBox.Name = "permissionsBox";
            this.permissionsBox.Size = new System.Drawing.Size(224, 21);
            this.permissionsBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Admin:";
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 242);
            this.Controls.Add(this.permissionsBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.newUserCancel);
            this.Controls.Add(this.newUserOK);
            this.Controls.Add(this.departmentAssign);
            this.Controls.Add(this.confirmNewUserPassword);
            this.Controls.Add(this.newUserPassword);
            this.Controls.Add(this.newUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewUser";
            this.Text = "NewUser";
            this.Load += new System.EventHandler(this.NewUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox newUsername;
        private System.Windows.Forms.TextBox newUserPassword;
        private System.Windows.Forms.TextBox confirmNewUserPassword;
        private System.Windows.Forms.Button newUserOK;
        private System.Windows.Forms.Button newUserCancel;
        private System.Windows.Forms.ComboBox departmentAssign;
        private System.Windows.Forms.ComboBox permissionsBox;
        private System.Windows.Forms.Label label5;
    }
}