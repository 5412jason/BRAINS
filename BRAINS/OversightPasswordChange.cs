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
        private int uuid;

        public OversightPasswordChange()
        {
            InitializeComponent();
        }

        public OversightPasswordChange(int uuid)
        {
            InitializeComponent();
            this.uuid = uuid;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void oversightPasswordChangeDialogOK_Click(object sender, EventArgs e)
        {
            int currentPasswordHash = SqlManager.FindUser(uuid).Password;

            if(ComputeSha256Hash(currentPasswordHash) == ComputeSha256Hash(OversightPasswordChangeCurrentTextBox.Text))
            {
                UserData userUpdatedPassword = new userUpdatedPassword;
                userUpdatedPassword.Username = SqlManager.FindUser(uuid).Username;
                userUpdatedPassword.UUID = uuid;
                userUpdatedPassword.DepartmentName = SqlManager.FindUser(uuid).DepartmentName;
                userUpdatedPassword.DepartmentUID = SqlManager.FindUser(uuid).DepartmentUID;

                SqlManager.ChangeUser(userUpdatedPassword);
            }

            this.Close();
        }

        private void oversightPasswordChangeDialogCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
