using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class CourseWiseTopicModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get;set; }
        public string TopicDescription { get; set; }    
    }
}
