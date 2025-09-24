using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class InterviewQuestionAnswersModel
    {
        public int InterviewQuestionAnswerId { get; set; }
        public int InterviewQuestionId { get; set; }
        public string Answer { get; set; } = null!;
        public int Flag { get; set; }
        public virtual InterviewQuestionsModel InterviewQuestion { get; set; } 
    }
}
