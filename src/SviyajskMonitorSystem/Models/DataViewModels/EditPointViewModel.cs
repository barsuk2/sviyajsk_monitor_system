using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DataViewModels
{
    public class EditPointViewModel
    {
        [Key]
        public int id { get; set; }
        //  [Required(ErrorMessage ="не указана широта")]
        public float latitude { get; set; }
        // [Required(ErrorMessage = "не указана долгота")]
        public float longitude { get; set; }
        //  [Required(ErrorMessage = "не указана высота")]
        public float altitude { get; set; }
      // [Required(ErrorMessage = "не указан код образца")]
        public string shifr { get; set; }
      //  [Required(ErrorMessage = "не указана дата взятия образца")]
        public DateTime dateofget { get; set; }
        public string placedescription { get; set; }
       // [DataType(DataType.b)]
        public bool needchangestorage { get; set; }

        public bool needchangeperson { get; set; }


        public EditPointViewModel(Point p)
        {
            id = p.Id;
            latitude = p.Latitude;
            altitude = p.Altitude;
            //shifr = p.shifr;
         //   dateofget = p.dateofget;
            placedescription = p.Placedescription;
        }
     
    }
}
