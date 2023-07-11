using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SviyajskMonitorSystem.Models
{
    public class Sector: AbstractEnttity
    {
        [Key]
        public int Id { get; set; }
        public string Number { get; set; }

        public Color Color { get; set; }

        public List<ChemistryElMassDole> Massdoles { get; set; }


        [JsonIgnore]
        public virtual List<Photo> Photos { get; set; }
        [JsonIgnore]
        public virtual Region Region { get; set; }
    }
}