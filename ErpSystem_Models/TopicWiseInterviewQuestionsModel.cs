using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public  class TopicWiseInterviewQuestionsModel
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
   
      public int ContentId { get; set; }
      public string ContentName { get; set; }
        public int InterviewQuestionId { get; set; }
        public  string InterviewQuestion { get; set; }
        public string Explanation { get; set; }
        public int Flag { get; set; }
    }
}
