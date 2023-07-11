using SviyajskMonitorSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models
{
    public interface IDeleteConnectedObj
    {
       void DeleteConnectedObj(ApplicationDbContext context);
    }
}
