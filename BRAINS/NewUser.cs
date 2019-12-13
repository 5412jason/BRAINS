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
        public NewUser()
        {
            InitializeComponent();
        }

        private void NewUser_Load(object sender, EventArgs e)
        {

        }

        private void newUserOK_Click(object sender, EventArgs e)
        {
            UserData newUserObj = new UserData();

            if (NewUserPasswordTextbox.Text == NewUserPasswordConfirmTextbox.Text)
            {
                newUserObj.Username = NewUserUsernameTextbox.Text;
                newUserObj.Password = NewUserPasswordTextbox.Text;
                newUserObj.DepartmentName = NewUserDepartmentComboBox.Text;
            }
            
            this.Close();
        }

        private void newUserCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
