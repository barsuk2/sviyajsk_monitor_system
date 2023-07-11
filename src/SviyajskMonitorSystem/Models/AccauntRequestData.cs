using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models
{
    public class AccauntRequestData
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Укажите имя")]
        [Display(Name ="Имя")]
        public string name { get; set; }
        [Required(ErrorMessage = "Укажите фамилию")]
        [Display(Name = "Фамилия")]
        public string surname { get; set; }
        [Required(ErrorMessage = "Укажите email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Укажите корректный email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Укажите телефон")]
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Укажите корректный номер телефона")]
        public string phone { get; set; }
    }
}
