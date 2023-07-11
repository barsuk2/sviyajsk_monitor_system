using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models
{
    public class TreeType:IChoosable
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<AttributeKey> keys { get; set; }

        public string getid()
        {
            return id.ToString();
        }

        public string getlistname()
        {
            return "treetypes";
        }

        public string getvalue()
        {
            return name;
        }
    }
}
