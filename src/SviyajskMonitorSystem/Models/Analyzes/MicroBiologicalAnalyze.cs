using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using SviyajskMonitorSystem.Data;

namespace SviyajskMonitorSystem.Models
{

    public class MicroBiologicalAnalyze:Analyze
    {
       
        public long Count { get; set; }


        public int Proteznaya { get; set; }
        public int Lingnirazr { get; set; }
        public int Celluloznaya { get; set; }

        //  [JsonIgnore]
        public virtual List<HasBactery> Bacteries { get; set; }

        public override void DeleteConnectedObj(ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }
    }
}
