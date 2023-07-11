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
    public class Bacterya: AbstractEnttity
    {
        [Key]
        public int id { get; set; }
        public string vidname { get; set; }
        public string rodname { get; set; }



        [JsonIgnore]
        public virtual List<HasBactery> bacteries { get; set; }



        public override string ToString()
        {
            return rodname + " " + vidname;
        }

    }
}
