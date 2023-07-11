using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DynamicFields
{
    public class FloatAttributeValue:AbstractAttributeValue
    {
        public float floatvalue { get; set; }
        [NotMapped]
        public float value {get
            {
                return floatvalue;
            }
        }

        public override string getvalue()
        {
           return value.ToString();
        }
    }
}
