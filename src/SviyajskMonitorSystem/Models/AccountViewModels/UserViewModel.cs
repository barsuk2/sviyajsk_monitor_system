using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.AccountViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public bool isadmin { get; set; }
        public bool isresearcher { get; set; }
    }

}
