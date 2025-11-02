using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class TopicAndContentWiseMcqsQuestionsModel
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public int ContentId { get; set; }
        public string ContentName { get; set; }
        public string ContentDescription { get; set; }
        public int McqsQuestionId { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string CorrectAnswer { get; set; }
        public string AnswerExplaination { get; set; } = null!;
        public string Flag { get; set; }
    }
}
