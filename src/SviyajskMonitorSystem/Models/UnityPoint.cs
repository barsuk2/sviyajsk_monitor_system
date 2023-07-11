using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace SviyajskMonitorSystem.Models
{
    public class UnityPoint
    {
        [Key]
        public int Id { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Direction { get; set; }
        [JsonIgnore]
        public _3DModel Model { get; set; }

    }
}
