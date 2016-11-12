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
    public class SucursalesController : Controller
    {
        private BDFinancieraEntities db = new BDFinancieraEntities();

        // GET: Sucursales
        public ActionResult Index()
        {
            return View(db.Sucursales.ToList());
        }

        // GET: Sucursales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursales sucursales = db.Sucursales.Find(id);
            if (sucursales == null)
            {
                return HttpNotFound();
            }
            return View(sucursales);
        }

        // GET: Sucursales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sucursales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sucursalesID,nombre,departamento,ciudad,direccion")] Sucursales sucursales)
        {
            if (ModelState.IsValid)
            {
                db.Sucursales.Add(sucursales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sucursales);
        }

        // GET: Sucursales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursales sucursales = db.Sucursales.Find(id);
            if (sucursales == null)
            {
                return HttpNotFound();
            }
            return View(sucursales);
        }

        // POST: Sucursales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sucursalesID,nombre,departamento,ciudad,direccion")] Sucursales sucursales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sucursales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sucursales);
        }

        // GET: Sucursales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sucursales sucursales = db.Sucursales.Find(id);
            if (sucursales == null)
            {
                return HttpNotFound();
            }
            return View(sucursales);
        }

        // POST: Sucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sucursales sucursales = db.Sucursales.Find(id);
            db.Sucursales.Remove(sucursales);
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
