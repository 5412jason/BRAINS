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
            try
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
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
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
                    qSet.Priority = row.Field<int>("Priority");
                    qSet.Violated = Convert.ToBoolean(row.Field<int>("Violated"));

                    if (row.Field<string>("Category") != null)
                    {
                        qSet.Category = row.Field<string>("Category");
                    }
                    if (row.Field<string>("DueDate") != null)
                    {
                        //test
                        string test = row.Field<string>("DueDate");
                        qSet.DueDate = DateTime.ParseExact(row.Field<string>("DueDate"), "MM/dd/yyyy hh:mm:ss tt", null);
                    }
                    if (row.Field<string>("SubmittedDate") != null)
                    {
                        string test = row.Field<string>("SubmittedDate");
                        qSet.SubmittedDate = DateTime.ParseExact(row.Field<string>("SubmittedDate"), "MM/dd/yyyy hh:mm:ss tt", null);
                    }
                    if (row.Field<string>("Status") != null)
                    {
                        qSet.Status = row.Field<string>("Status");
                    }

                    qSet.Questions = new List<Question>();

                    DataTable questionTable = QueryDatabase("SELECT * FROM StenerTable WHERE StenerSetUID = " + qSet.UniqueID.ToString());

                    foreach(DataRow questionRow in questionTable.Rows)
                    {
                        Question question = new Question();
                        question.QuestionID = questionRow.Field<int>("QuestionUID");
                        question.Compliance = Convert.ToBoolean(questionRow.Field<int>("Compliance"));

                        if (questionRow.Field<string>("Question") != null)
                        {
                            question.QuestionText = questionRow.Field<string>("Question");
                        }
                        if (questionRow.Field<string>("Answer") != null)
                        {
                            question.Answer = questionRow.Field<string>("Answer");
                        }
                        if (questionRow.Field<string>("LocationEvidence") != null)
                        {
                            question.EvidenceLocation = questionRow.Field<string>("LocationEvidence");
                        }
                        if (questionRow.Field<string>("PlanForSolution") != null)
                        {
                            question.PlanForSolution = questionRow.Field<string>("PlanForSolution");
                        }
                        
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

        static public List<QuestionSet> GetAllDepartmentQuestionSets(int departmentID)
        {
            try
            {
                DataTable questionsDataTable = QueryDatabase("SELECT * FROM StenerTable WHERE DepartmentUID = " + departmentID.ToString());

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
                    qSet.Priority = row.Field<int>("Priority");
                    qSet.Violated = Convert.ToBoolean(row.Field<int>("Violated"));

                    if (row.Field<string>("Category") != null)
                    {
                        qSet.Category = row.Field<string>("Category");
                    }
                    if (row.Field<string>("DueDate") != null)
                    {
                        //test
                        string test = row.Field<string>("DueDate");
                        qSet.DueDate = DateTime.ParseExact(row.Field<string>("DueDate"), "MM/dd/yyyy hh:mm:ss tt", null);
                    }
                    if (row.Field<string>("SubmittedDate") != null)
                    {
                        string test = row.Field<string>("SubmittedDate");
                        qSet.SubmittedDate = DateTime.ParseExact(row.Field<string>("SubmittedDate"), "MM/dd/yyyy hh:mm:ss tt", null);
                    }
                    if (row.Field<string>("Status") != null)
                    {
                        qSet.Status = row.Field<string>("Status");
                    }

                    qSet.Questions = new List<Question>();

                    DataTable questionTable = QueryDatabase("SELECT * FROM StenerTable WHERE StenerSetUID = " + qSet.UniqueID.ToString());

                    foreach (DataRow questionRow in questionTable.Rows)
                    {
                        Question question = new Question();
                        question.QuestionID = questionRow.Field<int>("QuestionUID");
                        question.Compliance = Convert.ToBoolean(questionRow.Field<int>("Compliance"));

                        if (questionRow.Field<string>("Question") != null)
                        {
                            question.QuestionText = questionRow.Field<string>("Question");
                        }
                        if (questionRow.Field<string>("Answer") != null)
                        {
                            question.Answer = questionRow.Field<string>("Answer");
                        }
                        if (questionRow.Field<string>("LocationEvidence") != null)
                        {
                            question.EvidenceLocation = questionRow.Field<string>("LocationEvidence");
                        }
                        if (questionRow.Field<string>("PlanForSolution") != null)
                        {
                            question.PlanForSolution = questionRow.Field<string>("PlanForSolution");
                        }

                        qSet.Questions.Add(question);
                    }

                    questionSets.Add(qSet);
                }

                return questionSets;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<QuestionSet>();
            }
        }

        static public List<QuestionSet> GetAllQuestionSetsOfStatus(string status)
        {
            try
            {
                DataTable questionsDataTable = QueryDatabase("SELECT * FROM StenerTable WHERE Status = " + status);

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
                    qSet.Priority = row.Field<int>("Priority");
                    qSet.Violated = Convert.ToBoolean(row.Field<int>("Violated"));

                    if (row.Field<string>("Category") != null)
                    {
                        qSet.Category = row.Field<string>("Category");
                    }
                    if (row.Field<string>("DueDate") != null)
                    {
                        //test
                        string test = row.Field<string>("DueDate");
                        qSet.DueDate = DateTime.ParseExact(row.Field<string>("DueDate"), "MM/dd/yyyy hh:mm:ss tt", null);
                    }
                    if (row.Field<string>("SubmittedDate") != null)
                    {
                        string test = row.Field<string>("SubmittedDate");
                        qSet.SubmittedDate = DateTime.ParseExact(row.Field<string>("SubmittedDate"), "MM/dd/yyyy hh:mm:ss tt", null);
                    }
                    if (row.Field<string>("Status") != null)
                    {
                        qSet.Status = row.Field<string>("Status");
                    }

                    qSet.Questions = new List<Question>();

                    DataTable questionTable = QueryDatabase("SELECT * FROM StenerTable WHERE StenerSetUID = " + qSet.UniqueID.ToString());

                    foreach (DataRow questionRow in questionTable.Rows)
                    {
                        Question question = new Question();
                        question.QuestionID = questionRow.Field<int>("QuestionUID");
                        question.Compliance = Convert.ToBoolean(questionRow.Field<int>("Compliance"));

                        if (questionRow.Field<string>("Question") != null)
                        {
                            question.QuestionText = questionRow.Field<string>("Question");
                        }
                        if (questionRow.Field<string>("Answer") != null)
                        {
                            question.Answer = questionRow.Field<string>("Answer");
                        }
                        if (questionRow.Field<string>("LocationEvidence") != null)
                        {
                            question.EvidenceLocation = questionRow.Field<string>("LocationEvidence");
                        }
                        if (questionRow.Field<string>("PlanForSolution") != null)
                        {
                            question.PlanForSolution = questionRow.Field<string>("PlanForSolution");
                        }

                        qSet.Questions.Add(question);
                    }

                    questionSets.Add(qSet);
                }

                return questionSets;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new List<QuestionSet>();
            }
        }

        static public QuestionSet FindQuestionSet(int qSetID)
        {
            string query = "SELECT * FROM StenerTable WHERE StenerSetUID = " + qSetID.ToString();

            DataTable dataTable = QueryDatabase(query);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                QuestionSet qSet = new QuestionSet();
                qSet.UniqueID = row.Field<int>("StenerSetUID");
                qSet.AssignedDepartment = row.Field<int>("DepartmentUID");
                qSet.Priority = row.Field<int>("Priority");
                qSet.Violated = Convert.ToBoolean(row.Field<int>("Violated"));

                if (row.Field<string>("Category") != null)
                {
                    qSet.Category = row.Field<string>("Category");
                }
                if (row.Field<string>("DueDate") != null)
                {
                    qSet.DueDate = DateTime.ParseExact(row.Field<string>("DueDate"), "MM/dd/yyyy hh:mm:ss tt", null);
                }
                if (row.Field<string>("SubmittedDate") != null)
                {
                    qSet.SubmittedDate = DateTime.ParseExact(row.Field<string>("SubmittedDate"), "MM/dd/yyyy hh:mm:ss tt", null);
                }
                if (row.Field<string>("Status") != null)
                {
                    qSet.Status = row.Field<string>("Status");
                }

                foreach (DataRow questionRow in dataTable.Rows)
                {
                    Question question = new Question();
                    question.QuestionID = questionRow.Field<int>("QuestionUID");
                    question.Compliance = Convert.ToBoolean(questionRow.Field<int>("Compliance"));

                    if (questionRow.Field<string>("Question") != null)
                    {
                        question.QuestionText = questionRow.Field<string>("Question");
                    }
                    if (questionRow.Field<string>("Answer") != null)
                    {
                        question.Answer = questionRow.Field<string>("Answer");
                    }
                    if (questionRow.Field<string>("LocationEvidence") != null)
                    {
                        question.EvidenceLocation = questionRow.Field<string>("LocationEvidence");
                    }
                    if (questionRow.Field<string>("PlanForSolution") != null)
                    {
                        question.PlanForSolution = questionRow.Field<string>("PlanForSolution");
                    }

                    qSet.Questions.Add(question);
                }

                return qSet;
            }

            return null;
        }

        static public bool ModifyQuestionSet(QuestionSet updatedQSet)
        {
            string queryString =
                "UPDATE StenerTable SET DepartmentUID = '" + updatedQSet.AssignedDepartment.ToString()
                + "', Priority = '" + updatedQSet.Priority.ToString()
                + "', DueDate = '" + updatedQSet.DueDate.ToString("MM/dd/yyyy hh:mm:ss tt")
                + "', SubmittedDate = '" + updatedQSet.SubmittedDate.ToString("MM/dd/yyyy hh:mm:ss tt")
                + "', Status = '" + updatedQSet.Status
                + "', Category = '" + updatedQSet.Category
                + "' WHERE StenerSetUID = '" + updatedQSet.UniqueID.ToString() + "'";

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }

        static public bool AddQuestion(QuestionSet questionSet, Question question)
        {
            string queryString =
                "INSERT INTO StenerTable(QuestionUID, StenerSetUID, DepartmentUID, Category, Question, Answer, LocationEvidence, Priority, DueDate, Status, Compliance, PlanForSolution, SubmittedDate, Violated)"
                + "VALUES('" + question.QuestionID.ToString() + "','" + questionSet.UniqueID.ToString() + "','"
                + questionSet.AssignedDepartment.ToString() + "','" + questionSet.Category + "','"
                + question.QuestionText + "','" + question.Answer + "','" + question.EvidenceLocation + "','"
                + questionSet.Priority.ToString() + "','" + questionSet.DueDate.ToString("MM/dd/yyyy hh:mm:ss tt") + "','"
                + questionSet.Status + "','" + Convert.ToInt32(question.Compliance) + "','"
                + question.PlanForSolution + "','" + questionSet.SubmittedDate.ToString("MM/dd/yyyy hh:mm:ss tt") + "','" + Convert.ToInt32(questionSet.Violated) + "')";

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }

        static public bool RemoveQuestion(int questionUID, int qSetUID)
        {
            string queryString = "DELETE FROM StenerTable WHERE QuestionUID = '" + questionUID.ToString() + "' AND StenerSetUID = '" + qSetUID.ToString() + "'";

            bool passed = NonQueryDatabase(queryString);

            return passed;
        }

        static public bool ModifyQuestion(Question question, int qSetID)
        {
            string queryString =
                "UPDATE StenerTable SET "
                    + " Question = '" + question.QuestionText
                    + "', Answer = '" + question.Answer
                    + "', LocationEvidence = '" + question.EvidenceLocation
                    + "', PlanForSolution = '" + question.PlanForSolution
                    + "', Compliance = '" + Convert.ToInt32(question.Compliance).ToString()
                    + "' WHERE QuestionUID = '" + question.QuestionID.ToString() + "' AND StenerSetUID = '" + qSetID.ToString() + "'";

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
                    + questionSet.Priority.ToString() + "','" + questionSet.DueDate.ToString("MM/dd/yyyy hh:mm:ss tt") + "','"
                    + questionSet.Status + "','" + Convert.ToInt32(question.Compliance) + "','"
                    + question.PlanForSolution + "','" + Convert.ToInt32(questionSet.Violated) + "')";

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
                user.DepartmentUID = row.Field<int>("DepartmentUID");
                user.Permissions = Convert.ToBoolean(row.Field<int>("Permissions"));

                if (row.Field<string>("Username") != null)
                {
                    user.Username = row.Field<string>("Username");
                }
                if (row.Field<string>("Password") != null)
                {
                    user.Password = row.Field<string>("Password");
                }
                
                users.Add(user);
            }
            return users;
        }

        static public UserData FindUser(int userID)
        {
            DataTable dataTable = QueryDatabase("SELECT * FROM LoginTable WHERE UsernameUID = " + userID.ToString());

            if(dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                UserData user = new UserData();
                user.UUID = row.Field<int>("UsernameUID");
                user.DepartmentUID = row.Field<int>("DepartmentUID");
                user.Permissions = Convert.ToBoolean(row.Field<int>("Permissions"));

                if (row.Field<string>("Username") != null)
                {
                    user.Username = row.Field<string>("Username");
                }
                if (row.Field<string>("Password") != null)
                {
                    user.Password = row.Field<string>("Password");
                }

                return user;
            }
            else
            {
                return null;
            }
        }
        
        static public UserData AuthenticateCredentials(string username, string password)
        {
            DataTable userTable = QueryDatabase("SELECT * FROM LoginTable WHERE Username = '" + username + "' AND Password = '" + password + "'");
            
            if (userTable.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow row = userTable.Rows[0];
                UserData user = new UserData();
                user.UUID = row.Field<int>("UsernameUID");
                user.DepartmentUID = row.Field<int>("DepartmentUID");
                user.Permissions = Convert.ToBoolean(row.Field<int>("Permissions"));

                if (row.Field<string>("Username") != null)
                {
                    user.Username = row.Field<string>("Username");
                }
                if (row.Field<string>("Password") != null)
                {
                    user.Password = row.Field<string>("Password");
                }

                return user;
            }
        }

        static public bool ModifyUser(UserData user)
        {
            string query =
                           "UPDATE LoginTable SET"
                           + " Username = '" + user.Username
                           + "', DepartmentUID = '" + user.DepartmentUID.ToString()
                           + "', Permissions = '" + Convert.ToInt32(user.Permissions).ToString()
                           + "', Password = '" + user.Password
                           + "' WHERE UsernameUID = '" + user.UUID.ToString() + "'";

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
            string query = "INSERT INTO LoginTable(Username, DepartmentUID, Permissions, Password, UsernameUID)VALUES('"
                + user.Username + "','" + user.DepartmentUID.ToString() + "','"
                + Convert.ToInt32(user.Permissions) + "','" + user.Password + "','"
                + user.UUID.ToString() + "')";

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

                   if (row.Field<string>("ViolatedDate") != null)
                    {
                        //test
                        string test = row.Field<string>("ViolatedDate");
                        violation.ViolationDate = DateTime.ParseExact(row.Field<string>("ViolatedDate"), "MM/dd/yyyy", null);
                    }
                    if (row.Field<string>("ViolationDescription") != null)
                    {
                        violation.ViolationDescription = row.Field<string>("ViolationDescription");
                    }

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

                    violation.ViolationUID = row.Field<int>("ViolationUID");
                    violation.DepartmentUID = row.Field<int>("DepartmentUID");
                    violation.StenerSetUID = row.Field<int>("StenerSetUID");
                    violation.Severity = row.Field<int>("Severity");

                    if (row.Field<string>("ViolatedDate") != null)
                    {
                        violation.ViolationDate = DateTime.ParseExact(row.Field<string>("ViolatedDate"), "yyyy-MM-dd", null);
                    }
                    if (row.Field<string>("ViolationDescription") != null)
                    {
                        violation.ViolationDescription = row.Field<string>("ViolationDescription");
                    }

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
            string query = "INSERT INTO ViolationTable(ViolationUID, DepratrmentUID, StenerSetUID, Severity, ViolatedDate, ViolatedDescription)VALUES("
                + violation.ViolationUID.ToString() + "','" + violation.DepartmentUID.ToString() + "','"
                + violation.StenerSetUID.ToString() + "','" + violation.Severity.ToString() + "','"
                + violation.ViolationDate.ToString() + "','" + violation.ViolationDescription + "')";

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

        #region DEPARTMENTS
        static public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();

            string query = "SELECT * FROM Departments";
            DataTable dataTable = QueryDatabase(query);

            foreach(DataRow row in dataTable.Rows)
            {
                Department department = new Department();

                department.DepartmentUID = row.Field<int>("DepartmentUID");
                department.Admin = Convert.ToBoolean(row.Field<int>("Administrator"));

                if (row.Field<string>("DepartmentName") != null)
                {
                    department.Name = row.Field<string>("DepartmentName");
                }

                departments.Add(department);
            }

            return departments;
        }

        static public bool RemoveDepartment(int departmentUID)
        {
            string query = "DELETE FROM Departments WHERE DepartmentUID = " + departmentUID.ToString();

            bool passed = NonQueryDatabase(query);
            if(passed == true)
            {
                List<UserData> users = GetUsersInDepartment(departmentUID);
                foreach(UserData user in users)
                {
                    user.DepartmentUID = 0;
                    ModifyUser(user);
                }
                return passed;
            }
            else
            {
                return passed;
            }
        }
        
        static public bool AddDepartment(Department department)
        {
            string query = "INSERT INTO Departments(DepartmentUID, DepartmentName, Administrator)VALUES('"
                + department.DepartmentUID.ToString() + "','" + department.Name + "','" + Convert.ToInt32(department.Admin) + "')";

            bool passed = NonQueryDatabase(query);

            return passed;
        }

        static public List<UserData> GetUsersInDepartment(int departmentID)
        {
            string query = "SELECT * FROM LoginTable WHERE DepartmentUID = " + departmentID.ToString();

            List<UserData> users = new List<UserData>();
            DataTable dataTable = QueryDatabase(query);

            if(dataTable.Rows.Count > 0)
            {
                foreach(DataRow row in dataTable.Rows)
                {
                    UserData user = new UserData();

                    user.UUID = row.Field<int>("UsernameUID");
                    user.DepartmentUID = row.Field<int>("DepartmentUID");
                    user.Permissions = Convert.ToBoolean(row.Field<int>("Permissions"));

                    if (row.Field<string>("Username") != null)
                    {
                        user.Username = row.Field<string>("Username");
                    }
                    if (row.Field<string>("Password") != null)
                    {
                        user.Password = row.Field<string>("Password");
                    }

                    users.Add(user);
                }
            }

            return users;
        }

        static public Department FindDepartment(int departmentID)
        {
            string query = "SELECT * FROM Departments WHERE DepartmentUID = " + departmentID.ToString();

            DataTable dataTable = QueryDatabase(query);
            
            if(dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                Department department = new Department();

                department.DepartmentUID = row.Field<int>("DepartmentUID");
                department.Admin = Convert.ToBoolean(row.Field<int>("Administrator"));

                if (row.Field<string>("DepartmentName") != null)
                {
                    department.Name = row.Field<string>("DepartmentName");
                }

                return department;
            }
            else
            {
                return null;
            }
        }

        static public Department FindDepartmentByName(string name)
        {
            string query = "SELECT * FROM Departments WHERE DepartmentName = '" + name + "'";

            DataTable dataTable = QueryDatabase(query);

            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];

                Department department = new Department();

                department.DepartmentUID = row.Field<int>("DepartmentUID");
                department.Admin = Convert.ToBoolean(row.Field<int>("Administrator"));

                if (row.Field<string>("DepartmentName") != null)
                {
                    department.Name = row.Field<string>("DepartmentName");
                }

                return department;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}