using System;
using System.Windows.Forms;

namespace BRAINS
{
    public partial class Business : Form
    {
        private readonly UserData currentUser;
        private readonly StenerManagement stenerManagement;
        private readonly ViolationManagement violationManagement;
        private QuestionSet currentQuestionSet;
        private int currentQuestion;

        public Business()
        {
            InitializeComponent();
            stenerManagement = new StenerManagement();
            violationManagement = new ViolationManagement();
        }

        public Business(UserData user)
        {
            InitializeComponent();
            currentUser = user;
            stenerManagement = new StenerManagement();
            violationManagement = new ViolationManagement();
        }

        private void busniessViolationsrefreshButton_Click(object sender, EventArgs e)
        {
            BusinessViolationList.Items.Clear();

            var violations = violationManagement.GetDepartmentViolations(currentUser.DepartmentUid);
            foreach (var violate in violations)
            {
                string[] row =
                {
                    violate.ViolationUid.ToString(), violate.StenerSetUid.ToString(), violate.DepartmentUid.ToString(),
                    violate.ViolationDescription, violate.Severity.ToString(),
                    violate.ViolationDate.ToString("MM/dd/yyyy")
                };

                var listItem = new ListViewItem(row);
                BusinessViolationList.Items.Add(listItem);
            }
        }

        private void RefreshCompleteList_Click(object sender, EventArgs e)
        {
            refreshQuestionSetList();
        }

        private void refreshQuestionSetList()
        {
            if (currentUser == null)
            {
                completeStenerStatusLabel.Text = "No valid user logged in!";
                return;
            }

            var departmentID = currentUser.DepartmentUid;

            //get all question sets for the department
            var qSets = stenerManagement.GetQuestionSetsForDepartment(departmentID);
            completeQuestionSetListView.Items.Clear();

            foreach (var qSet in qSets)
            {
                string[] row =
                {
                    qSet.Priority.ToString(), qSet.UniqueID.ToString(), qSet.Questions.Count.ToString(),
                    qSet.DueDate.ToString("MM/dd/yyyy"), qSet.Status, qSet.Category,
                    qSet.SubmittedDate.Equals(new DateTime()) ? "" : qSet.SubmittedDate.ToString("MM/dd/yyyy")
                };
                var listItem = new ListViewItem(row);

                completeQuestionSetListView.Items.Add(listItem);
            }
        }

        private void WorkOnSelectedStenerButton_Click(object sender, EventArgs e)
        {
            if (completeQuestionSetListView.SelectedItems.Count > 0)
            {
                var qSetID = Convert.ToInt32(completeQuestionSetListView.SelectedItems[0].SubItems[1].Text);

                currentQuestionSet = stenerManagement.GetQuestionSet(qSetID);

                if (currentQuestionSet != null)
                {
                    currentQuestion = 1;

                    if (currentQuestionSet.Status == "SUBMITTED" || currentQuestionSet.Status == "APPROVED")
                    {
                        answerTextBox.Enabled = false;
                        evidenceLocationTextBox.Enabled = false;
                        complianceCheckBox.Enabled = false;
                        planForSolutionTextBox.Enabled = false;

                        saveAndCloseSetButton.Enabled = true;
                        completeQuestionSetListView.Enabled = false;
                        workOnSelectedStenerButton.Enabled = false;
                        refreshCompleteListButton.Enabled = false;
                    }
                    else
                    {
                        answerTextBox.Enabled = true;
                        complianceCheckBox.Enabled = true;
                    }

                    saveAndCloseSetButton.Enabled = true;

                    questionCountTextBox.Text = currentQuestion + "/" + currentQuestionSet.Questions.Count;
                    questionBodyTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].QuestionText;
                    complianceCheckBox.Checked = currentQuestionSet.Questions[currentQuestion - 1].Compliance;
                    answerTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].Answer;
                    planForSolutionTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution;
                    evidenceLocationTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation;

                    if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
                    {
                        if (complianceCheckBox.Checked)
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

                    if (currentQuestion == currentQuestionSet.Questions.Count)
                    {
                        nextButton.Enabled = false;
                        if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
                            submitQuestionSetButton.Enabled = true;
                    }
                    else
                    {
                        nextButton.Enabled = true;
                        submitQuestionSetButton.Enabled = false;
                    }

                    if (currentQuestion > 1)
                        backButton.Enabled = true;
                    else
                        backButton.Enabled = false;
                }
            }
        }

        private void ComplianceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
            {
                if (complianceCheckBox.Checked)
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
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            // check that the answer is not empty
            // check the stuff for compliance
            var passed = false;
            if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
                if (answerTextBox.Text != "")
                {
                    currentQuestionSet.Questions[currentQuestion - 1].Answer = answerTextBox.Text;
                    currentQuestionSet.Questions[currentQuestion - 1].Compliance = complianceCheckBox.Checked;

                    if (complianceCheckBox.Checked)
                    {
                        if (evidenceLocationTextBox.Text != "")
                        {
                            currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation =
                                evidenceLocationTextBox.Text;
                            currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution = "";

                            passed = true;
                        }
                    }
                    else
                    {
                        if (planForSolutionTextBox.Text != "")
                        {
                            currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation = "";
                            currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution =
                                planForSolutionTextBox.Text;

                            passed = true;
                        }
                    }
                }

            if (passed || currentQuestionSet.Status == "SUBMITTED" || currentQuestionSet.Status == "APPROVED")
                if (currentQuestion + 1 <= currentQuestionSet.Questions.Count)
                {
                    currentQuestion = currentQuestion + 1;
                    questionCountTextBox.Text = currentQuestion + "/" + currentQuestionSet.Questions.Count;
                    questionBodyTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].QuestionText;
                    complianceCheckBox.Checked = currentQuestionSet.Questions[currentQuestion - 1].Compliance;
                    answerTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].Answer;
                    planForSolutionTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution;
                    evidenceLocationTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation;

                    if (currentQuestion == currentQuestionSet.Questions.Count)
                    {
                        nextButton.Enabled = false;
                        if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
                            submitQuestionSetButton.Enabled = true;
                    }
                    else
                    {
                        nextButton.Enabled = true;
                        submitQuestionSetButton.Enabled = false;
                    }

                    if (currentQuestion > 1)
                        backButton.Enabled = true;
                    else
                        backButton.Enabled = false;
                }
        }

        private void SubmitQuestionSetButton_Click(object sender, EventArgs e)
        {
            if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
            {
                var passed = false;
                if (answerTextBox.Text != "")
                {
                    if (complianceCheckBox.Checked)
                    {
                        currentQuestionSet.Questions[currentQuestion - 1].Answer = answerTextBox.Text;
                        currentQuestionSet.Questions[currentQuestion - 1].Compliance = complianceCheckBox.Checked;

                        if (evidenceLocationTextBox.Text != "")
                        {
                            currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation =
                                evidenceLocationTextBox.Text;
                            currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution = "";

                            passed = true;
                        }
                    }
                    else
                    {
                        if (planForSolutionTextBox.Text != "")
                        {
                            currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation = "";
                            currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution =
                                planForSolutionTextBox.Text;

                            passed = true;
                        }
                    }
                }

                if (passed)
                {
                    currentQuestionSet.Status = "SUBMITTED";
                    currentQuestionSet.SubmittedDate = DateTime.Now;
                    var result = stenerManagement.SubmitQuestionSet(currentQuestionSet);

                    if (result)
                    {
                        questionCountTextBox.Text = "";
                        questionBodyTextBox.Text = "";
                        complianceCheckBox.Checked = false;
                        planForSolutionTextBox.Text = "";
                        evidenceLocationTextBox.Text = "";
                        answerTextBox.Text = "";

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
            }
        }

        private void SaveAndCloseSetButton_Click(object sender, EventArgs e)
        {
            if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
            {
                currentQuestionSet.Status = "INPROGRESS";
                var result = stenerManagement.SubmitQuestionSet(currentQuestionSet);

                if (result)
                    completeStenerStatusLabel.Text = "Saved Successfully!";
                else
                    completeStenerStatusLabel.Text = "Error Saving!";
            }

            questionCountTextBox.Text = "";
            questionBodyTextBox.Text = "";
            complianceCheckBox.Checked = false;
            planForSolutionTextBox.Text = "";
            evidenceLocationTextBox.Text = "";
            answerTextBox.Text = "";

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
            ;

            currentQuestion = 1;
            currentQuestionSet = null;

            refreshQuestionSetList();
            completeStenerStatusLabel.Text = "Closed Successfully!";
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            // check that the answer is not empty
            // check the stuff for compliance
            var passed = false;
            if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
                if (answerTextBox.Text != "")
                {
                    if (complianceCheckBox.Checked)
                    {
                        if (evidenceLocationTextBox.Text != "")
                        {
                            currentQuestionSet.Questions[currentQuestion - 1].Answer = answerTextBox.Text;
                            currentQuestionSet.Questions[currentQuestion - 1].Compliance = complianceCheckBox.Checked;
                            currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation =
                                evidenceLocationTextBox.Text;
                            currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution = "";

                            passed = true;
                        }
                    }
                    else
                    {
                        if (planForSolutionTextBox.Text != "")
                        {
                            currentQuestionSet.Questions[currentQuestion - 1].Answer = answerTextBox.Text;
                            currentQuestionSet.Questions[currentQuestion - 1].Compliance = complianceCheckBox.Checked;
                            currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation = "";
                            currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution =
                                planForSolutionTextBox.Text;

                            passed = true;
                        }
                    }
                }

            if (passed || currentQuestionSet.Status == "SUBMITTED" || currentQuestionSet.Status == "APPROVED")
                if (currentQuestion - 1 > 0)
                {
                    currentQuestion = currentQuestion - 1;
                    questionCountTextBox.Text = currentQuestion + "/" + currentQuestionSet.Questions.Count;
                    questionBodyTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].QuestionText;
                    complianceCheckBox.Checked = currentQuestionSet.Questions[currentQuestion - 1].Compliance;
                    answerTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].Answer;
                    planForSolutionTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution;
                    evidenceLocationTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation;

                    if (currentQuestion == currentQuestionSet.Questions.Count)
                    {
                        nextButton.Enabled = false;
                        if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
                            submitQuestionSetButton.Enabled = true;
                    }
                    else
                    {
                        nextButton.Enabled = true;
                        submitQuestionSetButton.Enabled = false;
                    }

                    if (currentQuestion > 1)
                        backButton.Enabled = true;
                    else
                        backButton.Enabled = false;
                }
        }
    }
}