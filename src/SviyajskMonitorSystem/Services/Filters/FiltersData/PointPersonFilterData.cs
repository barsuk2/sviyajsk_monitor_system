using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Services.Filters
{
    public class PointPersonFilterData:IFilterData
    {
        List<int> personids;

        public IFilter CreateFilter()
        {
            throw new NotImplementedException();
        }
    }
}
