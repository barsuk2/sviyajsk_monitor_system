using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;

namespace SviyajskMonitorSystem.Controllers
{
    public class StoragesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoragesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Storages
        public async Task<IActionResult> Index()
        {
            return View(await _context.Storage.Include(s=>s.Organization).ToListAsync());
        }

        // GET: Storages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storage = await _context.Storage
                .SingleOrDefaultAsync(m => m.Id == id);
            if (storage == null)
            {
                return NotFound();
            }

            return View(storage);
        }

        // GET: Storages/Create
        public IActionResult Create()
        {
            ViewData["Organization"] = _context.Organizations.ToList<IChoosable>();
            return View();
        }

        // POST: Storages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Place")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storage);
                string orgid = Request.Form.FirstOrDefault(f => f.Key == "Organization").Value;
                storage.Organization = _context.Organizations.FirstOrDefault(org => org.Id.ToString() == orgid);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(storage);
        }

        // GET: Storages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storage = await _context.Storage.SingleOrDefaultAsync(m => m.Id == id);
            if (storage == null)
            {
                return NotFound();
            }
            return View(storage);
        }

        // POST: Storages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,place")] Storage storage)
        {
            if (id != storage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StorageExists(storage.Id))
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
            return View(storage);
        }

        // GET: Storages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storage = await _context.Storage
                .SingleOrDefaultAsync(m => m.Id == id);
            if (storage == null)
            {
                return NotFound();
            }

            return View(storage);
        }

        // POST: Storages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storage = await _context.Storage.SingleOrDefaultAsync(m => m.Id == id);
            _context.Storage.Remove(storage);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StorageExists(int id)
        {
            return _context.Storage.Any(e => e.Id == id);
        }


        public IActionResult GetStoragesJson()
        {
            return Json(_context.Storage.Include(s=>s.Organization));
        }
    }
}
