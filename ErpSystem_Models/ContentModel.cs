using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class ContentModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDecsription { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public int ContentId { get; set; }
        public string ContentName { get; set; }
        public string ContentDescription { get; set; }
        public int CourseTopicId { get; set; }
        public int Flag { get; set; }
    }
}
