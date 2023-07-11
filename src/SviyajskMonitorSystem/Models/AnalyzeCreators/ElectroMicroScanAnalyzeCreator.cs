using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SviyajskMonitorSystem.Data;

namespace SviyajskMonitorSystem.Models.AnalyzeCreators
{
    public class ElectroMicroScanAnalyzeCreator : AnalyzeCreator
    {

       public List<Region> regions;
       


        public ElectroMicroScanAnalyzeCreator(string shifr, DateTime date, int personid) : base(shifr, date, personid)
        {
        }

       

        public override Analyze Create(ApplicationDbContext context)
        {
            ElectroMicroScanAnalyze an = new ElectroMicroScanAnalyze();
            an.Type = AnalyzeType.electronnayamicroscopiya;
            an.Regions = new List<Region>();
            an= (ElectroMicroScanAnalyze)SetBaseData( an,context);
            List<int> regs = AddRegions(regions,context);
            context.ElMsAnalyze.Add(an);
            an.Regions.AddRange(context.Regions.Where(r => regs.Contains(r.Id)));
            context.SaveChanges();
            return an;
        }


        public List<int> AddRegions(List<Region> regions, ApplicationDbContext context)
        {
            List<int> regionids = new List<int>();
            foreach(var region in regions)
            {
                List<int> sectorsids = Addsectors(region.Sectors,context);
                context.Add(region);
                region.Sectors.AddRange(context.Sectors.Where(s => sectorsids.Contains(s.Id)));
               
                context.SaveChanges();
                regionids.Add(region.Id);
            }
            return regionids;
        }

        public List<int> Addsectors(List<Sector> sectors, ApplicationDbContext context)
        {
            List<int> sectorids = new List<int>();
            foreach(var sector in sectors)
            {
                List<int> mdids = AddMsaaDoles(sector.Massdoles, context);
                sector.Color = context.Color.FirstOrDefault(c => c.id == sector.Color.id);
                context.Sectors.Add(sector);
               
                sector.Massdoles.AddRange(context.ChemistryElMassDole.Where(md => mdids.Contains(md.Id)));
                context.SaveChanges();
                sectorids.Add(sector.Id);
            }
            return sectorids;
        }

        public List<int> AddMsaaDoles(List<ChemistryElMassDole> massdoles, ApplicationDbContext context)
        {
            List<int> mdids = new List<int>();
            foreach(var md in massdoles)
            {
                md.Chelement = context.ChemistryElement.FirstOrDefault(chel => chel.id == md.Chelement.id);
                context.ChemistryElMassDole.Add(md);
                context.SaveChanges();
                mdids.Add(md.Id);
            }
            return mdids;
        }

    }
}
