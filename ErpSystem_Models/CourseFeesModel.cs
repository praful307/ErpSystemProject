using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class CourseFeesModel
    {
        public int FeesId { get; set; }
        public string FeesMode { get; set; }
        public float FeesAmount { get; set; }
        public string Gst { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int Flag { get; set; }
    
    }
}
