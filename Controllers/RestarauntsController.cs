using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment.Models;

namespace FIT5032_Assignment.Controllers
{
    public class RestarauntsController : Controller
    {
        private MariosPizzaModelContainer db = new MariosPizzaModelContainer();

        // GET: Restaraunts
        public ActionResult Index()
        {
            return View(db.Restaraunts.ToList());
        }

        // GET: Restaraunts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaraunt restaraunt = db.Restaraunts.Find(id);
            if (restaraunt == null)
            {
                return HttpNotFound();
            }
            return View(restaraunt);
        }

        // GET: Restaraunts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaraunts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestId,RestAddress,RestPhone")] Restaraunt restaraunt)
        {
            if (ModelState.IsValid)
            {
                db.Restaraunts.Add(restaraunt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaraunt);
        }

        // GET: Restaraunts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaraunt restaraunt = db.Restaraunts.Find(id);
            if (restaraunt == null)
            {
                return HttpNotFound();
            }
            return View(restaraunt);
        }

        // POST: Restaraunts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestId,RestAddress,RestPhone")] Restaraunt restaraunt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaraunt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaraunt);
        }

        // GET: Restaraunts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaraunt restaraunt = db.Restaraunts.Find(id);
            if (restaraunt == null)
            {
                return HttpNotFound();
            }
            return View(restaraunt);
        }

        // POST: Restaraunts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaraunt restaraunt = db.Restaraunts.Find(id);
            db.Restaraunts.Remove(restaraunt);
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
