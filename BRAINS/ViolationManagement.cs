using System.Collections.Generic;

namespace BRAINS
{
    internal class ViolationManagement
    {
        public List<Violation> GetViolationList()
        {
            var violate = SqlManager.GetAllViolations();
            if (violate == null) return new List<Violation>();
            return violate;
        }

        public bool AddViolation(Violation violation)
        {
            violation.ViolationUid = GetNextViolationID();
            var result = SqlManager.AddViolation(violation);
            return result;
        }

        public List<Violation> GetDepartmentViolations(int departmentId)
        {
            var violations = SqlManager.GetDepartmentViolations(departmentId);
            if (violations == null) return new List<Violation>();
            return violations;
        }

        private int GetNextViolationID()
        {
            var violations = SqlManager.GetAllViolations();
            var nextId = 0;
            if (violations != null)
                foreach (var violation in violations)
                    if (violation.ViolationUid > nextId)
                        nextId = violation.ViolationUid;

            nextId += 1;

            return nextId;
        }
    }
}