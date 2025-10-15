using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class TopicAndContentWiseProgramQuestionsModel
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int ContentId { get;set; }
        public string ContentName { get;set; }
        public string ContentDescription { get; set; }
        public int ProgramQuestionId { get; set; }
        public string Question { get; set; }
        public int Flag { get; set; }
 
       
    }
}
