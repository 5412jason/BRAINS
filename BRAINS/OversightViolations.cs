using System;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class Oversight
    {
        private void ViolationRefreshButton_Click(object sender, EventArgs e)
        {
            OversightViolationList.Items.Clear();
            violations = violationManagement.GetViolationList();
            foreach (var violate in violations)
            {
                string[] row =
                {
                    violate.ViolationUid.ToString(), violate.StenerSetUid.ToString(), violate.DepartmentUid.ToString(),
                    violate.ViolationDescription, violate.Severity.ToString(),
                    violate.ViolationDate.ToString("MM/dd/yyyy")
                };

                var listItem = new ListViewItem(row);
                OversightViolationList.Items.Add(listItem);
            }
        }

        private void RemoveViolation_Click(object sender, EventArgs e)

        {
            if (OversightViolationList.SelectedItems.Count > 0)
            {
                var violationUid = Convert.ToInt32(OversightViolationList.SelectedItems[0].Text);
                SqlManager.RemoveViolation(violationUid);
            }
            else
            {
                MessageBox.Show("Please select a violation to delete");
            }
        }
    }
}