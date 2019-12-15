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

        public void changePassword(string password)
        {
            
        }
        public void createUser()
        {

        }
        public void deleteUser()
        {

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
