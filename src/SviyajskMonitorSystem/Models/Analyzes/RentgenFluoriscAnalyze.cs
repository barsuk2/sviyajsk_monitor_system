using System;
using System.Collections.Generic;
using System.Linq;

using System.Runtime.Serialization;
using Newtonsoft.Json;
using SviyajskMonitorSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace SviyajskMonitorSystem.Models
{
    public class RentgenFluoriscAnalyze:Analyze
    {
        [JsonIgnore]
        public virtual List<ChemistryElMassDole> Massdoles { get; set; }
        [JsonIgnore]
        public virtual Color Color { get; set; }

        public override void DeleteConnectedObj(ApplicationDbContext context)
        {
            //Massdoles = context.ChemistryElMassDole.ToList();
            //context.ChemistryElMassDole.RemoveRange(Massdoles);
            //context.SaveChanges();
        }
    }
}