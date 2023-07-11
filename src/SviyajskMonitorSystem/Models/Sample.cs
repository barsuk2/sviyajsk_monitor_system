using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models
{
    public class Sample
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Не указан шифр")]
        [Display(Name ="Шифр")]
        public string Shifr { get; set; }
        [Required(ErrorMessage ="Не указана дата изъятия")]
        [Display(Name ="дата изъятия")]
        public DateTime Dateofget { get; set; }
        [Required(ErrorMessage = "Не указан тип")]
        [Display(Name = "Физический")]
        public bool Physical { get; set; }



        public virtual Storage Storage { get; set; }

       // public virtual Organization Organization { get; set; }
        //[JsonIgnore]
        public virtual Person Pperson { get; set; }
        
        public virtual Point SamplePlace { get; set; }



        public virtual List<Analyze> Analyzes { get; set; }
    }
}
