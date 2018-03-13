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
    public class BilimKurguController : Controller
    {
        private KitapSitesiEntities db = new KitapSitesiEntities();

        // GET: BilimKurgu
        public ActionResult Index()
        {
            return View(db.BilimKurgu.ToList());
        }

        // GET: BilimKurgu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilimKurgu bilimKurgu = db.BilimKurgu.Find(id);
            if (bilimKurgu == null)
            {
                return HttpNotFound();
            }
            return View(bilimKurgu);
        }

        // GET: BilimKurgu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BilimKurgu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,BilimKurguKitapAdı,KitapResmi,Yazarı,Özeti,Fiyat")] BilimKurgu bilimKurgu)
        {
            if (ModelState.IsValid)
            {
                db.BilimKurgu.Add(bilimKurgu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bilimKurgu);
        }

        // GET: BilimKurgu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilimKurgu bilimKurgu = db.BilimKurgu.Find(id);
            if (bilimKurgu == null)
            {
                return HttpNotFound();
            }
            return View(bilimKurgu);
        }

        // POST: BilimKurgu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,BilimKurguKitapAdı,KitapResmi,Yazarı,Özeti,Fiyat")] BilimKurgu bilimKurgu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bilimKurgu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bilimKurgu);
        }

        // GET: BilimKurgu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilimKurgu bilimKurgu = db.BilimKurgu.Find(id);
            if (bilimKurgu == null)
            {
                return HttpNotFound();
            }
            return View(bilimKurgu);
        }

        // POST: BilimKurgu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BilimKurgu bilimKurgu = db.BilimKurgu.Find(id);
            db.BilimKurgu.Remove(bilimKurgu);
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
