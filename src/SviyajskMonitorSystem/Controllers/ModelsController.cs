using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SviyajskMonitorSystem.Data;
using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Models;
using SviyajskMonitorSystem.Services;
using Microsoft.AspNetCore.Http;

namespace SviyajskMonitorSystem.Controllers
{
    public class ModelsController : Controller
    {


        ApplicationDbContext context;


        public ModelsController(ApplicationDbContext _cont)
        {
            context = _cont;
        }


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult GetModel(int elid)
        {
            Element element = context.Element.Include(el => el.Models).FirstOrDefault(el => el.Id == elid);
            List < _3DModel > models= element.Models;
            if (models == null)
            {
                models = new List<_3DModel>();
            }
            return PartialView("ModelsView",models);
        }



        public IActionResult CreateModel(int treeelement, string description)
        {
            Element element = context.Element.Include(el => el.Models).FirstOrDefault(el => el.Id == treeelement);
            _3DModel model = new _3DModel
            {
                Description = description,
                Element = element
            };
           
            context.Models.Add(model);
            context.SaveChanges();
            FileUpload fupl = new FileUpload("/AssetBundles");
            IFormFile file = Request.Form.Files.GetFile("3Dmodel");
            fupl.SaveFile(file,model.Id.ToString());
            return RedirectToAction("GetModel",treeelement);
        }

    }
}