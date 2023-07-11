using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models
{
    public class Storage
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Укажите название места")]
        [Display(Name ="Место хранения")]
        public string Place { get; set; }
        [JsonIgnore]
        public virtual Organization Organization { get; set; }
    }
}
