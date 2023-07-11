using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DynamicFields
{
    public class TreeRoot
    {
        [Key]
        public int id { get; set; }
        public Element element { get; set; }
        public TreeType treetype { get; set; }
        public List<TreeElement> elements { get; set; }
    }
}
