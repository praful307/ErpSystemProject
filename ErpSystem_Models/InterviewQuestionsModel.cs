using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class InterviewQuestionsModel
    {
        public int InterviewQuestionId { get; set; }
        public string InterviewQuestion { get; set; } 
        public string Explaination { get; set; }
        public int ContentId { get; set; }
        public string ContentName { get; set; }
        public string ContentDescription { get; set; }

        public int Flag { get; set; }
    
    }
}
