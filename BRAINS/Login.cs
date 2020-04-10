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
        // Upon login button click
        private void loginButton_Click(object sender, EventArgs e)
        {

            // Initialize Objects
            var accMan = new AccountManagement();
            var notifications = new Notifications();
            var user = accMan.Login(usernameTextBox.Text, passwordTextBox.Text);

            // If user exists
            if (user != null)
            {
                // If user is admin
                if (user.Permissions)
                {
                    var Landingpage = new Oversight(user);
                    Landingpage.Show();
                    notifications.StartProcess(user);
                    //Close();
                }

                // If user is business user
                else
                {
                    var Landingpage = new Business(user);
                    Landingpage.Show();
                    notifications.StartProcess(user);
                    //Close();
                }
            }

            // Else invalid login and password message
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