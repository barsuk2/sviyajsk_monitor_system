using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models.DynamicFields;
using SviyajskMonitorSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace SviyajskMonitorSystem.Controllers
{
    public class TreeTypesController : Controller
    {


        ApplicationDbContext context;

        public TreeTypesController(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            List<TreeType> types = context.Treetypes.Include(t => t.keys).ThenInclude(k => k.entitytype).ToList();
            return View("treeTypeView",types);
        }

        public IActionResult CreateType()
        {
            ViewData["ETypes"] = context.Types.ToList<IChoosable>();
            return View("CreateTreeType");
        }
    }
}