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
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        #region QUESTION_SETS
        static public List<QuestionSet> GetAllQuestionSets()
        {
            try
            {
                DataTable questionsDataTable = QueryDatabase("SELECT * FROM StenerTable");

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
                    qSet.Category = row.Field<string>("Category");
                    qSet.Priority = row.Field<int>("Priority");
                    //broken
                    qSet.DueDate = Convert.ToDateTime(row["DueDate"].ToString());
                    qSet.Status = row.Field<String>("Status");
                    //qSet.SubmittedDate = row.Field<DateTime>("SubmittedDate");

                    qSet.Questions = new List<Question>();

                    DataTable questionTable = QueryDatabase("SELECT * FROM StenerTable");

                    foreach(DataRow questionRow in questionTable.Rows)
                    {
                        Question question = new Question();
                        question.QuestionID = questionRow.Field<int>("QuestionUID");
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
            catch(Exception e)
            {
                Console.WriteLine(e);
                return new List<QuestionSet>();
            }
        }

        static public bool ModifyQuestionSet(QuestionSet updatedQSet)
        {
            string queryString =
                "UPDATE StenerTable SET DepartmentUID = " + updatedQSet.AssignedDepartment.ToString()
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
                "INSERT INTO StenerTable SET"
                + " DepartmentUID = " + questionSet.AssignedDepartment.ToString()
                + " Priority = " + questionSet.Priority.ToString()
                + " DueDate = " + questionSet.DueDate.ToString()
                + " Status = " + questionSet.Status
                + " Category = " + questionSet.Category
                + " StenerSetUID = " + questionSet.UniqueID.ToString()
                + " QuestionUID = " + question.QuestionID.ToString()
                + " Question = " + question.QuestionText
                + " Answer = " + question.Answer
                + " LocationEvidence = " + question.EvidenceLocation;

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }

        static public bool RemoveQuestion(int questionUID)
        {
            string queryString = "DELETE FROM StenerTable WHERE QuestionUID = " + questionUID.ToString();

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }

        static public bool ModifyQuestion(Question question)
        {
            string queryString =
                "UPDATE StenerTable SET "
                    + " Question = " + question.QuestionText
                    + " Answer = " + question.Answer
                    + " LocationEvidence = " + question.EvidenceLocation
                    + " WHERE QuestionUID = " + question.QuestionID.ToString();

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }

        static public bool CreateNewQuestionSet(QuestionSet questionSet)
        {
            foreach (Question question in questionSet.Questions)
            {
                string queryString =
                    "INSERT INTO StenerTable(QuestionUID, StenerSetUID, DepartmentUID, Category, Question, Answer, LocationEvidence, Priority, DueDate, Status, Compliance, PlanForSolution, Violated)"
                    + "VALUES('" + question.QuestionID.ToString() + "','" + questionSet.UniqueID.ToString() + "','"
                    + questionSet.AssignedDepartment.ToString() + "','" + questionSet.Category + "','"
                    + question.QuestionText + "','" + question.Answer + "','" + question.EvidenceLocation + "','"
                    + questionSet.Priority.ToString() + "','" + questionSet.DueDate.ToString() + "','"
                    + questionSet.Status + "','" + question.Compliance.ToString() + "','"
                    + question.PlanForSolution + "','" + question.Violated.ToString() + "')";

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
            string queryString = "DELETE FROM StenerTable WHERE StenerSetUID = " + questionSetUID.ToString();

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

        #region VIOLATION_STUFF
        static public List<Violation> GetAllViolations()
        {
            string query = "SELECT * FROM ViolationTable";
            
            DataTable violationTable = QueryDatabase(query);

            List<Violation> violations = new List<Violation>();

            if(violationTable.Rows.Count != 0)
            {
                foreach (DataRow row in violationTable.Rows)
                {
                    Violation violation = new Violation();
                    violation.ViolationUID = row.Field<int>("ViolationUID");
                    violation.DepartmentUID = row.Field<int>("DepartmentUID");
                    violation.StenerSetUID = row.Field<int>("StenerSetUID");
                    violation.Severity = row.Field<int>("Severity");
                    violation.ViolationDate = row.Field<DateTime>("ViolatedDate");
                    violation.ViolationDescription = row.Field<string>("ViolationDescription");

                    violations.Add(violation);
                }
                return violations;
            }
            else
            {
                return null;
            }
        }

        static public List<Violation> GetDepartmentViolations(int departmentUID)
        {
            string query = "SELECT * FROM ViolationTable WHERE DepartmentUID = " + departmentUID.ToString();

            DataTable violationTable = QueryDatabase(query);

            List<Violation> violations = new List<Violation>();

            if (violationTable.Rows.Count != 0)
            {
                foreach (DataRow row in violationTable.Rows)
                {
                    Violation violation = new Violation();
                    violation.DepartmentUID = row.Field<int>("DepartmentUID");
                    violation.StenerSetUID = row.Field<int>("StenerSetUID");
                    violation.Severity = row.Field<int>("Severity");
                    violation.ViolationDate = row.Field<DateTime>("ViolatedDate");
                    violation.ViolationDescription = row.Field<string>("ViolationDescription");

                    violations.Add(violation);
                }
                return violations;
            }
            else
            {
                return null;
            }
        }

        static public bool AddViolation(Violation violation)
        {
            string query =
                "INSERT INTO ViolationTable SET"
                + " ViolaitonUID = " + violation.ViolationUID.ToString()
                + " DepartmentUID = " + violation.DepartmentUID.ToString()
                + " StenerSetUID = " + violation.StenerSetUID.ToString()
                + " Severity = " + violation.Severity.ToString()
                + " ViolatedDate = " + violation.ViolationDate.ToString()
                + " ViolatedDescription = " + violation.ViolationDescription;

            bool passed = NonQueryDatabase(query);

            return passed;
        }

        static public bool RemoveViolation(int violationUID)
        {
            string query =
                "DELETE FROM ViolationTable WHERE ViolationUID = " + violationUID.ToString();

            bool passed = NonQueryDatabase(query);

            return passed;
        }
        #endregion
    }
}