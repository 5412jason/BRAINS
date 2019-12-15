using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAINS
{
    class StenerManagement
    {
        public StenerManagement() { }

        public List<QuestionSet> GetStenerList()
        {
            List<QuestionSet> steners = SqlManager.GetAllQuestionSets();

            return steners;
        }

        public void DeleteQuesitonSet(int id)
        {
            SqlManager.RemoveQuestionSet(id);
        }

        public bool CreateQuestionSet(int departmentID, int priority, DateTime dueDate, string question, string category)
        {
            QuestionSet qSet = new QuestionSet();

            //TODO: Getassigned department ID from a string parmaneter

            qSet.AssignedDepartment = departmentID;
            qSet.Priority = priority;
            qSet.DueDate = dueDate;
            qSet.UniqueID = GetNextQuestionSetID();
            qSet.Status = "CREATED";

            Question newQuestion = new Question();
            newQuestion.QuestionText = question;
            newQuestion.QuestionID = GetNextQuestionID(qSet);
            qSet.Questions.Add(newQuestion);

            bool result = SqlManager.CreateNewQuestionSet(qSet);

            return result;
        }

        private int GetNextQuestionSetID()
        {
            List<QuestionSet> qSets = SqlManager.GetAllQuestionSets();
            int nextID = 0;
            foreach(QuestionSet qSet in qSets)
            {
                if(qSet.UniqueID > nextID)
                {
                    nextID = qSet.UniqueID;
                }
            }

            nextID = nextID + 1;

            return nextID;
        }

        private int GetNextQuestionID(QuestionSet qSet)
        {
            int nextID = 0;

            if (qSet.Questions != null)
            {
                foreach (Question q in qSet.Questions)
                {
                    if (q.QuestionID > nextID)
                    {
                        nextID = q.QuestionID;
                    }
                }
            }

            nextID = nextID + 1;

            return nextID;
        }
    }
}