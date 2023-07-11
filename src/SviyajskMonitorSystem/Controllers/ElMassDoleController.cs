using System.Linq;

using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;

namespace SviyajskMonitorSystem.Controllers
{
   
    [Authorize]
    public class ElMassDoleController : Controller
    {

        private ApplicationDbContext context;

        public ElMassDoleController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Authorize(Roles = "Researcher")]
        public IActionResult Create()
        {
            List<int> doleids = new List<int>();
            List<ChemistryElement> chel = context.ChemistryElement.ToList();
            foreach(ChemistryElement ch in chel)
            {
                double value = double.Parse(Request.Form.FirstOrDefault(k => k.Key == ch.id.ToString()).Value);
                ChemistryElMassDole massdole = new ChemistryElMassDole();
                massdole.Value = value;
                massdole.Chelement = ch;
             //   massdole.OnCreate(context.Users.FirstOrDefault(us => us.UserName == User.Identity.Name.ToString()));
                context.ChemistryElMassDole.Add(massdole);
                context.SaveChanges();
                doleids.Add(massdole.Id);
            }
            TempData["RFElMassDole"] = doleids;
            return Ok();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}