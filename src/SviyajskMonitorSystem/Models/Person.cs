using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SviyajskMonitorSystem.Models
{
   public class Person: AbstractEnttity,IChoosable
    {
       public int Id{ get; set; }
        [Required(ErrorMessage = "Введите имя")]
        [Display(Name ="Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите фамилию")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [JsonIgnore]
        public virtual List<Analyze> Analyses { get; set; }



        public override string ToString()
        {
            return Name+" "+Surname;
        }

        public string getid()
        {
            return Id.ToString();
        }

        public string getvalue()
        {
            return Name + " " + Surname;
        }

        public string getlistname()
        {
            return "Person";
        }
    }
}
