using System;
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
                    Landingpage.Show();
                    this.Close();
                }
                else
                {
                    Business Landingpage = new Business(user);
                    Landingpage.Show();
                    this.Close();

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
