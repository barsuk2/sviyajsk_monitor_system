using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DynamicFields
{
    public class EntityValue
    {
        public int id { get; set; }
        [JsonIgnore]
        public EntityType type { get; set; }
        public string value { get; set; }
    }
}
