using SviyajskMonitorSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.AnalyzeCreators
{
    public abstract class AnalyzeCreator
    {
        public string shifr;
        public DateTime date;
        public int personid;
        public bool newsample;
        public int sampleid;

       

        public AnalyzeCreator(string shifr,DateTime date,int personid)
        {
            this.shifr = shifr;
            this.date = date;
            this.personid = personid;
           // this.sampleid = sampleid;
           // this.newsample = newsamp;
        }


        public Analyze SetBaseData(Analyze analyze,ApplicationDbContext context)
        {
            analyze.Date = date;
            analyze.Number = shifr;
            analyze.Sample = context.Samples.FirstOrDefault(s => s.Id == sampleid);
            analyze.Person = context.Person.FirstOrDefault(p => p.Id == personid);
            return analyze;
        }

        public abstract Analyze Create(ApplicationDbContext context);

    }
}
