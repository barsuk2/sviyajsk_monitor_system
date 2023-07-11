using System;
using System.Collections.Generic;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using SviyajskMonitorSystem.Data;
using System.IO;

namespace SviyajskMonitorSystem.Models
{
    public class Photo: AbstractEnttity,IDeleteConnectedObj
    {
        [Key]
        public int Id { get; set; }

        public void DeleteConnectedObj(ApplicationDbContext context)
        {
            throw new NotImplementedException();
        }
    }
}