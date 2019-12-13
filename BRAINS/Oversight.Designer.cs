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
            this.memberList = new System.Windows.Forms.ListView();
            this.Members = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removeUserButton = new System.Windows.Forms.Button();
            this.addUserButton = new System.Windows.Forms.Button();
            this.refreshButtonDepartments = new System.Windows.Forms.Button();
            this.RemoveDepartmentButton = new System.Windows.Forms.Button();
            this.addDepartmentButton = new System.Windows.Forms.Button();
            this.departmentList = new System.Windows.Forms.ListView();
            this.Departments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.accountsTab = new System.Windows.Forms.TabPage();
            this.refreshButtonAccounts = new System.Windows.Forms.Button();
            this.changePasswordButton = new System.Windows.Forms.Button();
            this.changeUsernameButton = new System.Windows.Forms.Button();
            this.accountList = new System.Windows.Forms.ListView();
            this.UUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Password = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Department = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Permissions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.violationsTab = new System.Windows.Forms.TabPage();
            this.oversightTabControl.SuspendLayout();
            this.departmentTab.SuspendLayout();
            this.accountsTab.SuspendLayout();
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
            this.departmentTab.Controls.Add(this.memberList);
            this.departmentTab.Controls.Add(this.removeUserButton);
            this.departmentTab.Controls.Add(this.addUserButton);
            this.departmentTab.Controls.Add(this.refreshButtonDepartments);
            this.departmentTab.Controls.Add(this.RemoveDepartmentButton);
            this.departmentTab.Controls.Add(this.addDepartmentButton);
            this.departmentTab.Controls.Add(this.departmentList);
            this.departmentTab.Location = new System.Drawing.Point(4, 22);
            this.departmentTab.Name = "departmentTab";
            this.departmentTab.Padding = new System.Windows.Forms.Padding(3);
            this.departmentTab.Size = new System.Drawing.Size(977, 573);
            this.departmentTab.TabIndex = 2;
            this.departmentTab.Text = "Departments";
            this.departmentTab.UseVisualStyleBackColor = true;
            // 
            // memberList
            // 
            this.memberList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Members});
            this.memberList.HideSelection = false;
            this.memberList.Location = new System.Drawing.Point(234, 26);
            this.memberList.Name = "memberList";
            this.memberList.Size = new System.Drawing.Size(215, 383);
            this.memberList.TabIndex = 6;
            this.memberList.UseCompatibleStateImageBehavior = false;
            this.memberList.View = System.Windows.Forms.View.Details;
            // 
            // Members
            // 
            this.Members.Text = "Members";
            this.Members.Width = 236;
            // 
            // removeUserButton
            // 
            this.removeUserButton.Location = new System.Drawing.Point(752, 182);
            this.removeUserButton.Name = "removeUserButton";
            this.removeUserButton.Size = new System.Drawing.Size(149, 23);
            this.removeUserButton.TabIndex = 5;
            this.removeUserButton.Text = "Remove User from Dept.";
            this.removeUserButton.UseVisualStyleBackColor = true;
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(752, 137);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(149, 23);
            this.addUserButton.TabIndex = 4;
            this.addUserButton.Text = "Add User to Department";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // refreshButtonDepartments
            // 
            this.refreshButtonDepartments.Location = new System.Drawing.Point(752, 229);
            this.refreshButtonDepartments.Name = "refreshButtonDepartments";
            this.refreshButtonDepartments.Size = new System.Drawing.Size(149, 23);
            this.refreshButtonDepartments.TabIndex = 3;
            this.refreshButtonDepartments.Text = "Refresh";
            this.refreshButtonDepartments.UseVisualStyleBackColor = true;
            // 
            // RemoveDepartmentButton
            // 
            this.RemoveDepartmentButton.Location = new System.Drawing.Point(752, 90);
            this.RemoveDepartmentButton.Name = "RemoveDepartmentButton";
            this.RemoveDepartmentButton.Size = new System.Drawing.Size(149, 23);
            this.RemoveDepartmentButton.TabIndex = 2;
            this.RemoveDepartmentButton.Text = "Remove Department";
            this.RemoveDepartmentButton.UseVisualStyleBackColor = true;
            // 
            // addDepartmentButton
            // 
            this.addDepartmentButton.Location = new System.Drawing.Point(752, 44);
            this.addDepartmentButton.Name = "addDepartmentButton";
            this.addDepartmentButton.Size = new System.Drawing.Size(149, 23);
            this.addDepartmentButton.TabIndex = 1;
            this.addDepartmentButton.Text = "Add Department";
            this.addDepartmentButton.UseVisualStyleBackColor = true;
            this.addDepartmentButton.Click += new System.EventHandler(this.addDepartmentButton_Click);
            // 
            // departmentList
            // 
            this.departmentList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Departments});
            this.departmentList.HideSelection = false;
            this.departmentList.Location = new System.Drawing.Point(29, 26);
            this.departmentList.Name = "departmentList";
            this.departmentList.Size = new System.Drawing.Size(179, 383);
            this.departmentList.TabIndex = 0;
            this.departmentList.UseCompatibleStateImageBehavior = false;
            this.departmentList.View = System.Windows.Forms.View.Details;
            // 
            // Departments
            // 
            this.Departments.Text = "Departments";
            this.Departments.Width = 188;
            // 
            // accountsTab
            // 
            this.accountsTab.Controls.Add(this.refreshButtonAccounts);
            this.accountsTab.Controls.Add(this.changePasswordButton);
            this.accountsTab.Controls.Add(this.changeUsernameButton);
            this.accountsTab.Controls.Add(this.accountList);
            this.accountsTab.Location = new System.Drawing.Point(4, 22);
            this.accountsTab.Name = "accountsTab";
            this.accountsTab.Padding = new System.Windows.Forms.Padding(3);
            this.accountsTab.Size = new System.Drawing.Size(977, 573);
            this.accountsTab.TabIndex = 3;
            this.accountsTab.Text = "Accounts";
            this.accountsTab.UseVisualStyleBackColor = true;
            this.accountsTab.Click += new System.EventHandler(this.accountsTab_Click);
            // 
            // refreshButtonAccounts
            // 
            this.refreshButtonAccounts.Location = new System.Drawing.Point(781, 285);
            this.refreshButtonAccounts.Name = "refreshButtonAccounts";
            this.refreshButtonAccounts.Size = new System.Drawing.Size(128, 23);
            this.refreshButtonAccounts.TabIndex = 5;
            this.refreshButtonAccounts.Text = "Refresh";
            this.refreshButtonAccounts.UseVisualStyleBackColor = true;
            // 
            // changePasswordButton
            // 
            this.changePasswordButton.Location = new System.Drawing.Point(781, 99);
            this.changePasswordButton.Name = "changePasswordButton";
            this.changePasswordButton.Size = new System.Drawing.Size(128, 23);
            this.changePasswordButton.TabIndex = 2;
            this.changePasswordButton.Text = "Change Password";
            this.changePasswordButton.UseVisualStyleBackColor = true;
            this.changePasswordButton.Click += new System.EventHandler(this.changePasswordButton_Click);
            // 
            // changeUsernameButton
            // 
            this.changeUsernameButton.Location = new System.Drawing.Point(781, 59);
            this.changeUsernameButton.Name = "changeUsernameButton";
            this.changeUsernameButton.Size = new System.Drawing.Size(128, 23);
            this.changeUsernameButton.TabIndex = 1;
            this.changeUsernameButton.Text = "Change Username";
            this.changeUsernameButton.UseVisualStyleBackColor = true;
            this.changeUsernameButton.Click += new System.EventHandler(this.changeUsernameButton_Click);
            // 
            // accountList
            // 
            this.accountList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UUID,
            this.Username,
            this.Password,
            this.Department,
            this.Permissions});
            this.accountList.HideSelection = false;
            this.accountList.Location = new System.Drawing.Point(31, 17);
            this.accountList.Name = "accountList";
            this.accountList.Size = new System.Drawing.Size(700, 358);
            this.accountList.TabIndex = 0;
            this.accountList.UseCompatibleStateImageBehavior = false;
            this.accountList.View = System.Windows.Forms.View.Details;
            this.accountList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // UUID
            // 
            this.UUID.Text = "UUID";
            this.UUID.Width = 113;
            // 
            // Username
            // 
            this.Username.Text = "Username";
            this.Username.Width = 111;
            // 
            // Password
            // 
            this.Password.Text = "Password";
            this.Password.Width = 126;
            // 
            // Department
            // 
            this.Department.Text = "Department";
            this.Department.Width = 152;
            // 
            // Permissions
            // 
            this.Permissions.Text = "Permissions";
            this.Permissions.Width = 123;
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
            // Oversight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 599);
            this.Controls.Add(this.oversightTabControl);
            this.Name = "Oversight";
            this.Text = "Oversight";
            this.oversightTabControl.ResumeLayout(false);
            this.departmentTab.ResumeLayout(false);
            this.accountsTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl oversightTabControl;
        private System.Windows.Forms.TabPage submissionsTab;
        private System.Windows.Forms.TabPage stenerManagementTab;
        private System.Windows.Forms.TabPage departmentTab;
        private System.Windows.Forms.TabPage accountsTab;
        private System.Windows.Forms.TabPage violationsTab;
        private System.Windows.Forms.ListView accountList;
        private System.Windows.Forms.ColumnHeader UUID;
        private System.Windows.Forms.ColumnHeader Username;
        private System.Windows.Forms.ColumnHeader Password;
        private System.Windows.Forms.ColumnHeader Department;
        private System.Windows.Forms.ColumnHeader Permissions;
        private System.Windows.Forms.Button changeUsernameButton;
        private System.Windows.Forms.Button changePasswordButton;
        private System.Windows.Forms.Button refreshButtonAccounts;
        private System.Windows.Forms.ListView departmentList;
        private System.Windows.Forms.Button RemoveDepartmentButton;
        private System.Windows.Forms.Button addDepartmentButton;
        private System.Windows.Forms.Button removeUserButton;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.Button refreshButtonDepartments;
        private System.Windows.Forms.ListView memberList;
        private System.Windows.Forms.ColumnHeader Members;
        private System.Windows.Forms.ColumnHeader Departments;
    }
}