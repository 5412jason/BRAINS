using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class Oversight : Form
    {
        private StenerManagement stenerManagement;
        private List<QuestionSet> questionSets;
        private UserData currentUser;
        private UserData deleteUser;
        private enum stenerManagementMode
        {
            None,
            CreateQuestionSet,
            ModifyQuestion,
            AddQuestion
        }

        private stenerManagementMode currentStenerManagementMode = stenerManagementMode.None;


        public Oversight()
        {
            InitializeComponent();

            stenerManagement = new StenerManagement();
        }
        public Oversight(UserData user)
        {
            InitializeComponent();

            stenerManagement = new StenerManagement();
            currentUser = user;
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void accountsTab_Click(object sender, EventArgs e)
        {

        }

        private void addDepartmentButton_Click(object sender, EventArgs e)
        {
            OversightAddDepartment form = new OversightAddDepartment();
            form.Show();
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
        }
        private void OversightAccountsRemoveUser_Click (object sender, EventArgs e)
        {
            /*
            * Get user id from list
           */
            SqlManager.RemoveUser(deleteUser.UUID);
        }

        private void changeUsernameButton_Click(object sender, EventArgs e)
        {
            OversightAccountsUsernameChange form = new OversightAccountsUsernameChange(Int32.Parse(accountList.SelectedItems.ToString()));
            form.Show();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            /*
             * Get user id from list
             * call find user to get the user data from sql manager
             * pass user in as parameter to oversight password change
            */
            OversightPasswordChange passwordChange = new OversightPasswordChange();
            passwordChange.Show();
        }

        private void OversightAccountsAddUser_Click(object sender, EventArgs e)
        {
            NewUser form = new NewUser();
            form.Show();
        }
        private void violationRefreshButton_Click(object sender, EventArgs e)
        {
            //ViolationsListView.Items.Clear();
            this.questionSets = stenerManagement.GetStenerList();
            foreach (QuestionSet qSet in this.questionSets)
            {
                string[] row = { qSet.UniqueID.ToString(), qSet.AssignedDepartment.ToString(), qSet.QuestionCount.ToString(), qSet.SubmittedDate.ToString(), qSet.Status, qSet.Category };

                var listItem = new ListViewItem(row);
                StenerManagementListView.Items.Add(listItem);
            }
        }
        private void editViolation_Click(object sender, EventArgs e)
        {
            
        }
        private void removeViolation_Click(object sender, EventArgs e)
        {

        }

        #region STENER_MANAGEMENT
        private void stenerManageRefreshBtn_Click(object sender, EventArgs e)
        {
            this.refreshStenerManagementList();
        }
        private void deleteQuestionSetButton_Click(object sender, EventArgs e)
        {
            ListViewItem selectedItem = StenerManagementListView.SelectedItems[0]; //only can select one item at a time

            int questionSetUID = Convert.ToInt32(selectedItem.Text);

            stenerManagement.DeleteQuesitonSet(questionSetUID);

            this.refreshStenerManagementList();
        }

        private void createQuestionSetButton_Click(object sender, EventArgs e)
        {
            departmentComboBox.Enabled = true;
            priorityComboBox.Enabled = true;
            dueDateCalendar.Enabled = true;
            questionTextbox.Enabled = true;
            submitStenerManagementButton.Enabled = true;

            currentStenerManagementMode = stenerManagementMode.CreateQuestionSet;

        }

        private void refreshStenerManagementList()
        {
            StenerManagementListView.Items.Clear();
            this.questionSets = stenerManagement.GetStenerList();
            foreach (QuestionSet qSet in this.questionSets)
            {
                string[] row = { qSet.UniqueID.ToString(), qSet.AssignedDepartment.ToString(), qSet.QuestionCount.ToString(), qSet.SubmittedDate.ToString(), qSet.Status, qSet.Category };

                var listItem = new ListViewItem(row);
                StenerManagementListView.Items.Add(listItem);
            }
        }

        private void submitStenerManagementButton_Click(object sender, EventArgs e)
        {
            bool success = false;
            string statusMessage = "";

            if (currentStenerManagementMode == stenerManagementMode.CreateQuestionSet)
            {
                // TODO: Need to populate the department drop down box dynamically and get a string name
                if (departmentComboBox.SelectedItem != null 
                    && priorityComboBox.SelectedItem != null
                    && dueDateCalendar.SelectionStart != null
                    && questionTextbox.Text != "")
                {
                    int departmentName = Convert.ToInt32(departmentComboBox.SelectedItem.ToString());
                    int priority = Convert.ToInt32(priorityComboBox.SelectedItem);
                    DateTime dueDate = dueDateCalendar.SelectionStart;
                    string question = questionTextbox.Text;

                    bool result = stenerManagement.CreateQuestionSet(departmentName, priority, dueDate, question);
                    
                    if (result == true)
                    {
                        success = true;
                        statusMessage = "Successfully added the new question set.";
                    }
                    else
                    {
                        success = false;
                        statusMessage = "Error adding the new question set.";
                    }
                }
                else
                {
                    success = false;
                    statusMessage = "Cannot submit until all fields have a selection or an value entered!";
                }
            }
            else if(currentStenerManagementMode == stenerManagementMode.ModifyQuestion)
            {

            }
            else if(currentStenerManagementMode == stenerManagementMode.AddQuestion)
            {

            }
            else if(currentStenerManagementMode == stenerManagementMode.None)
            {

            }
            else
            {
                //error stuffs
            }

            // disable everything if submission was successfull

            if(success == true)
            {
                departmentComboBox.Enabled = false;
                priorityComboBox.Enabled = false;
                dueDateCalendar.Enabled = false;
                questionTextbox.Enabled = false;
                submitStenerManagementButton.Enabled = false;
            }

            stenerManagementStatusLabel.Text = statusMessage;
        }
        #endregion

        private void PreviewStenerButton_Click(object sender, EventArgs e)
        {
            OversightPreview preview = new OversightPreview();
            preview.Show();
        }
    }
}
