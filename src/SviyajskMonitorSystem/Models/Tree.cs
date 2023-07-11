using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SviyajskMonitorSystem.Models
{
    public class Tree: AbstractEnttity
    {
        [Key]
        public  int id { get; set; }
        public string name { get; set; }

        [JsonIgnore]
        public virtual List<DendroChronologicalAnalyze> dchanalyze { get; set; }



        public override string ToString()
        {
            return name;
        }
    }
}