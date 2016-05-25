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
    public class RentsController : Controller
    {
        private RentAKittenEntities db = new RentAKittenEntities();

        // GET: Rents
        public ActionResult Index()
        {
            var rents = db.Rents.Include(r => r.Customer).Include(r => r.Kitten).Include(r => r.Rating).Include(r => r.RentalDetail);
            return View(rents.ToList());
        }

        // GET: Rents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // GET: Rents/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.KittenID = new SelectList(db.Kittens, "KittenID", "KittenName");
            ViewBag.RatingID = new SelectList(db.Ratings, "RatingID", "RatingID");
            ViewBag.RentalDetailID = new SelectList(db.RentalDetails, "RentalDetailID", "RentalDetailID");
            return View();
        }

        // POST: Rents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RentalID,RentalDate,ReturnDate,CustomerID,KittenID,RatingID,RentalDetailID")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                db.Rents.Add(rent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", rent.CustomerID);
            ViewBag.KittenID = new SelectList(db.Kittens, "KittenID", "KittenName", rent.KittenID);
            ViewBag.RatingID = new SelectList(db.Ratings, "RatingID", "RatingID", rent.RatingID);
            ViewBag.RentalDetailID = new SelectList(db.RentalDetails, "RentalDetailID", "RentalDetailID", rent.RentalDetailID);
            return View(rent);
        }

        // GET: Rents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", rent.CustomerID);
            ViewBag.KittenID = new SelectList(db.Kittens, "KittenID", "KittenName", rent.KittenID);
            ViewBag.RatingID = new SelectList(db.Ratings, "RatingID", "RatingID", rent.RatingID);
            ViewBag.RentalDetailID = new SelectList(db.RentalDetails, "RentalDetailID", "RentalDetailID", rent.RentalDetailID);
            return View(rent);
        }

        // POST: Rents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RentalID,RentalDate,ReturnDate,CustomerID,KittenID,RatingID,RentalDetailID")] Rent rent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", rent.CustomerID);
            ViewBag.KittenID = new SelectList(db.Kittens, "KittenID", "KittenName", rent.KittenID);
            ViewBag.RatingID = new SelectList(db.Ratings, "RatingID", "RatingID", rent.RatingID);
            ViewBag.RentalDetailID = new SelectList(db.RentalDetails, "RentalDetailID", "RentalDetailID", rent.RentalDetailID);
            return View(rent);
        }

        // GET: Rents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent rent = db.Rents.Find(id);
            if (rent == null)
            {
                return HttpNotFound();
            }
            return View(rent);
        }

        // POST: Rents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rent rent = db.Rents.Find(id);
            db.Rents.Remove(rent);
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
