using System;

namespace BRAINS
{
    class Violation
    {
        private string violationDescription;
        private int severity;
        private int departmentUID;
        private DateTime violationDate;
        private int stenerSetUID;
        private int violationUID;

        public string ViolationDescription  { get => violationDescription; set => violationDescription = value; }
        public int Severity { get => severity; set => severity = value; } 
        public int DepartmentUID { get => departmentUID; set => departmentUID = value; }
        public DateTime ViolationDate { get => violationDate; set => violationDate = value; }
        public int ViolationUID { get => violationUID; set => violationUID = value; }
        public int StenerSetUID { get => stenerSetUID; set => stenerSetUID = value; }
    }
}
