using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SviyajskMonitorSystem.Controllers
{
    public class AnalyzeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Images()
        {
            return View("Images");
        }

        public IActionResult Paging()
        {
            return PartialView();
        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult BaseComponent()
        {
            return PartialView();
        }

        public IActionResult AnalyzeComponent()
        {
            return PartialView("CreateAnalyzeView");
        }

        public IActionResult ElEmScanRes()
        {
            return PartialView("AddElMicroScanDataView");
        }

        public IActionResult CreatePlace()
        {
            return PartialView("CreatePlaceView");
        }

        public IActionResult OldPlace()
        {
            return PartialView("OldPlaceView");
        }

        public IActionResult OldSample()
        {
            return PartialView("OldSampleView");
        }
    }




}