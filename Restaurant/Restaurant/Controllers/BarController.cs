using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class BarController : Controller
    {
        // GET: Bar
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bar/Create
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

        // GET: Bar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bar/Edit/5
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

        // GET: Bar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bar/Delete/5
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
