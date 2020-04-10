using System;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class NewUser : Form
    {
        private readonly DepartmentManagement departmentManagement;

        public NewUser()
        {
            InitializeComponent();
            departmentManagement = new DepartmentManagement();

            departmentAssign.Items.Clear();
            var departmentNames = departmentManagement.GetDepartmentNames();
            foreach (var dept in departmentNames) departmentAssign.Items.Add(dept);
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
        }

        private void NewUserOK_Click(object sender, EventArgs e)
        {
            var newUser = new AccountManagement();
            var department = new DepartmentManagement();
            var departmentByName = department.GetDepartmentByName(departmentAssign.Text);
            if (newUsername.Text == "" || newUserPassword.Text == "" || confirmNewUserPassword.Text == "" ||
                departmentAssign.Text == "" || permissionsBox.Text == "" || confirmNewUserPassword.Text == "")
            {
                MessageBox.Show("You must have a value for ALL fields");
            }
            else if (newUserPassword.Text != "" || confirmNewUserPassword.Text != "")
            {
                if (confirmNewUserPassword.Text == newUserPassword.Text)
                {
                    newUser.CreateUser(newUsername.Text, newUserPassword.Text, departmentByName.DepartmentUid,
                        Convert.ToInt32(permissionsBox.Text));
                    Hide();
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match, Please re-enter");
            }
        }

        private void newUserCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}