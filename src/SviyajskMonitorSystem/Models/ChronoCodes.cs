using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SviyajskMonitorSystem.Models
{
    public class ChronoCodes: AbstractEnttity
    {
        [Key]
        public int id { get; set; }

        [JsonIgnore]
        public virtual List<DendroChronologicalAnalyze> dchanalyze { get; set; }
    }
}