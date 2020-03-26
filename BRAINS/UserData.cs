namespace BRAINS
{
    public class UserData
    {
        private int uuid;
        private string username;
        private string password;
        private int departmentUID;
        private bool permissions;

        public int UUID { get => uuid; set => uuid = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int DepartmentUID { get => departmentUID; set => departmentUID = value; }
        public bool Permissions { get => permissions; set => permissions = value; }
    }
}
