using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DynamicFields
{
    public class IntAttributeValue:AbstractAttributeValue
    {
        public int intvalue { get; set; }

        [NotMapped]
        public int value
        {
            get
            {
                return intvalue;
            }
        }

        public override string getvalue()
        {
           return value.ToString();
        }
    }
}
