using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesafioPractico.Models;

namespace DesafioPractico.Controllers
{
    public class t_transaccionController : Controller
    {
        private banco db = new banco();

        // GET: t_transaccion
        public ActionResult Index()
        {
            return View(db.tipoTransaccion.ToList());
        }

        // GET: t_transaccion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_transaccion t_transaccion = db.tipoTransaccion.Find(id);
            if (t_transaccion == null)
            {
                return HttpNotFound();
            }
            return View(t_transaccion);
        }

        // GET: t_transaccion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: t_transaccion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tipo")] t_transaccion t_transaccion)
        {
            if (ModelState.IsValid)
            {
                db.tipoTransaccion.Add(t_transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_transaccion);
        }

        // GET: t_transaccion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_transaccion t_transaccion = db.tipoTransaccion.Find(id);
            if (t_transaccion == null)
            {
                return HttpNotFound();
            }
            return View(t_transaccion);
        }

        // POST: t_transaccion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipo")] t_transaccion t_transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_transaccion);
        }

        // GET: t_transaccion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_transaccion t_transaccion = db.tipoTransaccion.Find(id);
            if (t_transaccion == null)
            {
                return HttpNotFound();
            }
            return View(t_transaccion);
        }

        // POST: t_transaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            t_transaccion t_transaccion = db.tipoTransaccion.Find(id);
            db.tipoTransaccion.Remove(t_transaccion);
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
