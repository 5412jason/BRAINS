namespace BRAINS
{
    partial class OversightRemoveDepartment
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
            this.departmentNameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteDepartmentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // departmentNameText
            // 
            this.departmentNameText.Location = new System.Drawing.Point(163, 55);
            this.departmentNameText.Name = "departmentNameText";
            this.departmentNameText.Size = new System.Drawing.Size(259, 20);
            this.departmentNameText.TabIndex = 9;
            this.departmentNameText.TextChanged += new System.EventHandler(this.departmentNameText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Department UID:";
            // 
            // deleteDepartmentButton
            // 
            this.deleteDepartmentButton.Location = new System.Drawing.Point(350, 330);
            this.deleteDepartmentButton.Name = "deleteDepartmentButton";
            this.deleteDepartmentButton.Size = new System.Drawing.Size(72, 36);
            this.deleteDepartmentButton.TabIndex = 10;
            this.deleteDepartmentButton.Text = "Delete Department";
            this.deleteDepartmentButton.UseVisualStyleBackColor = true;
            this.deleteDepartmentButton.Click += new System.EventHandler(this.deleteDepartmentButton_Click);
            // 
            // OversightRemoveDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteDepartmentButton);
            this.Controls.Add(this.departmentNameText);
            this.Controls.Add(this.label1);
            this.Name = "OversightRemoveDepartment";
            this.Text = "OversightRemoveDepartment";
            this.Load += new System.EventHandler(this.OversightRemoveDepartment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox departmentNameText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteDepartmentButton;
    }
}