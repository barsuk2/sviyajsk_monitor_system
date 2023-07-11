using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models.DynamicFields;

namespace SviyajskMonitorSystem.Models
{

    public class Point:IDeleteConnectedObj
    {
        [Key]
        public int Id { get; set; }

       
        public UnityPoint Unitypoint { get; set; }

        [Display(Name ="широта")]
        public float Latitude { get; set; }
        [Display(Name = "долгота")]
        public float Longitude { get; set; }
        [Display(Name = "высота")]
        public float Altitude { get; set; }

        [Display(Name ="Описание места")]
        public string Placedescription { get; set; }
       
       
       public virtual Storage StoragePlace { get; set; }
       
        public virtual Element Element { get; set; }

        public virtual List<TreeElement> Treeelements { get; set; }

        public virtual List<Sample> Samples { get; set; }

        public virtual List<Photo> Photos { get; set; }



        public void DeleteConnectedObj(ApplicationDbContext context)
        {
            //foreach(var an in analyze)
            //{
            //    an.DeleteConnectedObj(context);
            //}
            //context.analyzes.RemoveRange(analyze);
            //foreach(var ph in photos)
            //{
            //    ph.DeleteConnectedObj(context);
            //}
            //context.photos.RemoveRange(photos);
            //context.SaveChanges();
            //context.Point.Remove(this);
            //context.SaveChanges();
        }
    }


    public class Vector3
    {
        [Key]
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
}

