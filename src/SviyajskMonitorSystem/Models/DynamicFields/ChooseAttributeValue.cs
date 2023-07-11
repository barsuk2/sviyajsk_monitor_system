using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DynamicFields
{
    public class ChooseAttributeValue:AbstractAttributeValue
    {
       public EntityValue value { get; set; }

        public override string getvalue()
        {
            return value.value;
        }
    }
}
