using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Services
{
    public interface IFilter
    {


        

        List<Analyze> DoFilter(List<Analyze> analyzes, ApplicationDbContext context);

    }
}
