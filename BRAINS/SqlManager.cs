using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BRAINS
{
    static class SqlManager
    {

        static private DataTable QueryDatabase(string query)
        {
            DataTable dataTable = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["Brains"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connString))
            {

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dataTable.Load(reader);

                    con.Close();
                }

            }
            return dataTable;
        }

        static private bool NonQueryDatabase(string query)
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["Brains"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connString))
                {

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();

                        cmd.ExecuteNonQuery();

                        con.Close();
                    }

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        static public List<QuestionSet> GetAllQuestionSets()
        {
            try
            {
                DataTable questionsDataTable = QueryDatabase("SELECT * FROM QuestionTable");

                List<DataRow> qSetRows = new List<DataRow>();
                List<int> qSetIds = new List<int>();

                foreach (DataRow row in questionsDataTable.Rows)
                {
                    if (qSetIds.Contains(row.Field<int>("StenerSetUID")) == false)
                    {
                        qSetIds.Add(row.Field<int>("StenerSetUID"));
                        qSetRows.Add(row);
                    }
                }

                List<QuestionSet> questionSets = new List<QuestionSet>();
                foreach (DataRow row in qSetRows)
                {
                    QuestionSet qSet = new QuestionSet();
                    qSet.UniqueID = row.Field<int>("StenerSetUID");
                    qSet.AssignedDepartment = row.Field<int>("DepartmentUID");
                    qSet.Category = row.Field<string>("Categroy");
                    qSet.Priority = row.Field<int>("Priority");
                    qSet.DueDate = row.Field<DateTime>("DueDate");
                    qSet.Status = row.Field<String>("Status");
                    //qSet.SubmittedDate = row.Field<DateTime>("SubmittedDate");

                    qSet.Questions = new List<Question>();

                    DataTable questionTable = QueryDatabase("SELECT * FROM QuestionTable");

                    foreach(DataRow questionRow in questionTable.Rows)
                    {
                        Question question = new Question();
                        question.QuestionID = questionRow.Field<int>("QuestionID");
                        question.QuestionText = questionRow.Field<string>("Question");
                        question.Answer = questionRow.Field<string>("Answer");
                        question.EvidenceLocation = questionRow.Field<string>("LocationEvidence");
                        //question.Compliance = questionRow.Field<bool>("Compliance");
                        //question.SolutionPlan = questionRow.Field<string>("PlanForSolution");
                        //violated?
                        qSet.Questions.Add(question);
                    }

                    questionSets.Add(qSet);
                }

                return questionSets;
            }
            catch
            {
                return new List<QuestionSet>();
            }
        }

        static public QuestionSet FindQuestionSet()
        {

            return new QuestionSet();
        }

        static public bool ModifyQuestionSet(QuestionSet updatedQSet)
        {
            string queryString =
                "UPDATE StenerDatabase SET DepartmentUID = " + updatedQSet.AssignedDepartment.ToString()
                + " Priority = " + updatedQSet.Priority.ToString()
                + " DueDate = " + updatedQSet.DueDate.ToString()
                + " Status = " + updatedQSet.Status
                + " Category = " + updatedQSet.Category
                + " Where StenerSetUID = " + updatedQSet.UniqueID.ToString();

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }

        static public bool AddQuestion(QuestionSet questionSet, Question question)
        {
            return false;
        }

        static public bool RemoveQuestion(int questionUID)
        {
            return false;
        }

        static public bool ModifyQuestion(Question question)
        {
            return false;
        }

        static public bool AddQuestionSet(QuestionSet questionSet)
        {
            return true;
        }

        static public bool RemoveQuestionSet(int questionSetUID)
        {
            return true;
        }

    }
}
