using System;
using System.Collections.Generic;

namespace BRAINS
{
    public class QuestionSet
    {
        public QuestionSet()
        {
            Questions = new List<Question>();
        }

        public int UniqueID { get; set; }

        public int QuestionCount { get; set; }

        public int AssignedDepartment { get; set; }

        public string Category { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime SubmittedDate { get; set; }

        public string Status { get; set; }

        public int Priority { get; set; }

        internal List<Question> Questions { get; set; }

        public bool Violated { get; set; }
    }
}