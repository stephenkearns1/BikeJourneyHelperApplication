using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using BikeJourneyHelperApplication.DAL;
using BikeJourneyHelperApplication.Models;

namespace BikeJourneyHelperApplication.Controllers
{
    public class GaragesController : Controller
    {
        private BikeJourneyHelperContext db = new BikeJourneyHelperContext();

        // GET: Garages
        public ActionResult Index()
        {
            return View(db.Garages.ToList());
        }

        // GET: Garages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garage garage = db.Garages.Find(id);
            if (garage == null)
            {
                return HttpNotFound();
            }
            return View(garage);
        }

        // POST Garages/GetLocation
        [HttpPost]
        public JsonResult GetLocation(Garage model)
        {
            Thread.Sleep(1000);
            Garage garage = db.Garages.FirstOrDefault(s => s.GarageID == model.GarageID);
            return Json(garage, "json");

        }


        // GET: Garages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Garages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GarageID,Name,Address,OpeningHours,PumpsAvailable,Lat,Lng")] Garage garage)
        {
            if (ModelState.IsValid)
            {
                db.Garages.Add(garage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(garage);
        }

        // GET: Garages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garage garage = db.Garages.Find(id);
            if (garage == null)
            {
                return HttpNotFound();
            }
            return View(garage);
        }

        // POST: Garages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GarageID,Name,Address,OpeningHours,PumpsAvailable,Lat,Lng")] Garage garage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(garage);
        }

        // GET: Garages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garage garage = db.Garages.Find(id);
            if (garage == null)
            {
                return HttpNotFound();
            }
            return View(garage);
        }

        // POST: Garages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Garage garage = db.Garages.Find(id);
            db.Garages.Remove(garage);
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
