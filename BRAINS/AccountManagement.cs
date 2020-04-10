using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BRAINS
{
    internal class AccountManagement
    {
        public void ChangePassword(string password, int uuid)
        {
            var user = SqlManager.FindUser(uuid);
            user.Password = ComputeSha256Hash(password);
            SqlManager.ModifyUser(user);
        }

        public List<UserData> GetUserList()
        {
            var usersData = SqlManager.GetAllUsers();

            return usersData;
        }

        public void CreateUser(string username, string password, int department, int permissions)
        {
            var user = new UserData
            {
                Username = username,
                Password = ComputeSha256Hash(password),
                DepartmentUid = department,
                Permissions = Convert.ToBoolean(permissions),
                Uuid = GetNextUserId()
            };
            SqlManager.AddUser(user);
        }

        private static int GetNextUserId()
        {
            var users = SqlManager.GetAllUsers();
            var nextId = 0;
            foreach (var user in users)
                if (user.Uuid > nextId)
                    nextId = user.Uuid;

            return nextId + 1;
        }

        public void DeleteUser(int uuid)
        {
            SqlManager.RemoveUser(uuid);
        }

        public UserData FindUser(int x)
        {
            var tempUserData = SqlManager.FindUser(x);
            return tempUserData;
        }

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

        public UserData Login(string username, string password)
        {
            var user = SqlManager.AuthenticateCredentials(username, ComputeSha256Hash(password));
            return user;
        }
    }
}