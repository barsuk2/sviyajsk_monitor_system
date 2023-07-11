using SviyajskMonitorSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DataViewModels
{
    public class PlaceViewModel
    {
       
        public bool haspoint;
        public bool hasgeocords;
        public Vector3 pos;
        public Vector3 dir;
        public int modelid;
        public Vector3 geocords;
        public int elementid;
        public string placedescription;
        public string[] photoids;
        public SampleViewModel sample;

        public UnityPoint CreateUnitypoint(ApplicationDbContext context)
        {
            UnityPoint up = new UnityPoint()
            {
                Direction = dir,
                Position = pos,
                Model = context.Models.FirstOrDefault(m => m.Id == modelid)
            };
            context.UnityPoints.Add(up);
            context.SaveChanges();
            return up;
        }

        public Point CreatePoint(ApplicationDbContext context)
        {
            Point p = new Point()
            {
                Placedescription = placedescription,
                Element=context.Element.FirstOrDefault(el=>el.Id==elementid)
            };
            if (hasgeocords)
            {
                p.Latitude = geocords.X;
                p.Longitude = geocords.Y;
                p.Altitude = geocords.Z;
            }
            if (photoids != null)
            {
                if (photoids.Length > 0)
                {
                    foreach (var id in photoids)
                    {
                        p.Photos.Add(context.Photos.FirstOrDefault(ph => ph.Id.ToString() == id));
                    }
                }
            }
            context.Point.Add(p);
            if (haspoint)
            {
                UnityPoint up = CreateUnitypoint(context);
                p.Unitypoint = context.UnityPoints.FirstOrDefault(u => u.Id == up.Id);
            }
            context.SaveChanges();
            return p;
        }

        public Sample CreateSample(ApplicationDbContext context)
        {
            Point point = CreatePoint(context);
            Sample s = new Sample()
            {
                Shifr = sample.shifr,
                Physical = sample.physical,
                Dateofget = DateTime.Parse( sample.date),
                Pperson = context.Person.FirstOrDefault(p => p.Id == sample.personid),
                Storage = context.Storage.FirstOrDefault(p => p.Id == sample.storageid),
                SamplePlace = context.Point.FirstOrDefault(pt => pt.Id == point.Id)
            };
            context.Samples.Add(s);
            context.SaveChanges();
            return s;
        }
    }
}
