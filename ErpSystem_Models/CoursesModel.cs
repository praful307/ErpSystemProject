using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class CoursesModel
    {
       public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }
        public int Flag { get; set; }
    }
}
