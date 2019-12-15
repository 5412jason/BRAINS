using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class Oversight : Form
    {
        public Oversight()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void accountsTab_Click(object sender, EventArgs e)
        {

        }

        private void addDepartmentButton_Click(object sender, EventArgs e)
        {
            OversightAddDepartment form = new OversightAddDepartment();
            form.Show();
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            OversightDepartmentAddUser form = new OversightDepartmentAddUser();
            form.Show();
        }

        private void changeUsernameButton_Click(object sender, EventArgs e)
        {
            OversightAccountsUsernameChange form = new OversightAccountsUsernameChange(Int32.Parse(accountList.SelectedItems.ToString()));
            form.Show();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            //Verify Line 51 is working.
            OversightPasswordChange form = new OversightPasswordChange(Int32.Parse(accountList.SelectedItems.ToString()));
            form.Show();
        }

        private void OversightAccountsAddUser_Click(object sender, EventArgs e)
        {
            NewUser form = new NewUser();
            form.Show();
        }

        private void violationRefreshButton_Click(object sender, EventArgs e)
        {

        }
        private void editViolation_Click(object sender, EventArgs e)
        {
            
        }
        private void removeViolation_Click(object sender, EventArgs e)
        {

        }

    }
}
