using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BRAINS
{
    public class Notifications
    {
        private UserData userToMonitor;
        StenerManagement stenerManagement = new StenerManagement();

        public void StartProcess(UserData notificationsUser)
        {
            userToMonitor = notificationsUser;


            // Initial questions to compare

            var initialQuestionSets = stenerManagement.GetQuestionSetsForDepartment(notificationsUser.DepartmentUID);


            // Time parameters
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);



            // Every 5 minutes this runs, if data, popup appears

            var timer = new System.Threading.Timer((e) => {

            var toBeDisplayed = RefreshNotifications(initialQuestionSets, userToMonitor);
            string totalString = "";

                if (toBeDisplayed != null)
                {
                    foreach(QuestionSet qs in toBeDisplayed)
                    {
                        var statusString = qs.Status.ToString();
                        totalString += statusString + " ";
                        var idString = qs.UniqueID.ToString();
                        totalString += idString + ", ";
                    }
                }
               MessageBox.Show(totalString);

            }, null, startTimeSpan, periodTimeSpan);

        }



        public void EndProcess()
        {
            //terminates thread
        }



        public List<QuestionSet> RefreshNotifications(List<QuestionSet> initQuestionSetList, UserData user)
        {

            // Gets List of QuestionSets that differ from initial at beginning of count
            var newQuestionSets = stenerManagement.GetQuestionSetsForDepartment(user.DepartmentUID);

            // If Admin user, return list of new question sets with status of submitted
            if (user.Permissions == true) 
            {
                var adminUserQuestionSets = newQuestionSets.Except(initQuestionSetList).ToList();
                var adminUserQSSubmitted = adminUserQuestionSets.FindAll(s => s.Status.Equals("submitted"));
                if (adminUserQSSubmitted.Count > 0)
                {
                    return adminUserQSSubmitted;
                }
                else
                    return null;
            }

            // If business user, return list of all new question sets
            else
            {
                var busUserQuestionSets = newQuestionSets.Except(initQuestionSetList).ToList();
                if (busUserQuestionSets.Count > 0)
                {
                    return busUserQuestionSets;
                }
                else
                    return null;
            }


            //It will query the database through the stenerManagement object every 5 minutes
            //The list of question sets that are known will be compared with the list that is retrieved from the database system.
            //If there are new updates(status = CREATED, SUBMITTED, REJECTED, APPROVED), then a dialog box will be displayed with the updated question set id.
            //For Business users: Only track created, rejected, and approved status.
            //For Oversight users: Only track Submitted status

        }
    }
}
