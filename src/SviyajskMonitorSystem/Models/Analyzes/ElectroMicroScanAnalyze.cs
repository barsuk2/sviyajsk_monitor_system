using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.Serialization;
using Newtonsoft.Json;
using SviyajskMonitorSystem.Data;

namespace SviyajskMonitorSystem.Models
{
    public class ElectroMicroScanAnalyze:Analyze
    {
        [JsonIgnore]
        public virtual List<Region> Regions { get; set; }

        public override void DeleteConnectedObj(ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }
    }
}