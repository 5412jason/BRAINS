using System;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class Oversight
    {
        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (accountList.SelectedItems.Count > 0)
            {
                var uuid = Convert.ToInt32(accountList.SelectedItems[0].Text);
                var passwordChange = new OversightPasswordChange(uuid);
                passwordChange.Show();
            }
            else
            {
                accountManagementStatusStrip.Text = "Please select a user to change their password";
            }
        }

        private void OversightAccountsAddUser_Click(object sender, EventArgs e)
        {
            var newUser = new NewUser();
            newUser.Show();
        }

        public void RefreshButtonAccounts_Click(object sender, EventArgs e)
        {
            RefreshAccountList();
        }

        private void OversightAccountsRemoveUser_Click(object sender, EventArgs e)
        {
            if (accountList.SelectedItems.Count > 0)
            {
                var uuid = Convert.ToInt32(accountList.SelectedItems[0].Text);
                accountManagement.FindUser(uuid);
                var deleteUser = new AccountManagement();
                deleteUser.DeleteUser(uuid);
                RefreshAccountList();
            }
            else
            {
                accountManagementStatusStrip.Text = "Please select a user";
            }
        }

        public void RefreshAccountList()
        {
            accountList.Items.Clear();
            usersData = accountManagement.GetUserList();
            foreach (var user in usersData)
            {
                string[] row =
                    {user.Uuid.ToString(), user.Username, user.DepartmentUid.ToString(), user.Permissions.ToString()};

                var listItem = new ListViewItem(row);
                accountList.Items.Add(listItem);
            }
        }
    }
}