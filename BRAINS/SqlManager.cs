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
    class SqlManager
    {

        private DataTable QueryDatabase(string query)
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

                }

            }
            return dataTable;
        }

        public List<QuestionSet> GetAllQuestionSets()
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

                    DataTable questionTable = QueryDatabase("SELECT * FROM QuestionTable");

                    questionSets.Add(qSet);
                }
            }
            catch
            {
                return new List<QuestionSet>();
            }
            
            return new List<QuestionSet>();
        }

        public QuestionSet FindQuestionSet()
        {
            return new QuestionSet();
        }

        public bool ModifyQuestionSet()
        {
            return true;
        }

        public bool AddQuestionSet()
        {
            return true;
        }

        public bool RemoveQuestionSet()
        {
            return true;
        }

        // Retreive stener database values

       
        // Retrieve violation database values
    }
}
