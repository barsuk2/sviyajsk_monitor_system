using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SviyajskMonitorSystem.Controllers
{
    public class TreesElementsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetMain()
        {
            return PartialView("Main");
        }

        public IActionResult GetTType()
        {
            return PartialView("TreeType");
        }

        public IActionResult GetRedactor()
        {
            return PartialView("TreeRedactor");
        }

        public IActionResult GetElementsTemp()
        {
            return PartialView("ElementsTempl");
        }


    }
}
