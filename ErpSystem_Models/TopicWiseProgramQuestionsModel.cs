using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class TopicWiseProgramQuestionsModel
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int ContentId { get;set; }
        public int ContentName { get;set; }
        public int ProgramQuestionId { get; set; }
        public string Question { get; set; }
        public int Flag { get; set; }
 
       
    }
}
