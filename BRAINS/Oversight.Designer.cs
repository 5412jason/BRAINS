namespace BRAINS
{
    partial class Oversight
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
            this.oversightTabControl = new System.Windows.Forms.TabControl();
            this.submissionsTab = new System.Windows.Forms.TabPage();
            this.stenerManagementTab = new System.Windows.Forms.TabPage();
            this.departmentTab = new System.Windows.Forms.TabPage();
            this.accountsTab = new System.Windows.Forms.TabPage();
            this.violationsTab = new System.Windows.Forms.TabPage();
            this.OversightViolationList = new System.Windows.Forms.ListView();
            this.refreshButton = new System.Windows.Forms.Button();
            this.removeViolation = new System.Windows.Forms.Button();
            this.oversightTabControl.SuspendLayout();
            this.violationsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // oversightTabControl
            // 
            this.oversightTabControl.Controls.Add(this.submissionsTab);
            this.oversightTabControl.Controls.Add(this.stenerManagementTab);
            this.oversightTabControl.Controls.Add(this.departmentTab);
            this.oversightTabControl.Controls.Add(this.accountsTab);
            this.oversightTabControl.Controls.Add(this.violationsTab);
            this.oversightTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oversightTabControl.Location = new System.Drawing.Point(0, 0);
            this.oversightTabControl.Name = "oversightTabControl";
            this.oversightTabControl.SelectedIndex = 0;
            this.oversightTabControl.Size = new System.Drawing.Size(985, 599);
            this.oversightTabControl.TabIndex = 0;
            // 
            // submissionsTab
            // 
            this.submissionsTab.Location = new System.Drawing.Point(4, 22);
            this.submissionsTab.Name = "submissionsTab";
            this.submissionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.submissionsTab.Size = new System.Drawing.Size(977, 573);
            this.submissionsTab.TabIndex = 0;
            this.submissionsTab.Text = "Submissions";
            this.submissionsTab.UseVisualStyleBackColor = true;
            // 
            // stenerManagementTab
            // 
            this.stenerManagementTab.Location = new System.Drawing.Point(4, 22);
            this.stenerManagementTab.Name = "stenerManagementTab";
            this.stenerManagementTab.Padding = new System.Windows.Forms.Padding(3);
            this.stenerManagementTab.Size = new System.Drawing.Size(977, 573);
            this.stenerManagementTab.TabIndex = 1;
            this.stenerManagementTab.Text = "STENER Management";
            this.stenerManagementTab.UseVisualStyleBackColor = true;
            // 
            // departmentTab
            // 
            this.departmentTab.Location = new System.Drawing.Point(4, 22);
            this.departmentTab.Name = "departmentTab";
            this.departmentTab.Padding = new System.Windows.Forms.Padding(3);
            this.departmentTab.Size = new System.Drawing.Size(977, 573);
            this.departmentTab.TabIndex = 2;
            this.departmentTab.Text = "Departments";
            this.departmentTab.UseVisualStyleBackColor = true;
            // 
            // accountsTab
            // 
            this.accountsTab.Location = new System.Drawing.Point(4, 22);
            this.accountsTab.Name = "accountsTab";
            this.accountsTab.Padding = new System.Windows.Forms.Padding(3);
            this.accountsTab.Size = new System.Drawing.Size(977, 573);
            this.accountsTab.TabIndex = 3;
            this.accountsTab.Text = "Accounts";
            this.accountsTab.UseVisualStyleBackColor = true;
            // 
            // violationsTab
            // 
            this.violationsTab.Controls.Add(this.removeViolation);
            this.violationsTab.Controls.Add(this.refreshButton);
            this.violationsTab.Controls.Add(this.OversightViolationList);
            this.violationsTab.Location = new System.Drawing.Point(4, 22);
            this.violationsTab.Name = "violationsTab";
            this.violationsTab.Padding = new System.Windows.Forms.Padding(3);
            this.violationsTab.Size = new System.Drawing.Size(977, 573);
            this.violationsTab.TabIndex = 4;
            this.violationsTab.Text = "Violations";
            this.violationsTab.UseVisualStyleBackColor = true;
            this.violationsTab.Click += new System.EventHandler(this.violationsTab_Click);
            // 
            // OversightViolationList
            // 
            this.OversightViolationList.HideSelection = false;
            this.OversightViolationList.Location = new System.Drawing.Point(0, 49);
            this.OversightViolationList.Name = "OversightViolationList";
            this.OversightViolationList.Size = new System.Drawing.Size(700, 524);
            this.OversightViolationList.TabIndex = 0;
            this.OversightViolationList.UseCompatibleStateImageBehavior = false;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(762, 49);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(107, 32);
            this.refreshButton.TabIndex = 1;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // removeViolation
            // 
            this.removeViolation.Location = new System.Drawing.Point(762, 179);
            this.removeViolation.Name = "removeViolation";
            this.removeViolation.Size = new System.Drawing.Size(107, 32);
            this.removeViolation.TabIndex = 2;
            this.removeViolation.Text = "Remove Violation";
            this.removeViolation.UseVisualStyleBackColor = true;
            // 
            // Oversight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 599);
            this.Controls.Add(this.oversightTabControl);
            this.Name = "Oversight";
            this.Text = "Oversight";
            this.oversightTabControl.ResumeLayout(false);
            this.violationsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl oversightTabControl;
        private System.Windows.Forms.TabPage submissionsTab;
        private System.Windows.Forms.TabPage stenerManagementTab;
        private System.Windows.Forms.TabPage departmentTab;
        private System.Windows.Forms.TabPage accountsTab;
        private System.Windows.Forms.TabPage violationsTab;
        private System.Windows.Forms.ListView OversightViolationList;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button removeViolation;
    }
}