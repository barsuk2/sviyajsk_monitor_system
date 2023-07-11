using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SviyajskMonitorSystem.Models
{
    public class Organization: AbstractEnttity ,IChoosable
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название организации")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        public virtual List<Storage> Storages { get; set; }
        public string getid()
        {
            return Id.ToString();
        }

        public string getvalue()
        {
            return Name;
        }

        public string getlistname()
        {
            return "Organization";
        }
    }
}