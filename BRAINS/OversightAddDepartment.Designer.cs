﻿namespace BRAINS
{
    partial class OversightAddDepartment
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
            this.departmentNameText = new System.Windows.Forms.TextBox();
            this.oversightAddDepartmentDialogOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.departmentPermissionsText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Department Name:";
            // 
            // departmentNameText
            // 
            this.departmentNameText.Location = new System.Drawing.Point(163, 30);
            this.departmentNameText.Name = "departmentNameText";
            this.departmentNameText.Size = new System.Drawing.Size(259, 20);
            this.departmentNameText.TabIndex = 1;
            this.departmentNameText.TextChanged += new System.EventHandler(this.departmentNameText_TextChanged);
            // 
            // oversightAddDepartmentDialogOK
            // 
            this.oversightAddDepartmentDialogOK.Location = new System.Drawing.Point(247, 120);
            this.oversightAddDepartmentDialogOK.Name = "oversightAddDepartmentDialogOK";
            this.oversightAddDepartmentDialogOK.Size = new System.Drawing.Size(75, 23);
            this.oversightAddDepartmentDialogOK.TabIndex = 4;
            this.oversightAddDepartmentDialogOK.Text = "OK";
            this.oversightAddDepartmentDialogOK.UseVisualStyleBackColor = true;
            this.oversightAddDepartmentDialogOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(347, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Department Permissions:";
            // 
            // departmentPermissionsText
            // 
            this.departmentPermissionsText.Location = new System.Drawing.Point(163, 77);
            this.departmentPermissionsText.Name = "departmentPermissionsText";
            this.departmentPermissionsText.Size = new System.Drawing.Size(259, 20);
            this.departmentPermissionsText.TabIndex = 7;
            this.departmentPermissionsText.TextChanged += new System.EventHandler(this.departmentPermissionsText_TextChanged);
            // 
            // OversightAddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 155);
            this.Controls.Add(this.departmentPermissionsText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.oversightAddDepartmentDialogOK);
            this.Controls.Add(this.departmentNameText);
            this.Controls.Add(this.label1);
            this.Name = "OversightAddDepartment";
            this.Text = "OversightAddDepartment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox departmentNameText;
        private System.Windows.Forms.Button oversightAddDepartmentDialogOK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox departmentPermissionsText;
    }
}