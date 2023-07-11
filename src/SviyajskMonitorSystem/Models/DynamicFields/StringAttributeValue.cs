using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DynamicFields
{
    public class StringAttributeValue:AbstractAttributeValue
    {
        public string stringvalue { get; set; }


        [NotMapped]
        public string value
        {
            get
            {
                return stringvalue;
            }
        }

        public override string getvalue()
        {
            return value;
        }
    }
}
