using Microsoft.AspNetCore.Mvc.Rendering;
using SviyajskMonitorSystem.Models.DynamicFields;
using SviyajskMonitorSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models
{
    public class AttributeKey
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public AttributeTypes type { get; set; }
        
        public EntityType entitytype { get; set; }



        public static explicit operator AttributeKey(string v)
        {
            throw new NotImplementedException();
        }

        public string gettype()
        {
            string attrtype = "text";
            if (type == AttributeTypes.intval || type == AttributeTypes.floatval)
            {
                attrtype = "number";
            }
            if (type == AttributeTypes.photo)
            {
                attrtype = "file";
            }
            return attrtype;
        }


        
       


    }

    public enum AttributeTypes
    {
        intval,
        floatval,
        stringval,
        Choosable,
        photo,
        elements
    }
}
