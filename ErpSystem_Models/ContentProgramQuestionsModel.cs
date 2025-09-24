using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class ContentProgramQuestionsModel
    {
        public int ProgramQuestionId { get; set; }
        public int ContentId { get; set; }
        public string Question { get; set; } = null!;
       
        public int Flag { get; set; }
        public virtual TopicContentsModel Contents { get; set; } = null!;
    }
}
