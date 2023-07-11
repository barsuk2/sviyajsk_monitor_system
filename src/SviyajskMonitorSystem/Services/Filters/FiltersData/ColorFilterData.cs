using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Services.Filters.FiltersData
{
    public class ColorFilterData : IFilterData
    {
        public List<int> colorids;
        public IFilter CreateFilter()
        {
            throw new NotImplementedException();
        }
    }
}
