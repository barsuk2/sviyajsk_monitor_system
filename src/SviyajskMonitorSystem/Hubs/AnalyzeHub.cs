using Microsoft.AspNetCore.SignalR;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Models.DataViewModels;
using SviyajskMonitorSystem.Services;
using SviyajskMonitorSystem.Models.AnalyzeCreators;
using Microsoft.Extensions.DependencyInjection;
using SviyajskMonitorSystem.Models.DynamicFields;

namespace SviyajskMonitorSystem.Hubs
{
    public class AnalyzeHub:Hub
    {

         ApplicationDbContext _context;

        private PlaceSamplesService _psservice;


        public AnalyzeHub(IServiceProvider sp, PlaceSamplesService psservice)
        {
            var services = sp.CreateScope();
            _context = services.ServiceProvider.GetService<ApplicationDbContext>();
            _psservice = psservice;
        }


        public override Task OnConnected()
        {
            //string s = "";
            return base.OnConnected();
        }
        public List<ElementViewModel> GetElements()
        {
            
            List<Element> elements = _context.Element.Include(el=>el.Parent).ToList();
            List < ElementViewModel > elementvm= new List<ElementViewModel>();
            foreach(var el in elements)
            {
                elementvm.Add(new ElementViewModel(el));
            }
           // string els = JsonConvert.SerializeObject(elements);
            return elementvm;
        }
#region GetItems
        public List<Organization> GetOrgs()
        {
            List<Organization> orgs = _context.Organizations.ToList();
            return orgs ;
        }


        public List<Storage> GetStorageByOrg(int orgid)
        {
            return _context.Organizations.Include(org => org.Storages).FirstOrDefault(org => org.Id == orgid).Storages.ToList();
        }



        public List<OldPlaceViewModel> GetPlaces()
        {

            List<Point> points = _context.Point.Include(p => p.Element).Include(p => p.Unitypoint).Include(p=>p.Unitypoint.Direction).Include(p=>p.Unitypoint.Position).Include(p=>p.Samples).ToList();
            List<OldPlaceViewModel> oldp = new List<OldPlaceViewModel>();
            foreach(var point in points)
            {
                OldPlaceViewModel op = new OldPlaceViewModel()
                {
                    pointid = point.Id,
                    elementpath = LowLevelHelper.GetAllParents(_context, point.Element.Id)
                };
                if (point.Unitypoint != null)
                {
                    op.pos = point.Unitypoint.Position;
                    op.dir = point.Unitypoint.Direction;
                }
                foreach(var s in point.Samples)
                {
                    op.samplecodes += s.Shifr;
                    op.samplecodes += "; ";
                }
                oldp.Add(op);
            }

            return oldp;
        }

        public List<OldSampleViewModel> GetSamples()
        {

            List<Sample> samples = _context.Samples.Include(s => s.SamplePlace).Include(s=>s.Analyzes).Include(s=>s.Pperson).Include(s => s.SamplePlace.Unitypoint.Direction).Include(s => s.SamplePlace.Unitypoint.Position).Include(s => s.SamplePlace.Element).Include(s => s.Pperson).Include(s => s.Storage).Where(s=>s.Physical).ToList();
            List<OldSampleViewModel> old = new List<OldSampleViewModel>();
            foreach (var sample in samples)
            {
                OldPlaceViewModel op = new OldPlaceViewModel()
                {
                    pointid = sample.SamplePlace.Id,
                    elementpath = LowLevelHelper.GetAllParents(_context, sample.SamplePlace.Element.Id)
                };
                if (sample.SamplePlace.Unitypoint != null)
                {
                    op.pos = sample.SamplePlace.Unitypoint.Position;
                    op.dir = sample.SamplePlace.Unitypoint.Direction;
                }
                OldSampleViewModel os = new OldSampleViewModel()
                {
                    place = op,
                    sampleid = sample.Id,
                    shifr = sample.Shifr,
                    date=sample.Dateofget,
                    researcher=sample.Pperson
                   
                };
                foreach(var an in sample.Analyzes)
                {
                    os.researchCodes += an.Number;
                    os.researchCodes += "; ";
                }
                old.Add(os);
            }

            return old;
        }

#endregion
        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }


        public void SetNewPlace(PlaceViewModel psvm)
        {

             _psservice.newplaces.Add(Context.ConnectionId, psvm);
            Clients.Caller.ON_POINT_SENDED();
            Clients.Caller.AN_CREATOR_LOADED(psvm.sample.physical);
        }


        public void SetAnalyze(AnalyzeBaseViewModel baseData)
        {
           // AnalyzeCreator creator=null;
            
            _psservice.creators.Add(Context.ConnectionId, baseData);
            Clients.Caller.ANALYZE_SENDED(AnTypeToComponent(baseData.type));
        }

        public void SetExistingPlace(SampleViewModel samplevm)
        {
            _psservice.newsample.Add(Context.ConnectionId, samplevm);
            Clients.Caller.ON_POINT_SENDED();
            Clients.Caller.AN_CREATOR_LOADED(samplevm.physical);

        }


        public void SetExistingSample(int sampleid)
        {
            _psservice.sampleid.Add(Context.ConnectionId, sampleid);
            Clients.Caller.ON_POINT_SENDED();
            Clients.Caller.AN_CREATOR_LOADED(true);
        }



        public void CreateElEmScanAnalyze(Region[] regions)
        {
            _psservice.creators.TryGetValue(Context.ConnectionId, out AnalyzeBaseViewModel basedata);
            bool newplace =  _psservice.newplaces.TryGetValue(Context.ConnectionId, out PlaceViewModel place);
            bool newsample = _psservice.newsample.TryGetValue(Context.ConnectionId, out SampleViewModel nsample);
            bool oldsample = _psservice.sampleid.TryGetValue(Context.ConnectionId, out int sampleid);
            if (newplace)
            {
              Sample s=  place.CreateSample(_context);
                ElectroMicroScanAnalyzeCreator creator = new ElectroMicroScanAnalyzeCreator(basedata.shifr, basedata.date, basedata.personid)
                {
                    sampleid = s.Id,
                    regions = regions.ToList()
                };
                creator.Create(_context);
            }
            if (newsample)
            {
                Sample s = nsample.CreateSample(_context);
                ElectroMicroScanAnalyzeCreator creator = new ElectroMicroScanAnalyzeCreator(basedata.shifr, basedata.date, basedata.personid)
                {
                    sampleid = s.Id,
                    regions = regions.ToList()
                };
                creator.Create(_context);
            }
            if (oldsample)
            {
                ElectroMicroScanAnalyzeCreator creator = new ElectroMicroScanAnalyzeCreator(basedata.shifr, basedata.date, basedata.personid)
                {
                    sampleid = sampleid,
                    regions = regions.ToList()
                };
                creator.Create(_context);
            }
            Clients.Caller.DATA_SENDED(0);

        }



        public List<ElementViewModel> GetTreeEls(int elid, string typename)
        {
            TreeRoot root = _context.Roots.Include(r => r.elements).ThenInclude(els => els.parent).Include(r => r.element).FirstOrDefault(r => r.element.Id == elid && r.treetype.name == typename);
            List<ElementViewModel> elementvm = new List<ElementViewModel>();
            foreach (var item in root.elements)
            {
                elementvm.Add(new ElementViewModel(item));
            }
            return elementvm;
        }




        private int AnTypeToComponent(AnalyzeType type)
        {
            switch (type)
            {
                case AnalyzeType.MicroBiologicalAnalyzes:return 4;
                   
                case AnalyzeType.rentgenfluoriscentnyi:return 3;
                   
                case AnalyzeType.electronnayamicroscopiya:return 2;
                   
                case AnalyzeType.DendroChronologicalAnalyzes:return 5;
                   
                default:return 0;
            }
        }

    }
}
