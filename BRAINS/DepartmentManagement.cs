using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAINS
{
    class DepartmentManagement
    { 
        public List<UserData> getAllUsersInDepartment(int departmentUID)
        {
            List<UserData> allUsers = SqlManager.GetAllUsers(departmentUID);
            return allUsers;
        }

        public List<Department> getDepartments()
        {
            List<Department> allDepartments = SqlManager.GetAllDepartments();
            return allDepartments;
        }

        public void addDepartment(Department newDepartment)
        {
            SqlManager.AddDepartment(newDepartment);
        }

        public void addDeparmentUser(UserData user)
        {
            SqlManager.ModifyUser(user);
        }

        //Assigned value to be updated with each new highlight of an entry in Department panel of Oversight UI.
        SqlManager mySqlManager = new SqlManager();

        public List<UserData> getAllUsersInDepartment(int departmentUID)
        {
            List<UserData> allUsers = mySqlManager.GetAllUsers(departmentUID);
            return allUsers;
        }

        public List<Department> getDepartments()
        {
            List<Department> allDepartments = mySqlManager.GetAllDepartments();
            return allDepartments;
        }

        public void addDepartment(Department newDepartment)
        {
            mySqlManager.AddDepartment(newDepartment);
        }

        public void addDeparmentUser(UserData user)
        {
            mySqlManager.ModifyUser(user);
        }

        public void removeDeparment(int departmentUID)
        {
            mySqlManager.RemoveDepartment(departmentUID);
        }

        public void removeDeparmentUser(UserData user)
        {
            mySqlManager.ModifyUser(user);
        }
    }
}
