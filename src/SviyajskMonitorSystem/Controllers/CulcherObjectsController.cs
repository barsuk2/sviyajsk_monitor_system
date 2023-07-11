using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using SviyajskMonitorSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace SviyajskMonitorSystem.Controllers
{
    [Authorize]
    public class CulcherObjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CulcherObjectsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CulcherObjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.CulcherObject.ToListAsync());
        }

        // GET: CulcherObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var culcherObject = await _context.CulcherObject.SingleOrDefaultAsync(m => m.id == id);
            if (culcherObject == null)
            {
                return NotFound();
            }

            return View(culcherObject);
        }

        // GET: CulcherObjects/Create
        [Authorize(Roles = "Researcher")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CulcherObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Create([Bind("id,name")] CulcherObject culcherObject)
        {
            if (ModelState.IsValid)
            {
           //     culcherObject.OnCreate(_context.Users.FirstOrDefault(us => us.UserName == User.Identity.Name.ToString()));
                _context.Add(culcherObject);
                await _context.SaveChangesAsync();
             
             //   el.OnCreate(_context.Users.FirstOrDefault(us => us.UserName == User.Identity.Name.ToString()));
              
                return RedirectToAction("Index");
            }
            return View(culcherObject);
        }



        public IActionResult GetAsset(int? id)
        {
           // int coid;
            Element el = _context.Element.FirstOrDefault(e => e.Id == id);

            //if (el.culcherobject != null)
            //{
            //    coid = el.culcherobject.id;
            //    return PhysicalFile("/AssetBundles/" + coid.ToString(), "application/x-msdownload");
            //}
            return Ok();
        }


        // GET: CulcherObjects/Edit/5
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var culcherObject = await _context.CulcherObject.SingleOrDefaultAsync(m => m.id == id);
            if (culcherObject == null)
            {
                return NotFound();
            }
            return View(culcherObject);
        }

        // POST: CulcherObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Edit(int id, [Bind("id,CreatedAt,LastUpdatedAt,name")] CulcherObject culcherObject)
        {
            if (id != culcherObject.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                //    culcherObject.OnUpdate(_context.Users.FirstOrDefault(us => us.UserName == User.Identity.Name.ToString()));
                    _context.Update(culcherObject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CulcherObjectExists(culcherObject.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(culcherObject);
        }

        // GET: CulcherObjects/Delete/5
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var culcherObject = await _context.CulcherObject.SingleOrDefaultAsync(m => m.id == id);
            if (culcherObject == null)
            {
                return NotFound();
            }

            return View(culcherObject);
        }

        // POST: CulcherObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var culcherObject = await _context.CulcherObject.SingleOrDefaultAsync(m => m.id == id);
            _context.CulcherObject.Remove(culcherObject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CulcherObjectExists(int id)
        {
            return _context.CulcherObject.Any(e => e.id == id);
        }
    }
}
