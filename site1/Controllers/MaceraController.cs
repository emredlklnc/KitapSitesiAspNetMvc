using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using site1.Models;

namespace site1.Controllers
{
    public class MaceraController : Controller
    {
        private KitapSitesiEntities db = new KitapSitesiEntities();

        // GET: Macera
        public ActionResult Index()
        {
            return View(db.Macera.ToList());
        }

        // GET: Macera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Macera macera = db.Macera.Find(id);
            if (macera == null)
            {
                return HttpNotFound();
            }
            return View(macera);
        }

        // GET: Macera/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Macera/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,MaceraKitabıAdı,KitapResmi,Yazarı,Özeti,Fiyat")] Macera macera)
        {
            if (ModelState.IsValid)
            {
                db.Macera.Add(macera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(macera);
        }

        // GET: Macera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Macera macera = db.Macera.Find(id);
            if (macera == null)
            {
                return HttpNotFound();
            }
            return View(macera);
        }

        // POST: Macera/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,MaceraKitabıAdı,KitapResmi,Yazarı,Özeti,Fiyat")] Macera macera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(macera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(macera);
        }

        // GET: Macera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Macera macera = db.Macera.Find(id);
            if (macera == null)
            {
                return HttpNotFound();
            }
            return View(macera);
        }

        // POST: Macera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Macera macera = db.Macera.Find(id);
            db.Macera.Remove(macera);
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
