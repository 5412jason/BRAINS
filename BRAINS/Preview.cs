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
            resultStr += " " + resultsByID.AssignedDepartment + "\r\n";
            resultStr += "Category : ";
            resultStr += " " + resultsByID.Category + "\r\n";
            resultStr += "Due Date : ";
            resultStr += " " + resultsByID.DueDate + "\r\n";
            resultStr += "Priority : ";
            resultStr += " " + resultsByID.Priority + "\r\n";
            resultStr += "Question Count: ";
            resultStr += " " + resultsByID.QuestionCount + "\r\n";
            resultStr += "Submitted Date : ";
            resultStr += " " + resultsByID.SubmittedDate + "\r\n";
            resultStr += "Unique ID : ";
            resultStr += " " + resultsByID.UniqueID + "\r\n";
            resultStr += "Violated : ";
            resultStr += " " + resultsByID.Violated + "\r\n";
            resultStr += "Status : ";
            resultStr += " " + resultsByID.Status + "\r\n";
           
            

            foreach (Question question in resultsByID.Questions)
            {
                resultStr += "Question ID: ";
                resultStr += question.QuestionID + "\r\n";
                resultStr += "Question: ";
                resultStr += question.QuestionText + "\r\n";
                resultStr += "Answer: ";
                resultStr += question.Answer + "\r\n";
                resultStr += "Evidence Location: ";
                resultStr += question.EvidenceLocation + "\r\n";
                resultStr += "Compliance: ";
                resultStr += question.Compliance + "\r\n";
                resultStr += "Plan For Solution: ";
                resultStr += question.PlanForSolution + "\r\n";

            }

            return resultStr;
        }
    }
}