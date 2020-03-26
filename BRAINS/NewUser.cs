using System;
using System.Collections.Generic;
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
            if (newUsername.Text == "" || newUserPassword.Text == "" || confirmNewUserPassword.Text == "" || departmentAssign.Text == "" || permissionsBox.Text == ""  || confirmNewUserPassword.Text == "")
            {
                MessageBox.Show("You must have a value for ALL fields");

            }
            else if (newUserPassword.Text != "" || confirmNewUserPassword.Text != "")
            { 
                    if(confirmNewUserPassword.Text == newUserPassword.Text)
                    {
                        newUser.createUser(newUsername.Text, newUserPassword.Text, confirmNewUserPassword.Text, newdepartment.DepartmentUID, Convert.ToInt32(permissionsBox.Text));
                        this.Hide();
                    }
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
