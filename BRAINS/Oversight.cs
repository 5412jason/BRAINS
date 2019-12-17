﻿using System;
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
        private DepartmentManagement departmentManagement;
        private AccountManagement accountManagement;
        private ViolationManagement violationManagement;
        private List<QuestionSet> questionSets;
        private List<UserData> usersData;
        private List<Violation> violations;
        private UserData currentUser;
        //private UserData deleteUser;
        

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
            departmentManagement = new DepartmentManagement();
            accountManagement = new AccountManagement();
            violationManagement = new ViolationManagement();

        }
        public Oversight(UserData user)
        {
            InitializeComponent();

            stenerManagement = new StenerManagement();
            departmentManagement = new DepartmentManagement();
            accountManagement = new AccountManagement();
            violationManagement = new ViolationManagement();
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

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            if(accountList.SelectedItems.Count > 0)
            {
                int UUID = Convert.ToInt32(accountList.SelectedItems[0].Text);
                UserData user = accountManagement.FindUser(UUID);
                OversightPasswordChange passwordChange = new OversightPasswordChange(UUID);
                passwordChange.Show();
            }
            else
            {
                accountManagementStatusStrip.Text = "Please select a user to change their password";

            }

        }

        #region STENER_MANAGEMENT
        private void stenerManageRefreshBtn_Click(object sender, EventArgs e)
        {
            this.refreshStenerManagementList();
        }

        private void StenerManagementListView_ItemSelectionChanged(object sender, EventArgs e)
        {
            stenerManagementQuestionList.Items.Clear();
            if (StenerManagementListView.SelectedItems.Count > 0)
            {
                int selectedID = Convert.ToInt32(StenerManagementListView.SelectedItems[0].SubItems[0].Text);
                QuestionSet qSet = stenerManagement.GetQuestionSet(selectedID);

                if (qSet != null)
                {
                    foreach (Question question in qSet.Questions)
                    {
                        string[] row = { question.QuestionID.ToString(), question.QuestionText };
                        var listItem = new ListViewItem(row);

                        stenerManagementQuestionList.Items.Add(listItem);
                    }
                }
            }
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
            categoryTextBox.Enabled = true;

            departmentComboBox.Items.Clear();

            List<string> departmentNames = departmentManagement.GetDepartmentNames();

            foreach(string dept in departmentNames)
            {
                departmentComboBox.Items.Add(dept);
            }

            currentStenerManagementMode = stenerManagementMode.CreateQuestionSet;

        }

        private void refreshStenerManagementList()
        {
            StenerManagementListView.Items.Clear();
            stenerManagementQuestionList.Items.Clear();
            this.questionSets = stenerManagement.GetStenerList();
            foreach (QuestionSet qSet in this.questionSets)
            {
                string[] row = { qSet.UniqueID.ToString(), qSet.AssignedDepartment.ToString(), qSet.QuestionCount.ToString(), qSet.DueDate.ToString("MM/dd/yyyy"), (qSet.SubmittedDate.Equals(new DateTime()) ? "" : qSet.SubmittedDate.ToString("MM/dd/yyyy")), qSet.Status, qSet.Category };

                var listItem = new ListViewItem(row);
                StenerManagementListView.Items.Add(listItem);
            }
        }
        public void refreshAccountList()
        {
            accountList.Items.Clear();
            this.usersData = accountManagement.GetUserList();
            foreach (UserData user in this.usersData)
            {
                string[] row = { user.UUID.ToString(), user.Username.ToString(), user.DepartmentUID.ToString(), user.Permissions.ToString()};

                var listItem = new ListViewItem(row);
                accountList.Items.Add(listItem);
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
                    && questionTextbox.Text != ""
                    && categoryTextBox.Text != "")
                {
                    string departmentName = departmentComboBox.SelectedItem.ToString();
                    int priority = Convert.ToInt32(priorityComboBox.SelectedItem);
                    DateTime dueDate = dueDateCalendar.SelectionStart;
                    string question = questionTextbox.Text;
                    string category = categoryTextBox.Text;

                    int departmentID = departmentManagement.GetDepartmentByName(departmentName).DepartmentUID;

                    bool result = stenerManagement.CreateQuestionSet(departmentID, priority, dueDate, question, category);

                    if (result == true)
                    {
                        success = true;
                        statusMessage = "Successfully added the new question set.";
                        currentStenerManagementMode = stenerManagementMode.None;
                        departmentComboBox.Items.Clear();
                        questionTextbox.Text = "";
                        categoryTextBox.Text = "";
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
            else if (currentStenerManagementMode == stenerManagementMode.ModifyQuestion)
            {
                if (StenerManagementListView.SelectedItems.Count > 0 && stenerManagementQuestionList.SelectedItems.Count > 0 && questionTextbox.Text != "")
                {
                    int qSetID = Convert.ToInt32(StenerManagementListView.SelectedItems[0].SubItems[0].Text);
                    int qID = Convert.ToInt32(stenerManagementQuestionList.SelectedItems[0].SubItems[0].Text);

                    bool result = stenerManagement.ModifyQuestion(questionTextbox.Text, qSetID, qID);

                    if (result == true)
                    {
                        success = true;

                        statusMessage = "Successfully modified the question.";
                        currentStenerManagementMode = stenerManagementMode.None;
                        questionTextbox.Text = "";
                        this.refreshStenerManagementList();
                    }
                    else
                    {
                        success = false;

                        statusMessage = "Error modifying the question.";
                        questionTextbox.Text = "";
                    }
                }
                else
                {
                    success = false;

                    statusMessage = "Error modifying the question.";
                }
            }
            else if (currentStenerManagementMode == stenerManagementMode.AddQuestion)
            {
                if (StenerManagementListView.SelectedItems.Count > 0 && questionTextbox.Text != "")
                {
                    int qSetID = Convert.ToInt32(StenerManagementListView.SelectedItems[0].SubItems[0].Text);

                    bool result = stenerManagement.AddQuestion(questionTextbox.Text, qSetID);

                    if (result == true)
                    {
                        success = true;

                        statusMessage = "Successfully added the question.";
                        currentStenerManagementMode = stenerManagementMode.None;
                        questionTextbox.Text = "";
                        this.refreshStenerManagementList();
                    }
                    else
                    {
                        success = false;

                        statusMessage = "Error adding the question.";
                        questionTextbox.Text = "";
                    }
                }
                else
                {
                    success = false;

                    statusMessage = "Error modifying the question.";
                }
            }
            else if (currentStenerManagementMode == stenerManagementMode.None)
            {

            }
            else
            {
                //error stuffs
            }

            // disable everything if submission was successfull

            if(success == true)
            {
                StenerManagementListView.Enabled = true;
                stenerManagementQuestionList.Enabled = true;

                departmentComboBox.Enabled = false;
                priorityComboBox.Enabled = false;
                dueDateCalendar.Enabled = false;
                questionTextbox.Enabled = false;
                submitStenerManagementButton.Enabled = false;
                categoryTextBox.Enabled = false;
            }

            stenerManagementStatusLabel.Text = statusMessage;
        }

        private void removeQuestionButton_Click(object sender, EventArgs e)
        {
            if (StenerManagementListView.SelectedItems.Count > 0 && stenerManagementQuestionList.SelectedItems.Count > 0) 
            {
                int qSetID = Convert.ToInt32(StenerManagementListView.SelectedItems[0].SubItems[0].Text);
                int qID = Convert.ToInt32(stenerManagementQuestionList.SelectedItems[0].SubItems[0].Text);

                stenerManagement.DeleteQuestion(qSetID, qID);

                this.refreshStenerManagementList();

                stenerManagementStatusLabel.Text = "Successfully removed question.";
            }
            else
            {
                stenerManagementStatusLabel.Text = "Error removing question.";
            }
        }

        private void modifyQuestionButton_Click(object sender, EventArgs e)
        {
            if (StenerManagementListView.SelectedItems.Count > 0 && stenerManagementQuestionList.SelectedItems.Count > 0)
            {
                currentStenerManagementMode = stenerManagementMode.ModifyQuestion;
                questionTextbox.Enabled = true;
                submitStenerManagementButton.Enabled = true;
                questionTextbox.Text = stenerManagementQuestionList.SelectedItems[0].SubItems[1].Text;

                StenerManagementListView.Enabled = false;
                stenerManagementQuestionList.Enabled = false;

                stenerManagementStatusLabel.Text = "Modifying question.";
            }
            else
            {
                stenerManagementStatusLabel.Text = "Error modifying question.";
            }
        }
        private void addQuestionButton_Click(object sender, EventArgs e)
        {
            if (StenerManagementListView.SelectedItems.Count > 0)
            {
                currentStenerManagementMode = stenerManagementMode.AddQuestion;
                questionTextbox.Enabled = true;
                submitStenerManagementButton.Enabled = true;

                StenerManagementListView.Enabled = false;
                stenerManagementQuestionList.Enabled = false;

                stenerManagementStatusLabel.Text = "Adding question.";
            }
            else
            {
                stenerManagementStatusLabel.Text = "Error adding question.";
            }
        }
        #endregion

        private void OversightAccountsAddUser_Click(object sender, EventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();
        }

        private void PreviewStenerButton_Click(object sender, EventArgs e)
        {
            OversightPreview preview = new OversightPreview();
            preview.Show();
        }

        public void refreshAccountList(object sender, EventArgs e)
        {
            accountList.Items.Clear();
            this.usersData = accountManagement.GetUserList();
            foreach (UserData user in this.usersData)
            {
                string[] row = { user.UUID.ToString(), user.Username.ToString(), user.DepartmentUID.ToString(), user.Permissions.ToString() };

                var listItem = new ListViewItem(row);
                accountList.Items.Add(listItem);
            }

        }

        public void refreshButtonAccounts_Click(object sender, EventArgs e)
        {
            this.refreshAccountList();
        }

        private void OversightAccountsRemoveUser_Click(object sender, EventArgs e)
        {
            if (accountList.SelectedItems.Count > 0)
            {
                int UUID = Convert.ToInt32(accountList.SelectedItems[0].Text);
                accountManagement.FindUser(UUID);
                AccountManagement deleteUser = new AccountManagement();
                deleteUser.DeleteUser(UUID);
                this.refreshAccountList();
            }
            else
            {
                accountManagementStatusStrip.Text = "Please select a user";

            }

        }

        private void violationRefreshButton_Click(object sender, EventArgs e)
        {
            OversightViolationList.Items.Clear();
            this.violations = violationManagement.GetViolationList();
            foreach (Violation violate in this.violations)
            {
                string[] row = { violate.ViolationUID.ToString(), violate.StenerSetUID.ToString(), violate.DepartmentUID.ToString(), violate.ViolationDescription.ToString(), violate.Severity.ToString(), violate.ViolationDate.ToString("MM/dd/yyyy") };

                var listItem = new ListViewItem(row);
                OversightViolationList.Items.Add(listItem);
            }
        }

        private void removeViolation_Click(object sender, EventArgs e)
        {
            int violationUID = Convert.ToInt32(OversightViolationList.SelectedItems[0].Text);
            SqlManager.RemoveViolation(violationUID);

        }

        private void editViolation_Click(object sender, EventArgs e)
        {

        }
    }
}
