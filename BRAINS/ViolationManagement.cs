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
            if(violate == null)
            {
                return new List<Violation>();
            }
            return violate;
        }
        public void RemoveViolation(int violationUID)
        {
            SqlManager.RemoveViolation(violationUID);
        }
        public bool AddViolation(Violation violation)
        {
            violation.ViolationUID = this.GetNextViolationID();
            bool result = SqlManager.AddViolation(violation);
            return result;
        }
        public List<Violation> GetDepartmentViolations(int departmentID)
        {
            List<Violation> violations = SqlManager.GetDepartmentViolations(departmentID);
            if(violations == null)
            {
                return new List<Violation>();
            }
            return violations;
        }
        private int GetNextViolationID()
        {
            List<Violation> violations = SqlManager.GetAllViolations();
            int nextID = 0;
            if (violations != null)
            {
                foreach (Violation violation in violations)
                {
                    if (violation.ViolationUID > nextID)
                    {
                        nextID = violation.ViolationUID;
                    }
                }
            }

            nextID = nextID + 1;

            return nextID;
        }
    }
}
