using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.ELEmScanViewModels
{
    public class SectorViewModel
    {
        public string number;
        public int colorid;
        public List<int> photos;
        public List<ChElementViewModel> chelements;
    }
}
