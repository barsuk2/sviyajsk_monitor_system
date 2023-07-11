using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Services.Filters
{
    public class PointDateFilterData:IFilterData
    {
        public DateTime fromdate;
        public DateTime todate;

        public IFilter CreateFilter()
        {
            throw new NotImplementedException();
        }
    }
}
