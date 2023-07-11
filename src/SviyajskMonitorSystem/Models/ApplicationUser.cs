using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SviyajskMonitorSystem.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string name { get; set; }
        public string surname { get; set; }
        //public bool hasinfo { get; set; }

    }

    public enum Post
    {
        Admin,
        Laborant,
        Researcher,
        GroupLider
    }
}
