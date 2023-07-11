using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DynamicFields
{
    public class PhotoAttributeValue : AbstractAttributeValue
    {

        public List<Photo> photos { get; set; }

        public override string getvalue()
        {
            return "photo";
        }
    }
}
