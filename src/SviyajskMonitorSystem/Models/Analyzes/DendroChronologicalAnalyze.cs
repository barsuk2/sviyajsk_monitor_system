using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.Serialization;
using Newtonsoft.Json;
using SviyajskMonitorSystem.Data;

namespace SviyajskMonitorSystem.Models
{
    public class DendroChronologicalAnalyze:Analyze
    {
        public int Roundscount { get; set; }
       
        public int DateFrom { get; set; }

        public int DateTo { get; set; }

        [JsonIgnore]
        public virtual Tree Tree { get; set; }
        [JsonIgnore]
        public virtual ChronoCodes Code { get; set; }

        public override void DeleteConnectedObj(ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }
    }
}