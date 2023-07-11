using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Services;
using SviyajskMonitorSystem.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SviyajskMonitorSystem.Controllers
{
    public class ImagesController : Controller
    {
        ApplicationDbContext _context;
        FileUpload _upload;

        public ImagesController(ApplicationDbContext context,FileUpload upload)
        {
            _context = context;
            _upload = upload;
        }

        // GET: /<controller>/
        public IActionResult ImgTemplate()
        {
            return PartialView("Template");
        }


        public IActionResult UploadImage([FromBody] string[] urls)
        {
            List<string> pids = new List<string>();
            foreach ( var url in urls) {
                Photo p = new Photo();
                _context.Photos.Add(p);
                _context.SaveChanges();
                _upload.SavePhoto(url, p.Id);
                pids.Add(p.Id.ToString());
            }

            return Json(pids);
        }

    }
}
