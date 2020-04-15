using System;
using System.Windows.Forms;
using System.IO;

namespace BRAINS
{
    public partial class Business : Form
    {
        // local variables for various management objects
        private readonly UserData currentUser;
        private readonly StenerManagement stenerManagement;
        private readonly ViolationManagement violationManagement;
        private int currentQuestion;
        private QuestionSet currentQuestionSet;

        // Default constructor
        public Business()
        {
            InitializeComponent();
            stenerManagement = new StenerManagement();
            violationManagement = new ViolationManagement();
        }

        // constructor accepting the current user object as parameter
        public Business(UserData user)
        {
            InitializeComponent();
            currentUser = user;
            stenerManagement = new StenerManagement();
            violationManagement = new ViolationManagement();
        }

        // Event handler for the violations refresh button
        private void BusinessViolationsRefreshButton_Click(object sender, EventArgs e)
        {
            BusinessViolationList.Items.Clear();

            // get all violations corresponding to the user's department
            var violations = violationManagement.GetDepartmentViolations(currentUser.DepartmentUid);
            //loop through each violation to populate the UI list
            foreach (var violate in violations)
            {
                // create a string array for the view's row.
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

        //refresh question set event handler
        private void RefreshCompleteList_Click(object sender, EventArgs e)
        {
            RefreshQuestionSetList();
        }

        // used to refresh the all question sets in the UI list
        private void RefreshQuestionSetList()
        {
            // verify that the current user is valid
            if (currentUser == null)
            {
                completeStenerStatusLabel.Text = "No valid user logged in!";
                return;
            }

            // retrieve current user's uid
            var currentUserDepartmentUid = currentUser.DepartmentUid;

            //get all question sets for the department
            var qSets = stenerManagement.GetQuestionSetsForDepartment(currentUserDepartmentUid);
            completeQuestionSetListView.Items.Clear();

            // loop through each question set that was retrieved
            foreach (var qSet in qSets)
            {
                string[] row =
                {
                    qSet.Priority.ToString(), qSet.UniqueID.ToString(), qSet.Questions.Count.ToString(),
                    qSet.DueDate.ToString("MM/dd/yyyy"), qSet.Status, qSet.Category,
                    qSet.SubmittedDate.Equals(new DateTime()) ? "" : qSet.SubmittedDate.ToString("MM/dd/yyyy")
                };
                var listItem = new ListViewItem(row);

                // add the data to the ui.
                completeQuestionSetListView.Items.Add(listItem);
            }
        }

        // event handler for selecting a stener to work on.
        private void WorkOnSelectedStenerButton_Click(object sender, EventArgs e)
        {
            // verify that a q-set is actually selected
            if (completeQuestionSetListView.SelectedItems.Count > 0)
            {
                var qSetID = Convert.ToInt32(completeQuestionSetListView.SelectedItems[0].SubItems[1].Text);

                // retrieve the current question set from the db
                currentQuestionSet = stenerManagement.GetQuestionSet(qSetID);

                if (currentQuestionSet != null)
                {
                    currentQuestion = 1;

                    // disable editing of the question set if it has been approved or is still in the review process
                    if (currentQuestionSet.Status == "SUBMITTED" || currentQuestionSet.Status == "APPROVED")
                    {
                        // disable text boxes
                        answerTextBox.Enabled = false;
                        evidenceLocationTextBox.Enabled = false;
                        complianceCheckBox.Enabled = false;
                        planForSolutionTextBox.Enabled = false;

                        // handle button activations
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

                    // populate the text boxes with the question's data
                    questionCountTextBox.Text = currentQuestion + "/" + currentQuestionSet.Questions.Count;
                    questionBodyTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].QuestionText;
                    complianceCheckBox.Checked = currentQuestionSet.Questions[currentQuestion - 1].Compliance;
                    answerTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].Answer;
                    planForSolutionTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution;
                    evidenceLocationTextBox.Text = currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation;

                    // enable editing if the question has not been approved and is not in the review process
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

                    // if this is this last question disable the next button
                    if (currentQuestion == currentQuestionSet.Questions.Count)
                    {
                        nextButton.Enabled = false;
                        if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
                            submitQuestionSetButton.Enabled = true;
                    }
                    // otherwise enable the next button
                    else
                    {
                        nextButton.Enabled = true;
                        submitQuestionSetButton.Enabled = false;
                    }

                    // enable back if this is not the first question
                    if (currentQuestion > 1)
                        backButton.Enabled = true;
                    // otherwise disable it.
                    else
                        backButton.Enabled = false;
                }
            }
        }

        // Event handler for when the compliance check box is checked
        private void ComplianceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // enable the evidence input section if the question set is modifiable 
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

        // next button event handler
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

                    // enable evidence input if in compliance
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
                    // otherwise enable the plan for solution input sections
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

            // if the question set is submitted or approved, display data.
            if (passed || currentQuestionSet.Status == "SUBMITTED" || currentQuestionSet.Status == "APPROVED")
                if (currentQuestion + 1 <= currentQuestionSet.Questions.Count)
                {
                    // set the ui elements.
                    currentQuestion += 1;
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

        // event handler for pressing the submit button
        private void SubmitQuestionSetButton_Click(object sender, EventArgs e)
        {
            // if submission is allowed
            if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
            {
                var passed = false;
                // verify the text entries are not empty
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
                        // verify solution text box is not empty
                        if (planForSolutionTextBox.Text != "")
                        {
                            currentQuestionSet.Questions[currentQuestion - 1].EvidenceLocation = "";
                            currentQuestionSet.Questions[currentQuestion - 1].PlanForSolution =
                                planForSolutionTextBox.Text;

                            passed = true;
                        }
                    }
                }

                // if the data entered is valid data
                if (passed)
                {
                    // update the question set's status and submission data
                    currentQuestionSet.Status = "SUBMITTED";
                    currentQuestionSet.SubmittedDate = DateTime.Now;
                    var result = stenerManagement.SubmitQuestionSet(currentQuestionSet);

                    if (result)
                    {
                        // clear entry fields
                        questionCountTextBox.Text = "";
                        questionBodyTextBox.Text = "";
                        complianceCheckBox.Checked = false;
                        planForSolutionTextBox.Text = "";
                        evidenceLocationTextBox.Text = "";
                        answerTextBox.Text = "";

                        // disable input boxes
                        answerTextBox.Enabled = false;
                        complianceCheckBox.Enabled = false;
                        planForSolutionTextBox.Enabled = false;
                        evidenceLocationTextBox.Enabled = false;

                        // disable/enable buttons
                        backButton.Enabled = false;
                        nextButton.Enabled = false;
                        saveAndCloseSetButton.Enabled = false;
                        submitQuestionSetButton.Enabled = false;
                        completeQuestionSetListView.Enabled = true;
                        workOnSelectedStenerButton.Enabled = true;
                        refreshCompleteListButton.Enabled = true;

                        RefreshQuestionSetList();

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

        // event handler for hitting the save/close button when completing a question set.
        private void SaveAndCloseSetButton_Click(object sender, EventArgs e)
        {
            if (currentQuestionSet.Status != "SUBMITTED" && currentQuestionSet.Status != "APPROVED")
            {
                // update the status of the q set
                currentQuestionSet.Status = "INPROGRESS";
                var result = stenerManagement.SubmitQuestionSet(currentQuestionSet);

                // display the status of saving or loading
                if (result)
                    completeStenerStatusLabel.Text = "Saved Successfully!";
                else
                    completeStenerStatusLabel.Text = "Error Saving!";
            }

            // clear the input fields
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

            // refresh the ui lists
            RefreshQuestionSetList();
            completeStenerStatusLabel.Text = "Closed Successfully!";
        }

        // event handler for pressing the back button
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

        public void EvidenceLocationButton_Click(object sender, EventArgs e)
        {
            // Show File Dialog Screen
            DialogResult dialog = openFileDialog1.ShowDialog(); 

            // Test the result
            if (dialog == DialogResult.OK) 
            {
                string file = openFileDialog1.FileName;

                string[] f = file.Split('\\');
                
                // Get File Name
                string fn = f[(f.Length) - 1];
                string dest = @"C:\Users\15862\Documents\GitHub\BRAINS\BRAINS" + fn;

                // Copy file to destination folder
                File.Copy(file, dest, true);

                // Get current QuestionSet
                var qSetID = Convert.ToInt32(completeQuestionSetListView.SelectedItems[0].SubItems[1].Text);

                // Save to database
                string q = "INSERT INTO [Brains].dbo.StenerTable VALUES('" + fn + "','" + dest + "') WHERE StenerSetUID = "+qSetID;

                //Use Sql manager to query database
                SqlManager.QueryDatabase(q);

                // Show success
                MessageBox.Show("Success");
            }

        }
    }
}