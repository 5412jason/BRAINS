namespace BRAINS
{
    public class Preview
    {
        public string PreviewStener(int qID)
        {
            var questionSet = SqlManager.FindQuestionSet(qID);

            var resultStr = "";

            resultStr += "Assigned Department : ";
            resultStr += " " + questionSet.AssignedDepartment + "\r\n";
            resultStr += "Category : ";
            resultStr += " " + questionSet.Category + "\r\n";
            resultStr += "Due Date : ";
            resultStr += " " + questionSet.DueDate + "\r\n";
            resultStr += "Priority : ";
            resultStr += " " + questionSet.Priority + "\r\n";
            resultStr += "Question Count: ";
            resultStr += " " + questionSet.QuestionCount + "\r\n";
            resultStr += "Submitted Date : ";
            resultStr += " " + questionSet.SubmittedDate + "\r\n";
            resultStr += "Unique ID : ";
            resultStr += " " + questionSet.UniqueID + "\r\n";
            resultStr += "Violated : ";
            resultStr += " " + questionSet.Violated + "\r\n";
            resultStr += "Status : ";
            resultStr += " " + questionSet.Status + "\r\n";


            foreach (var question in questionSet.Questions)
            {
                resultStr += "Question ID: ";
                resultStr += question.QuestionId + "\r\n";
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