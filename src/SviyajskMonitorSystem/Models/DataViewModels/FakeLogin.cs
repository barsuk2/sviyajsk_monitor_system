using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DataViewModels
{
    public class FakeLogin
    {
        [Required(ErrorMessage = "Введите логин")]
        public string login { get; set; }
        [Required(ErrorMessage = "Введите пароль")]
        public string password { get; set; }
    }
}
