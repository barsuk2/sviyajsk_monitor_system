using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SviyajskMonitorSystem.Data;

namespace SviyajskMonitorSystem.Models.AnalyzeCreators
{
    public class RfAnalyzeCreator : AnalyzeCreator
    {
        public RfAnalyzeCreator(string shifr, DateTime date, int personid ) : base(shifr, date, personid)
        {
        }

       

        public override Analyze Create(ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }
    }
}
