using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAINS
{
    class Question
    {
        private int questionID;
        private string questionText;
        private string answer;
        private string evidenceLocation;
        private bool compliance;
        private bool violated;
        private string planForSolution;

        public int QuestionID { get => questionID; set => questionID = value; }
        public string QuestionText { get => questionText; set => questionText = value; }
        public string Answer { get => answer; set => answer = value; }
        public string EvidenceLocation { get => evidenceLocation; set => evidenceLocation = value; }
        public bool Violated { get => violated; set => violated = value; }
        public bool Compliance { get => compliance; set => compliance = value; }
        public string PlanForSolution { get => planForSolution; set => planForSolution = value; }
    }
}
