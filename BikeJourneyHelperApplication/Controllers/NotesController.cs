using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeJourneyHelperApplication.DAL;
using BikeJourneyHelperApplication.Models;
using System.Threading;

namespace BikeJourneyHelperApplication.Controllers
{
    public class NotesController : Controller
    {
        private BikeJourneyHelperContext db = new BikeJourneyHelperContext();

        [Authorize]
        // GET: Notes
        public ActionResult Index()
        {
            return View(db.Notes.ToList());
        }


        // POST Notes/GetDetailedInfo
        [HttpPost]
        public JsonResult GetDetailedInfo(Note model)
        {
            Thread.Sleep(1000);
            Note note = db.Notes.FirstOrDefault(n => n.NoteID == model.NoteID);
            return Json(note, "json");

        }

        // GET: Notes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoteID,Tittle,Date,Content")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Notes.Add(note);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(note);
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NoteID,Tittle,Date,Content")] Note note)
        {
            if (ModelState.IsValid)
            {
                db.Entry(note).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Note note = db.Notes.Find(id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Note note = db.Notes.Find(id);
            db.Notes.Remove(note);
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
