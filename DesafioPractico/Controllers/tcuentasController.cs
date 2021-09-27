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
    public class tcuentasController : Controller
    {
        private banco db = new banco();

        // GET: tcuentas
        public ActionResult Index()
        {
            return View(db.tipoCuentaBancaria.ToList());
        }

        // GET: tcuentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcuenta tcuenta = db.tipoCuentaBancaria.Find(id);
            if (tcuenta == null)
            {
                return HttpNotFound();
            }
            return View(tcuenta);
        }

        // GET: tcuentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tcuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tipo,Activo")] tcuenta tcuenta)
        {
            if (ModelState.IsValid)
            {
                db.tipoCuentaBancaria.Add(tcuenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tcuenta);
        }

        // GET: tcuentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcuenta tcuenta = db.tipoCuentaBancaria.Find(id);
            if (tcuenta == null)
            {
                return HttpNotFound();
            }
            return View(tcuenta);
        }

        // POST: tcuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tipo,Activo")] tcuenta tcuenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tcuenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tcuenta);
        }

        // GET: tcuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tcuenta tcuenta = db.tipoCuentaBancaria.Find(id);
            if (tcuenta == null)
            {
                return HttpNotFound();
            }
            return View(tcuenta);
        }

        // POST: tcuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tcuenta tcuenta = db.tipoCuentaBancaria.Find(id);
            db.tipoCuentaBancaria.Remove(tcuenta);
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
