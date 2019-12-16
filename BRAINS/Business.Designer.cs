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
            this.violationTab = new System.Windows.Forms.TabPage();
            this.BusinessViolationList = new System.Windows.Forms.ListView();
            this.businessStenerSetUID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessSeverity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessViolatedDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.busniessViolationsrefreshButton = new System.Windows.Forms.Button();
            this.refreshCompleteList = new System.Windows.Forms.Button();
            this.workOnSelectedStenerButton = new System.Windows.Forms.Button();
            this.completeStenerStatusStrip = new System.Windows.Forms.StatusStrip();
            this.completeStenerStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.questionBodyTextBox = new System.Windows.Forms.TextBox();
            this.questionBodyLabel = new System.Windows.Forms.Label();
            this.questionNumberLabel = new System.Windows.Forms.Label();
            this.questionCountTextBox = new System.Windows.Forms.TextBox();
            this.complianceCheckBox = new System.Windows.Forms.CheckBox();
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.answerLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.planForSolutionLabel = new System.Windows.Forms.Label();
            this.evidenceLocationTextBox = new System.Windows.Forms.TextBox();
            this.evidenceLocationLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.closeQuestionSetButton = new System.Windows.Forms.Button();
            this.submitQuestionSetButton = new System.Windows.Forms.Button();
            this.completeQuestionSetListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.businessTabControl.SuspendLayout();
            this.completeStenerTab.SuspendLayout();
            this.violationTab.SuspendLayout();
            this.completeStenerStatusStrip.SuspendLayout();
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
            this.completeStenerTab.Controls.Add(this.completeQuestionSetListView);
            this.completeStenerTab.Controls.Add(this.submitQuestionSetButton);
            this.completeStenerTab.Controls.Add(this.closeQuestionSetButton);
            this.completeStenerTab.Controls.Add(this.nextButton);
            this.completeStenerTab.Controls.Add(this.backButton);
            this.completeStenerTab.Controls.Add(this.evidenceLocationLabel);
            this.completeStenerTab.Controls.Add(this.evidenceLocationTextBox);
            this.completeStenerTab.Controls.Add(this.planForSolutionLabel);
            this.completeStenerTab.Controls.Add(this.textBox1);
            this.completeStenerTab.Controls.Add(this.answerLabel);
            this.completeStenerTab.Controls.Add(this.answerTextBox);
            this.completeStenerTab.Controls.Add(this.complianceCheckBox);
            this.completeStenerTab.Controls.Add(this.questionCountTextBox);
            this.completeStenerTab.Controls.Add(this.questionNumberLabel);
            this.completeStenerTab.Controls.Add(this.questionBodyLabel);
            this.completeStenerTab.Controls.Add(this.questionBodyTextBox);
            this.completeStenerTab.Controls.Add(this.completeStenerStatusStrip);
            this.completeStenerTab.Controls.Add(this.workOnSelectedStenerButton);
            this.completeStenerTab.Controls.Add(this.refreshCompleteList);
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
            this.violationTab.Size = new System.Drawing.Size(956, 548);
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
            // refreshCompleteList
            // 
            this.refreshCompleteList.Location = new System.Drawing.Point(3, 453);
            this.refreshCompleteList.Name = "refreshCompleteList";
            this.refreshCompleteList.Size = new System.Drawing.Size(464, 23);
            this.refreshCompleteList.TabIndex = 1;
            this.refreshCompleteList.Text = "Refresh List";
            this.refreshCompleteList.UseVisualStyleBackColor = true;
            this.refreshCompleteList.Click += new System.EventHandler(this.RefreshCompleteList_Click);
            // 
            // workOnSelectedStenerButton
            // 
            this.workOnSelectedStenerButton.Location = new System.Drawing.Point(3, 483);
            this.workOnSelectedStenerButton.Name = "workOnSelectedStenerButton";
            this.workOnSelectedStenerButton.Size = new System.Drawing.Size(464, 23);
            this.workOnSelectedStenerButton.TabIndex = 2;
            this.workOnSelectedStenerButton.Text = "Work On Selected Stener";
            this.workOnSelectedStenerButton.UseVisualStyleBackColor = true;
            // 
            // completeStenerStatusStrip
            // 
            this.completeStenerStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.completeStenerStatusLabel});
            this.completeStenerStatusStrip.Location = new System.Drawing.Point(3, 523);
            this.completeStenerStatusStrip.Name = "completeStenerStatusStrip";
            this.completeStenerStatusStrip.Size = new System.Drawing.Size(950, 22);
            this.completeStenerStatusStrip.TabIndex = 3;
            // 
            // completeStenerStatusLabel
            // 
            this.completeStenerStatusLabel.Name = "completeStenerStatusLabel";
            this.completeStenerStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // questionBodyTextBox
            // 
            this.questionBodyTextBox.Location = new System.Drawing.Point(561, 97);
            this.questionBodyTextBox.Multiline = true;
            this.questionBodyTextBox.Name = "questionBodyTextBox";
            this.questionBodyTextBox.ReadOnly = true;
            this.questionBodyTextBox.Size = new System.Drawing.Size(392, 97);
            this.questionBodyTextBox.TabIndex = 4;
            // 
            // questionBodyLabel
            // 
            this.questionBodyLabel.AutoSize = true;
            this.questionBodyLabel.Location = new System.Drawing.Point(558, 81);
            this.questionBodyLabel.Name = "questionBodyLabel";
            this.questionBodyLabel.Size = new System.Drawing.Size(52, 13);
            this.questionBodyLabel.TabIndex = 5;
            this.questionBodyLabel.Text = "Question:";
            // 
            // questionNumberLabel
            // 
            this.questionNumberLabel.AutoSize = true;
            this.questionNumberLabel.Location = new System.Drawing.Point(558, 58);
            this.questionNumberLabel.Name = "questionNumberLabel";
            this.questionNumberLabel.Size = new System.Drawing.Size(83, 13);
            this.questionNumberLabel.TabIndex = 6;
            this.questionNumberLabel.Text = "Question Count:";
            // 
            // questionCountTextBox
            // 
            this.questionCountTextBox.Location = new System.Drawing.Point(647, 55);
            this.questionCountTextBox.Name = "questionCountTextBox";
            this.questionCountTextBox.ReadOnly = true;
            this.questionCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.questionCountTextBox.TabIndex = 7;
            // 
            // complianceCheckBox
            // 
            this.complianceCheckBox.AutoSize = true;
            this.complianceCheckBox.Enabled = false;
            this.complianceCheckBox.Location = new System.Drawing.Point(561, 300);
            this.complianceCheckBox.Name = "complianceCheckBox";
            this.complianceCheckBox.Size = new System.Drawing.Size(93, 17);
            this.complianceCheckBox.TabIndex = 9;
            this.complianceCheckBox.Text = "In Compliance";
            this.complianceCheckBox.UseVisualStyleBackColor = true;
            // 
            // answerTextBox
            // 
            this.answerTextBox.Enabled = false;
            this.answerTextBox.Location = new System.Drawing.Point(561, 241);
            this.answerTextBox.Multiline = true;
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(392, 53);
            this.answerTextBox.TabIndex = 10;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Location = new System.Drawing.Point(558, 225);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(45, 13);
            this.answerLabel.TabIndex = 11;
            this.answerLabel.Text = "Answer:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(561, 336);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(392, 49);
            this.textBox1.TabIndex = 12;
            // 
            // planForSolutionLabel
            // 
            this.planForSolutionLabel.AutoSize = true;
            this.planForSolutionLabel.Location = new System.Drawing.Point(558, 320);
            this.planForSolutionLabel.Name = "planForSolutionLabel";
            this.planForSolutionLabel.Size = new System.Drawing.Size(90, 13);
            this.planForSolutionLabel.TabIndex = 13;
            this.planForSolutionLabel.Text = "Plan For Solution:";
            // 
            // evidenceLocationTextBox
            // 
            this.evidenceLocationTextBox.Enabled = false;
            this.evidenceLocationTextBox.Location = new System.Drawing.Point(561, 404);
            this.evidenceLocationTextBox.Multiline = true;
            this.evidenceLocationTextBox.Name = "evidenceLocationTextBox";
            this.evidenceLocationTextBox.Size = new System.Drawing.Size(392, 43);
            this.evidenceLocationTextBox.TabIndex = 14;
            // 
            // evidenceLocationLabel
            // 
            this.evidenceLocationLabel.AutoSize = true;
            this.evidenceLocationLabel.Location = new System.Drawing.Point(558, 388);
            this.evidenceLocationLabel.Name = "evidenceLocationLabel";
            this.evidenceLocationLabel.Size = new System.Drawing.Size(157, 13);
            this.evidenceLocationLabel.TabIndex = 15;
            this.evidenceLocationLabel.Text = "Compliance Evidence Location:";
            // 
            // backButton
            // 
            this.backButton.Enabled = false;
            this.backButton.Location = new System.Drawing.Point(561, 453);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(174, 23);
            this.backButton.TabIndex = 16;
            this.backButton.Text = "Previous Question";
            this.backButton.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.Enabled = false;
            this.nextButton.Location = new System.Drawing.Point(779, 453);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(174, 23);
            this.nextButton.TabIndex = 17;
            this.nextButton.Text = "Next Question";
            this.nextButton.UseVisualStyleBackColor = true;
            // 
            // closeQuestionSetButton
            // 
            this.closeQuestionSetButton.Enabled = false;
            this.closeQuestionSetButton.Location = new System.Drawing.Point(561, 482);
            this.closeQuestionSetButton.Name = "closeQuestionSetButton";
            this.closeQuestionSetButton.Size = new System.Drawing.Size(174, 23);
            this.closeQuestionSetButton.TabIndex = 18;
            this.closeQuestionSetButton.Text = "Close Question Set";
            this.closeQuestionSetButton.UseVisualStyleBackColor = true;
            // 
            // submitQuestionSetButton
            // 
            this.submitQuestionSetButton.Enabled = false;
            this.submitQuestionSetButton.Location = new System.Drawing.Point(779, 482);
            this.submitQuestionSetButton.Name = "submitQuestionSetButton";
            this.submitQuestionSetButton.Size = new System.Drawing.Size(174, 23);
            this.submitQuestionSetButton.TabIndex = 19;
            this.submitQuestionSetButton.Text = "Submit Question Set";
            this.submitQuestionSetButton.UseVisualStyleBackColor = true;
            // 
            // completeQuestionSetListView
            // 
            this.completeQuestionSetListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7});
            this.completeQuestionSetListView.FullRowSelect = true;
            this.completeQuestionSetListView.HideSelection = false;
            this.completeQuestionSetListView.Location = new System.Drawing.Point(3, 3);
            this.completeQuestionSetListView.MultiSelect = false;
            this.completeQuestionSetListView.Name = "completeQuestionSetListView";
            this.completeQuestionSetListView.Size = new System.Drawing.Size(464, 444);
            this.completeQuestionSetListView.TabIndex = 20;
            this.completeQuestionSetListView.UseCompatibleStateImageBehavior = false;
            this.completeQuestionSetListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Priority";
            this.columnHeader1.Width = 47;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Q-SetID";
            this.columnHeader2.Width = 61;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Question Count";
            this.columnHeader3.Width = 87;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Due Date";
            this.columnHeader4.Width = 82;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            this.columnHeader5.Width = 102;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Category";
            this.columnHeader7.Width = 75;
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
            this.completeStenerTab.PerformLayout();
            this.violationTab.ResumeLayout(false);
            this.completeStenerStatusStrip.ResumeLayout(false);
            this.completeStenerStatusStrip.PerformLayout();
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
        private System.Windows.Forms.Button workOnSelectedStenerButton;
        private System.Windows.Forms.Button refreshCompleteList;
        private System.Windows.Forms.StatusStrip completeStenerStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel completeStenerStatusLabel;
        private System.Windows.Forms.Label questionBodyLabel;
        private System.Windows.Forms.TextBox questionBodyTextBox;
        private System.Windows.Forms.TextBox questionCountTextBox;
        private System.Windows.Forms.Label questionNumberLabel;
        private System.Windows.Forms.CheckBox complianceCheckBox;
        private System.Windows.Forms.Button submitQuestionSetButton;
        private System.Windows.Forms.Button closeQuestionSetButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label evidenceLocationLabel;
        private System.Windows.Forms.TextBox evidenceLocationTextBox;
        private System.Windows.Forms.Label planForSolutionLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.ListView completeQuestionSetListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}