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
    public class RomantikController : Controller
    {
        private KitapSitesiEntities db = new KitapSitesiEntities();

        // GET: Romantik
        public ActionResult Index()
        {
            return View(db.Romantik.ToList());
        }

        // GET: Romantik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Romantik romantik = db.Romantik.Find(id);
            if (romantik == null)
            {
                return HttpNotFound();
            }
            return View(romantik);
        }

        // GET: Romantik/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Romantik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,RomantikKitapAdı,KitapResmi,Yazarı,Özeti,Fiyat")] Romantik romantik)
        {
            if (ModelState.IsValid)
            {
                db.Romantik.Add(romantik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(romantik);
        }

        // GET: Romantik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Romantik romantik = db.Romantik.Find(id);
            if (romantik == null)
            {
                return HttpNotFound();
            }
            return View(romantik);
        }

        // POST: Romantik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,RomantikKitapAdı,KitapResmi,Yazarı,Özeti,Fiyat")] Romantik romantik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(romantik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(romantik);
        }

        // GET: Romantik/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Romantik romantik = db.Romantik.Find(id);
            if (romantik == null)
            {
                return HttpNotFound();
            }
            return View(romantik);
        }

        // POST: Romantik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Romantik romantik = db.Romantik.Find(id);
            db.Romantik.Remove(romantik);
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
