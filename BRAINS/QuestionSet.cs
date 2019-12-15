using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAINS
{
    public class QuestionSet
    {
        private int uniqueID;
        private int questionCount;
        private List<Question> questions;
        private int assignedDepartment;
        private string category;
        private DateTime dueDate;
        private DateTime submittedDate;
        private string status;
        private int priority;

        public int UniqueID { get => uniqueID; set => uniqueID = value; }
        public int QuestionCount { get => questionCount; set => questionCount = value; }
        public int AssignedDepartment { get => assignedDepartment; set => assignedDepartment = value; }
        public string Category { get => category; set => category = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public DateTime SubmittedDate { get => submittedDate; set => submittedDate = value; }
        public string Status { get => status; set => status = value; }
        public int Priority { get => priority; set => priority = value; }
        internal List<Question> Questions { get => questions; set => questions = value; }

        public QuestionSet()
        {
            questions = new List<Question>();
        }
    }
}
