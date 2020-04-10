using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BRAINS
{
    public class AccountManagement
    {
        // Used to change the password corresponding to the uuid given
        public void ChangePassword(string password, int uuid)
        {
            var user = SqlManager.FindUser(uuid);
            user.Password = ComputeSha256Hash(password);
            // modify the database
            SqlManager.ModifyUser(user);
        }

        // Used to retrieve a list of all registered users
        public List<UserData> GetUserList()
        {
            // Query the db.
            var usersData = SqlManager.GetAllUsers();
            return usersData;
        }

        // Used to create a new user 
        public void CreateUser(string username, string password, int department, int permissions)
        {
            // set user data attributes
            var user = new UserData
            {
                Username = username,
                Password = ComputeSha256Hash(password),
                DepartmentUid = department,
                Permissions = Convert.ToBoolean(permissions),
                Uuid = GetNextUserId()
            };
            // add user to database
            SqlManager.AddUser(user);
        }

        // Returns the next available user id
        // Used when creating a new user.
        private static int GetNextUserId()
        {
            var users = SqlManager.GetAllUsers();
            var nextId = 0;
            foreach (var user in users)
                if (user.Uuid > nextId)
                    nextId = user.Uuid;

            return nextId + 1;
        }

        // Remove the specified user from the database
        public void DeleteUser(int uuid)
        {
            SqlManager.RemoveUser(uuid);
        }

        // find a specific user
        public UserData FindUser(int x)
        {
            var tempUserData = SqlManager.FindUser(x);
            return tempUserData;
        }

        // Compute the Sha256 hash value of the specified password string
        public string ComputeSha256Hash(string password)
        {
            // Create a SHA256   
            using (var sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert byte array to a string   
                var builder = new StringBuilder();
                for (var i = 0; i < bytes.Length; i++) builder.Append(bytes[i].ToString("x2"));

                return builder.ToString();
            }
        }
        
        // attempt to authenticate a users username and password with the db.
        public UserData Login(string username, string password)
        {
            var user = SqlManager.AuthenticateCredentials(username, ComputeSha256Hash(password));
            return user;
        }
    }
}