using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinancieraAmetrano.Models;

namespace FinancieraAmetrano.Controllers
{
    public class CuentasController : Controller
    {
        private BDFinancieraEntities db = new BDFinancieraEntities();

        // GET: Cuentas
        public ActionResult Index()
        {
            var cuentas = db.Cuentas.Include(c => c.Clientes).Include(c => c.Monedas).Include(c => c.Productos).Include(c => c.Sucursales);
            return View(cuentas.ToList());
        }

        // GET: Cuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuentas cuentas = db.Cuentas.Find(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            return View(cuentas);
        }

        // GET: Cuentas/Create
        public ActionResult Create()
        {
            ViewBag.clientesID = new SelectList(db.Clientes, "clientesID", "clientesID");
            ViewBag.monedasID = new SelectList(db.Monedas, "monedasID", "descripcionMoneda");
            ViewBag.productosID = new SelectList(db.Productos, "productosID", "descripcion");
            ViewBag.sucursalesID = new SelectList(db.Sucursales, "sucursalesID", "nombre");
            return View();
        }

        // POST: Cuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cuentasID,clientesID,productosID,monedasID,saldo,fechaApertura,sucursalesID")] Cuentas cuentas)
        {
            if (ModelState.IsValid)
            {
                db.Cuentas.Add(cuentas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.clientesID = new SelectList(db.Clientes, "clientesID", "clientesID", cuentas.clientesID);
            ViewBag.monedasID = new SelectList(db.Monedas, "monedasID", "descripcionMoneda", cuentas.monedasID);
            ViewBag.productosID = new SelectList(db.Productos, "productosID", "descripcion", cuentas.productosID);
            ViewBag.sucursalesID = new SelectList(db.Sucursales, "sucursalesID", "nombre", cuentas.sucursalesID);
            return View(cuentas);
        }

        // GET: Cuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuentas cuentas = db.Cuentas.Find(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientesID = new SelectList(db.Clientes, "clientesID", "clientesID", cuentas.clientesID);
            ViewBag.monedasID = new SelectList(db.Monedas, "monedasID", "descripcionMoneda", cuentas.monedasID);
            ViewBag.productosID = new SelectList(db.Productos, "productosID", "descripcion", cuentas.productosID);
            ViewBag.sucursalesID = new SelectList(db.Sucursales, "sucursalesID", "nombre", cuentas.sucursalesID);
            return View(cuentas);
        }

        // POST: Cuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cuentasID,clientesID,productosID,monedasID,saldo,fechaApertura,sucursalesID")] Cuentas cuentas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.clientesID = new SelectList(db.Clientes, "clientesID", "clientesID", cuentas.clientesID);
            ViewBag.monedasID = new SelectList(db.Monedas, "monedasID", "descripcionMoneda", cuentas.monedasID);
            ViewBag.productosID = new SelectList(db.Productos, "productosID", "descripcion", cuentas.productosID);
            ViewBag.sucursalesID = new SelectList(db.Sucursales, "sucursalesID", "nombre", cuentas.sucursalesID);
            return View(cuentas);
        }

        // GET: Cuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuentas cuentas = db.Cuentas.Find(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            return View(cuentas);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuentas cuentas = db.Cuentas.Find(id);
            db.Cuentas.Remove(cuentas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
