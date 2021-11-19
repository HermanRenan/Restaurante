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
    public class CozinhaController : Controller
    {
        // GET: Cozinha
        public ActionResult Index()
        {
            List<PedidoModel> listaPedidos = new List<PedidoModel>();

            var app = UtillClass.StartInterface();

            using (var scope = app.container.BeginLifetimeScope())
            {
                var dataClient = scope.Resolve<ServicePedido>().List();
                listaPedidos = dataClient.Result;

                listaPedidos.ForEach(x =>
                {
                    var list = x.PedidoFechado.Where(b => b.Estoque == null);
                    if (list.Any())
                    {
                        x.PedidoFechado.ToList().ForEach(b =>
                        {
                            b.Estoque = scope.Resolve<ServiceEstoque>().GetEntityById(b.EstoqueId).Result;
                        });
                    }
                });

                var dataClientt = scope.Resolve<ServiceEstoque>().List();
            }

            return View(listaPedidos);
        }

        // GET: Cozinha/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cozinha/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cozinha/Create
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

        // GET: Cozinha/Edit/5
        public ActionResult Edit(int id)
        {
            var PedidoIem = new PedidoModel();
            var app = UtillClass.StartInterface();

            using (var scope = app.container.BeginLifetimeScope())
            {
                var dataClient = scope.Resolve<ServicePedido>().GetEntityById(id);
                PedidoIem = dataClient.Result;
            }

            return View(PedidoIem);
        }

        // POST: Cozinha/Edit/5
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

        // GET: Cozinha/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cozinha/Delete/5
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
