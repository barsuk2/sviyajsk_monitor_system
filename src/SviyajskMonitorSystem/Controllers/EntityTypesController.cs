using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SviyajskMonitorSystem.Data;

namespace SviyajskMonitorSystem.Controllers
{
    public class EntityTypesController : Controller
    {

        ApplicationDbContext context;

        public EntityTypesController(ApplicationDbContext cont)
        {
            context = cont;
        }


        // GET: EntityTypes
        public ActionResult Index()
        {
            //context
            return View("index",context.Types.ToList());
        }

        // GET: EntityTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EntityTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntityTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EntityTypes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EntityTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EntityTypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EntityTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}