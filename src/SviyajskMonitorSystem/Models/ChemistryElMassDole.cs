using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SviyajskMonitorSystem.Data;

namespace SviyajskMonitorSystem.Models
{
    public class ChemistryElMassDole: AbstractEnttity,IDeleteConnectedObj
    {
        [Key]
        public int Id { get; set; }

        public double Value { get; set; }
      //  [JsonIgnore]
        public virtual ChemistryElement Chelement { get; set; }

        public void DeleteConnectedObj(ApplicationDbContext context)
        {
            context.Remove(this);
            context.SaveChanges();
        }
    }
}