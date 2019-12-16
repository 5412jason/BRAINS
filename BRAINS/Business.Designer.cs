namespace BRAINS
{
    partial class Business
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
            this.businessTabControl = new System.Windows.Forms.TabControl();
            this.completeStenerTab = new System.Windows.Forms.TabPage();
            this.violationTab = new System.Windows.Forms.TabPage();
            this.BusinessViolationList = new System.Windows.Forms.ListView();
            this.businessStenerSetUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessSeverity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessViolatedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.busniessViolationsrefreshButton = new System.Windows.Forms.Button();
            this.completeStenerListView = new System.Windows.Forms.ListView();
            this.priorityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qSetID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.questionCountColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessTabControl.SuspendLayout();
            this.completeStenerTab.SuspendLayout();
            this.violationTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // businessTabControl
            // 
            this.businessTabControl.Controls.Add(this.completeStenerTab);
            this.businessTabControl.Controls.Add(this.violationTab);
            this.businessTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.businessTabControl.Location = new System.Drawing.Point(0, 0);
            this.businessTabControl.Name = "businessTabControl";
            this.businessTabControl.SelectedIndex = 0;
            this.businessTabControl.Size = new System.Drawing.Size(964, 574);
            this.businessTabControl.TabIndex = 0;
            // 
            // completeStenerTab
            // 
            this.completeStenerTab.Controls.Add(this.completeStenerListView);
            this.completeStenerTab.Location = new System.Drawing.Point(4, 22);
            this.completeStenerTab.Name = "completeStenerTab";
            this.completeStenerTab.Padding = new System.Windows.Forms.Padding(3);
            this.completeStenerTab.Size = new System.Drawing.Size(956, 548);
            this.completeStenerTab.TabIndex = 0;
            this.completeStenerTab.Text = "Complete STENERs";
            this.completeStenerTab.UseVisualStyleBackColor = true;
            // 
            // violationTab
            // 
            this.violationTab.Controls.Add(this.BusinessViolationList);
            this.violationTab.Controls.Add(this.busniessViolationsrefreshButton);
            this.violationTab.Location = new System.Drawing.Point(4, 22);
            this.violationTab.Name = "violationTab";
            this.violationTab.Padding = new System.Windows.Forms.Padding(3);
            this.violationTab.Size = new System.Drawing.Size(1104, 478);
            this.violationTab.TabIndex = 1;
            this.violationTab.Text = "Violations";
            this.violationTab.UseVisualStyleBackColor = true;
            // 
            // BusinessViolationList
            // 
            this.BusinessViolationList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.businessStenerSetUID,
            this.businessDepartment,
            this.businessSeverity,
            this.businessDescription,
            this.businessViolatedDate});
            this.BusinessViolationList.HideSelection = false;
            this.BusinessViolationList.Location = new System.Drawing.Point(0, 28);
            this.BusinessViolationList.Name = "BusinessViolationList";
            this.BusinessViolationList.Size = new System.Drawing.Size(640, 450);
            this.BusinessViolationList.TabIndex = 3;
            this.BusinessViolationList.UseCompatibleStateImageBehavior = false;
            this.BusinessViolationList.View = System.Windows.Forms.View.Details;
            // 
            // businessStenerSetUID
            // 
            this.businessStenerSetUID.Text = "Document";
            this.businessStenerSetUID.Width = 91;
            // 
            // businessDepartment
            // 
            this.businessDepartment.Text = "Department";
            this.businessDepartment.Width = 83;
            // 
            // businessSeverity
            // 
            this.businessSeverity.Text = "Severity";
            this.businessSeverity.Width = 79;
            // 
            // businessDescription
            // 
            this.businessDescription.Text = "Description";
            this.businessDescription.Width = 91;
            // 
            // businessViolatedDate
            // 
            this.businessViolatedDate.Text = "Date Violated";
            this.businessViolatedDate.Width = 88;
            // 
            // busniessViolationsrefreshButton
            // 
            this.busniessViolationsrefreshButton.Location = new System.Drawing.Point(673, 28);
            this.busniessViolationsrefreshButton.Name = "busniessViolationsrefreshButton";
            this.busniessViolationsrefreshButton.Size = new System.Drawing.Size(107, 32);
            this.busniessViolationsrefreshButton.TabIndex = 2;
            this.busniessViolationsrefreshButton.Text = "Refresh";
            this.busniessViolationsrefreshButton.UseVisualStyleBackColor = true;
            // 
            // completeStenerListView
            // 
            this.completeStenerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.priorityColumn,
            this.qSetID,
            this.categoryColumn,
            this.questionCountColumn,
            this.statusColumn});
            this.completeStenerListView.FullRowSelect = true;
            this.completeStenerListView.HideSelection = false;
            this.completeStenerListView.Location = new System.Drawing.Point(3, 3);
            this.completeStenerListView.MultiSelect = false;
            this.completeStenerListView.Name = "completeStenerListView";
            this.completeStenerListView.Size = new System.Drawing.Size(382, 232);
            this.completeStenerListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.completeStenerListView.TabIndex = 0;
            this.completeStenerListView.UseCompatibleStateImageBehavior = false;
            this.completeStenerListView.View = System.Windows.Forms.View.Details;
            // 
            // priorityColumn
            // 
            this.priorityColumn.Text = "Priority";
            // 
            // qSetID
            // 
            this.qSetID.Text = "Q-Set ID";
            // 
            // categoryColumn
            // 
            this.categoryColumn.Text = "Category";
            this.categoryColumn.Width = 98;
            // 
            // questionCountColumn
            // 
            this.questionCountColumn.Text = "# of Questions";
            // 
            // statusColumn
            // 
            this.statusColumn.Text = "Status";
            this.statusColumn.Width = 98;
            // 
            // Business
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 574);
            this.Controls.Add(this.businessTabControl);
            this.Name = "Business";
            this.Text = "Business";
            this.businessTabControl.ResumeLayout(false);
            this.completeStenerTab.ResumeLayout(false);
            this.violationTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl businessTabControl;
        private System.Windows.Forms.TabPage completeStenerTab;
        private System.Windows.Forms.TabPage violationTab;
        private System.Windows.Forms.Button busniessViolationsrefreshButton;
        private System.Windows.Forms.ListView BusinessViolationList;
        private System.Windows.Forms.ColumnHeader businessStenerSetUID;
        private System.Windows.Forms.ColumnHeader businessDepartment;
        private System.Windows.Forms.ColumnHeader businessSeverity;
        private System.Windows.Forms.ColumnHeader businessDescription;
        private System.Windows.Forms.ColumnHeader businessViolatedDate;
        private System.Windows.Forms.ListView completeStenerListView;
        private System.Windows.Forms.ColumnHeader priorityColumn;
        private System.Windows.Forms.ColumnHeader qSetID;
        private System.Windows.Forms.ColumnHeader categoryColumn;
        private System.Windows.Forms.ColumnHeader questionCountColumn;
        private System.Windows.Forms.ColumnHeader statusColumn;
    }
}