using System;
using System.Collections.Generic;

namespace BRAINS
{
    internal class StenerManagement
    {
        public List<QuestionSet> GetStenerList()
        {
            var steners = SqlManager.GetAllQuestionSets(-1, "");

            return steners;
        }

        public QuestionSet GetQuestionSet(int id)
        {
            var qSet = SqlManager.FindQuestionSet(id);
            return qSet;
        }

        public List<QuestionSet> GetQuestionSetsForDepartment(int departmentID)
        {
            var qSets = SqlManager.GetAllQuestionSets(departmentID, "");
            return qSets;
        }

        public List<QuestionSet> GetSubmittedQuestionSets()
        {
            var qSets = SqlManager.GetAllQuestionSets(-1, "SUBMITTED");

            return qSets;
        }

        public bool ModifyQuestion(string qText, int qSetID, int qID)
        {
            var qSet = SqlManager.FindQuestionSet(qSetID);
            if (qSet != null)
            {
                foreach (var q in qSet.Questions)
                    if (q.QuestionId == qID)
                    {
                        q.QuestionText = qText;
                        var passed = SqlManager.ModifyQuestion(q, qSetID);
                        qSet.Status = "UPDATED";
                        SqlManager.ModifyQuestionSet(qSet);

                        return passed;
                    }

                return false;
            }

            return false;
        }

        public bool SubmitQuestionSet(QuestionSet qSet)
        {
            var result = SqlManager.ModifyQuestionSet(qSet);

            if (result)
                foreach (var q in qSet.Questions)
                    SqlManager.ModifyQuestion(q, qSet.UniqueID);

            return result;
        }

        public bool AddQuestion(string qText, int qSetID)
        {
            var qSet = SqlManager.FindQuestionSet(qSetID);
            if (qSet != null)
            {
                var question = new Question();
                question.QuestionText = qText;
                question.QuestionId = GetNextQuestionId(qSet);
                qSet.Questions.Add(question);
                qSet.Status = "UPDATED";
                var passed = SqlManager.AddQuestion(qSet, question);
                SqlManager.ModifyQuestionSet(qSet);
                return passed;
            }

            return false;
        }

        public void DeleteQuestionSet(int id)
        {
            SqlManager.RemoveQuestionSet(id);
        }

        public void DeleteQuestion(int qSetId, int qId)
        {
            SqlManager.RemoveQuestion(qId, qSetId);
        }

        public bool CreateQuestionSet(int departmentId, int priority, DateTime dueDate, string question,
            string category)
        {
            var qSet = new QuestionSet
            {
                AssignedDepartment = departmentId,
                Priority = priority,
                DueDate = dueDate,
                Category = category,
                UniqueID = GetNextQuestionSetId(),
                Status = "CREATED"
            };

            var newQuestion = new Question
            {
                QuestionText = question,
                QuestionId = GetNextQuestionId(qSet)
            };
            qSet.Questions.Add(newQuestion);

            var result = SqlManager.CreateNewQuestionSet(qSet);

            return result;
        }

        private static int GetNextQuestionSetId()
        {
            var qSets = SqlManager.GetAllQuestionSets(-1, "");
            var nextId = 0;
            if (qSets != null)
                foreach (var qSet in qSets)
                    if (qSet.UniqueID > nextId)
                        nextId = qSet.UniqueID;
            nextId += 1;

            return nextId;
        }

        private static int GetNextQuestionId(QuestionSet qSet)
        {
            var nextId = 0;

            if (qSet.Questions != null)
                foreach (var q in qSet.Questions)
                    if (q.QuestionId > nextId)
                        nextId = q.QuestionId;

            nextId += 1;

            return nextId;
        }
    }
}