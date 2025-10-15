using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem_Models
{
    public class TopicModelCheckbox
    {
        public int TopicId { get; set; }
        public string TopicName {  get; set; }
        public bool Iselected {  get; set; }
    }
}
