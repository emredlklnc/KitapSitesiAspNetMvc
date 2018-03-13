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
    public class KisiselGelisimController : Controller
    {
        private KitapSitesiEntities db = new KitapSitesiEntities();

        // GET: KisiselGelisim
        public ActionResult Index()
        {
            return View(db.KisiselGelisim.ToList());
        }

        // GET: KisiselGelisim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KisiselGelisim kisiselGelisim = db.KisiselGelisim.Find(id);
            if (kisiselGelisim == null)
            {
                return HttpNotFound();
            }
            return View(kisiselGelisim);
        }

        // GET: KisiselGelisim/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KisiselGelisim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,KisişelGelişimKitapAdı,KitapResmi,Yazarı,Özeti,Fiyat")] KisiselGelisim kisiselGelisim)
        {
            if (ModelState.IsValid)
            {
                db.KisiselGelisim.Add(kisiselGelisim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kisiselGelisim);
        }

        // GET: KisiselGelisim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KisiselGelisim kisiselGelisim = db.KisiselGelisim.Find(id);
            if (kisiselGelisim == null)
            {
                return HttpNotFound();
            }
            return View(kisiselGelisim);
        }

        // POST: KisiselGelisim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,KisişelGelişimKitapAdı,KitapResmi,Yazarı,Özeti,Fiyat")] KisiselGelisim kisiselGelisim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kisiselGelisim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kisiselGelisim);
        }

        // GET: KisiselGelisim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KisiselGelisim kisiselGelisim = db.KisiselGelisim.Find(id);
            if (kisiselGelisim == null)
            {
                return HttpNotFound();
            }
            return View(kisiselGelisim);
        }

        // POST: KisiselGelisim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KisiselGelisim kisiselGelisim = db.KisiselGelisim.Find(id);
            db.KisiselGelisim.Remove(kisiselGelisim);
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
