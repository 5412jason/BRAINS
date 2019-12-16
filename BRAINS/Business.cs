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

        private QuestionSet currentQuestionSet;
        private int currentQuestion;

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
                string[] row = { qSet.Priority.ToString(), qSet.UniqueID.ToString(), qSet.Questions.Count.ToString(), qSet.DueDate.ToString("MM/dd/yyyy"), qSet.Status.ToString(), qSet.Category, (qSet.SubmittedDate.Equals(new DateTime()) ? "" : qSet.SubmittedDate.ToString("MM/dd/yyyy")) };
                var listItem = new ListViewItem(row);

                completeQuestionSetListView.Items.Add(listItem);
            }
        }

        private void WorkOnSelectedStenerButton_Click(object sender, EventArgs e)
        {
            if (completeQuestionSetListView.SelectedItems.Count > 0)
            {
                int qSetID = Convert.ToInt32(completeQuestionSetListView.SelectedItems[0].SubItems[1].Text);

                currentQuestionSet = stenerManagement.GetQuestionSet(qSetID);

                if (currentQuestionSet != null)
                {
                    currentQuestion = 1;

                    questionCountTextBox.Text = currentQuestion + "/" + currentQuestionSet.Questions.Count.ToString();
                    questionBodyTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].QuestionText;
                    complianceCheckBox.Checked = currentQuestionSet.Questions[currentQuestion - 1].Compliance;
                    answerTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].Answer;
                    planForSolutionTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution;
                    evidenceLocationTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation;

                    if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
                    {
                        answerTextBox.Enabled = true;
                        saveAndCloseSetButton.Enabled = true;
                        completeQuestionSetListView.Enabled = false;
                        workOnSelectedStenerButton.Enabled = false;
                        refreshCompleteListButton.Enabled = false;
                    }


                    if (currentQuestion <= currentQuestionSet.Questions.Count)
                    {
                        questionCountTextBox.Text = currentQuestion + "/" + currentQuestionSet.Questions.Count.ToString();
                        questionBodyTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].QuestionText;
                        complianceCheckBox.Checked = currentQuestionSet.Questions[currentQuestion - 1].Compliance;
                        planForSolutionTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution;
                        evidenceLocationTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation;

                        if (currentQuestion == currentQuestionSet.Questions.Count)
                        {
                            nextButton.Enabled = false;
                            submitQuestionSetButton.Enabled = true;
                        }
                        else
                        {
                            nextButton.Enabled = true;
                            submitQuestionSetButton.Enabled = false;
                        }
                        if (currentQuestion > 1)
                        {
                            backButton.Enabled = true;
                        }
                        else
                        {
                            backButton.Enabled = false;
                        }
                    }
                }
            }
        }

        private void ComplianceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(complianceCheckBox.Checked == true)
            {
                planForSolutionTextBox.Enabled = false;
                evidenceLocationTextBox.Enabled = true;
            }
            else
            {
                planForSolutionTextBox.Enabled = true;
                evidenceLocationTextBox.Enabled = false;
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            // check that the answer is not empty
            // check the stuff for compliance
            bool passed = false;

            if(answerTextBox.Text != "")
            {
                if(complianceCheckBox.Checked == true)
                {
                    if (evidenceLocationTextBox.Text != "")
                    {
                        currentQuestionSet.Questions[currentQuestion - 1].Answer = answerTextBox.Text;
                        currentQuestionSet.Questions[currentQuestion - 1].Compliance = complianceCheckBox.Checked;
                        currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation = evidenceLocationTextBox.Text;
                        currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution = "";

                        passed = true;
                    }
                }
                else
                {
                    if(planForSolutionTextBox.Text != "")
                    {
                        currentQuestionSet.Questions[currentQuestion - 1].Answer = answerTextBox.Text;
                        currentQuestionSet.Questions[currentQuestion - 1].Compliance = complianceCheckBox.Checked;
                        currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation = "";
                        currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution = planForSolutionTextBox.Text;

                        passed = true;
                    }
                }
            }
            if(passed == true)
            {
                if (currentQuestion + 1 <= currentQuestionSet.Questions.Count)
                {
                    currentQuestion = currentQuestion + 1;
                    questionCountTextBox.Text = currentQuestion + "/" + currentQuestionSet.Questions.Count.ToString();
                    questionBodyTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].QuestionText;
                    complianceCheckBox.Checked = currentQuestionSet.Questions[currentQuestion - 1].Compliance;
                    planForSolutionTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution;
                    evidenceLocationTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation;

                    if(currentQuestion == currentQuestionSet.Questions.Count)
                    {
                        nextButton.Enabled = false;
                        submitQuestionSetButton.Enabled = true; 
                    }
                    else
                    {
                        nextButton.Enabled = true;
                        submitQuestionSetButton.Enabled = false;
                    }
                    if(currentQuestion > 1)
                    {
                        backButton.Enabled = true;
                    }
                    else
                    {
                        backButton.Enabled = false;
                    }
                }
            }
        }

        private void SubmitQuestionSetButton_Click(object sender, EventArgs e)
        {
            currentQuestionSet.Status = "SUBMITTED";
            currentQuestionSet.SubmittedDate = DateTime.Now;
            bool result = stenerManagement.SubmitQuestionSet(currentQuestionSet);

            if(result == true)
            {
                questionCountTextBox.Text = "";
                questionBodyTextBox.Text = "";
                complianceCheckBox.Checked = false;
                planForSolutionTextBox.Text = "";
                evidenceLocationTextBox.Text = "";

                answerTextBox.Enabled = false;
                complianceCheckBox.Enabled = false;
                planForSolutionTextBox.Enabled = false;
                evidenceLocationTextBox.Enabled = false;

                backButton.Enabled = false;
                nextButton.Enabled = false;
                saveAndCloseSetButton.Enabled = false;
                submitQuestionSetButton.Enabled = false;
                completeQuestionSetListView.Enabled = true;
                workOnSelectedStenerButton.Enabled = true;
                refreshCompleteListButton.Enabled = true;

                refreshQuestionSetList();

                completeStenerStatusLabel.Text = "Submitted Successfully!";
            }
            else
            {
                completeStenerStatusLabel.Text = "Error Submitting!";
                currentQuestionSet.Status = "INPROGRESS";
            }
        }

        private void SaveAndCloseSetButton_Click(object sender, EventArgs e)
        {
            currentQuestionSet.Status = "INPROGRESS";
            bool result = stenerManagement.SubmitQuestionSet(currentQuestionSet);

            if (result == true)
            {
                questionCountTextBox.Text = "";
                questionBodyTextBox.Text = "";
                complianceCheckBox.Checked = false;
                planForSolutionTextBox.Text = "";
                evidenceLocationTextBox.Text = "";

                answerTextBox.Enabled = false;
                complianceCheckBox.Enabled = false;
                planForSolutionTextBox.Enabled = false;
                evidenceLocationTextBox.Enabled = false;

                backButton.Enabled = false;
                nextButton.Enabled = false;
                saveAndCloseSetButton.Enabled = false;
                submitQuestionSetButton.Enabled = false;

                currentQuestion = 1;
                currentQuestionSet = null;

                refreshQuestionSetList();

                completeStenerStatusLabel.Text = "Submitted Successfully!";
            }
            else
            {
                completeStenerStatusLabel.Text = "Error Saving!";
                currentQuestionSet.Status = "INPROGRESS";
            }
        }
    }
}