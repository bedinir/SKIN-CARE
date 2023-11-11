using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SKIN_CARE.Models;

namespace SKIN_CARE.Controllers
{
    public class KategoritesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Kategorites
        public ActionResult Index()
        {
       
            return View(db.Kategorite.ToList());
        }

        [HttpGet]
        public ActionResult KerkoKategori(string kategori)
        {

            if (!string.IsNullOrEmpty(kategori))
            {
                return Json( db.Kategorite.Where(s => s.EmriKategorise.Contains(kategori)), JsonRequestBehavior.AllowGet);
            }
            return View(db.Kategorite.ToList());
        }

       

        // GET: Kategorites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorite kategorite = db.Kategorite.Find(id);
            if (kategorite == null)
            {
                return HttpNotFound();
            }
            return View(kategorite);
        }

        [Authorize(Roles = "Admin")]
        // GET: Kategorites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategorites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmriKategorise")] Kategorite kategorite)
        {
            if (ModelState.IsValid)
            {
                db.Kategorite.Add(kategorite);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategorite);
        }

        [Authorize(Roles = "Admin")]
        // GET: Kategorites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorite kategorite = db.Kategorite.Find(id);
            if (kategorite == null)
            {
                return HttpNotFound();
            }
            return View(kategorite);
        }

        // POST: Kategorites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmriKategorise")] Kategorite kategorite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategorite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorite);
        }

        [Authorize(Roles = "Admin")]
        // GET: Kategorites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategorite kategorite = db.Kategorite.Find(id);
            if (kategorite == null)
            {
                return HttpNotFound();
            }
            return View(kategorite);
        }

        // POST: Kategorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategorite kategorite = db.Kategorite.Find(id);
            db.Kategorite.Remove(kategorite);
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
