using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models
{
    public class Region
    {
        public int Id { get; set; }
        public List<Sector> Sectors { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
