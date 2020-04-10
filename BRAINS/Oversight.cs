using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class Oversight : Form
    {
        private readonly AccountManagement accountManagement;
        private readonly DepartmentManagement departmentManagement;
        private readonly StenerManagement stenerManagement;
        private readonly ViolationManagement violationManagement;
        private StenerManagementMode currentStenerManagementMode = StenerManagementMode.None;
        private List<QuestionSet> questionSets;
        private List<UserData> usersData;
        private List<Violation> violations;

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
        }

        private void addDepartmentButton_Click(object sender, EventArgs e)
        {
            var form = new OversightAddDepartment();
            form.Show();
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            if (accountList.SelectedItems.Count > 0)
            {
                var UUID = Convert.ToInt32(accountList.SelectedItems[0].Text);
                var passwordChange = new OversightPasswordChange(UUID);
                passwordChange.Show();
            }
            else
            {
                accountManagementStatusStrip.Text = "Please select a user to change their password";
            }
        }

        private void OversightAccountsAddUser_Click(object sender, EventArgs e)
        {
            var newUser = new NewUser();
            newUser.Show();
        }

        public void refreshButtonAccounts_Click(object sender, EventArgs e)
        {
            RefreshAccountList();
        }

        private void OversightAccountsRemoveUser_Click(object sender, EventArgs e)
        {
            if (accountList.SelectedItems.Count > 0)
            {
                var uuid = Convert.ToInt32(accountList.SelectedItems[0].Text);
                accountManagement.FindUser(uuid);
                var deleteUser = new AccountManagement();
                deleteUser.DeleteUser(uuid);
                RefreshAccountList();
            }
            else
            {
                accountManagementStatusStrip.Text = "Please select a user";
            }
        }

        private void violationRefreshButton_Click(object sender, EventArgs e)
        {
            OversightViolationList.Items.Clear();
            violations = violationManagement.GetViolationList();
            foreach (var violate in violations)
            {
                string[] row =
                {
                    violate.ViolationUid.ToString(), violate.StenerSetUid.ToString(), violate.DepartmentUid.ToString(),
                    violate.ViolationDescription, violate.Severity.ToString(),
                    violate.ViolationDate.ToString("MM/dd/yyyy")
                };

                var listItem = new ListViewItem(row);
                OversightViolationList.Items.Add(listItem);
            }
        }

        private void removeViolation_Click(object sender, EventArgs e)

        {
            if (OversightViolationList.SelectedItems.Count > 0)
            {
                var violationUid = Convert.ToInt32(OversightViolationList.SelectedItems[0].Text);
                SqlManager.RemoveViolation(violationUid);
            }
            else
            {
                MessageBox.Show("Please select a violation to delete");
            }
        }

        private void RemoveDepartmentButton_Click(object sender, EventArgs e)
        {
            var form1 = new OversightRemoveDepartment();
            form1.Show();
        }

        private void RefreshButtonDepartments_Click(object sender, EventArgs e)
        {
            RefreshDepartmentManagementList();
        }

        private void RefreshDepartmentManagementList()
        {
            departmentList.Items.Clear();
            memberList.Items.Clear();

            var departmentNames = departmentManagement.getDepartments();

            foreach (var dept in departmentNames)
            {
                string[] row = {dept.DepartmentUid.ToString(), dept.Name};
                var listItem = new ListViewItem(row);
                departmentList.Items.Add(listItem);
            }
        }

        private void DepartmentListItemSelectionChanged(object sender, EventArgs e)
        {
            memberList.Items.Clear();
            if (departmentList.SelectedItems.Count > 0)
            {
                var selectedId = Convert.ToInt32(departmentList.SelectedItems[0].Text);
                usersData = departmentManagement.getAllUsersInDepartment(selectedId);

                if (usersData != null)
                    foreach (var user in usersData)
                        if (user.DepartmentUid == selectedId)
                        {
                            string[] row = {user.Username};
                            var listItem = new ListViewItem(row);
                            memberList.Items.Add(listItem);
                        }
            }
        }

        private void AddUserButton_Click(object sender, EventArgs e)
        {
            if (allUsersList.SelectedItems.Count > 0 && removeUserText.Text != null)
            {
                var uuid = Convert.ToInt32(allUsersList.SelectedItems[0].SubItems[0].Text);
                var departmentId = Convert.ToInt32(departmentText.Text);
                departmentManagement.addDeparmentUser(uuid, departmentId);
            }
        }

        private void removeUserButton_Click(object sender, EventArgs e)
        {
            if (allUsersList.SelectedItems.Count > 0 && removeUserText.Text != null)
            {
                var uuid = Convert.ToInt32(allUsersList.SelectedItems[0].SubItems[0].Text);
                var departmentId = Convert.ToInt32(removeUserText.Text);
                departmentManagement.removeDeparmentUser(uuid, departmentId);
            }
        }

        private void RefreshAllUsers_Click(object sender, EventArgs e)
        {
            RefreshAllUsersList();
        }

        private void RefreshAllUsersList()
        {
            allUsersList.Items.Clear();
            usersData = accountManagement.GetUserList();
            foreach (var user in usersData)
            {
                string[] row = {user.Uuid.ToString(), user.Username, user.DepartmentUid.ToString()};

                var listItem = new ListViewItem(row);
                allUsersList.Items.Add(listItem);
            }
        }

        private enum StenerManagementMode
        {
            None,
            CreateQuestionSet,
            ModifyQuestion,
            AddQuestion
        }

        #region STENER_MANAGEMENT

        private void StenerManageRefresh(object sender, EventArgs e)
        {
            RefreshStenerManagementList();
        }

        private void StenerManagementListView_ItemSelectionChanged(object sender, EventArgs e)
        {
            stenerManagementQuestionList.Items.Clear();
            if (StenerManagementListView.SelectedItems.Count > 0)
            {
                var selectedId = Convert.ToInt32(StenerManagementListView.SelectedItems[0].SubItems[0].Text);
                var qSet = stenerManagement.GetQuestionSet(selectedId);

                if (qSet != null)
                    foreach (var question in qSet.Questions)
                    {
                        string[] row = {question.QuestionId.ToString(), question.QuestionText};
                        var listItem = new ListViewItem(row);

                        stenerManagementQuestionList.Items.Add(listItem);
                    }
            }
        }

        private void DeleteQuestionSetButton_Click(object sender, EventArgs e)
        {
            if (StenerManagementListView.SelectedItems.Count > 0)
            {
                var selectedItem = StenerManagementListView.SelectedItems[0]; //only can select one item at a time

                var questionSetUid = Convert.ToInt32(selectedItem.Text);

                stenerManagement.DeleteQuestionSet(questionSetUid);

                RefreshStenerManagementList();
            }
            else
            {
                stenerManagementStatusLabel.Text = "Please select a question set to delete";
            }
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

            var departmentNames = departmentManagement.GetDepartmentNames();

            foreach (var dept in departmentNames) departmentComboBox.Items.Add(dept);

            currentStenerManagementMode = StenerManagementMode.CreateQuestionSet;
        }

        private void RefreshStenerManagementList()
        {
            StenerManagementListView.Items.Clear();
            stenerManagementQuestionList.Items.Clear();
            questionSets = stenerManagement.GetStenerList();
            foreach (var qSet in questionSets)
            {
                string[] row =
                {
                    qSet.UniqueID.ToString(), qSet.AssignedDepartment.ToString(), qSet.QuestionCount.ToString(),
                    qSet.DueDate.ToString("MM/dd/yyyy"),
                    qSet.SubmittedDate.Equals(new DateTime()) ? "" : qSet.SubmittedDate.ToString("MM/dd/yyyy"),
                    qSet.Status, qSet.Category
                };

                var listItem = new ListViewItem(row);
                StenerManagementListView.Items.Add(listItem);
            }
        }

        public void RefreshAccountList()
        {
            accountList.Items.Clear();
            usersData = accountManagement.GetUserList();
            foreach (var user in usersData)
            {
                string[] row =
                    {user.Uuid.ToString(), user.Username, user.DepartmentUid.ToString(), user.Permissions.ToString()};

                var listItem = new ListViewItem(row);
                accountList.Items.Add(listItem);
            }
        }

        private void SubmitStenerManagementButton(object sender, EventArgs e)
        {
            var success = false;
            string statusMessage;
            if (currentStenerManagementMode == StenerManagementMode.CreateQuestionSet)
            {
                // TODO: Need to populate the department drop down box dynamically and get a string name
                if (departmentComboBox.SelectedItem != null
                    && priorityComboBox.SelectedItem != null
                    && questionTextbox.Text != ""
                    && categoryTextBox.Text != "")
                {
                    var departmentName = departmentComboBox.SelectedItem.ToString();
                    var priority = Convert.ToInt32(priorityComboBox.SelectedItem);
                    var dueDate = dueDateCalendar.SelectionStart;
                    var question = questionTextbox.Text;
                    var category = categoryTextBox.Text;

                    var departmentUid = departmentManagement.GetDepartmentByName(departmentName).DepartmentUid;

                    var result =
                        stenerManagement.CreateQuestionSet(departmentUid, priority, dueDate, question, category);

                    if (result)
                    {
                        success = true;
                        statusMessage = "Successfully added the new question set.";
                        currentStenerManagementMode = StenerManagementMode.None;
                        departmentComboBox.Items.Clear();
                        questionTextbox.Text = "";
                        categoryTextBox.Text = "";
                    }
                    else
                    {
                        statusMessage = "Error adding the new question set.";
                    }
                }
                else
                {
                    statusMessage = "Cannot submit until all fields have a selection or an value entered!";
                }
            }
            else if (currentStenerManagementMode == StenerManagementMode.ModifyQuestion)
            {
                if (StenerManagementListView.SelectedItems.Count > 0 &&
                    stenerManagementQuestionList.SelectedItems.Count > 0 && questionTextbox.Text != "")
                {
                    var qSetId = Convert.ToInt32(StenerManagementListView.SelectedItems[0].SubItems[0].Text);
                    var qId = Convert.ToInt32(stenerManagementQuestionList.SelectedItems[0].SubItems[0].Text);

                    var result = stenerManagement.ModifyQuestion(questionTextbox.Text, qSetId, qId);

                    if (result)
                    {
                        success = true;

                        statusMessage = "Successfully modified the question.";
                        currentStenerManagementMode = StenerManagementMode.None;
                        questionTextbox.Text = "";
                        RefreshStenerManagementList();
                    }
                    else
                    {
                        statusMessage = "Error modifying the question.";
                        questionTextbox.Text = "";
                    }
                }
                else
                {
                    statusMessage = "Error modifying the question.";
                }
            }
            else if (currentStenerManagementMode == StenerManagementMode.AddQuestion)
            {
                if (StenerManagementListView.SelectedItems.Count > 0 && questionTextbox.Text != "")
                {
                    var qSetId = Convert.ToInt32(StenerManagementListView.SelectedItems[0].SubItems[0].Text);

                    var result = stenerManagement.AddQuestion(questionTextbox.Text, qSetId);

                    if (result)
                    {
                        success = true;

                        statusMessage = "Successfully added the question.";
                        currentStenerManagementMode = StenerManagementMode.None;
                        questionTextbox.Text = "";
                        RefreshStenerManagementList();
                    }
                    else
                    {
                        statusMessage = "Error adding the question.";
                        questionTextbox.Text = "";
                    }
                }
                else
                {
                    statusMessage = "Error modifying the question.";
                }
            }
            else
            {
                //error stuffs
                statusMessage = "Error modifying the question.";
            }

            // disable everything if submission was successfull
            if (success)
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

        private void RemoveQuestionButton_Click(object sender, EventArgs e)
        {
            if (StenerManagementListView.SelectedItems.Count > 0 &&
                stenerManagementQuestionList.SelectedItems.Count > 0)
            {
                var qSetId = Convert.ToInt32(StenerManagementListView.SelectedItems[0].SubItems[0].Text);
                var qId = Convert.ToInt32(stenerManagementQuestionList.SelectedItems[0].SubItems[0].Text);

                stenerManagement.DeleteQuestion(qSetId, qId);

                RefreshStenerManagementList();

                stenerManagementStatusLabel.Text = "Successfully removed question.";
            }
            else
            {
                stenerManagementStatusLabel.Text = "Error removing question.";
            }
        }

        private void ModifyQuestionButton_Click(object sender, EventArgs e)
        {
            if (StenerManagementListView.SelectedItems.Count > 0 &&
                stenerManagementQuestionList.SelectedItems.Count > 0)
            {
                currentStenerManagementMode = StenerManagementMode.ModifyQuestion;
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

        private void AddQuestionButton_Click(object sender, EventArgs e)
        {
            if (StenerManagementListView.SelectedItems.Count > 0)
            {
                currentStenerManagementMode = StenerManagementMode.AddQuestion;
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

        #region SUBMISSIONS

        private void RefreshSubmissionsList()
        {
            submittedStenerListView.Items.Clear();
            questionSets = stenerManagement.GetSubmittedQuestionSets();
            foreach (var qSet in questionSets)
            {
                string[] row =
                {
                    qSet.UniqueID.ToString(), qSet.AssignedDepartment.ToString(), qSet.Questions.Count.ToString(),
                    qSet.DueDate.ToString("MM/dd/yyyy"),
                    qSet.SubmittedDate.Equals(new DateTime()) ? "" : qSet.SubmittedDate.ToString("MM/dd/yyyy"),
                    qSet.Status
                };

                var listItem = new ListViewItem(row);
                submittedStenerListView.Items.Add(listItem);
            }
        }

        private void RefreshSubmissionsButton_Click(object sender, EventArgs e)
        {
            RefreshSubmissionsList();
        }

        private void ApproveButton_Click(object sender, EventArgs e)
        {
            if (submittedStenerListView.SelectedItems.Count > 0)
            {
                var qSetId = Convert.ToInt32(submittedStenerListView.SelectedItems[0].SubItems[0].Text);
                var qSet = stenerManagement.GetQuestionSet(qSetId);

                qSet.Status = "APPROVED";

                RefreshSubmissionsList();
                submissionStatusLabel.Text = "Approved STENER!";
            }
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            if (submittedStenerListView.SelectedItems.Count > 0)
            {
                var qSetId = Convert.ToInt32(submittedStenerListView.SelectedItems[0].SubItems[0].Text);
                var qSet = stenerManagement.GetQuestionSet(qSetId);
                if (violationCheckbox.Checked)
                {
                    if (severityDropdown.SelectedItem != null && violationDescriptionTextBox.Text != "")
                    {
                        var violation = new Violation
                        {
                            DepartmentUid = qSet.AssignedDepartment,
                            Severity = Convert.ToInt32(severityDropdown.SelectedItem),
                            StenerSetUid = qSetId,
                            ViolationDescription = violationDescriptionTextBox.Text,
                            ViolationDate = DateTime.Now
                        };

                        violationManagement.AddViolation(violation);
                    }
                    else
                    {
                        submissionStatusLabel.Text =
                            "Error: Ensure all violation fields are filled in for a violation!";
                        return;
                    }
                }

                qSet.Status = "REJECTED";

                RefreshSubmissionsList();
                submissionStatusLabel.Text = "Rejected STENER!";
            }
        }

        private void PreviewStenerButton_Click(object sender, EventArgs e)
        {
            if (submittedStenerListView.SelectedItems.Count > 0)
            {
                var qSetId = Convert.ToInt32(submittedStenerListView.SelectedItems[0].SubItems[0].Text);
                var preview = new OversightPreview(qSetId);
                preview.Show();
            }
        }

        #endregion
    }
}