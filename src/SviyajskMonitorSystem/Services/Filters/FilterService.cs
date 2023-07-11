using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Models;
using SviyajskMonitorSystem.Models.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SviyajskMonitorSystem.Data;

namespace SviyajskMonitorSystem.Services
{
    public class FilterService
    {
        public List<IFilter> filters;
        //public FiltersViewModel filtersData;

       // public BuildFilters



        public List<Analyze> DoFilter(List<Analyze> analyzes, ApplicationDbContext context)
        {
            foreach (var filter in filters)
            {
                analyzes = filter.DoFilter(analyzes, context);
            }
            return analyzes;
        }
    }
}
