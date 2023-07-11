using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models
{
    public abstract class AbstractAttributeValue
    {
        [Key]
        public long id { get; set; }
        public virtual AttributeKey attributekey{ get; set;}


        public abstract string getvalue();

       // public T value { get; set; }
        
    }
}
