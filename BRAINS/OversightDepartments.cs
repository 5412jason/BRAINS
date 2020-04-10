using System;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class Oversight
    {
        private void addDepartmentButton_Click(object sender, EventArgs e)
        {
            var form = new OversightAddDepartment();
            form.Show();
        }

        private void RemoveDepartmentButton_Click(object sender, EventArgs e)
        {
            var form1 = new OversightRemoveDepartment();
            form1.Show();
        }

        private void RefreshButtonDepartments_Click(object sender, EventArgs e)
        {
            RefreshDepartmentManagementList();
        }

        private void RefreshDepartmentManagementList()
        {
            departmentList.Items.Clear();
            memberList.Items.Clear();

            var departmentNames = departmentManagement.getDepartments();

            foreach (var dept in departmentNames)
            {
                string[] row = {dept.DepartmentUid.ToString(), dept.Name};
                var listItem = new ListViewItem(row);
                departmentList.Items.Add(listItem);
            }
        }

        private void DepartmentListItemSelectionChanged(object sender, EventArgs e)
        {
            memberList.Items.Clear();
            if (departmentList.SelectedItems.Count > 0)
            {
                var selectedId = Convert.ToInt32(departmentList.SelectedItems[0].Text);
                usersData = departmentManagement.getAllUsersInDepartment(selectedId);

                if (usersData != null)
                    foreach (var user in usersData)
                        if (user.DepartmentUid == selectedId)
                        {
                            string[] row = {user.Username};
                            var listItem = new ListViewItem(row);
                            memberList.Items.Add(listItem);
                        }
            }
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (allUsersList.SelectedItems.Count > 0 && removeUserText.Text != null)
            {
                var uuid = Convert.ToInt32(allUsersList.SelectedItems[0].SubItems[0].Text);
                var departmentId = Convert.ToInt32(departmentText.Text);
                departmentManagement.addDeparmentUser(uuid, departmentId);
            }
        }

        private void RemoveUserButton_Click(object sender, EventArgs e)
        {
            if (allUsersList.SelectedItems.Count > 0 && removeUserText.Text != null)
            {
                var uuid = Convert.ToInt32(allUsersList.SelectedItems[0].SubItems[0].Text);
                var departmentId = Convert.ToInt32(removeUserText.Text);
                departmentManagement.removeDeparmentUser(uuid, departmentId);
            }
        }

        private void RefreshAllUsers_Click(object sender, EventArgs e)
        {
            RefreshAllUsersList();
        }

        private void RefreshAllUsersList()
        {
            allUsersList.Items.Clear();
            usersData = accountManagement.GetUserList();
            foreach (var user in usersData)
            {
                string[] row = {user.Uuid.ToString(), user.Username, user.DepartmentUid.ToString()};

                var listItem = new ListViewItem(row);
                allUsersList.Items.Add(listItem);
            }
        }
    }
}