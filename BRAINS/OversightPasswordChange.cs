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
        private UserData userToModify;

        public OversightPasswordChange()
        {
            InitializeComponent();
        }
        public OversightPasswordChange(UserData user)
        {
            InitializeComponent();
            userToModify = user;
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

            if (OversightPasswordChangeNewTextBox.Text == confirmPassword.Text)
            {
               /* userToModify.Password = */ SqlManager.ModifyUser(userToModify);
            }

        }
        
        private void oversightPasswordChangeDialogCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
