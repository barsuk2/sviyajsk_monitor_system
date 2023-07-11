using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DynamicFields
{
    public class TreeElement
    {
        [Key]
        public long id { get; set; }
        public string identifier { get; set; }
        public virtual TreeElement parent { get; set; }
        public virtual List<TreeElement> children { get; set; }
        public virtual Element materialobject { get; set; }
        public virtual List<AbstractAttributeValue> values { get; set; }
        public virtual TreeType type { get; set; }
        public virtual TreeRoot root { get; set; }
    }
}
