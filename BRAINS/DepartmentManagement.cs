using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAINS
{
    class DepartmentManagement
    {
        //Assigned value to be updated with each new highlight of an entry in Department panel of Oversight UI.
        private int currentDepartmentUUID;
        SqlManager mySqlManager = new SqlManager();

        public List<UserData> getAllUsersInDepartment()
        {
            List<UserData> allUsers = mySqlManager.getAllUsers(currentDepartmentUUID);
            return allUsers;
        }

        public List<Department> getDepartments()
        {
            List<Department> allDepartments = mySqlManager.getAllDepartments();
            return allDepartments;
        }

        public void addDepartment(Department newDepartment)
        {
            mySqlManager.addDepartment(NewDepartment);
        }

        public void addDeparmentUser(Department newUser)
        {
            mySqlManager.get
        }

        public void removeDeparment()
        {

        }

        public void removeDeparmentUser()
        {

        }

        public void refreshDepartment(int deptUUID)
        {

        }
    }
}
