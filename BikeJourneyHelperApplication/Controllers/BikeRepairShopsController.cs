﻿using System;
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
using PagedList;

namespace BikeJourneyHelperApplication.Controllers
{
    public class BikeRepairShopsController : Controller
    {
        private BikeJourneyHelperContext db = new BikeJourneyHelperContext();

        // GET: BikeRepairShops
        public ActionResult Index(string order, string currentFilter, string searchShop, int? page)
        {
            ViewBag.CurrentSort = order;
            ViewBag.NameSortParm = String.IsNullOrEmpty(order) ? "repairshop_desc" : "";
            if (searchShop != null)
            {
                page = 1;
            }
            else
            {
                searchShop = currentFilter;
            }

            ViewBag.CurrentFilter = searchShop;
            var repaireshops = from r in db.BikeRepairShop
                               select r;
            if (!String.IsNullOrEmpty(searchShop))
            {
                repaireshops = repaireshops.Where(r => r.ShopName.Contains(searchShop));
            }

            switch (order)
            {
                case "repairshop_desc":
                    repaireshops = repaireshops.OrderByDescending(r => r.ShopName);
                    break;
                default:
                    repaireshops = repaireshops.OrderBy(r => r.ShopName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(repaireshops.ToPagedList(pageNumber, pageSize));
        }

        // GET: BikeRepairShops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeRepairShop bikeRepairShop = db.BikeRepairShop.Find(id);
            if (bikeRepairShop == null)
            {
                return HttpNotFound();
            }
            return View(bikeRepairShop);
        }

        // POST Garages/GetLocation
        [HttpPost]
        public JsonResult GetLocation(BikeRepairShop model)
        {
            Thread.Sleep(1000);
            BikeRepairShop repairshop = db.BikeRepairShop.FirstOrDefault(rs => rs.BikeRepairShopID == model.BikeRepairShopID);
            return Json(repairshop, "json");

        }

        // GET: BikeRepairShops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BikeRepairShops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BikeRepairShopID,ShopName,Address,OpeningHours,Lat,Lng")] BikeRepairShop bikeRepairShop)
        {
            if (ModelState.IsValid)
            {
                db.BikeRepairShop.Add(bikeRepairShop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bikeRepairShop);
        }

        // GET: BikeRepairShops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeRepairShop bikeRepairShop = db.BikeRepairShop.Find(id);
            if (bikeRepairShop == null)
            {
                return HttpNotFound();
            }
            return View(bikeRepairShop);
        }

        // POST: BikeRepairShops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BikeRepairShopID,ShopName,Address,OpeningHours,Lat,Lng")] BikeRepairShop bikeRepairShop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bikeRepairShop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bikeRepairShop);
        }

        // GET: BikeRepairShops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BikeRepairShop bikeRepairShop = db.BikeRepairShop.Find(id);
            if (bikeRepairShop == null)
            {
                return HttpNotFound();
            }
            return View(bikeRepairShop);
        }

        // POST: BikeRepairShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BikeRepairShop bikeRepairShop = db.BikeRepairShop.Find(id);
            db.BikeRepairShop.Remove(bikeRepairShop);
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
