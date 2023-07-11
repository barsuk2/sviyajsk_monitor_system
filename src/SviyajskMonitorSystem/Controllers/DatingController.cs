using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SviyajskMonitorSystem.Controllers
{
   [Authorize]
    public class DatingController : Controller
    {

        ApplicationDbContext context;
        public DatingController(ApplicationDbContext cont)
        {
            context = cont;
        }


        [Authorize(Roles = "Researcher")]
        public ActionResult Create(Dating dating)
        {
            context.Datings.Add(dating);
            context.SaveChanges();
            List<int> dids = new List<int>();
            if (TempData.ContainsKey("datings"))
            {
                dids.AddRange((int[])TempData["datings"]);
            }
            dids.Add(dating.Id);
            TempData["datings"] = dids;
            List<Dating> dat = context.Datings.Where(d => dids.Contains(d.Id)).ToList();
            return PartialView("Index",dat);
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
