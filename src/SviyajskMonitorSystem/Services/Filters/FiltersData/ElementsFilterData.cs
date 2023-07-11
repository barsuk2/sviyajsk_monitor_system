using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Services.Filters.FiltersData
{
    public class ElementsFilterData:IFilterData
    {
        public int elid;
        public bool needrange;
        public float max;
        public float min;

        public IFilter CreateFilter()
        {
            throw new NotImplementedException();
        }
    }
}
