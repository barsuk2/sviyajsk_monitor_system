using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SviyajskMonitorSystem.Models
{
    public class ChemistryElement: AbstractEnttity,IChoosable
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Введите полное имя")]
        [Display(Name = "полное имя")]
        public string fullname { get; set; }
        [Required(ErrorMessage = "Введите короткое имя")]
        [Display(Name = "Короткое имя")]
        public string shortname { get; set; }
        [JsonIgnore]
        public virtual List<ChemistryElMassDole> massdoles { get; set; }

        public string getid()
        {
            return id.ToString();
        }

        public string getvalue()
        {
            return shortname;
        }

        public string getlistname()
        {
            return "ChemistryElements";
        }
    }
}