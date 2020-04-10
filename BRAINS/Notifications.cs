using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace BRAINS
{
    public class Notifications
    {
        private readonly StenerManagement stenerManagement = new StenerManagement();
        private UserData userToMonitor;

        public void StartProcess(UserData notificationsUser)
        {
            userToMonitor = notificationsUser;


            // Initial questions to compare

            var initialQuestionSets = stenerManagement.GetQuestionSetsForDepartment(notificationsUser.DepartmentUid);


            // Time parameters

            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(5);


            // Every 5 minutes this runs, if data, popup appears

            var timer = new Timer(e =>
            {
                var toBeDisplayed = RefreshNotifications(initialQuestionSets, userToMonitor);
                var totalString = "";

                if (toBeDisplayed != null)
                    foreach (var qs in toBeDisplayed)
                    {
                        var statusString = qs.Status;
                        totalString += "Status: " + statusString + " StenerSetID: ";
                        var idString = qs.UniqueID.ToString();
                        totalString += idString + "; ";
                    }

                MessageBox.Show(totalString);
            }, null, startTimeSpan, periodTimeSpan);
        }


        public List<QuestionSet> RefreshNotifications(List<QuestionSet> initQuestionSetList, UserData user)
        {
            // Gets List of QuestionSets that differ from initial at beginning of count
            var newQuestionSets = stenerManagement.GetQuestionSetsForDepartment(user.DepartmentUid);

            // If Admin user, return list of new question sets with status of submitted
            if (user.Permissions)
            {
                var adminUserQuestionSets = newQuestionSets.Except(initQuestionSetList).ToList();
                var userQsSubmitted = adminUserQuestionSets.FindAll(s => s.Status.Equals("submitted"));
                if (userQsSubmitted.Count > 0)
                    return userQsSubmitted;
                return null;
            }

            // If business user, return list of all new question sets

            var busUserQuestionSets = newQuestionSets.Except(initQuestionSetList).ToList();
            if (busUserQuestionSets.Count > 0)
                return busUserQuestionSets;
            return null;

            //It will query the database through the stenerManagement object every 5 minutes
            //The list of question sets that are known will be compared with the list that is retrieved from the database system.
            //If there are new updates(status = CREATED, SUBMITTED, REJECTED, APPROVED), then a dialog box will be displayed with the updated question set id.
            //For Business users: Only track created, rejected, and approved status.
            //For Oversight users: Only track Submitted status
        }
    }
}