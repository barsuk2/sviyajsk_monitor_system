using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using System.Collections.Generic;
using System.Linq;


namespace SviyajskMonitorSystem.Controllers
{
    //  [Authorize(Policy = ("checked"))]
    [Authorize]
    public class HasBacteryController:Controller
    {
        ApplicationDbContext context;
        public HasBacteryController(ApplicationDbContext cont)
        {
            context = cont;
        }

        [HttpPost]
        [Authorize(Roles = "Researcher")]
        public IActionResult Create(HasBactery bact)
        {
            string bactname = Request.Form.First(p => p.Key == "bacterya").Value;
            Bacterya bacterya = context.Bacterya.First(b => b.ToString() == bactname);
            bact.Bacterya = bacterya;
            context.HasBactery.Add(bact);
            context.SaveChanges();
            List<int> hbids = new List<int>();
            if (TempData.ContainsKey("bacteries"))
            {
                hbids.AddRange((int[]) TempData["bacteries"]);
            }
            hbids.Add(bact.Id);
            TempData["bacteries"] = hbids;
            List<HasBactery> bacteries = context.HasBactery.Where(hb => hbids.Contains(hb.Id)).ToList();
            return PartialView("index",bacteries);
        }
    }
}
