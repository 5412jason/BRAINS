using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAINS
{
    class DepartmentManagement
    { 
        public List<String> GetDepartmentNames()
        {
            List<Department> departments = SqlManager.GetAllDepartments();
            List<string> names = new List<string>();

            foreach(Department dept in departments)
            {
                names.Add(dept.Name);
            }
            return names;
        }

        public Department GetDepartmentByName(string departmentName)
        {
            Department department = SqlManager.FindDepartmentByName(departmentName);

            return department;
        }

        public List<UserData> getAllUsersInDepartment(int departmentUID)
        {
            //List<UserData> allUsers = SqlManager.GetAllUsersInDepartment(departmentUID);
            //return allUsers;
            return null;
        }

        public List<Department> getDepartments()
        {
            //List<Department> allDepartments = SqlManager.GetAllDepartments();
            //return allDepartments;
            return null;

        }

        public void addDepartment(Department newDepartment)
        {
            //SqlManager.AddDepartment(newDepartment);

        }

        public void addDeparmentUser(UserData user)
        {
            SqlManager.ModifyUser(user);
        }

        public void removeDeparment(int departmentUID)
        {
            //SqlManager.RemoveDepartment(departmentUID);
        }

        public void removeDeparmentUser(UserData user)
        {
            SqlManager.ModifyUser(user);
        }
    }
    
}
