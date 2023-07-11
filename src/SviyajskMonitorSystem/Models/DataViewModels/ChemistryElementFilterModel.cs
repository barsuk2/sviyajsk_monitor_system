using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DataViewModels
{

    //model to chemistry element filter
    public class ChemistryElementFilterModel
    {
        public ChemistryElement element;
        public bool needrange;//true if we need range value of chemistry element mass dole
        public float minvalue;
        public float maxvalue;
    }
}
