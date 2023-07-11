using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DynamicFields
{
    public class ElementsAttributeValue : AbstractAttributeValue
    {
        public string MatObjects { get; set; }


        public override string getvalue()
        {
            return "MatObjects";
        }
    }
}
