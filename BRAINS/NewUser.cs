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
        private DepartmentManagement departmentManagement;

        public NewUser()
        {
            InitializeComponent();
            departmentManagement = new DepartmentManagement();

            departmentAssign.Items.Clear();
            List<string> departmentNames = departmentManagement.GetDepartmentNames();
            foreach (string dept in departmentNames)
            {
                departmentAssign.Items.Add(dept);
            }
        }
        public NewUser(UserData user)
        {
            InitializeComponent();
            newUser = user;
            departmentManagement = new DepartmentManagement();


        }

        private void NewUser_Load(object sender, EventArgs e)
        {

        }
        
        private void newUserOK_Click(object sender, EventArgs e)
        {

            AccountManagement newUser = new AccountManagement();
            DepartmentManagement department = new DepartmentManagement();
            Department newdepartment = department.GetDepartmentByName(departmentAssign.Text);

            if (confirmNewUserPassword.Text == newUserPassword.Text)
            {
                newUser.createUser(newUsername.Text, newUserPassword.Text, confirmNewUserPassword.Text, newdepartment.DepartmentUID, Convert.ToInt32(permissionsBox.Text));
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
