using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models.DynamicFields;
using SviyajskMonitorSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Hubs
{
    public class EntityValueHub:Hub
    {
        ApplicationDbContext context;

        public EntityValueHub(IServiceProvider sp)
        {
            var services = sp.CreateScope();
            context = services.ServiceProvider.GetService<ApplicationDbContext>();
        }


        public void AddValue(string value,int typeid)
        {
            EntityValue val = new EntityValue()
            {
                value = value
            };
            val.type = context.Types.FirstOrDefault(t => t.Id == typeid);
            context.Values.Add(val);
            context.SaveChanges();
            TagBuilder tr = new TagBuilder("tr");
            TagBuilder th = new TagBuilder("th");
            th.InnerHtml.Append(val.value);
            tr.InnerHtml.AppendHtml(th);
            Clients.Caller.ShowNewValue(LowLevelHelper.GetHtmlString(tr));
        }



    }
}
