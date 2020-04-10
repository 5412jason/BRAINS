using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BRAINS
{
    internal static class SqlManager
    {
        private static DataTable QueryDatabase(string query)
        {
            try
            {
                var dataTable = new DataTable();

                var connString = ConfigurationManager.ConnectionStrings["Brains"].ConnectionString;

                using (var con = new SqlConnection(connString))
                {
                    using (var cmd = new SqlCommand(query, con))
                    {
                        con.Open();

                        var reader = cmd.ExecuteReader();

                        dataTable.Load(reader);

                        con.Close();
                    }
                }

                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        // Since we always use try and catch we do not need to have a bool function
        private static bool NonQueryDatabase(string query)
        {
            try
            {
                var connString = ConfigurationManager.ConnectionStrings["Brains"].ConnectionString;

                using (var con = new SqlConnection(connString))
                {
                    using (var cmd = new SqlCommand(query, con))
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

        // If requesting for all departments, pass a negative department id.
        // If requesting for all status, pass and empty status string.
        public static List<QuestionSet> GetAllQuestionSets(int departmentID, string status)
        {
            try
            {
                DataTable questionsDataTable;

                if (departmentID >= 0)
                {
                    if (status == "")
                        questionsDataTable =
                            QueryDatabase("SELECT * FROM StenerTable WHERE DepartmentUid = " + departmentID);
                    else
                        questionsDataTable = QueryDatabase("SELECT * FROM StenerTable WHERE DepartmentUid = "
                                                           + departmentID + " AND "
                                                           + " Status = '" + status + "'");
                }
                else if (status != "")
                {
                    questionsDataTable = QueryDatabase("SELECT * FROM StenerTable WHERE Status = '" + status + "'");
                }
                else
                {
                    questionsDataTable = QueryDatabase("SELECT * FROM StenerTable");
                }

                var qSetRows = new List<DataRow>();
                var qSetIds = new List<int>();

                foreach (DataRow row in questionsDataTable.Rows)
                    if (qSetIds.Contains(row.Field<int>("StenerSetUid")) == false)
                    {
                        qSetIds.Add(row.Field<int>("StenerSetUid"));
                        qSetRows.Add(row);
                    }

                var questionSets = new List<QuestionSet>();
                foreach (var row in qSetRows)
                {
                    var qSet = new QuestionSet
                    {
                        UniqueID = row.Field<int>("StenerSetUid"),
                        AssignedDepartment = row.Field<int>("DepartmentUid"),
                        Priority = row.Field<int>("Priority"),
                        Violated = Convert.ToBoolean(row.Field<int>("Violated"))
                    };

                    if (row.Field<string>("Category") != null) qSet.Category = row.Field<string>("Category");
                    if (row.Field<string>("DueDate") != null)
                    {
                        //test
                        var test = row.Field<string>("DueDate");
                        qSet.DueDate =
                            DateTime.ParseExact(row.Field<string>("DueDate"), "MM/dd/yyyy hh:mm:ss tt", null);
                    }

                    if (row.Field<string>("SubmittedDate") != null)
                    {
                        var test = row.Field<string>("SubmittedDate");
                        qSet.SubmittedDate = DateTime.ParseExact(row.Field<string>("SubmittedDate"),
                            "MM/dd/yyyy hh:mm:ss tt", null);
                    }

                    if (row.Field<string>("Status") != null) qSet.Status = row.Field<string>("Status");

                    qSet.Questions = new List<Question>();

                    var questionTable =
                        QueryDatabase("SELECT * FROM StenerTable WHERE StenerSetUid = " + qSet.UniqueID);

                    foreach (DataRow questionRow in questionTable.Rows)
                    {
                        var question = new Question();
                        question.QuestionId = questionRow.Field<int>("QuestionUID");
                        question.Compliance = Convert.ToBoolean(questionRow.Field<int>("Compliance"));

                        if (questionRow.Field<string>("Question") != null)
                            question.QuestionText = questionRow.Field<string>("Question");
                        if (questionRow.Field<string>("Answer") != null)
                            question.Answer = questionRow.Field<string>("Answer");
                        if (questionRow.Field<string>("LocationEvidence") != null)
                            question.EvidenceLocation = questionRow.Field<string>("LocationEvidence");
                        if (questionRow.Field<string>("PlanForSolution") != null)
                            question.PlanForSolution = questionRow.Field<string>("PlanForSolution");

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

        public static QuestionSet FindQuestionSet(int qSetID)
        {
            var query = "SELECT * FROM StenerTable WHERE StenerSetUid = " + qSetID;

            var dataTable = QueryDatabase(query);
            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];

                var qSet = new QuestionSet
                {
                    UniqueID = row.Field<int>("StenerSetUid"),
                    AssignedDepartment = row.Field<int>("DepartmentUid"),
                    Priority = row.Field<int>("Priority"),
                    Violated = Convert.ToBoolean(row.Field<int>("Violated"))
                };

                if (row.Field<string>("Category") != null) qSet.Category = row.Field<string>("Category");
                if (row.Field<string>("DueDate") != null)
                    qSet.DueDate = DateTime.ParseExact(row.Field<string>("DueDate"), "MM/dd/yyyy hh:mm:ss tt", null);
                if (row.Field<string>("SubmittedDate") != null)
                    qSet.SubmittedDate = DateTime.ParseExact(row.Field<string>("SubmittedDate"),
                        "MM/dd/yyyy hh:mm:ss tt", null);
                if (row.Field<string>("Status") != null) qSet.Status = row.Field<string>("Status");

                foreach (DataRow questionRow in dataTable.Rows)
                {
                    var question = new Question
                    {
                        QuestionId = questionRow.Field<int>("QuestionUID"),
                        Compliance = Convert.ToBoolean(questionRow.Field<int>("Compliance"))
                    };

                    if (questionRow.Field<string>("Question") != null)
                        question.QuestionText = questionRow.Field<string>("Question");
                    if (questionRow.Field<string>("Answer") != null)
                        question.Answer = questionRow.Field<string>("Answer");
                    if (questionRow.Field<string>("LocationEvidence") != null)
                        question.EvidenceLocation = questionRow.Field<string>("LocationEvidence");
                    if (questionRow.Field<string>("PlanForSolution") != null)
                        question.PlanForSolution = questionRow.Field<string>("PlanForSolution");

                    qSet.Questions.Add(question);
                }

                return qSet;
            }

            return null;
        }


        //Is this modifying a table? if so tables should not be modified from code
        //Usually tables are modified in a release then cannot be changed by users
        public static bool ModifyQuestionSet(QuestionSet updatedQSet)
        {
            var queryString =
                "UPDATE StenerTable SET DepartmentUid = '" + updatedQSet.AssignedDepartment
                                                           + "', Priority = '" + updatedQSet.Priority
                                                           + "', DueDate = '" +
                                                           updatedQSet.DueDate.ToString("MM/dd/yyyy hh:mm:ss tt")
                                                           + "', SubmittedDate = '" +
                                                           updatedQSet.SubmittedDate.ToString("MM/dd/yyyy hh:mm:ss tt")
                                                           + "', Status = '" + updatedQSet.Status
                                                           + "', Category = '" + updatedQSet.Category
                                                           + "' WHERE StenerSetUid = '" + updatedQSet.UniqueID + "'";

            var passed = NonQueryDatabase(queryString);

            return passed;
        }

        public static bool AddQuestion(QuestionSet questionSet, Question question)
        {
            var queryString =
                "INSERT INTO StenerTable(QuestionUID, StenerSetUid, DepartmentUid, Category, Question, Answer, LocationEvidence, Priority, DueDate, Status, Compliance, PlanForSolution, SubmittedDate, Violated)"
                + "VALUES('" + question.QuestionId + "','" + questionSet.UniqueID + "','"
                + questionSet.AssignedDepartment + "','" + questionSet.Category + "','"
                + question.QuestionText + "','" + question.Answer + "','" + question.EvidenceLocation + "','"
                + questionSet.Priority + "','" + questionSet.DueDate.ToString("MM/dd/yyyy hh:mm:ss tt") + "','"
                + questionSet.Status + "','" + Convert.ToInt32(question.Compliance) + "','"
                + question.PlanForSolution + "','" + questionSet.SubmittedDate.ToString("MM/dd/yyyy hh:mm:ss tt") +
                "','" + Convert.ToInt32(questionSet.Violated) + "')";

            var passed = NonQueryDatabase(queryString);

            return passed;
        }

        public static bool RemoveQuestion(int questionUID, int qSetUID)
        {
            var queryString = "DELETE FROM StenerTable WHERE QuestionUID = '" + questionUID + "' AND StenerSetUid = '" +
                              qSetUID + "'";

            var passed = NonQueryDatabase(queryString);

            return passed;
        }

        public static bool ModifyQuestion(Question question, int qSetID)
        {
            var queryString =
                "UPDATE StenerTable SET "
                + " Question = '" + question.QuestionText
                + "', Answer = '" + question.Answer
                + "', LocationEvidence = '" + question.EvidenceLocation
                + "', PlanForSolution = '" + question.PlanForSolution
                + "', Compliance = '" + Convert.ToInt32(question.Compliance)
                + "' WHERE QuestionUID = '" + question.QuestionId + "' AND StenerSetUid = '" + qSetID + "'";

            var passed = NonQueryDatabase(queryString);

            return passed;
        }

        public static bool CreateNewQuestionSet(QuestionSet questionSet)
        {
            foreach (var question in questionSet.Questions)
            {
                var queryString =
                    "INSERT INTO StenerTable(QuestionUID, StenerSetUid, DepartmentUid, Category, Question, Answer, LocationEvidence, Priority, DueDate, Status, Compliance, PlanForSolution, Violated)"
                    + "VALUES('" + question.QuestionId + "','" + questionSet.UniqueID + "','"
                    + questionSet.AssignedDepartment + "','" + questionSet.Category + "','"
                    + question.QuestionText + "','" + question.Answer + "','" + question.EvidenceLocation + "','"
                    + questionSet.Priority + "','" + questionSet.DueDate.ToString("MM/dd/yyyy hh:mm:ss tt") + "','"
                    + questionSet.Status + "','" + Convert.ToInt32(question.Compliance) + "','"
                    + question.PlanForSolution + "','" + Convert.ToInt32(questionSet.Violated) + "')";

                var passed = NonQueryDatabase(queryString);
                if (passed == false) return false;
            }

            return true;
        }

        public static bool RemoveQuestionSet(int questionSetUID)
        {
            var queryString = "DELETE FROM StenerTable WHERE StenerSetUid = " + questionSetUID;

            var passed = NonQueryDatabase(queryString);

            return passed;
        }

        #endregion

        #region USER_DATA_STUFF

        public static List<UserData> GetAllUsers()
        {
            var usersTable = QueryDatabase("SELECT * FROM LoginTable");
            var users = new List<UserData>();

            foreach (DataRow row in usersTable.Rows)
            {
                var user = new UserData();
                user.Uuid = row.Field<int>("UsernameUID");
                user.DepartmentUid = row.Field<int>("DepartmentUid");
                user.Permissions = Convert.ToBoolean(row.Field<int>("Permissions"));

                if (row.Field<string>("Username") != null) user.Username = row.Field<string>("Username");
                if (row.Field<string>("Password") != null) user.Password = row.Field<string>("Password");

                users.Add(user);
            }

            return users;
        }

        public static UserData FindUser(int userID)
        {
            var dataTable = QueryDatabase("SELECT * FROM LoginTable WHERE UsernameUID = " + userID);

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];

                var user = new UserData();
                user.Uuid = row.Field<int>("UsernameUID");
                user.DepartmentUid = row.Field<int>("DepartmentUid");
                user.Permissions = Convert.ToBoolean(row.Field<int>("Permissions"));

                if (row.Field<string>("Username") != null) user.Username = row.Field<string>("Username");
                if (row.Field<string>("Password") != null) user.Password = row.Field<string>("Password");

                return user;
            }

            return null;
        }

        public static UserData AuthenticateCredentials(string username, string password)
        {
            var userTable = QueryDatabase("SELECT * FROM LoginTable WHERE Username = '" + username +
                                          "' AND Password = '" + password + "'");

            if (userTable.Rows.Count == 0) return null;

            var row = userTable.Rows[0];
            var user = new UserData();
            user.Uuid = row.Field<int>("UsernameUID");
            user.DepartmentUid = row.Field<int>("DepartmentUid");
            user.Permissions = Convert.ToBoolean(row.Field<int>("Permissions"));

            if (row.Field<string>("Username") != null) user.Username = row.Field<string>("Username");
            if (row.Field<string>("Password") != null) user.Password = row.Field<string>("Password");

            return user;
        }

        public static bool ModifyUser(UserData user)
        {
            var query =
                "UPDATE LoginTable SET"
                + " Username = '" + user.Username
                + "', DepartmentUid = '" + user.DepartmentUid
                + "', Permissions = '" + Convert.ToInt32(user.Permissions)
                + "', Password = '" + user.Password
                + "' WHERE UsernameUID = '" + user.Uuid + "'";

            var passed = NonQueryDatabase(query);

            return passed;
        }

        public static bool RemoveUser(int uid)
        {
            var query = "DELETE FROM LoginTable WHERE UsernameUID = " + uid;

            var passed = NonQueryDatabase(query);

            return passed;
        }

        public static bool AddUser(UserData user)
        {
            var query = "INSERT INTO LoginTable(Username, DepartmentUid, Permissions, Password, UsernameUID)VALUES('"
                        + user.Username + "','" + user.DepartmentUid + "','"
                        + Convert.ToInt32(user.Permissions) + "','" + user.Password + "','"
                        + user.Uuid + "')";

            var passed = NonQueryDatabase(query);

            return passed;
        }

        #endregion

        #region VIOLATION_STUFF

        public static List<Violation> GetAllViolations()
        {
            var query = "SELECT * FROM ViolationTable";

            var violationTable = QueryDatabase(query);

            var violations = new List<Violation>();

            if (violationTable.Rows.Count != 0)
            {
                foreach (DataRow row in violationTable.Rows)
                {
                    var violation = new Violation();

                    violation.ViolationUid = row.Field<int>("ViolationUid");
                    violation.DepartmentUid = row.Field<int>("DepartmentUid");
                    violation.StenerSetUid = row.Field<int>("StenerSetUid");
                    violation.Severity = row.Field<int>("Severity");

                    if (row.Field<string>("ViolatedDate") != null)
                    {
                        //test
                        var test = row.Field<string>("ViolatedDate");
                        violation.ViolationDate = DateTime.ParseExact(row.Field<string>("ViolatedDate"),
                            "MM/dd/yyyy hh:mm:ss tt", null);
                    }

                    if (row.Field<string>("ViolationDescription") != null)
                        violation.ViolationDescription = row.Field<string>("ViolationDescription");

                    violations.Add(violation);
                }

                return violations;
            }

            return null;
        }

        public static List<Violation> GetDepartmentViolations(int departmentUID)
        {
            var query = "SELECT * FROM ViolationTable WHERE DepartmentUid = " + departmentUID;

            var violationTable = QueryDatabase(query);

            var violations = new List<Violation>();

            if (violationTable.Rows.Count != 0)
            {
                foreach (DataRow row in violationTable.Rows)
                {
                    var violation = new Violation();

                    violation.ViolationUid = row.Field<int>("ViolationUid");
                    violation.DepartmentUid = row.Field<int>("DepartmentUid");
                    violation.StenerSetUid = row.Field<int>("StenerSetUid");
                    violation.Severity = row.Field<int>("Severity");

                    if (row.Field<string>("ViolatedDate") != null)
                        violation.ViolationDate = DateTime.ParseExact(row.Field<string>("ViolatedDate"),
                            "MM/dd/yyyy hh:mm:ss tt", null);
                    if (row.Field<string>("ViolationDescription") != null)
                        violation.ViolationDescription = row.Field<string>("ViolationDescription");

                    violations.Add(violation);
                }

                return violations;
            }

            return null;
        }

        public static bool AddViolation(Violation violation)
        {
            var query =
                "INSERT INTO ViolationTable(ViolationUid, DepartmentUid, StenerSetUid, Severity, ViolatedDate, ViolationDescription)VALUES('"
                + violation.ViolationUid + "','" + violation.DepartmentUid + "','"
                + violation.StenerSetUid + "','" + violation.Severity + "','"
                + violation.ViolationDate.ToString("MM/dd/yyyy hh:mm:ss tt") + "','" + violation.ViolationDescription +
                "')";

            var passed = NonQueryDatabase(query);

            return passed;
        }

        public static bool RemoveViolation(int violationUID)
        {
            var query =
                "DELETE FROM ViolationTable WHERE ViolationUid = " + violationUID;

            var passed = NonQueryDatabase(query);

            return passed;
        }

        #endregion

        #region DEPARTMENTS

        public static List<Department> GetAllDepartments()
        {
            var departments = new List<Department>();

            var query = "SELECT * FROM Departments";
            var dataTable = QueryDatabase(query);

            foreach (DataRow row in dataTable.Rows)
            {
                var department = new Department();

                department.DepartmentUid = row.Field<int>("DepartmentUid");
                department.Admin = Convert.ToBoolean(row.Field<int>("Administrator"));

                if (row.Field<string>("DepartmentName") != null) department.Name = row.Field<string>("DepartmentName");

                departments.Add(department);
            }

            return departments;
        }

        public static bool RemoveDepartment(int departmentUID)
        {
            var query = "DELETE FROM Departments WHERE DepartmentUid = " + departmentUID;

            var passed = NonQueryDatabase(query);
            if (passed)
            {
                var users = GetUsersInDepartment(departmentUID);
                foreach (var user in users)
                {
                    user.DepartmentUid = 0;
                    ModifyUser(user);
                }

                return passed;
            }

            return passed;
        }

        public static bool AddDepartment(Department department)
        {
            var query = "INSERT INTO Departments(DepartmentUid, DepartmentName, Administrator)VALUES('"
                        + department.DepartmentUid + "','" + department.Name + "','" +
                        Convert.ToInt32(department.Admin) + "')";

            var passed = NonQueryDatabase(query);

            return passed;
        }

        public static List<UserData> GetUsersInDepartment(int departmentID)
        {
            var query = "SELECT * FROM LoginTable WHERE DepartmentUid = " + departmentID;

            var users = new List<UserData>();
            var dataTable = QueryDatabase(query);

            if (dataTable.Rows.Count > 0)
                foreach (DataRow row in dataTable.Rows)
                {
                    var user = new UserData();

                    user.Uuid = row.Field<int>("UsernameUID");
                    user.DepartmentUid = row.Field<int>("DepartmentUid");
                    user.Permissions = Convert.ToBoolean(row.Field<int>("Permissions"));

                    if (row.Field<string>("Username") != null) user.Username = row.Field<string>("Username");
                    if (row.Field<string>("Password") != null) user.Password = row.Field<string>("Password");

                    users.Add(user);
                }

            return users;
        }

        public static Department FindDepartment(int departmentID)
        {
            var query = "SELECT * FROM Departments WHERE DepartmentUid = " + departmentID;

            var dataTable = QueryDatabase(query);

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];

                var department = new Department();

                department.DepartmentUid = row.Field<int>("DepartmentUid");
                department.Admin = Convert.ToBoolean(row.Field<int>("Administrator"));

                if (row.Field<string>("DepartmentName") != null) department.Name = row.Field<string>("DepartmentName");

                return department;
            }

            return null;
        }

        public static Department FindDepartmentByName(string name)
        {
            var query = "SELECT * FROM Departments WHERE DepartmentName = '" + name + "'";

            var dataTable = QueryDatabase(query);

            if (dataTable.Rows.Count > 0)
            {
                var row = dataTable.Rows[0];

                var department = new Department();

                department.DepartmentUid = row.Field<int>("DepartmentUid");
                department.Admin = Convert.ToBoolean(row.Field<int>("Administrator"));

                if (row.Field<string>("DepartmentName") != null) department.Name = row.Field<string>("DepartmentName");

                return department;
            }

            return null;
        }

        #endregion
    }
}