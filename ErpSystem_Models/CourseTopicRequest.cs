using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public  class CourseTopicRequest
    {
        public int CourseId { get; set; }
        public List<TopicModelCheckbox> Topics {  get; set; }
    }
}
