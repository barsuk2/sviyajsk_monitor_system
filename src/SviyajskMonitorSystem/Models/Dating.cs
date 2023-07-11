using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SviyajskMonitorSystem.Models
{
    public class Dating: AbstractEnttity
    {
        [Key]
        public int Id { get; set; }
        public int DateFrom { get; set; }
        public int DateTo { get; set; }
        public double Probability { get; set; }

       
        [JsonIgnore]
        public virtual RadioCarbonAnalyze Rcanalyze { get; set; }
    }
}