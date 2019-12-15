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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            AccountManagement accMan = new AccountManagement();
            UserData user = accMan.Login(usernameTextBox.Text, passwordTextBox.Text);
            if (user != null)
            {
                
                if (user.Permissions == true)
                {

                    Oversight Landingpage = new Oversight(user);
                    this.Hide();
                    Landingpage.Show();
                }
                else
                {
                    Business Landingpage = new Business(user);
                    this.Hide();
                    Landingpage.Show();

                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
               
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
