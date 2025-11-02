using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class CourseTopicsModel
    {
        public int CourseTopicId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public int ContentId { get; set; }
        public string ContentName { get; set; }
        public int Flag { get; set; }
 
    }
}
