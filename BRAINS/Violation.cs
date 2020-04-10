using System;

namespace BRAINS
{
    public class Violation
    {
        public string ViolationDescription { get; set; }

        public int Severity { get; set; }

        public int DepartmentUid { get; set; }

        public DateTime ViolationDate { get; set; }

        public int ViolationUid { get; set; }

        public int StenerSetUid { get; set; }
    }
}