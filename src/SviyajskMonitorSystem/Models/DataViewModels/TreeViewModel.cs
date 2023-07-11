using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SviyajskMonitorSystem.Models.DynamicFields;

namespace SviyajskMonitorSystem.Models
{
    public class TreeViewModel
    {
        [JsonProperty]
        string id { get; set; }
        [JsonProperty]
        string parent { get; set; }
        [JsonProperty]
        string text { get; set; }//name of element



        public TreeViewModel() { }
        public TreeViewModel(Element el)
        {
            id = el.Id.ToString();
            if (el.Parent != null)
            {
                parent = el.Parent.Id.ToString();
            }else
            {
                parent = "#";
            }
            text = el.Name;
        }

        public TreeViewModel(TreeElement el)
        {
            id = el.id.ToString();
            if (el.parent != null)
            {
                parent = el.parent.id.ToString();
            }
            else
            {
                parent = "#";
            }
            text = el.identifier;
        }

      

    }

}
