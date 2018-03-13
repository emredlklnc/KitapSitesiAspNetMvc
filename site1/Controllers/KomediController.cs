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
    public class KomediController : Controller
    {
        private KitapSitesiEntities db = new KitapSitesiEntities();

        // GET: Komedi
        public ActionResult Index()
        {
            return View(db.Komedi.ToList());
        }

        // GET: Komedi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komedi komedi = db.Komedi.Find(id);
            if (komedi == null)
            {
                return HttpNotFound();
            }
            return View(komedi);
        }

        // GET: Komedi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Komedi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,KomediKitapAdı,KitapResmi,Yazarı,Özeti,Fiyat")] Komedi komedi)
        {
            if (ModelState.IsValid)
            {
                db.Komedi.Add(komedi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(komedi);
        }

        // GET: Komedi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komedi komedi = db.Komedi.Find(id);
            if (komedi == null)
            {
                return HttpNotFound();
            }
            return View(komedi);
        }

        // POST: Komedi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,KomediKitapAdı,KitapResmi,Yazarı,Özeti,Fiyat")] Komedi komedi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(komedi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(komedi);
        }

        // GET: Komedi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komedi komedi = db.Komedi.Find(id);
            if (komedi == null)
            {
                return HttpNotFound();
            }
            return View(komedi);
        }

        // POST: Komedi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Komedi komedi = db.Komedi.Find(id);
            db.Komedi.Remove(komedi);
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
