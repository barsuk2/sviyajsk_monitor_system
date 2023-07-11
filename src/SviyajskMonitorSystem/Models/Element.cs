using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SviyajskMonitorSystem.Models
{
    public class Element: AbstractEnttity
    {
        [Key]
        public int Id { get; set; }
       // public string Shifr { get; set; }
        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "название")]
        public string Name { get; set; }


        [JsonIgnore]
        public virtual Element Parent { get; set; }
        [JsonIgnore]
        public virtual List<Element> Childs { get; set; }
        [JsonIgnore]
        public List<_3DModel> Models { get; set; }
        [JsonIgnore]
        public virtual List<Point> Point { get; set; }


        


    }
}