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
    public partial class OversightAccountsUsernameChange : Form
    {
        private int uuid;

        public OversightAccountsUsernameChange()
        {
            InitializeComponent();
        }

        public OversightAccountsUsernameChange(int uuid)
        {
            InitializeComponent();
            this.uuid = uuid;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void OversightAccountsUsernameChange_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void oversightAccountsUsernameChangeOK_Click(object sender, EventArgs e)
        {
            string currentUsername = SqlManager.FindUser(uuid).Username;

            if (currentUsername == OversightAccountsUsernameChangeCurrentTextbox.Text);
            {
                UserData userUpdatedPassword = SqlManager.FindUser(uuid).Password;
                userUpdatedPassword.Username = OversightAccountsUsernameChangeNewTextbox.Text;
                userUpdatedPassword.UUID = uuid;
                userUpdatedPassword.DepartmentName = SqlManager.FindUser(uuid).DepartmentName;
                userUpdatedPassword.DepartmentUID = SqlManager.FindUser(uuid).DepartmentUID;

                SqlManager.ChangeUser(userUpdatedPassword);
            }

            this.Close();
        }
    }
}
