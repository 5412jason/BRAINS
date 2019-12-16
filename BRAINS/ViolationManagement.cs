using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAINS
{
    class ViolationManagement
    {
        public List<Violation> GetViolationList()
        {
            List<Violation> violate = SqlManager.GetAllViolations();

            return violate;
        }
        public void RemoveViolation(int violationUID)
        {
            SqlManager.FindQuestionSet(violationUID);
            SqlManager.RemoveViolation(violationUID);
        }
        public void viewDepartmentViolations()
        {

        }
        public void viewAllViolations()
        {

        }
        public void editViolation()
        {

        }
    }
}
