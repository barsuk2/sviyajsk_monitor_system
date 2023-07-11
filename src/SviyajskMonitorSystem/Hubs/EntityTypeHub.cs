using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models.DynamicFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SviyajskMonitorSystem.Services;
using Microsoft.Extensions.DependencyInjection;

namespace SviyajskMonitorSystem.Hubs
{
    public class EntityTypeHub:Hub
    {
        ApplicationDbContext context;


        public EntityTypeHub(IServiceProvider sp)
        {
            var services = sp.CreateScope();
            context = services.ServiceProvider.GetService<ApplicationDbContext>();
            //context = cont;
        }


        public void AddEType(string name)
        {
            EntityType et = new EntityType()
            {
                Name = name
            };
            
            context.Types.Add(et);
            context.SaveChanges();
            TagBuilder container = new TagBuilder("tr");
            TagBuilder content = new TagBuilder("th");
            TagBuilder hrefcontainer = new TagBuilder("th");
            TagBuilder href = new TagBuilder("a");
            content.InnerHtml.Append(name);
            container.InnerHtml.AppendHtml(content);
            href.InnerHtml.Append("Перейти к справочнику");
            href.Attributes.Add("href", $"/EntityValues/Index/{et.Id}");
            hrefcontainer.InnerHtml.AppendHtml(href);
            container.InnerHtml.AppendHtml(hrefcontainer);
            Clients.All.ShowNewType(LowLevelHelper.GetHtmlString(container));
        }


    }
}
