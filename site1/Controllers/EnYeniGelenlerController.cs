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
    public class EnYeniGelenlerController : Controller
    {
        private KitapSitesiEntities db = new KitapSitesiEntities();

        // GET: EnYeniGelenler
        public ActionResult Index()
        {
            return View(db.EnYeniGelenler.ToList());
        }

        // GET: EnYeniGelenler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnYeniGelenler enYeniGelenler = db.EnYeniGelenler.Find(id);
            if (enYeniGelenler == null)
            {
                return HttpNotFound();
            }
            return View(enYeniGelenler);
        }

        // GET: EnYeniGelenler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnYeniGelenler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,YeniGelenKitapAdı,KitapResmi,Yazarı,Özeti,Fiyatı")] EnYeniGelenler enYeniGelenler)
        {
            if (ModelState.IsValid)
            {
                db.EnYeniGelenler.Add(enYeniGelenler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(enYeniGelenler);
        }

        // GET: EnYeniGelenler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnYeniGelenler enYeniGelenler = db.EnYeniGelenler.Find(id);
            if (enYeniGelenler == null)
            {
                return HttpNotFound();
            }
            return View(enYeniGelenler);
        }

        // POST: EnYeniGelenler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,YeniGelenKitapAdı,KitapResmi,Yazarı,Özeti,Fiyatı")] EnYeniGelenler enYeniGelenler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enYeniGelenler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enYeniGelenler);
        }

        // GET: EnYeniGelenler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnYeniGelenler enYeniGelenler = db.EnYeniGelenler.Find(id);
            if (enYeniGelenler == null)
            {
                return HttpNotFound();
            }
            return View(enYeniGelenler);
        }

        // POST: EnYeniGelenler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnYeniGelenler enYeniGelenler = db.EnYeniGelenler.Find(id);
            db.EnYeniGelenler.Remove(enYeniGelenler);
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
