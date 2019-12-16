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
    public partial class NewUser : Form
    {
        private UserData newUser;
        public NewUser()
        {
            InitializeComponent();
        }
        public NewUser(UserData user)
        {
            InitializeComponent();
            newUser = user;
        }

        private void NewUser_Load(object sender, EventArgs e)
        {

        }

        private void newUserOK_Click(object sender, EventArgs e)
        {

            AccountManagement newUser = new AccountManagement();
            DepartmentManagement deptartment = new DepartmentManagement();
            Department newdepartment = deptartment.GetDepartmentByName(departmentAssign.Text);
            newUser.createUser(newUsername.Text, newUserPassword.Text, confirmNewUserPassword.Text, newdepartment.DepartmentUID, permissionsBox.Text);
            if (confirmNewUserPassword == newUserPassword)
            {
                 this.Hide();
            }
            else
            MessageBox.Show("Passwords do not match, Please re-enter");
        }

        private void newUserCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
