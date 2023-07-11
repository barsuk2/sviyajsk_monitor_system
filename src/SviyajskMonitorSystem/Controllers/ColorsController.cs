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
    public class ColorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColorsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Colors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Color.ToListAsync());
        }

        // GET: Colors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await _context.Color.SingleOrDefaultAsync(m => m.id == id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // GET: Colors/Create
        [Authorize(Roles = "Researcher")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Create([Bind("id,name")] Color color)
        {
            if (ModelState.IsValid)
            {
                _context.Add(color);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(color);
        }

        // GET: Colors/Edit/5
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await _context.Color.SingleOrDefaultAsync(m => m.id == id);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }

        // POST: Colors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] Color color)
        {
            if (id != color.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(color);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorExists(color.id))
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
            return View(color);
        }

        // GET: Colors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var color = await _context.Color.SingleOrDefaultAsync(m => m.id == id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }

        // POST: Colors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var color = await _context.Color.SingleOrDefaultAsync(m => m.id == id);
            _context.Color.Remove(color);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ColorExists(int id)
        {
            return _context.Color.Any(e => e.id == id);
        }


        public IActionResult GetColorsJson()
        {
            return Json(_context.Color.ToList());
        }
    }
}
