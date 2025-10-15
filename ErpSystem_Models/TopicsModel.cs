using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public  class TopicsModel
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }       
   
        public int Flag { get; set; }
    }
}
