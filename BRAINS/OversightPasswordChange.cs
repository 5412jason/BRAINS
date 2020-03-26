using System;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class OversightPasswordChange : Form
    {
        private int userID;
        public OversightPasswordChange()
        {
            InitializeComponent();
        }
        public OversightPasswordChange(int ID)
        {
            InitializeComponent();
            userID = ID;
        }

        private void OversightPasswordChange_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void oversightPasswordChangeDialogCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void changePassword_Click(object sender, EventArgs e)
        {
            AccountManagement newPassword = new AccountManagement();

            newPassword.changePassword(OversightPasswordChangeNewTextBox.Text, userID);
            if (OversightPasswordChangeNewTextBox.Text == confirmPassword.Text)
            {
                MessageBox.Show("Password changed");
                this.Close();
            }
            else
                MessageBox.Show("Passwords do not match, Please re-enter");

        }
    }
}
