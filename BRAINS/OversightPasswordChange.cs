using System;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class OversightPasswordChange : Form
    {
        private readonly int userId;

        public OversightPasswordChange()
        {
            InitializeComponent();
        }

        public OversightPasswordChange(int ID)
        {
            InitializeComponent();
            userId = ID;
        }

        private void OversightPasswordChangeDialogCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangePassword_Click(object sender, EventArgs e)
        {
            var newPassword = new AccountManagement();

            newPassword.ChangePassword(OversightPasswordChangeNewTextBox.Text, userId);
            if (OversightPasswordChangeNewTextBox.Text == confirmPassword.Text)
            {
                MessageBox.Show("Password changed");
                Close();
            }
            else
            {
                MessageBox.Show("Passwords do not match, Please re-enter");
            }
        }
    }
}