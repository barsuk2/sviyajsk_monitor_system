using SviyajskMonitorSystem.Models.DynamicFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Models.DataViewModels
{
    public class ElementViewModel
    {
        public string id;
        public string parent;
        public string text;

        public ElementViewModel(Element el)
        {
            id = el.Id.ToString();
            if (el.Parent != null)
            {
                parent = el.Parent.Id.ToString();
            }
            else
            {
                parent = "#";
            }
            
            text = el.Name;
        }


        public ElementViewModel(TreeElement treeelement)
        {
            id = treeelement.id.ToString();
            if (treeelement.parent != null)
            {
                parent = treeelement.parent.id.ToString();
            }
            else
            {
                parent = "#";
            }

            text = treeelement.identifier;

        }

    }
}
