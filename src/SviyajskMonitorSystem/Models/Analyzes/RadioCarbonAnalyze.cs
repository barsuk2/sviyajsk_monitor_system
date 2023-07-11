using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.Serialization;
using Newtonsoft.Json;
using SviyajskMonitorSystem.Data;

namespace SviyajskMonitorSystem.Models
{
    public class RadioCarbonAnalyze:Analyze
    {
        public int Labdatingnumber { get; set; }
        public int Rcdate { get; set; }
        public float Error { get; set; }
        [JsonIgnore]
        public virtual List<Dating> Datings { get; set; }

        public Tree TreeType { get; set; }

        public override void DeleteConnectedObj(ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }
    }
}