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
            this.BusniessViolations = new System.Windows.Forms.ListView();
            this.refreshButton = new System.Windows.Forms.Button();
            this.businessTabControl.SuspendLayout();
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
            this.businessTabControl.Size = new System.Drawing.Size(800, 450);
            this.businessTabControl.TabIndex = 0;
            // 
            // completeStenerTab
            // 
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
            this.violationTab.Controls.Add(this.refreshButton);
            this.violationTab.Controls.Add(this.BusniessViolations);
            this.violationTab.Location = new System.Drawing.Point(4, 22);
            this.violationTab.Name = "violationTab";
            this.violationTab.Padding = new System.Windows.Forms.Padding(3);
            this.violationTab.Size = new System.Drawing.Size(792, 424);
            this.violationTab.TabIndex = 1;
            this.violationTab.Text = "Violations";
            this.violationTab.UseVisualStyleBackColor = true;
            // 
            // BusniessViolations
            // 
            this.BusniessViolations.HideSelection = false;
            this.BusniessViolations.Location = new System.Drawing.Point(-4, 28);
            this.BusniessViolations.Name = "BusniessViolations";
            this.BusniessViolations.Size = new System.Drawing.Size(615, 396);
            this.BusniessViolations.TabIndex = 0;
            this.BusniessViolations.UseCompatibleStateImageBehavior = false;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(648, 28);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(107, 32);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Business
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.businessTabControl);
            this.Name = "Business";
            this.Text = "Business";
            this.businessTabControl.ResumeLayout(false);
            this.violationTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl businessTabControl;
        private System.Windows.Forms.TabPage completeStenerTab;
        private System.Windows.Forms.TabPage violationTab;
        private System.Windows.Forms.ListView BusniessViolations;
        private System.Windows.Forms.Button refreshButton;
    }
}