using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment.Models;
using Microsoft.AspNet.Identity;

namespace FIT5032_Assignment.Controllers
{
    [Authorize(Roles = "SuperUser, Customer")]
    public class BookingsController : Controller
    {
        private MariosPizzaModelContainer db = new MariosPizzaModelContainer();

        // GET: Bookings
        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Restaraunt).Include(b => b.Customer);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {

        
            //string currentUserId = User.Identity.GetUserId();
            //return View(db.Bookings.Where(m => m.AuthorId ==
            //currentUserId).ToList());

            ViewBag.RestarauntRestId = new SelectList(db.Restaraunts, "RestId", "RestAddress");
            ViewBag.CustomerCustId = new SelectList(db.Customers, "CustId", "CustFirstName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingId,BookingGuestNum,BookingDate,BookingTime,RestarauntRestId,CustomerCustId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestarauntRestId = new SelectList(db.Restaraunts, "RestId", "RestAddress", booking.RestarauntRestId);
            ViewBag.CustomerCustId = new SelectList(db.Customers, "CustId", "CustFirstName", booking.CustomerCustId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestarauntRestId = new SelectList(db.Restaraunts, "RestId", "RestAddress", booking.RestarauntRestId);
            ViewBag.CustomerCustId = new SelectList(db.Customers, "CustId", "CustFirstName", booking.CustomerCustId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingId,BookingGuestNum,BookingDate,BookingTime,RestarauntRestId,CustomerCustId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestarauntRestId = new SelectList(db.Restaraunts, "RestId", "RestAddress", booking.RestarauntRestId);
            ViewBag.CustomerCustId = new SelectList(db.Customers, "CustId", "CustFirstName", booking.CustomerCustId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
