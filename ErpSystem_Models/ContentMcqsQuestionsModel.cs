using System;
using System.Collections.Generic;
using System.Linq   
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class ContentMcqsQuestionsModel
    {
        public int McqsQuestionId { get; set; }
   
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int ContentId { get; set; }
        public string ContentName { get; set; }
        public string ContentDescription { get; set; }
        public string Question { get; set; } = null!;
        public string OptionA { get; set; } = null!;
        public string OptionB { get; set; } = null!;
        public string OptionC { get; set; } = null!;
        public string OptionD { get; set; } = null!;
        public int CorrectAnswer { get; set; } = null!;
        public string AnswerExplaination { get; set; } = null!;
        public int Flag { get; set; }
      
    }
}
