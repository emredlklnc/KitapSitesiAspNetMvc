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
    public class TemelEserlerController : Controller
    {
        private KitapSitesiEntities db = new KitapSitesiEntities();

        // GET: TemelEserler
        public ActionResult Index()
        {
            return View(db.TemelEserler.ToList());
        }

        // GET: TemelEserler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemelEserler temelEserler = db.TemelEserler.Find(id);
            if (temelEserler == null)
            {
                return HttpNotFound();
            }
            return View(temelEserler);
        }

        // GET: TemelEserler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TemelEserler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TemelEserAdı,KitapResmi,Yazarı,Özeti,Fiyat")] TemelEserler temelEserler)
        {
            if (ModelState.IsValid)
            {
                db.TemelEserler.Add(temelEserler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(temelEserler);
        }

        // GET: TemelEserler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemelEserler temelEserler = db.TemelEserler.Find(id);
            if (temelEserler == null)
            {
                return HttpNotFound();
            }
            return View(temelEserler);
        }

        // POST: TemelEserler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TemelEserAdı,KitapResmi,Yazarı,Özeti,Fiyat")] TemelEserler temelEserler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temelEserler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(temelEserler);
        }

        // GET: TemelEserler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TemelEserler temelEserler = db.TemelEserler.Find(id);
            if (temelEserler == null)
            {
                return HttpNotFound();
            }
            return View(temelEserler);
        }

        // POST: TemelEserler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TemelEserler temelEserler = db.TemelEserler.Find(id);
            db.TemelEserler.Remove(temelEserler);
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
