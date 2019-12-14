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
            this.button1 = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.approveButton = new System.Windows.Forms.Button();
            this.submittedStenerListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.assignedDepartmentHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.questionCountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dueDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.submittedDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.submittedByHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reviewedByHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stenerManagementTab = new System.Windows.Forms.TabPage();
            this.createQuestionSetButton = new System.Windows.Forms.Button();
            this.deleteQuestionSetButton = new System.Windows.Forms.Button();
            this.addQuestionButton = new System.Windows.Forms.Button();
            this.modifyQuestionButton = new System.Windows.Forms.Button();
            this.removeQuestionButton = new System.Windows.Forms.Button();
            this.qNumTextBoxRO = new System.Windows.Forms.TextBox();
            this.questionTextboxRO = new System.Windows.Forms.TextBox();
            this.questionTextLabel = new System.Windows.Forms.Label();
            this.questionNumberLabel = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.qNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.questionDataHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.editViolation = new System.Windows.Forms.Button();
            this.removeViolation = new System.Windows.Forms.Button();
            this.violationRefreshButton = new System.Windows.Forms.Button();
            this.OversightViolationList = new System.Windows.Forms.ListView();
            this.oversightStenerSetUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.oversightDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.oversightSeverity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.oversightDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.oversightViolatedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OversightAccountsAddUser = new System.Windows.Forms.Button();
            this.OversightAccountsRemoveUser = new System.Windows.Forms.Button();
            this.oversightTabControl.SuspendLayout();
            this.submissionsTab.SuspendLayout();
            this.stenerManagementTab.SuspendLayout();
            this.departmentTab.SuspendLayout();
            this.accountsTab.SuspendLayout();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(756, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "View Selected STENER";
            this.button1.UseVisualStyleBackColor = true;
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
            // approveButton
            // 
            this.approveButton.Location = new System.Drawing.Point(802, 255);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(121, 23);
            this.approveButton.TabIndex = 3;
            this.approveButton.Text = "Approve";
            this.approveButton.UseVisualStyleBackColor = true;
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
            // stenerManagementTab
            // 
            this.stenerManagementTab.Controls.Add(this.createQuestionSetButton);
            this.stenerManagementTab.Controls.Add(this.deleteQuestionSetButton);
            this.stenerManagementTab.Controls.Add(this.addQuestionButton);
            this.stenerManagementTab.Controls.Add(this.modifyQuestionButton);
            this.stenerManagementTab.Controls.Add(this.removeQuestionButton);
            this.stenerManagementTab.Controls.Add(this.qNumTextBoxRO);
            this.stenerManagementTab.Controls.Add(this.questionTextboxRO);
            this.stenerManagementTab.Controls.Add(this.questionTextLabel);
            this.stenerManagementTab.Controls.Add(this.questionNumberLabel);
            this.stenerManagementTab.Controls.Add(this.listView2);
            this.stenerManagementTab.Controls.Add(this.listView1);
            this.stenerManagementTab.Location = new System.Drawing.Point(4, 22);
            this.stenerManagementTab.Name = "stenerManagementTab";
            this.stenerManagementTab.Padding = new System.Windows.Forms.Padding(3);
            this.stenerManagementTab.Size = new System.Drawing.Size(977, 573);
            this.stenerManagementTab.TabIndex = 1;
            this.stenerManagementTab.Text = "STENER Management";
            this.stenerManagementTab.UseVisualStyleBackColor = true;
            // 
            // createQuestionSetButton
            // 
            this.createQuestionSetButton.Location = new System.Drawing.Point(746, 510);
            this.createQuestionSetButton.Name = "createQuestionSetButton";
            this.createQuestionSetButton.Size = new System.Drawing.Size(145, 23);
            this.createQuestionSetButton.TabIndex = 13;
            this.createQuestionSetButton.Text = "Create Question Set";
            this.createQuestionSetButton.UseVisualStyleBackColor = true;
            // 
            // deleteQuestionSetButton
            // 
            this.deleteQuestionSetButton.Location = new System.Drawing.Point(746, 481);
            this.deleteQuestionSetButton.Name = "deleteQuestionSetButton";
            this.deleteQuestionSetButton.Size = new System.Drawing.Size(145, 23);
            this.deleteQuestionSetButton.TabIndex = 12;
            this.deleteQuestionSetButton.Text = "Delete Question Set";
            this.deleteQuestionSetButton.UseVisualStyleBackColor = true;
            // 
            // addQuestionButton
            // 
            this.addQuestionButton.Location = new System.Drawing.Point(764, 452);
            this.addQuestionButton.Name = "addQuestionButton";
            this.addQuestionButton.Size = new System.Drawing.Size(111, 23);
            this.addQuestionButton.TabIndex = 11;
            this.addQuestionButton.Text = "Add Question";
            this.addQuestionButton.UseVisualStyleBackColor = true;
            // 
            // modifyQuestionButton
            // 
            this.modifyQuestionButton.Location = new System.Drawing.Point(828, 423);
            this.modifyQuestionButton.Name = "modifyQuestionButton";
            this.modifyQuestionButton.Size = new System.Drawing.Size(108, 23);
            this.modifyQuestionButton.TabIndex = 10;
            this.modifyQuestionButton.Text = "Modify Question";
            this.modifyQuestionButton.UseVisualStyleBackColor = true;
            // 
            // removeQuestionButton
            // 
            this.removeQuestionButton.Location = new System.Drawing.Point(711, 423);
            this.removeQuestionButton.Name = "removeQuestionButton";
            this.removeQuestionButton.Size = new System.Drawing.Size(111, 23);
            this.removeQuestionButton.TabIndex = 9;
            this.removeQuestionButton.Text = "Remove Question";
            this.removeQuestionButton.UseVisualStyleBackColor = true;
            // 
            // qNumTextBoxRO
            // 
            this.qNumTextBoxRO.Location = new System.Drawing.Point(711, 220);
            this.qNumTextBoxRO.Name = "qNumTextBoxRO";
            this.qNumTextBoxRO.ReadOnly = true;
            this.qNumTextBoxRO.Size = new System.Drawing.Size(33, 20);
            this.qNumTextBoxRO.TabIndex = 8;
            // 
            // questionTextboxRO
            // 
            this.questionTextboxRO.Location = new System.Drawing.Point(658, 273);
            this.questionTextboxRO.Multiline = true;
            this.questionTextboxRO.Name = "questionTextboxRO";
            this.questionTextboxRO.ReadOnly = true;
            this.questionTextboxRO.Size = new System.Drawing.Size(316, 114);
            this.questionTextboxRO.TabIndex = 7;
            // 
            // questionTextLabel
            // 
            this.questionTextLabel.AutoSize = true;
            this.questionTextLabel.Location = new System.Drawing.Point(658, 256);
            this.questionTextLabel.Name = "questionTextLabel";
            this.questionTextLabel.Size = new System.Drawing.Size(52, 13);
            this.questionTextLabel.TabIndex = 5;
            this.questionTextLabel.Text = "Question:";
            // 
            // questionNumberLabel
            // 
            this.questionNumberLabel.AutoSize = true;
            this.questionNumberLabel.Location = new System.Drawing.Point(658, 223);
            this.questionNumberLabel.Name = "questionNumberLabel";
            this.questionNumberLabel.Size = new System.Drawing.Size(47, 13);
            this.questionNumberLabel.TabIndex = 4;
            this.questionNumberLabel.Text = "Number:";
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.qNumber,
            this.questionDataHeader});
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(658, 6);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(313, 197);
            this.listView2.TabIndex = 3;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // qNumber
            // 
            this.qNumber.Text = "#";
            // 
            // questionDataHeader
            // 
            this.questionDataHeader.Text = "Question";
            this.questionDataHeader.Width = 229;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader9,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 6);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(649, 561);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Q-Set ID";
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 6;
            this.columnHeader9.Text = "Category";
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "Assigned Department";
            this.columnHeader2.Width = 127;
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 2;
            this.columnHeader3.Text = "Question Count";
            this.columnHeader3.Width = 112;
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 3;
            this.columnHeader4.Text = "Due Date";
            this.columnHeader4.Width = 82;
            // 
            // columnHeader5
            // 
            this.columnHeader5.DisplayIndex = 4;
            this.columnHeader5.Text = "Submitted Date";
            this.columnHeader5.Width = 102;
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 5;
            this.columnHeader6.Text = "Status";
            this.columnHeader6.Width = 85;
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
            this.accountsTab.Controls.Add(this.OversightAccountsRemoveUser);
            this.accountsTab.Controls.Add(this.OversightAccountsAddUser);
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
            this.violationsTab.Controls.Add(this.editViolation);
            this.violationsTab.Controls.Add(this.removeViolation);
            this.violationsTab.Controls.Add(this.violationRefreshButton);
            this.violationsTab.Controls.Add(this.OversightViolationList);
            this.violationsTab.Location = new System.Drawing.Point(4, 22);
            this.violationsTab.Name = "violationsTab";
            this.violationsTab.Padding = new System.Windows.Forms.Padding(3);
            this.violationsTab.Size = new System.Drawing.Size(977, 573);
            this.violationsTab.TabIndex = 4;
            this.violationsTab.Text = "Violations";
            this.violationsTab.UseVisualStyleBackColor = true;
            // 
            // editViolation
            // 
            this.editViolation.Location = new System.Drawing.Point(762, 140);
            this.editViolation.Name = "editViolation";
            this.editViolation.Size = new System.Drawing.Size(107, 32);
            this.editViolation.TabIndex = 3;
            this.editViolation.Text = "Edit Violation";
            this.editViolation.UseVisualStyleBackColor = true;
            // 
            // removeViolation
            // 
            this.removeViolation.Location = new System.Drawing.Point(762, 230);
            this.removeViolation.Name = "removeViolation";
            this.removeViolation.Size = new System.Drawing.Size(107, 32);
            this.removeViolation.TabIndex = 2;
            this.removeViolation.Text = "Remove Violation";
            this.removeViolation.UseVisualStyleBackColor = true;
            // 
            // violationRefreshButton
            // 
            this.violationRefreshButton.Location = new System.Drawing.Point(762, 49);
            this.violationRefreshButton.Name = "violationRefreshButton";
            this.violationRefreshButton.Size = new System.Drawing.Size(107, 32);
            this.violationRefreshButton.TabIndex = 1;
            this.violationRefreshButton.Text = "Refresh";
            this.violationRefreshButton.UseVisualStyleBackColor = true;
            // 
            // OversightViolationList
            // 
            this.OversightViolationList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.oversightStenerSetUID,
            this.oversightDepartment,
            this.oversightSeverity,
            this.oversightDescription,
            this.oversightViolatedDate});
            this.OversightViolationList.HideSelection = false;
            this.OversightViolationList.Location = new System.Drawing.Point(-4, 6);
            this.OversightViolationList.Name = "OversightViolationList";
            this.OversightViolationList.Size = new System.Drawing.Size(700, 567);
            this.OversightViolationList.TabIndex = 0;
            this.OversightViolationList.UseCompatibleStateImageBehavior = false;
            this.OversightViolationList.View = System.Windows.Forms.View.Details;
            // 
            // oversightStenerSetUID
            // 
            this.oversightStenerSetUID.Text = "Document";
            this.oversightStenerSetUID.Width = 91;
            // 
            // oversightDepartment
            // 
            this.oversightDepartment.Text = "Department";
            this.oversightDepartment.Width = 83;
            // 
            // oversightSeverity
            // 
            this.oversightSeverity.Text = "Severity";
            this.oversightSeverity.Width = 79;
            // 
            // oversightDescription
            // 
            this.oversightDescription.Text = "Description";
            this.oversightDescription.Width = 91;
            // 
            // oversightViolatedDate
            // 
            this.oversightViolatedDate.Text = "Date Violated";
            this.oversightViolatedDate.Width = 88;
            // 
            // OversightAccountsAddUser
            // 
            this.OversightAccountsAddUser.Location = new System.Drawing.Point(781, 140);
            this.OversightAccountsAddUser.Name = "OversightAccountsAddUser";
            this.OversightAccountsAddUser.Size = new System.Drawing.Size(128, 23);
            this.OversightAccountsAddUser.TabIndex = 6;
            this.OversightAccountsAddUser.Text = "Add User";
            this.OversightAccountsAddUser.UseVisualStyleBackColor = true;
            // 
            // OversightAccountsRemoveUser
            // 
            this.OversightAccountsRemoveUser.Location = new System.Drawing.Point(781, 182);
            this.OversightAccountsRemoveUser.Name = "OversightAccountsRemoveUser";
            this.OversightAccountsRemoveUser.Size = new System.Drawing.Size(128, 23);
            this.OversightAccountsRemoveUser.TabIndex = 7;
            this.OversightAccountsRemoveUser.Text = "Remove User";
            this.OversightAccountsRemoveUser.UseVisualStyleBackColor = true;
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
            this.stenerManagementTab.ResumeLayout(false);
            this.stenerManagementTab.PerformLayout();
            this.departmentTab.ResumeLayout(false);
            this.accountsTab.ResumeLayout(false);
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
        private System.Windows.Forms.Label questionNumberLabel;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader qNumber;
        private System.Windows.Forms.ColumnHeader questionDataHeader;
        private System.Windows.Forms.TextBox qNumTextBoxRO;
        private System.Windows.Forms.TextBox questionTextboxRO;
        private System.Windows.Forms.Label questionTextLabel;
        private System.Windows.Forms.Button createQuestionSetButton;
        private System.Windows.Forms.Button deleteQuestionSetButton;
        private System.Windows.Forms.Button addQuestionButton;
        private System.Windows.Forms.Button modifyQuestionButton;
        private System.Windows.Forms.Button removeQuestionButton;
        private System.Windows.Forms.ListView OversightViolationList;
        private System.Windows.Forms.Button violationRefreshButton;
        private System.Windows.Forms.Button removeViolation;
        private System.Windows.Forms.Button editViolation;
        private System.Windows.Forms.ColumnHeader oversightStenerSetUID;
        private System.Windows.Forms.ColumnHeader oversightDepartment;
        private System.Windows.Forms.ColumnHeader oversightSeverity;
        private System.Windows.Forms.ColumnHeader oversightDescription;
        private System.Windows.Forms.ColumnHeader oversightViolatedDate;
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
        private System.Windows.Forms.Button OversightAccountsRemoveUser;
        private System.Windows.Forms.Button OversightAccountsAddUser;
    }
}