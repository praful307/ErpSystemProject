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
        public string VideoDescription { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public int ContentId { get; set; }
        public int Flag { get; set; }
        public virtual TopicContentsModel Contents { get; set; } 
    }
}
