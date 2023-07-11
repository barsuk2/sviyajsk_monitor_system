using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models
{
    public interface IChoosable
    {
        
        //Return id of entity
        string getid();

        //return string value of entity
        string getvalue();

        //return name of list in forn to entity
        string getlistname();
    }
}
