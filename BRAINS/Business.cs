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
        private StenerManagement stenerManagement;

        public Business()
        {
            InitializeComponent();
            stenerManagement = new StenerManagement();
        }

        public Business(UserData user)
        {
            InitializeComponent();
            currentUser = user;
            stenerManagement = new StenerManagement();
        }
        private void Business_Load(object sender, EventArgs e)
        {
            //CompleteStenerDataGridView.DataSource = GetDepartmentList();
        }
        private void busniessViolationsrefreshButton_Click(object sender, EventArgs e)
        {

        }

        private void RefreshCompleteList_Click(object sender, EventArgs e)
        {
            this.refreshQuestionSetList();
        }

        private void refreshQuestionSetList()
        {
            if (currentUser == null)
            {
                completeStenerStatusLabel.Text = "No valid user logged in!";
                return;
            }
            int departmentID = currentUser.DepartmentUID;

            //get all question sets for the department
            List<QuestionSet> qSets = stenerManagement.GetQuestionSetsForDepartment(departmentID);
            completeQuestionSetListView.Clear();

            foreach(QuestionSet qSet in qSets)
            {
                string[] row = { qSet.Priority.ToString(), qSet.UniqueID.ToString(), qSet.Questions.Count.ToString(), qSet.DueDate.ToString("MM/dd/yyyy"), qSet.Status.ToString(), qSet.Category };
                var listItem = new ListViewItem(row);

                completeQuestionSetListView.Items.Add(listItem);
            }
        }
    }
}
