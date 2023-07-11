using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SviyajskMonitorSystem.Models
{
    public class Color: AbstractEnttity,IChoosable
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Введите название цвета")]
        [Display(Name = "Цвет")]
        public string name { get; set; }

        [JsonIgnore]
        public virtual List<RentgenFluoriscAnalyze> rfanalyze{ get; set; }

        public string getid()
        {
            return id.ToString();
        }

        public string getlistname()
        {
           return "Colors";
        }

        public string getvalue()
        {
            return name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}