using Application_.Model;
using Application_.Service;
using Autofac;
using Restaurant.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restaurant.Controllers
{
    public class EstoqueController : Controller
    {
        // GET: Estoque
        public ActionResult Index()
        {
            List<EstoqueModel> listaPedidos = new List<EstoqueModel>();

            var app = UtillClass.StartInterface();

            using (var scope = app.container.BeginLifetimeScope())
            {
                var dataClient = scope.Resolve<ServiceEstoque>().List();
                listaPedidos = dataClient.Result;
            }

            return PartialView("_FormEstoque", listaPedidos);
        }

        // GET: Estoque/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estoque/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estoque/Create
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

        // GET: Estoque/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estoque/Edit/5
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

        // GET: Estoque/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estoque/Delete/5
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
