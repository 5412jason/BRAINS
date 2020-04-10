using System.Collections.Generic;

namespace BRAINS
{
    public class DepartmentManagement
    {
        public List<string> GetDepartmentNames()
        {
            var departments = SqlManager.GetAllDepartments();
            var names = new List<string>();

            foreach (var dept in departments) names.Add(dept.Name);
            return names;
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var department = SqlManager.FindDepartmentByName(departmentName);

            return department;
        }

        public List<UserData> getAllUsersInDepartment(int departmentUID)
        {
            var allUsers = SqlManager.GetUsersInDepartment(departmentUID);
            return allUsers;
            //return null;
        }

        private int getNextDepartmentID()
        {
            var departments = SqlManager.GetAllDepartments();
            var nextID = 0;
            foreach (var Department in departments)
                if (Department.DepartmentUid > nextID)
                    nextID = Department.DepartmentUid;
            return nextID + 1;
        }

        public List<Department> getDepartments()
        {
            var allDepartments = SqlManager.GetAllDepartments();
            return allDepartments;
            //return null;
        }

        public void addDepartment(string dpmtName, int dpmtPermissions)
        {
            var dpmt = new Department();
            dpmt.DepartmentUid = getNextDepartmentID();
            dpmt.Name = dpmtName;


            if (dpmtPermissions == 1)
                dpmt.Admin = true;
            else
                dpmt.Admin = false;
            SqlManager.AddDepartment(dpmt);
        }

        public void addDeparmentUser(int user, int dpmt)
        {
            var id = SqlManager.FindUser(user);
            id.DepartmentUid = dpmt;
            SqlManager.ModifyUser(id);
        }

        public void removeDeparment(int departmentUID)
        {
            var dpmt = new Department();
            var dpmtToDelete = dpmt.DepartmentUid;
            dpmt.DepartmentUid = departmentUID;
            dpmtToDelete = dpmt.DepartmentUid;
            SqlManager.RemoveDepartment(dpmtToDelete);
        }

        public void removeDeparmentUser(int user, int dpmt)
        {
            var id = SqlManager.FindUser(user);
            id.DepartmentUid = 0;
            SqlManager.ModifyUser(id);
        }
    }
}