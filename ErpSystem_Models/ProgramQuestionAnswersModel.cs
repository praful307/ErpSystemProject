using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class ProgramQuestionAnswersModel
    {
        public int ProgramAnswerId { get; set; }
        public int ProgramQuestionId { get; set; }
        public string Question { get; set; }
        public string ProgramingAnswer { get; set; } 
        public int Flag { get; set; }
     
    }
}
