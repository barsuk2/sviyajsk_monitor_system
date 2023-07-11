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
    public class ChronoCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChronoCodesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ChronoCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChronoCodes.ToListAsync());
        }

        // GET: ChronoCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chronoCodes = await _context.ChronoCodes.SingleOrDefaultAsync(m => m.id == id);
            if (chronoCodes == null)
            {
                return NotFound();
            }

            return View(chronoCodes);
        }

        // GET: ChronoCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChronoCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id")] ChronoCodes chronoCodes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chronoCodes);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(chronoCodes);
        }

        // GET: ChronoCodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chronoCodes = await _context.ChronoCodes.SingleOrDefaultAsync(m => m.id == id);
            if (chronoCodes == null)
            {
                return NotFound();
            }
            return View(chronoCodes);
        }

        // POST: ChronoCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id")] ChronoCodes chronoCodes)
        {
            if (id != chronoCodes.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chronoCodes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChronoCodesExists(chronoCodes.id))
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
            return View(chronoCodes);
        }

        // GET: ChronoCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chronoCodes = await _context.ChronoCodes.SingleOrDefaultAsync(m => m.id == id);
            if (chronoCodes == null)
            {
                return NotFound();
            }

            return View(chronoCodes);
        }

        // POST: ChronoCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chronoCodes = await _context.ChronoCodes.SingleOrDefaultAsync(m => m.id == id);
            _context.ChronoCodes.Remove(chronoCodes);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ChronoCodesExists(int id)
        {
            return _context.ChronoCodes.Any(e => e.id == id);
        }
    }
}
