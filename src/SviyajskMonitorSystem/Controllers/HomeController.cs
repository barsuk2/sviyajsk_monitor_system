using Microsoft.AspNetCore.Mvc;
using SviyajskMonitorSystem.Models;
using SviyajskMonitorSystem.Models.DataViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SviyajskMonitorSystem.Data;
using Microsoft.AspNetCore.Authorization;

namespace SviyajskMonitorSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private  ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        


      //  string login = "TestLogin";
      //  string password = "TestPassword";
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult AskAccount()
        {
            return View("AskAccount");
        }

        [AllowAnonymous]
        public IActionResult AccountRequest(AccauntRequestData data)
        {
            _context.AccauntReqest.Add(data);
            _context.SaveChanges();
            return View("EndRequest");
        }


        public IActionResult FirstPage()
        {
            return View();
        }

        public IActionResult Bibliogr()
        {
            return View();
        }

        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
