using SviyajskMonitorSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DataViewModels
{
    public class SampleViewModel
    {
        public int pointid;
        public bool physical;
        public string date;
        public string shifr;
        public int personid;
        public int storageid;


        public Sample CreateSample(ApplicationDbContext context)
        {
            Sample s = new Sample()
            {
                Shifr = shifr,
                Physical = physical,
                Dateofget = DateTime.Parse( date),
                Pperson = context.Person.FirstOrDefault(p => p.Id == personid),
                Storage = context.Storage.FirstOrDefault(p => p.Id == storageid),
                SamplePlace = context.Point.FirstOrDefault(pt => pt.Id == personid)
            };
            context.Samples.Add(s);
            context.SaveChanges();
            return s;
        }
    }
}
