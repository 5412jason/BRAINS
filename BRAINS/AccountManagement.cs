using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace BRAINS
{
    class AccountManagement
    {

        public void changePassword(string password, int UUID)
        {
            UserData user = SqlManager.FindUser(UUID);
            user.Password = ComputeSha256Hash(password);
            SqlManager.ModifyUser(user);
        }
        public List<UserData> GetUserList()
        {
            List<UserData> usersData = SqlManager.GetAllUsers();

            return usersData;
        }
        public void createUser(string username, string password, string confirmPassword, int department, int permissions)
        {
            UserData user = new UserData();
            user.Username = username;
            user.Password = ComputeSha256Hash(password);
            user.DepartmentUID = department;
            user.Permissions = Convert.ToBoolean(permissions);
            user.UUID = getNextUserID();
            SqlManager.AddUser(user);
        }
        private int getNextUserID()
        {
            List<UserData> users = SqlManager.GetAllUsers();
            int nextID = 0;
            foreach (UserData user in users)
            {
                if (user.UUID > nextID)
                {
                    nextID = user.UUID;
                }
            }
            return nextID + 1;
        }
        
        public void DeleteUser(int UUID)
        {
            UserData user = SqlManager.FindUser(UUID);
            SqlManager.RemoveUser(UUID);

        }
        public UserData FindUser(int x)
        {
            UserData tempUserData = SqlManager.FindUser(x);
            return tempUserData;
        }
        public string ComputeSha256Hash(string password)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public UserData Login(string username, string password)
        {
            UserData user = SqlManager.AuthenticateCredentials(username, ComputeSha256Hash(password));
            return user;
        }
    }
}
