namespace BRAINS
{
    public class Department
    {
        private int departmentUID;
        private string name;
        private bool admin;
        public int DepartmentUID { get => departmentUID; set => departmentUID = value; }
        public string Name { get => name; set => name = value; }
        public bool Admin { get => admin; set => admin = value; }
    }
}
