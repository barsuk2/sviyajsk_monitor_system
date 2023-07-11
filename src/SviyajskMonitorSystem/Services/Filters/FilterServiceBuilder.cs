using SviyajskMonitorSystem.Models.DataViewModels;
using SviyajskMonitorSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Services
{
    public class FilterServiceBuilder
    {
       public FilterService BuildFilterService(List<IFilterData> data)
        {
            FilterService service = new FilterService();
            
            foreach( var filterdata in data)
            {
                service.filters.Add(filterdata.CreateFilter());
            }
            return service;
        }
    }
}
