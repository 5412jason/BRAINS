using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;


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

        #region QUESTION_SETS
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

        static public bool ModifyQuestionSet(QuestionSet updatedQSet)
        {
            string queryString =
                "UPDATE StenerDatabase SET DepartmentUID = " + updatedQSet.AssignedDepartment.ToString()
                + " Priority = " + updatedQSet.Priority.ToString()
                + " DueDate = " + updatedQSet.DueDate.ToString()
                + " Status = " + updatedQSet.Status
                + " Category = " + updatedQSet.Category
                + " WHERE StenerSetUID = " + updatedQSet.UniqueID.ToString();

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }

        static public bool AddQuestion(QuestionSet questionSet, Question question)
        {
            string queryString =
                "INSERT INTO StenerDatabase SET"
                + " DepartmentUID = " + questionSet.AssignedDepartment.ToString()
                + " Priority = " + questionSet.Priority.ToString()
                + " DueDate = " + questionSet.DueDate.ToString()
                + " Status = " + questionSet.Status
                + " Category = " + questionSet.Category
                + " StenerSetUID = " + questionSet.UniqueID.ToString()
                + " QuestionID = " + question.QuestionID.ToString()
                + " Question = " + question.QuestionText
                + " Answer = " + question.Answer
                + " LocationEvidence = " + question.EvidenceLocation;

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }

        static public bool RemoveQuestion(int questionUID)
        {
            string queryString = "DELETE FROM StenerDatabase WHERE QuestionID = " + questionUID.ToString();

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }

        static public bool ModifyQuestion(Question question)
        {
            string queryString =
                "UPDATE StenerDatabase SET "
                    + " Question = " + question.QuestionText
                    + " Answer = " + question.Answer
                    + " LocationEvidence = " + question.EvidenceLocation
                    + " WHERE QuestionID = " + question.QuestionID.ToString();

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }

        static public bool CreateNewQuestionSet(QuestionSet questionSet)
        {
            foreach (Question question in questionSet.Questions)
            {
                string queryString =
                    "INSERT INTO StenerDatabase SET"
                    + " DepartmentUID = " + questionSet.AssignedDepartment.ToString()
                    + " Priority = " + questionSet.Priority.ToString()
                    + " DueDate = " + questionSet.DueDate.ToString()
                    + " Status = " + questionSet.Status
                    + " Category = " + questionSet.Category
                    + " StenerSetUID = " + questionSet.UniqueID.ToString()
                    + " QuestionID = " + question.QuestionID.ToString()
                    + " Question = " + question.QuestionText
                    + " Answer = " + question.Answer
                    + " LocationEvidence = " + question.EvidenceLocation;

                bool passed = NonQueryDatabase(queryString);
                if (passed == false)
                {
                    return false;
                }
            }
            return true;
        }

        static public bool RemoveQuestionSet(int questionSetUID)
        {
            string queryString = "DELETE FROM StenerDatabase WHERE StenerSetUID = " + questionSetUID.ToString();

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }
        #endregion

        #region USER_DATA_STUFF

        static public List<UserData> GetAllUsers()
        {
            DataTable usersTable = QueryDatabase("SELECT * FROM LoginTable");
            List<UserData> users = new List<UserData>();

            foreach (DataRow row in usersTable.Rows)
            {
                UserData user = new UserData();
                user.UUID = row.Field<int>("UsernameUID");
                user.Username = row.Field<string>("Username");
                user.Password = "";
                user.DepartmentUID = row.Field<int>("DepartmentUID");
                user.DepartmentName = row.Field<string>("Department");
                user.Permissions = row.Field<bool>("Permissions");
                
                users.Add(user);
            }
            return users;
        }
        
        static public UserData AuthenticateCredentials(string username, string password)
        {
            DataTable userTable = QueryDatabase(
                "SELECT * FROM LoginTable WHERE Username = " + username + " AND Password = " + password
                );
            
            if (userTable.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = userTable.Rows[0];
                UserData user = new UserData();
                user.UUID = row.Field<int>("UsernameUID");
                user.Username = row.Field<string>("Username");
                user.Password = "";
                user.DepartmentUID = row.Field<int>("DepartmentUID");
                user.DepartmentName = row.Field<string>("Department");
                user.Permissions = row.Field<bool>("Permissions");

                return user;
            }
        }


        static public bool ModifyUser(UserData user)
        {
            string query =
                "UPDATE LoginTable SET"
                + " Username = " + user.Username
                + " Department = " + user.DepartmentName
                + " DepartmentUID = " + user.DepartmentUID.ToString()
                + " Permissions = " + user.Permissions
                + " Password = " + user.Password
                + " WHERE UsernameUID = " + user.UUID.ToString();

            bool passed = NonQueryDatabase(query);
            
            return passed;
        }

        static public bool RemoveUser(int uid)
        {
            string query = "DELETE FROM LoginTable WHERE UsernameUID = " + uid.ToString();

            bool passed = NonQueryDatabase(query);

            return passed;
        }

        static public bool AddUser(UserData user)
        {
            string query =
                "INSERT INTO LoginTable SET"
                + " Username = " + user.Username
                + " Department = " + user.DepartmentName
                + " DepartmentUID = " + user.DepartmentUID.ToString()
                + " Permissions = " + user.Permissions
                + " Password = " + user.Password
                + " UsernameUID = " + user.UUID.ToString();

            bool passed = NonQueryDatabase(query);

            return passed;
        }

        #endregion
    }
}
