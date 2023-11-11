using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SKIN_CARE.Models;

namespace SKIN_CARE.Controllers
{
    
    public class ProduktetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Produktets
        public ActionResult Index(int? id, string search, int? kategoriID, string rendit)
        {

            if (id != null)
            {
                var produkt = from p in db.Produktet
                              where p.MarkaID == id
                              select p;
                return View(produkt);
            }
            else
                if (!string.IsNullOrEmpty(search))
            {
                var prod = from p in db.Produktet
                           where p.Emri.Contains(search)
                           select p;
                return View(prod);
            }
            else
                if (kategoriID != null)
            {
                var produkt = from p in db.Produktet
                              where p.KategoriID == kategoriID
                              select p;
                return View(produkt);
            }

            else
                ViewData["Renditja"] = string.IsNullOrEmpty(rendit) ? "desc" : "";
                ViewData["Renditja"] = string.IsNullOrEmpty(rendit) ? "asc" : "";
            switch (rendit)
            {
                case "desc":
                    return View(db.Produktet.OrderByDescending(p => p.Cmimi).ToList());
                case "asc":
                    return View(db.Produktet.OrderBy(p => p.Cmimi).ToList());
                case "all":
                    return View(db.Produktet.ToList());
            }
            return View(db.Produktet.ToList());
        }


        public ActionResult ShtoNeKart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produktet produkte = db.Produktet.Find(id);
            if (produkte == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAuthenticated)
            {
                string userId = User.Identity.GetUserId();
                ApplicationUser perdoruesi = db.Users.FirstOrDefault(x => x.Id == userId);
                ViewBag.Username = "Pershendetje " + perdoruesi.UserName;

                if (userId != null)
                {

                    if (Session["kart"] == null)
                    {
                        List<Karta> kart = new List<Karta>();

                        kart.Add(new Karta
                        {
                            Produktet = produkte,
                            Sasia = 1
                        });
                        Session["kart"] = kart;
                    }
                    else
                    {
                        List<Karta> kart = (List<Karta>)Session["kart"];
                        int index = isExist(id);
                        if (index != -1)
                        {
                            kart[index].Sasia++;
                        }
                        else
                        {
                            kart.Add(new Karta()
                            {
                                Produktet = produkte,
                                Sasia = 1
                            });
                        }
                        Session["kart"] = kart;
                    }

                }
            }
            //Karta Guest
            else
            {
                ViewBag.Username = "Guest";
                if (Session["guest"] == null)
                {
                    List<Karta> kart = new List<Karta>();

                    kart.Add(new Karta
                    {
                        Produktet = produkte,
                        Sasia = 1
                    });
                    Session["guest"] = kart;
                }
                else
                {
                    List<Karta> kart = (List<Karta>)Session["guest"];
                    int index = Ekziston(id);
                    if (index != -1)
                    {
                        kart[index].Sasia++;
                    }
                    else
                    {
                        kart.Add(new Karta()
                        {
                            Produktet = produkte,
                            Sasia = 1
                        });
                    }
                    Session["guest"] = kart;
                }



            }
            return View("ShtoNeKart");

        }

        public ActionResult Remove(int id)
        {
            List<Karta> kart = (List<Karta>)Session["kart"];
            int index = isExist(id);
            kart.RemoveAt(index);
            Session["kart"] = kart;
            return View("ShtoNeKart");
        }

        private int isExist(int? id)
        {
            List<Karta> kart = (List<Karta>)Session["kart"];
            for (int i = 0; i < kart.Count; i++)
                if (kart[i].Produktet.ID.Equals(id))
                    return i;
            return -1;
        }

        private int Ekziston(int? id)
        {
            List<Karta> kart = (List<Karta>)Session["guest"];
            for (int i = 0; i < kart.Count; i++)
                if (kart[i].Produktet.ID.Equals(id))
                    return i;
            return -1;
        }
        public ActionResult Fshi(int id)
        {
            List<Karta> kart = (List<Karta>)Session["guest"];
            int index = Ekziston(id);
            kart.RemoveAt(index);
            Session["guest"] = kart;
            return View("ShtoNeKart");
        }


        [Authorize]
        // GET: Produktets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produktet produktet = db.Produktet.Find(id);
            if (produktet == null)
            {
                return HttpNotFound();
            }
            return View(produktet);
        }

        [Authorize(Roles = "Admin")]
        // GET: Produktets/Create
        public ActionResult Create()
        {
            ViewBag.KategoriID = new SelectList(db.Kategorite, "ID", "EmriKategorise");
            ViewBag.MarkaID = new SelectList(db.Markat, "ID", "EmriMarkes");
            return View();
        }

        // POST: Produktets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Emri,Imazhi,Pershkrimi,Cmimi,KategoriID,MarkaID")] Produktet produktet, HttpPostedFileBase Imazhi)
        {
            ViewBag.KategoriID = new SelectList(db.Kategorite, "ID", "EmriKategorise", produktet.KategoriID);
            ViewBag.MarkaID = new SelectList(db.Markat, "ID", "EmriMarkes", produktet.MarkaID);

            if (ModelState.IsValid)
            {
                WebImage img = new WebImage(Imazhi.InputStream);
                img.Save(Konstante.ImazhPath + Imazhi.FileName);

                db.Produktet.Add(new Produktet
                {
                    Emri = produktet.Emri,
                    Imazhi = Imazhi.FileName,
                    Pershkrimi = produktet.Pershkrimi,
                    Cmimi = produktet.Cmimi,
                    KategoriID = produktet.KategoriID,
                    MarkaID = produktet.MarkaID

                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produktet);
        }

        [Authorize(Roles = "Admin")]
        // GET: Produktets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produktet produktet = db.Produktet.Find(id);
            if (produktet == null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriID = new SelectList(db.Kategorite, "ID", "EmriKategorise", produktet.KategoriID);
            ViewBag.MarkaID = new SelectList(db.Markat, "ID", "EmriMarkes", produktet.MarkaID);
            return View(produktet);
        }

        // POST: Produktets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Emri,Imazhi,Pershkrimi,Cmimi,KategoriID,MarkaID")] Produktet produktet)
        {
            ViewBag.KategoriID = new SelectList(db.Kategorite, "ID", "EmriKategorise", produktet.KategoriID);
            ViewBag.MarkaID = new SelectList(db.Markat, "ID", "EmriMarkes", produktet.MarkaID);
            if (ModelState.IsValid)
            {
                db.Entry(produktet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produktet);
        }
        [Authorize(Roles = "Admin")]
        // GET: Produktets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produktet produktet = db.Produktet.Find(id);
            if (produktet == null)
            {
                return HttpNotFound();
            }
            return View(produktet);
        }

        // POST: Produktets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produktet produktet = db.Produktet.Find(id);
            db.Produktet.Remove(produktet);
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
