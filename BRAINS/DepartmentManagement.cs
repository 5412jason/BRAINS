using System;
using System.Collections.Generic;

namespace BRAINS
{
    public class DepartmentManagement
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
            List<UserData> allUsers = SqlManager.GetUsersInDepartment(departmentUID);
            return allUsers;
            //return null;
        }

        private int getNextDepartmentID()
        {
            List<Department> departments = SqlManager.GetAllDepartments();
            int nextID = 0;
            foreach (Department Department in departments)
            {
                if (Department.DepartmentUID > nextID)
                {
                    nextID = Department.DepartmentUID;
                }
            }
            return nextID + 1;
        }

        public List<Department> getDepartments()
        {
            List<Department> allDepartments = SqlManager.GetAllDepartments();
            return allDepartments;
            //return null;

        }

        public void addDepartment(string dpmtName, int dpmtPermissions)
        {
            Department dpmt = new Department();
            dpmt.DepartmentUID = getNextDepartmentID();
            dpmt.Name = dpmtName;


            if (dpmtPermissions == 1)
            {
                dpmt.Admin = true;
            }
            else
            {
                dpmt.Admin = false;
            }
            SqlManager.AddDepartment(dpmt);
        }

        public void addDeparmentUser(int user,int dpmt)
        {
            UserData id = SqlManager.FindUser(user);
            id.DepartmentUID = dpmt;
            SqlManager.ModifyUser(id);

        }

        public void removeDeparment(int departmentUID)
        {
            Department dpmt = new Department();
            int dpmtToDelete = dpmt.DepartmentUID;
            dpmt.DepartmentUID = departmentUID;
            dpmtToDelete = dpmt.DepartmentUID;
            SqlManager.RemoveDepartment(dpmtToDelete);
            
        }

        public void removeDeparmentUser(int user, int dpmt)
        {
            UserData id = SqlManager.FindUser(user);
            id.DepartmentUID = 0;
            SqlManager.ModifyUser(id);
        }
    }
    
}
