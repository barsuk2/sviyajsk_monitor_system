using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models
{
    public class _3DModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Element Element { get; set; }
        public List<UnityPoint> Unitypoints { get; set; }
    }
}
