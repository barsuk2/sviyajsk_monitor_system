using SviyajskMonitorSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Services
{
    public interface IFilterData
    {

        //This method creates filter of needed type
        IFilter CreateFilter();
       

    }
}
