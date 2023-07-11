using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SviyajskMonitorSystem.Models

{
    
   public  class HasBactery: AbstractEnttity
    {
        [Key]
        public int Id { get; set; }
        public long Count { get; set; }

       // [JsonIgnore]
        public virtual Bacterya Bacterya { get; set; }
        [JsonIgnore]
        public virtual MicroBiologicalAnalyze Mbanalyze{ get; set; }
       
    }
}
