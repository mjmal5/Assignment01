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
    public class PizzaRatingsController : Controller
    {
        private MariosPizzaModelContainer db = new MariosPizzaModelContainer();

        // GET: PizzaRatings
        public ActionResult Index()
        {
            var pizzaRatings = db.PizzaRatings.Include(p => p.Pizza);
            return View(pizzaRatings.ToList());
        }

        // GET: PizzaRatings/Create
        public ActionResult Rate()
        {
            ViewBag.PizzaId = new SelectList(db.Pizzas, "Id", "Name");
            return View();
        }

        // POST: PizzaRatings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rate([Bind(Include = "Id,Rating,PizzaId")] PizzaRating pizzaRating)
        {

            pizzaRating.UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                db.PizzaRatings.Add(pizzaRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PizzaId = new SelectList(db.Pizzas, "Id", "Name", pizzaRating.PizzaId);
            return View(pizzaRating);
        }

        // GET: PizzaRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PizzaRating pizzaRating = db.PizzaRatings.Find(id);
            if (pizzaRating == null)
            {
                return HttpNotFound();
            }
            return View(pizzaRating);
        }

        // POST: PizzaRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PizzaRating pizzaRating = db.PizzaRatings.Find(id);
            db.PizzaRatings.Remove(pizzaRating);
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
