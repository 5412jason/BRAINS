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
            this.CompleteStenerDataGridView = new System.Windows.Forms.DataGridView();
            this.businessTabControl.SuspendLayout();
            this.completeStenerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompleteStenerDataGridView)).BeginInit();
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
            this.businessTabControl.Size = new System.Drawing.Size(800, 450);
            this.businessTabControl.TabIndex = 0;
            // 
            // completeStenerTab
            // 
            this.completeStenerTab.Controls.Add(this.CompleteStenerDataGridView);
            this.completeStenerTab.Location = new System.Drawing.Point(4, 22);
            this.completeStenerTab.Name = "completeStenerTab";
            this.completeStenerTab.Padding = new System.Windows.Forms.Padding(3);
            this.completeStenerTab.Size = new System.Drawing.Size(792, 424);
            this.completeStenerTab.TabIndex = 0;
            this.completeStenerTab.Text = "Complete STENERs";
            this.completeStenerTab.UseVisualStyleBackColor = true;
            // 
            // violationTab
            // 
            this.violationTab.Location = new System.Drawing.Point(4, 22);
            this.violationTab.Name = "violationTab";
            this.violationTab.Padding = new System.Windows.Forms.Padding(3);
            this.violationTab.Size = new System.Drawing.Size(792, 424);
            this.violationTab.TabIndex = 1;
            this.violationTab.Text = "Violations";
            this.violationTab.UseVisualStyleBackColor = true;
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
            // Business
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.businessTabControl);
            this.Name = "Business";
            this.Text = "Business";
            this.Load += new System.EventHandler(this.Business_Load);
            this.businessTabControl.ResumeLayout(false);
            this.completeStenerTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompleteStenerDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl businessTabControl;
        private System.Windows.Forms.TabPage completeStenerTab;
        private System.Windows.Forms.TabPage violationTab;
        private System.Windows.Forms.DataGridView CompleteStenerDataGridView;
    }
}