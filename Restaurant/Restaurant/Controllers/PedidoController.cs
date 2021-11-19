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
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            List<PedidoModel> listaPedidos = new List<PedidoModel>();

            var app = UtillClass.StartInterface();

            using (var scope = app.container.BeginLifetimeScope())
            {
                var dataClient = scope.Resolve<ServicePedido>().List();
                listaPedidos = dataClient.Result;

            }

            return View(listaPedidos);
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        public ActionResult Create(PedidoModel PedidoModel)
        {
            try
            {
                var app = UtillClass.StartInterface();

                using (var scope = app.container.BeginLifetimeScope())
                {
                    var dataClient = scope.Resolve<ServicePedido>().Add(PedidoModel);                    
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Edit/5
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

        // POST: Pedido/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PedidoModel PedidoModel)
        {
            try
            {
                // TODO: Add update logic here
                var app = UtillClass.StartInterface();

                using (var scope = app.container.BeginLifetimeScope())
                {
                    PedidoModel.PedidoId = id;
                    var dataClient = scope.Resolve<ServicePedido>().Update(PedidoModel);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int id)
        {
            var PedidoIem = new PedidoModel();
            var app = UtillClass.StartInterface();

            using (var scope = app.container.BeginLifetimeScope())
            {
                var dataClient = scope.Resolve<ServicePedido>().GetEntityById(id);
                PedidoIem = dataClient.Result;
            }

            return PartialView("_DeleteModal", PedidoIem);
        }

        // POST: Pedido/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PedidoModel PedidoModel)
        {
            try
            {
                var app = UtillClass.StartInterface();

                using (var scope = app.container.BeginLifetimeScope())
                {
                    PedidoModel.PedidoId = id;
                    var dataClient = scope.Resolve<ServicePedido>().Delete(PedidoModel);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
