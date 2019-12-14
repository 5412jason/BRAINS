﻿namespace BRAINS
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
            this.CompleteStenerDataGridView = new System.Windows.Forms.DataGridView();
            this.violationTab = new System.Windows.Forms.TabPage();
            this.BusinessViolationList = new System.Windows.Forms.ListView();
            this.businessStenerSetUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessSeverity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessViolatedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.busniessViolationsrefreshButton = new System.Windows.Forms.Button();
            this.businessTabControl.SuspendLayout();
            this.completeStenerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompleteStenerDataGridView)).BeginInit();
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
            this.businessTabControl.Size = new System.Drawing.Size(814, 504);
            this.businessTabControl.TabIndex = 0;
            // 
            // completeStenerTab
            // 
            this.completeStenerTab.Controls.Add(this.CompleteStenerDataGridView);
            this.completeStenerTab.Location = new System.Drawing.Point(4, 22);
            this.completeStenerTab.Name = "completeStenerTab";
            this.completeStenerTab.Padding = new System.Windows.Forms.Padding(3);
            this.completeStenerTab.Size = new System.Drawing.Size(806, 478);
            this.completeStenerTab.TabIndex = 0;
            this.completeStenerTab.Text = "Complete STENERs";
            this.completeStenerTab.UseVisualStyleBackColor = true;
            // 
            // CompleteStenerDataGridView
            // 
            this.CompleteStenerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompleteStenerDataGridView.Location = new System.Drawing.Point(9, 5);
            this.CompleteStenerDataGridView.Name = "CompleteStenerDataGridView";
            this.CompleteStenerDataGridView.Size = new System.Drawing.Size(780, 279);
            this.CompleteStenerDataGridView.TabIndex = 0;
            this.CompleteStenerDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // violationTab
            // 
            this.violationTab.Controls.Add(this.BusinessViolationList);
            this.violationTab.Controls.Add(this.busniessViolationsrefreshButton);
            this.violationTab.Location = new System.Drawing.Point(4, 22);
            this.violationTab.Name = "violationTab";
            this.violationTab.Padding = new System.Windows.Forms.Padding(3);
            this.violationTab.Size = new System.Drawing.Size(806, 478);
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
            // Business
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 504);
            this.Controls.Add(this.businessTabControl);
            this.Name = "Business";
            this.Text = "Business";
            this.Load += new System.EventHandler(this.Business_Load);
            this.businessTabControl.ResumeLayout(false);
            this.completeStenerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompleteStenerDataGridView)).EndInit();
            this.violationTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl businessTabControl;
        private System.Windows.Forms.TabPage completeStenerTab;
        private System.Windows.Forms.TabPage violationTab;
        private System.Windows.Forms.DataGridView CompleteStenerDataGridView;
        private System.Windows.Forms.Button busniessViolationsrefreshButton;
        private System.Windows.Forms.ListView BusinessViolationList;
        private System.Windows.Forms.ColumnHeader businessStenerSetUID;
        private System.Windows.Forms.ColumnHeader businessDepartment;
        private System.Windows.Forms.ColumnHeader businessSeverity;
        private System.Windows.Forms.ColumnHeader businessDescription;
        private System.Windows.Forms.ColumnHeader businessViolatedDate;
    }
}