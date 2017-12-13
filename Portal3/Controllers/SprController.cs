using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portal3.Controllers
{
    public class SprController : Controller
    {
        // GET: Spr
        public ActionResult Index()
        {
            return View();
        }

        // GET: Spr/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Spr/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Spr/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Spr/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Spr/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Spr/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Spr/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
