using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DataViewModels
{
    //base data of analyzes returned by client
    public class AnalyzeBaseViewModel
    {
        public string shifr;
        public DateTime date;
        public int personid;
        public AnalyzeType type;
    }
}
