using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class CourseWiseContentModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int ContentId { get; set; }

        public string ContentName { get; set; }
        public string ContentDescription { get; set; }
    }

  
   
}
