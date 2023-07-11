using System.Linq;

using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;

namespace SviyajskMonitorSystem.Controllers
{
    // [Authorize(Policy = ("checked"))]
    [Authorize]
    public class Vector3Controller : Controller
    {
        private ApplicationDbContext _context;

        public Vector3Controller(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Vector3
        public IActionResult Index()
        {
            return View();
            
        }

        // GET: Vector3/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return Ok();
            }

            Vector3 vector3 = _context.Vector3.Single(m => m.Id == id);
            if (vector3 == null)
            {
                return Ok();
            }

            return View(vector3);
        }

        // GET: Vector3/Create
        

        // POST: Vector3/Create
        [HttpPost]
        [Authorize(Roles = "Researcher")]
        public JsonResult Create()
        {
            
            string item = Request.Form.FirstOrDefault(i => i.Key == "item").Value;

            string number = Request.Form.FirstOrDefault(p => p.Key == "x").Value;
            float x = float.Parse(number, CultureInfo.InvariantCulture);
            number = Request.Form.FirstOrDefault(p => p.Key == "y").Value;
            float y = float.Parse(number, CultureInfo.InvariantCulture);
            number = Request.Form.FirstOrDefault(p => p.Key == "z").Value;
            float z= float.Parse(number, CultureInfo.InvariantCulture);
            Vector3 vector = new Vector3()
            {
                X = x,
                Y = y,
                Z = z
            };
            _context.Vector3.Add(vector);
            _context.SaveChanges();
            if (item == "pos")
            {
                TempData["pos"] = vector.Id;
            }
            if (item == "dir")
            {
                TempData["dir"] = vector.Id;
            }
            return Json(vector);
        }

        // GET: Vector3/Edit/5
        [Authorize(Roles = "Researcher")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return Ok();
            }

            Vector3 vector3 = _context.Vector3.Single(m => m.Id == id);
            if (vector3 == null)
            {
                return Ok();
            }
            return View(vector3);
        }

        // POST: Vector3/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Researcher")]
        public IActionResult Edit(Vector3 vector3)
        {
            if (ModelState.IsValid)
            {
                _context.Update(vector3);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vector3);
        }

        // GET: Vector3/Delete/5
        [ActionName("Delete")]
        [Authorize(Roles = "Researcher")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Ok();
            }

            Vector3 vector3 = _context.Vector3.Single(m => m.Id == id);
            if (vector3 == null)
            {
                return Ok();
            }

            return View(vector3);
        }

        // POST: Vector3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Researcher")]
        public IActionResult DeleteConfirmed(int id)
        {
            Vector3 vector3 = _context.Vector3.Single(m => m.Id == id);
            _context.Vector3.Remove(vector3);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
