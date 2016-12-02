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
    public class DublinBikesController : Controller
    {
        private BikeJourneyHelperContext db = new BikeJourneyHelperContext();

        // GET: DublinBikes
        public ActionResult Index()
        {
            return View(db.DublinBikes.ToList());
        }

        // GET: DublinBikes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DublinBike dublinBike = db.DublinBikes.Find(id);
            if (dublinBike == null)
            {
                return HttpNotFound();
            }
            return View(dublinBike);
        }

        // POST Garages/GetLocation
        [HttpPost]
        public JsonResult GetLocation(DublinBike model)
        {
            Thread.Sleep(1000);
            DublinBike dublinbike = db.DublinBikes.FirstOrDefault(dubbike => dubbike.DublinBikeID == model.DublinBikeID);
            return Json(dublinbike, "json");

        }

        // GET: DublinBikes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DublinBikes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DublinBikeID,Location,Available,Lat,Lng")] DublinBike dublinBike)
        {
            if (ModelState.IsValid)
            {
                db.DublinBikes.Add(dublinBike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dublinBike);
        }

        // GET: DublinBikes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DublinBike dublinBike = db.DublinBikes.Find(id);
            if (dublinBike == null)
            {
                return HttpNotFound();
            }
            return View(dublinBike);
        }

        // POST: DublinBikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DublinBikeID,Location,Available,Lat,Lng")] DublinBike dublinBike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dublinBike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dublinBike);
        }

        // GET: DublinBikes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DublinBike dublinBike = db.DublinBikes.Find(id);
            if (dublinBike == null)
            {
                return HttpNotFound();
            }
            return View(dublinBike);
        }

        // POST: DublinBikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DublinBike dublinBike = db.DublinBikes.Find(id);
            db.DublinBikes.Remove(dublinBike);
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
