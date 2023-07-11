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
    public class ChemistryElementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChemistryElementsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: ChemistryElements
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChemistryElement.ToListAsync());
        }

        // GET: ChemistryElements/Details/5
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chemistryElement = await _context.ChemistryElement.SingleOrDefaultAsync(m => m.id == id);
            if (chemistryElement == null)
            {
                return NotFound();
            }

            return View(chemistryElement);
        }

        // GET: ChemistryElements/Create
        [Authorize(Roles = "Researcher")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChemistryElements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Create([Bind("id,fullname,shortname")] ChemistryElement chemistryElement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chemistryElement);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(chemistryElement);
        }

        // GET: ChemistryElements/Edit/5
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chemistryElement = await _context.ChemistryElement.SingleOrDefaultAsync(m => m.id == id);
            if (chemistryElement == null)
            {
                return NotFound();
            }
            return View(chemistryElement);
        }

        // POST: ChemistryElements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Edit(int id, [Bind("id,fullname,shortname")] ChemistryElement chemistryElement)
        {
            if (id != chemistryElement.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chemistryElement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChemistryElementExists(chemistryElement.id))
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
            return View(chemistryElement);
        }

        // GET: ChemistryElements/Delete/5
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chemistryElement = await _context.ChemistryElement.SingleOrDefaultAsync(m => m.id == id);
            if (chemistryElement == null)
            {
                return NotFound();
            }

            return View(chemistryElement);
        }

        // POST: ChemistryElements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Researcher")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chemistryElement = await _context.ChemistryElement.SingleOrDefaultAsync(m => m.id == id);
            _context.ChemistryElement.Remove(chemistryElement);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ChemistryElementExists(int id)
        {
            return _context.ChemistryElement.Any(e => e.id == id);
        }



        public IActionResult GetChelJson()
        {
            return Json(_context.ChemistryElement.ToList());
        }
    }
}
