using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models.AnalyzeCreators;
using SviyajskMonitorSystem.Models.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Services
{
    public class PlaceSamplesService
    {
        public Dictionary<string, PlaceViewModel> newplaces = new Dictionary<string, PlaceViewModel>();
        public Dictionary<string, SampleViewModel> newsample = new Dictionary<string, SampleViewModel>();
        public Dictionary<string, int> sampleid = new Dictionary<string, int>();
        public Dictionary<string, AnalyzeBaseViewModel> creators = new Dictionary<string, AnalyzeBaseViewModel>();
        //private ApplicationDbContext _context;
    }
}
