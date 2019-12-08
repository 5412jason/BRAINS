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
            this.submittedStenerListView = new System.Windows.Forms.ListView();
            this.approveButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.assignedDepartmentHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.questionCountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dueDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.submittedDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.submittedByHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reviewedByHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.oversightTabControl.SuspendLayout();
            this.submissionsTab.SuspendLayout();
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
            this.submissionsTab.Controls.Add(this.button1);
            this.submissionsTab.Controls.Add(this.rejectButton);
            this.submissionsTab.Controls.Add(this.approveButton);
            this.submissionsTab.Controls.Add(this.submittedStenerListView);
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
            this.violationsTab.Location = new System.Drawing.Point(4, 22);
            this.violationsTab.Name = "violationsTab";
            this.violationsTab.Padding = new System.Windows.Forms.Padding(3);
            this.violationsTab.Size = new System.Drawing.Size(977, 573);
            this.violationsTab.TabIndex = 4;
            this.violationsTab.Text = "Violations";
            this.violationsTab.UseVisualStyleBackColor = true;
            // 
            // submittedStenerListView
            // 
            this.submittedStenerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.assignedDepartmentHeader,
            this.questionCountHeader,
            this.dueDateHeader,
            this.submittedDateHeader,
            this.statusHeader,
            this.submittedByHeader,
            this.reviewedByHeader});
            this.submittedStenerListView.HideSelection = false;
            this.submittedStenerListView.Location = new System.Drawing.Point(3, 6);
            this.submittedStenerListView.Name = "submittedStenerListView";
            this.submittedStenerListView.Size = new System.Drawing.Size(747, 561);
            this.submittedStenerListView.TabIndex = 0;
            this.submittedStenerListView.UseCompatibleStateImageBehavior = false;
            this.submittedStenerListView.View = System.Windows.Forms.View.Details;
            // 
            // approveButton
            // 
            this.approveButton.Location = new System.Drawing.Point(802, 255);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(121, 23);
            this.approveButton.TabIndex = 3;
            this.approveButton.Text = "Approve";
            this.approveButton.UseVisualStyleBackColor = true;
            // 
            // rejectButton
            // 
            this.rejectButton.Location = new System.Drawing.Point(802, 284);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(121, 23);
            this.rejectButton.TabIndex = 4;
            this.rejectButton.Text = "Reject";
            this.rejectButton.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.Text = "Q-Set ID";
            // 
            // assignedDepartmentHeader
            // 
            this.assignedDepartmentHeader.Text = "Assigned Department";
            this.assignedDepartmentHeader.Width = 127;
            // 
            // questionCountHeader
            // 
            this.questionCountHeader.Text = "Question Count";
            this.questionCountHeader.Width = 112;
            // 
            // dueDateHeader
            // 
            this.dueDateHeader.Text = "Due Date";
            this.dueDateHeader.Width = 82;
            // 
            // submittedDateHeader
            // 
            this.submittedDateHeader.Text = "Submitted Date";
            this.submittedDateHeader.Width = 102;
            // 
            // statusHeader
            // 
            this.statusHeader.Text = "Status";
            this.statusHeader.Width = 85;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(756, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "View Selected STENER";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // submittedByHeader
            // 
            this.submittedByHeader.Text = "Submitted By";
            this.submittedByHeader.Width = 93;
            // 
            // reviewedByHeader
            // 
            this.reviewedByHeader.Text = "Reviewed By";
            this.reviewedByHeader.Width = 81;
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
            this.submissionsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl oversightTabControl;
        private System.Windows.Forms.TabPage submissionsTab;
        private System.Windows.Forms.TabPage stenerManagementTab;
        private System.Windows.Forms.TabPage departmentTab;
        private System.Windows.Forms.TabPage accountsTab;
        private System.Windows.Forms.TabPage violationsTab;
        private System.Windows.Forms.ListView submittedStenerListView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader assignedDepartmentHeader;
        private System.Windows.Forms.ColumnHeader questionCountHeader;
        private System.Windows.Forms.ColumnHeader dueDateHeader;
        private System.Windows.Forms.ColumnHeader submittedDateHeader;
        private System.Windows.Forms.ColumnHeader statusHeader;
        private System.Windows.Forms.ColumnHeader submittedByHeader;
        private System.Windows.Forms.ColumnHeader reviewedByHeader;
    }
}