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
                DataTable questionSets = QueryDatabase("SELECT * FROM QuestionTable");

                
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
