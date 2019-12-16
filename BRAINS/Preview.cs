using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAINS
{
    public class Preview
    {
        public string previewStener(int qID)
        {

            QuestionSet resultsByID = SqlManager.FindQuestionSet(qID);

            string resultStr = "";

            resultStr += "Assigned Department : ";
            resultStr += " " + resultsByID.AssignedDepartment + "\n";
            resultStr += "Category : ";
            resultStr += " " + resultsByID.Category + "\n";
            resultStr += "Due Date : ";
            resultStr += " " + resultsByID.DueDate + "\n";
            resultStr += "Priority : ";
            resultStr += " " + resultsByID.Priority + "\n";
            resultStr += "Question Count: ";
            resultStr += " " + resultsByID.QuestionCount + "\n";
            resultStr += "Submitted Date : ";
            resultStr += " " + resultsByID.SubmittedDate + "\n";
            resultStr += "Unique ID : ";
            resultStr += " " + resultsByID.UniqueID + "\n";
            resultStr += "Violated : ";
            resultStr += " " + resultsByID.Violated + "\n";
            resultStr += "Status : ";
            resultStr += " " + resultsByID.Status + " \n";
           
            

            foreach (Question question in resultsByID.Questions)
            {
                resultStr += "Question ID: ";
                resultStr += question.QuestionID + "\n";
                resultStr += "Question: ";
                resultStr += question.QuestionText + " ";
                resultStr += "Answer: ";
                resultStr += question.Answer + "\n";
                resultStr += "Evidence Location: ";
                resultStr += question.EvidenceLocation + "\n";
                resultStr += "Compliance: ";
                resultStr += question.Compliance + "\n";
                resultStr += "Plan For Solution: ";
                resultStr += question.PlanForSolution + "\n";

            }

            return resultStr;
        }
    }
}