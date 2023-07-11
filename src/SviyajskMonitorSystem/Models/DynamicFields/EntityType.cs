using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DynamicFields
{
    public class EntityType:IChoosable
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


        public List<EntityValue> values { get; set; }

        public string getid()
        {
            return Id.ToString();
        }

        public string getlistname()
        {
           return "entitytypes";
        }

        public string getvalue()
        {
            return Name;
        }
    }
}
