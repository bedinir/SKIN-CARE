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
    public class MarkatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Markats
        public ActionResult Index()
        {

            return View(db.Markat.ToList());
        }

        // GET: Markats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markat markat = db.Markat.Find(id);
            if (markat == null)
            {
                return HttpNotFound();
            }
            return View(markat);
        }

        [Authorize(Roles = "Admin")]
        // GET: Markats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Markats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmriMarkes")] Markat markat)
        {
            if (ModelState.IsValid)
            {
                db.Markat.Add(markat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(markat);
        }

        [Authorize(Roles = "Admin")]
        // GET: Markats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markat markat = db.Markat.Find(id);
            if (markat == null)
            {
                return HttpNotFound();
            }
            return View(markat);
        }

        // POST: Markats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmriMarkes")] Markat markat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(markat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(markat);
        }

        [Authorize(Roles = "Admin")]
        // GET: Markats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Markat markat = db.Markat.Find(id);
            if (markat == null)
            {
                return HttpNotFound();
            }
            return View(markat);
        }

        // POST: Markats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Markat markat = db.Markat.Find(id);
            db.Markat.Remove(markat);
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
