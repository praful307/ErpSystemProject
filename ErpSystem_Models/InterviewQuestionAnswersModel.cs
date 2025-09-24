using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class InterviewQuestionAnswersModel
    {
        public int AnswerId { get; set; }
        public int InterviewQuestionId { get; set; }
        public string InterviewQuestion { get; set; }
        public string QuestionExplaintion { get; set; }

        public string InterviewAnswers { get; set; }
        public string AnswerExplaintion{ get; set; }


        public int Flag { get; set; }
      
    }
}
