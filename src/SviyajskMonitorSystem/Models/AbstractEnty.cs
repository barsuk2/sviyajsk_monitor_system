using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models
{
    public abstract class AbstractEnttity
    {
        [JsonIgnore]
        public string CreatedById { get; set; }
        [JsonIgnore]
        public string UpdatedById { get; set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; set; }
        [JsonIgnore]
        public DateTime LastUpdatedAt { get; set; }

        

        public void OnCreate(ApplicationUser user)
        {
            CreatedAt = DateTime.Now;
            CreatedById = user.Id;
        }


        public void OnUpdate(ApplicationUser user)
        {
           LastUpdatedAt = DateTime.Now;
          UpdatedById = user.Id;
        }




    }
}
