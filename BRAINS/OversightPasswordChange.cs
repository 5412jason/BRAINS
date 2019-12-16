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

       private void oversightPasswordChangeDialogOK_Click(object sender, EventArgs e)
        {
            AccountManagement newPassword = new AccountManagement();

            newPassword.changePassword(OversightPasswordChangeNewTextBox.Text, userID);
            if (OversightPasswordChangeNewTextBox.Text == confirmPassword.Text)
            {
                MessageBox.Show("Password changed");

                this.Hide();
            }
            else
            MessageBox.Show("Passwords do not match, Please re-enter");

        }

        private void oversightPasswordChangeDialogCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
