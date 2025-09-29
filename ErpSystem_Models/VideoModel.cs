using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class VideoModel
    {
        public int VideoId { get; set; }
        public string VideoTitle { get; set; } = null!;
    
        public string VideoUrl { get; set; } = null!;
        public int ContentId { get; set; }
        public string ContentName { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string ContentDescription{ get; set; }
        public int Flag { get; set; }
    
    }
}
