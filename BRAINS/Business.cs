using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace BRAINS
{
    public partial class Business : Form
    {

        private UserData currentUser;

        public Business()
        {
            InitializeComponent();
        }

        public Business(UserData user)
        {
            InitializeComponent();
            currentUser = user;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Business_Load(object sender, EventArgs e)
        {
            //CompleteStenerDataGridView.DataSource = GetDepartmentList();
        }
        private void busniessViolationsrefreshButton_Click(object sender, EventArgs e)
        {

        }

        private DataTable GetDepartmentList()
        {
            DataTable departmentList = new DataTable();

            string connString = ConfigurationManager.ConnectionStrings["Brains"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connString))
            {

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM StenerTable", con))
                {

                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    departmentList.Load(reader);

                }

            }
            return departmentList;
        }
    }
}
