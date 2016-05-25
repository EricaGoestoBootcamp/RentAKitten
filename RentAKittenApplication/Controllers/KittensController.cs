using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RentAKittenApplication.Models;

namespace RentAKittenApplication.Controllers
{
    public class KittensController : Controller
    {
        private RentAKittenEntities db = new RentAKittenEntities();

        // GET: Kittens
        public ActionResult Index()
        {
            return View(db.Kittens.ToList());
        }

        // GET: Kittens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitten kitten = db.Kittens.Find(id);
            if (kitten == null)
            {
                return HttpNotFound();
            }
            return View(kitten);
        }

        // GET: Kittens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kittens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KittenID,KittenName,KittenColor,FurLength,Personality,KittyImage")] Kitten kitten)
        {
            if (ModelState.IsValid)
            {
                db.Kittens.Add(kitten);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kitten);
        }

        // GET: Kittens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitten kitten = db.Kittens.Find(id);
            if (kitten == null)
            {
                return HttpNotFound();
            }
            return View(kitten);
        }

        // POST: Kittens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KittenID,KittenName,KittenColor,FurLength,Personality,KittyImage")] Kitten kitten)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kitten).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kitten);
        }

        // GET: Kittens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kitten kitten = db.Kittens.Find(id);
            if (kitten == null)
            {
                return HttpNotFound();
            }
            return View(kitten);
        }

        // POST: Kittens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kitten kitten = db.Kittens.Find(id);
            db.Kittens.Remove(kitten);
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
