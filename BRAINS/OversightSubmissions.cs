using System;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class Oversight
    {
        private void RefreshSubmissionsList()
        {
            submittedStenerListView.Items.Clear();
            questionSets = stenerManagement.GetSubmittedQuestionSets();
            foreach (var qSet in questionSets)
            {
                string[] row =
                {
                    qSet.UniqueID.ToString(), qSet.AssignedDepartment.ToString(), qSet.Questions.Count.ToString(),
                    qSet.DueDate.ToString("MM/dd/yyyy"),
                    qSet.SubmittedDate.Equals(new DateTime()) ? "" : qSet.SubmittedDate.ToString("MM/dd/yyyy"),
                    qSet.Status
                };

                var listItem = new ListViewItem(row);
                submittedStenerListView.Items.Add(listItem);
            }
        }

        private void RefreshSubmissionsButton_Click(object sender, EventArgs e)
        {
            RefreshSubmissionsList();
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            if (submittedStenerListView.SelectedItems.Count > 0)
            {
                var qSetId = Convert.ToInt32(submittedStenerListView.SelectedItems[0].SubItems[0].Text);
                var qSet = stenerManagement.GetQuestionSet(qSetId);

                qSet.Status = "APPROVED";

                RefreshSubmissionsList();
                submissionStatusLabel.Text = "Approved STENER!";
            }
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            if (submittedStenerListView.SelectedItems.Count > 0)
            {
                var qSetId = Convert.ToInt32(submittedStenerListView.SelectedItems[0].SubItems[0].Text);
                var qSet = stenerManagement.GetQuestionSet(qSetId);
                if (violationCheckbox.Checked)
                {
                    if (severityDropdown.SelectedItem != null && violationDescriptionTextBox.Text != "")
                    {
                        var violation = new Violation
                        {
                            DepartmentUid = qSet.AssignedDepartment,
                            Severity = Convert.ToInt32(severityDropdown.SelectedItem),
                            StenerSetUid = qSetId,
                            ViolationDescription = violationDescriptionTextBox.Text,
                            ViolationDate = DateTime.Now
                        };

                        violationManagement.AddViolation(violation);
                    }
                    else
                    {
                        submissionStatusLabel.Text =
                            "Error: Ensure all violation fields are filled in for a violation!";
                        return;
                    }
                }

                qSet.Status = "REJECTED";

                RefreshSubmissionsList();
                submissionStatusLabel.Text = "Rejected STENER!";
            }
        }

        private void PreviewStenerButton_Click(object sender, EventArgs e)
        {
            if (submittedStenerListView.SelectedItems.Count > 0)
            {
                var qSetId = Convert.ToInt32(submittedStenerListView.SelectedItems[0].SubItems[0].Text);
                var preview = new OversightPreview(qSetId);
                preview.Show();
            }
        }
    }
}