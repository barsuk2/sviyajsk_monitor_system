using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace SviyajskMonitorSystem.Controllers
{
    [Authorize]
    public class BacteryasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BacteryasController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Bacteryas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bacterya.ToListAsync());
        }

        // GET: Bacteryas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacterya = await _context.Bacterya.SingleOrDefaultAsync(m => m.id == id);
            if (bacterya == null)
            {
                return NotFound();
            }

            return View(bacterya);
        }

        // GET: Bacteryas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bacteryas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,rodname,vidname")] Bacterya bacterya)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bacterya);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bacterya);
        }

        // GET: Bacteryas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacterya = await _context.Bacterya.SingleOrDefaultAsync(m => m.id == id);
            if (bacterya == null)
            {
                return NotFound();
            }
            return View(bacterya);
        }

        // POST: Bacteryas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,rodname,vidname")] Bacterya bacterya)
        {
            if (id != bacterya.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bacterya);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BacteryaExists(bacterya.id))
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
            return View(bacterya);
        }

        // GET: Bacteryas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bacterya = await _context.Bacterya.SingleOrDefaultAsync(m => m.id == id);
            if (bacterya == null)
            {
                return NotFound();
            }

            return View(bacterya);
        }

        // POST: Bacteryas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bacterya = await _context.Bacterya.SingleOrDefaultAsync(m => m.id == id);
            _context.Bacterya.Remove(bacterya);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BacteryaExists(int id)
        {
            return _context.Bacterya.Any(e => e.id == id);
        }
    }
}
