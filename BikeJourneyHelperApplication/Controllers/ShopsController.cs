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
using PagedList;

namespace BikeJourneyHelperApplication.Controllers
{
    public class ShopsController : Controller
    {
        private BikeJourneyHelperContext db = new BikeJourneyHelperContext();

        // GET: Shops
        public ActionResult Index(string order,string currentFilter, string searchShop, int? page)
        {


            ViewBag.CurrentSort = order;
            ViewBag.NameSortParm = String.IsNullOrEmpty(order) ? "shopname_desc" : "";
            if (searchShop != null)
            {
                page = 1;
            }
            else
            {
                searchShop = currentFilter;
            }
           
            var shops = from s in db.Shops
                        select s;

            if (!String.IsNullOrEmpty(searchShop))
            {
                shops = shops.Where(s => s.ShopName.Contains(searchShop));
            }

            switch (order)
            {
                case "shopname_desc":
                    shops = shops.OrderByDescending(s => s.ShopName);
                    break;

                default:
                    shops = shops.OrderBy(s => s.ShopName);
                    break;
              
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(shops.ToPagedList(pageNumber, pageSize));
        }

        // GET: Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        [HttpPost]
        public JsonResult GetLocation(Shop model)
        {
            Thread.Sleep(1000);
            Shop shop = db.Shops.FirstOrDefault(s => s.ShopID == model.ShopID);
          
                return Json(shop, "json");
            

        }

        // GET: Shops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShopID,ShopName,Address,OpeningHours,Lat,Lng")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                db.Shops.Add(shop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shop);
        }

        // GET: Shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShopID,ShopName,Address,OpeningHours,Lat,Lng")] Shop shop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shop);
        }

        // GET: Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = db.Shops.Find(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shop shop = db.Shops.Find(id);
            db.Shops.Remove(shop);
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
