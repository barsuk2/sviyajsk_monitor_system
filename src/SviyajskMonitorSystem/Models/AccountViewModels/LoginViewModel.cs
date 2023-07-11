using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="EMail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}
