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
            var accMan = new AccountManagement();
            var notifications = new Notifications();
            var user = accMan.Login(usernameTextBox.Text, passwordTextBox.Text);
            if (user != null)
            {
                if (user.Permissions)
                {
                    var Landingpage = new Oversight(user);
                    Landingpage.Show();
                    notifications.StartProcess(user);
                    Close();
                }
                else
                {
                    var Landingpage = new Business(user);
                    Landingpage.Show();
                    notifications.StartProcess(user);
                    Close();
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