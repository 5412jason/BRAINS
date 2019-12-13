using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAINS
{
    class Department
    {
        private int departmentUID;
        private string name;
        private List<UserData> users;

        public int DepartmentUID { get => departmentUID; set => departmentUID = value; }
        public string Name { get => name; set => name = value; }
        public List<UserData> Users { get => users; set => users = value; }

    }
}
