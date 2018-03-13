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
    public class EnCokSatılanlarController : Controller
    {
        private KitapSitesiEntities db = new KitapSitesiEntities();

        // GET: EnCokSatılanlar
        public ActionResult Index()
        {
            return View(db.EnCokSatılanlar.ToList());
        }

        // GET: EnCokSatılanlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnCokSatılanlar enCokSatılanlar = db.EnCokSatılanlar.Find(id);
            if (enCokSatılanlar == null)
            {
                return HttpNotFound();
            }
            return View(enCokSatılanlar);
        }

        // GET: EnCokSatılanlar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnCokSatılanlar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,EncokSatılanKitapAdı,EncokSatılanKitapResim,Fiyat")] EnCokSatılanlar enCokSatılanlar)
        {
            if (ModelState.IsValid)
            {
                db.EnCokSatılanlar.Add(enCokSatılanlar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enCokSatılanlar);
        }

        // GET: EnCokSatılanlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnCokSatılanlar enCokSatılanlar = db.EnCokSatılanlar.Find(id);
            if (enCokSatılanlar == null)
            {
                return HttpNotFound();
            }
            return View(enCokSatılanlar);
        }

        // POST: EnCokSatılanlar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,EncokSatılanKitapAdı,EncokSatılanKitapResim,Fiyat")] EnCokSatılanlar enCokSatılanlar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enCokSatılanlar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enCokSatılanlar);
        }

        // GET: EnCokSatılanlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnCokSatılanlar enCokSatılanlar = db.EnCokSatılanlar.Find(id);
            if (enCokSatılanlar == null)
            {
                return HttpNotFound();
            }
            return View(enCokSatılanlar);
        }

        // POST: EnCokSatılanlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnCokSatılanlar enCokSatılanlar = db.EnCokSatılanlar.Find(id);
            db.EnCokSatılanlar.Remove(enCokSatılanlar);
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
