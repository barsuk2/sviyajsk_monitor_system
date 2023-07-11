using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SviyajskMonitorSystem.Models
{
    public class CulcherObject: AbstractEnttity
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Введите Имя ОКН")]
        [Display(Name = "имя")]
        public string name { get; set; }
    
        public string bandlepath { get; set; }     
    }
}