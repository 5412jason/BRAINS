using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRAINS
{
    class StenerManagement
    {
        public StenerManagement() { }

        public List<QuestionSet> GetStenerList()
        {
            List<QuestionSet> steners = SqlManager.GetAllQuestionSets();

            return steners;
        }
    }
}
