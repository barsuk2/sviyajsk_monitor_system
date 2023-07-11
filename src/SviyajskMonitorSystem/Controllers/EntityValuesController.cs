using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models.DynamicFields;
using SviyajskMonitorSystem.Models;

namespace SviyajskMonitorSystem.Controllers
{
    public class EntityValuesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntityValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EntityValues
        public IActionResult Index(int? id)
        {
            EntityType type = _context.Types.Include(t => t.values).FirstOrDefault(t => t.Id == id);
            return View("index", type);
        }


        public IActionResult GetValues(int typeid)
        {
            List<EntityValue> values = _context.Values.Include(v => v.type).Where(v => v.type.Id == typeid).ToList();
            return Json(values);
        }

    }
}
