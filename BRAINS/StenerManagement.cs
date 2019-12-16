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

        public QuestionSet GetQuestionSet(int id)
        {
            QuestionSet qSet = SqlManager.FindQuestionSet(id);
            return qSet;
        }

        public bool ModifyQuestion(string qText, int qSetID, int qID)
        {
            QuestionSet qSet = SqlManager.FindQuestionSet(qSetID);
            if(qSet != null)
            {
                foreach(Question q in qSet.Questions)
                {
                    if(q.QuestionID == qID)
                    {
                        q.QuestionText = qText;
                        bool passed = SqlManager.ModifyQuestion(q, qSetID);
                        qSet.Status = "UPDATED";
                        SqlManager.ModifyQuestionSet(qSet);

                        return passed;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool AddQuestion(string qText, int qSetID)
        {
            QuestionSet qSet = SqlManager.FindQuestionSet(qSetID);
            if(qSet != null)
            {
                Question question = new Question();
                question.QuestionText = qText;
                question.QuestionID = GetNextQuestionID(qSet);
                qSet.Questions.Add(question);
                qSet.Status = "UPDATED";
                bool passed = SqlManager.AddQuestion(qSet, question);
                SqlManager.ModifyQuestionSet(qSet);
                return passed;
            }
            else
            {
                return false;
            }
        }

        public void DeleteQuesitonSet(int id)
        {
            SqlManager.RemoveQuestionSet(id);
        }
        public void DeleteQuestion(int qSetID, int qID)
        {
            SqlManager.RemoveQuestion(qID, qSetID);
        }

        public bool CreateQuestionSet(int departmentID, int priority, DateTime dueDate, string question, string category)
        {
            QuestionSet qSet = new QuestionSet();

            //TODO: Getassigned department ID from a string parmaneter

            qSet.AssignedDepartment = departmentID;
            qSet.Priority = priority;
            qSet.DueDate = dueDate;
            qSet.Category = category;
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