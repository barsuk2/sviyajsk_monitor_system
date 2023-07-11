using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SviyajskMonitorSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DataViewModels
{
    public class RFPointViewModel
    {
      //  [Required(ErrorMessage = "Не указана широта")]
        [Display(Name ="Широта")]
        public float latitude { get; set; }

     //   [Required(ErrorMessage = "Не указана долгота")]
        [Display(Name = "Долгота")]
        public float longitude { get; set; }

      //  [Required(ErrorMessage = "Не указана высота")]
        [Display(Name = "Высота")]
        public float altitude { get; set; }

        [Required(ErrorMessage = "Не указан код образца")]
        [Display(Name = "Код образца")]
        public string shifr { get; set; }
        [Required(ErrorMessage = "Не указана дата взятия образца")]
        [Display(Name = "Дата взятия образца")]
        [DataType(DataType.Date)]
        public DateTime dateofget { get; set; }

        [Display(Name = "Описание места")]
        public string placedescription { get; set; }

        [Required(ErrorMessage = "Не указан код исследования")]
        [Display(Name = "Код исследования")]
        public string number { get; set; }

        [Required(ErrorMessage = "Не указана дата исследования")]
        [Display(Name = "Дата исследования")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        [Display(Name = "Цвет")]
        public int colorid { get; set; }

        [HiddenInput]
        [Required(ErrorMessage = "Не указан элемент")]
        [Display(Name = "Элемент")]
        public int elementid { get; set; }

        [Display(Name = "Художественный элемент")]
        public int decoreelementid { get; set; }

        public bool needdecoreelement { get; set; }

        [Display(Name = "Элемент конструкции")]
        public  int buildingelementid { get; set; }

        public bool needbuildingelement { get; set; }

        
        [Display(Name = "Исследователь")]
        public int personid { get; set; }
        
       
        //[Display(Name = "Место хранения")]
        //public int storageid { get; set; }


        public Point AddPoint(ApplicationDbContext context)
        {
            Point p = new Point();
            p.Altitude = altitude;
            p.Longitude = longitude;
            p.Latitude = latitude;
          //  p.dateofget = dateofget;
         //   p.shifr = shifr;
            p.Placedescription = placedescription;
            context.Add(p);
            context.SaveChanges();
            return p;
        }
        public RentgenFluoriscAnalyze AddRfAnalyze(ApplicationDbContext context)
        {
            RentgenFluoriscAnalyze rf = new RentgenFluoriscAnalyze();
            rf.Date = date;
            rf.Number = number;
            context.Add(rf);
            context.SaveChanges();
            return rf;
        }


    }
}
