using System;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class Oversight
    {
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

        private void CreateQuestionSetButton_Click(object sender, EventArgs e)
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

        private enum StenerManagementMode
        {
            None,
            CreateQuestionSet,
            ModifyQuestion,
            AddQuestion
        }
    }
}