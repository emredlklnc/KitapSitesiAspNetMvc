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
    public class KullanıcılarController : Controller
    {
        private KitapSitesiEntities db = new KitapSitesiEntities();

        // GET: Kullanıcılar
        public ActionResult CIKIS()
        {
            Session["KULLANICIADI"] = null;
            RedirectToAction("Index","Home");
            return View();
        }
        public ActionResult GIRIS()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GIRIS(Kullanıcılar Model)
        {
            var KULLANICI = db.Kullanıcılar.FirstOrDefault(x => x.KULLANICIADI == Model.KULLANICIADI && x.SIFRE == Model.SIFRE);
            if (KULLANICI != null)
            {
                Session["KULLANICIADI"] = KULLANICI;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Hata("kullanıcı Adı veya sıfre hatalı");
            return View();
        }
        public ActionResult Index()
        {
            return View(db.Kullanıcılar.ToList());
        }
        // GET: Kullanıcılar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcılar kullanıcılar = db.Kullanıcılar.Find(id);
            if (kullanıcılar == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcılar);
        }

        // GET: Kullanıcılar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanıcılar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KULLANICIADI,SIFRE,EMAİL,TARİH")] Kullanıcılar kullanıcılar)
        {
            if (ModelState.IsValid)
            {
                db.Kullanıcılar.Add(kullanıcılar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kullanıcılar);
        }

        // GET: Kullanıcılar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcılar kullanıcılar = db.Kullanıcılar.Find(id);
            if (kullanıcılar == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcılar);
        }

        // POST: Kullanıcılar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,KULLANICIADI,SIFRE,EMAİL,TARİH")] Kullanıcılar kullanıcılar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kullanıcılar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kullanıcılar);
        }

        // GET: Kullanıcılar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kullanıcılar kullanıcılar = db.Kullanıcılar.Find(id);
            if (kullanıcılar == null)
            {
                return HttpNotFound();
            }
            return View(kullanıcılar);
        }

        // POST: Kullanıcılar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kullanıcılar kullanıcılar = db.Kullanıcılar.Find(id);
            db.Kullanıcılar.Remove(kullanıcılar);
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
