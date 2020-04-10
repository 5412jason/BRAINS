namespace BRAINS
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public string Answer { get; set; }

        public string EvidenceLocation { get; set; }

        public bool Compliance { get; set; }

        public string PlanForSolution { get; set; }
    }
}