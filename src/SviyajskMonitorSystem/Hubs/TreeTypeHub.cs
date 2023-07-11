using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using SviyajskMonitorSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SviyajskMonitorSystem.Hubs
{
    public class TreeTypeHub:Hub
    {

        public static Dictionary<string, List<AttributeKey>> keys=new Dictionary<string, List<AttributeKey>>();

        ApplicationDbContext context;

        public TreeTypeHub(IServiceProvider sp)
        {
            var services = sp.CreateScope();
            context = services.ServiceProvider.GetService<ApplicationDbContext>();
            
        }



        public override Task OnConnected()
        {
            string connid = Context.ConnectionId;
            //keys=new Dictionary<string, List<AttributeKey>>(
            keys.Add(connid, new List<AttributeKey>());
           // ViewResult v = new ViewResult();
            
            return base.OnConnected();
        }


        public void AddKey(string name,string type,string listid)
        {
            if (name != null && name != "")
            {
                keys.TryGetValue(Context.ConnectionId, out List<AttributeKey> attributes);
                AttributeKey nkey = new AttributeKey()
                {
                    name = name,
                    type = (AttributeTypes)Enum.Parse(typeof(AttributeTypes), type)
                };
                if (nkey.type == AttributeTypes.Choosable)
                {
                    nkey.entitytype = new Models.DynamicFields.EntityType()
                    {
                        Id = int.Parse(listid)
                    };
                }
                attributes.Add(nkey);
                TagBuilder divbuilder = new TagBuilder("h5");
                divbuilder.Attributes.Add("id", name);
                divbuilder.InnerHtml.Append($"{nkey.name} : {LowLevelHelper.AttributeTypeToRussianString(nkey.type)}");

                Clients.Caller.ShowNewAttr(LowLevelHelper.GetHtmlString(divbuilder));
            }
           
        }



        public void CreateType(string name)
        {
            if (name != null && name != "")
            {
                keys.TryGetValue(Context.ConnectionId, out List<AttributeKey> attributes);
                TreeType type = new TreeType()
                {
                    name = name,
                    keys = new List<AttributeKey>()
                };
                context.Treetypes.Add(type);
                context.SaveChanges();
                foreach (AttributeKey attr in attributes)
                {

                   
                  // context.SaveChanges();
                    if (attr.type == AttributeTypes.Choosable)
                    {
                        attr.entitytype = context.Types.FirstOrDefault(e => e.Id == attr.entitytype.Id);
                    }
                    context.Attributekeys.Add(attr);
                    type.keys.Add(attr);
                    context.SaveChanges();
                }
                context.SaveChanges();
                attributes.Clear();
                Clients.Caller.ClearKeys();
            }
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            keys.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public void Test()
        {
           // Clients.
        }


    }
}
