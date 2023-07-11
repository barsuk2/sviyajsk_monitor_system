using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SviyajskMonitorSystem.Data;

namespace SviyajskMonitorSystem.Models
{
    public abstract class Analyze: AbstractEnttity,IDeleteConnectedObj
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "не указан код исследования")]
        public string Number { get; set; }
        [Required(ErrorMessage = "не указана дата исследования")]
        public DateTime Date { get; set; }
        public AnalyzeType Type { get; set; }

        [JsonIgnore]
        public virtual Sample Sample { get; set; }
        [JsonIgnore]
        public virtual Person Person { get; set; }

        public string GetTypeName()
        {
            switch (Type)
            {
                case AnalyzeType.MicroBiologicalAnalyzes:return "микробиологический";
                    
                case AnalyzeType.rentgenfluoriscentnyi:return "Рентгено-флюорисцентный";
                   
                case AnalyzeType.electronnayamicroscopiya:return "электронная микроскопия";
                   
                case AnalyzeType.DendroChronologicalAnalyzes:return "Дендрохронологический";
                   
               
            }
            return null;
        }

        public abstract void DeleteConnectedObj(ApplicationDbContext context);
    }


    public enum AnalyzeType
    {
        
        MicroBiologicalAnalyzes,
        rentgenfluoriscentnyi,
        electronnayamicroscopiya,
        DendroChronologicalAnalyzes

            
    }


}