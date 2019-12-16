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
            resultStr += " " + resultsByID.AssignedDepartment + " , ";
            resultStr += "Category : ";
            resultStr += " " + resultsByID.Category + " , ";
            resultStr += "Due Date : ";
            resultStr += " " + resultsByID.DueDate + " , ";
            resultStr += "Priority : ";
            resultStr += " " + resultsByID.Priority + " , ";
            resultStr += "Question Count: ";
            resultStr += " " + resultsByID.QuestionCount + " , ";
            resultStr += "Submitted Date : ";
            resultStr += " " + resultsByID.SubmittedDate + " , ";
            resultStr += "Unique ID : ";
            resultStr += " " + resultsByID.UniqueID + " , ";
            resultStr += "Violated : ";
            resultStr += " " + resultsByID.Violated + " , ";
            resultStr += "Status : ";
            resultStr += " " + resultsByID.Status + " , ";
           
            

            foreach (Question question in resultsByID.Questions)
            {
                resultStr += "Question ID: ";
                resultStr += question.QuestionID + " , ";
                resultStr += "Question: ";
                resultStr += question.QuestionText + " , ";
                resultStr += "Answer: ";
                resultStr += question.Answer + " , ";
                resultStr += "Evidence Location: ";
                resultStr += question.EvidenceLocation + " ,";
                resultStr += "Compliance: ";
                resultStr += question.Compliance + " , ";
                resultStr += "Plan For Solution: ";
                resultStr += question.PlanForSolution + " , ";

            }

            return resultStr;
        }
    }
}