using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using geaje.DataContext;
using geaje.Models;

namespace geaje.Controllers
{
    public class adminBookController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: adminBook
        public ActionResult Index()
        {
            var books = db.books.Include(b => b.venueModel);
            return View(books.ToList());
        }

        // GET: adminBook/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || db.books == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = db.books
                .Include(b => b.venueModel)
                .FirstOrDefault(m => m.booking_id == id);
      
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: adminBook/Create
        public ActionResult Create()
        {
            ViewBag.id_venue = new SelectList(db.venues, "venue_id", "venue_name");
            return View();
        }

        // POST: adminBook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "booking_id,customer_name,id_venue,tanggal_book,lama_book,no_hp")] bookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(bookModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_venue = new SelectList(db.venues, "venue_id", "venue_name", bookModel.id_venue);
            return View(bookModel);
        }

        // GET: adminBook/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bookModel bookModel = db.books.Find(id);
            if (bookModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_venue = new SelectList(db.venues, "venue_id", "venue_name", bookModel.id_venue);
            return View(bookModel);
        }

        // POST: adminBook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "booking_id,customer_name,id_venue,tanggal_book,lama_book,no_hp")] bookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_venue = new SelectList(db.venues, "venue_id", "venue_name", bookModel.id_venue);
            return View(bookModel);
        }

        // GET: adminBook/Delete/5
        public ActionResult Delete(int? id)
        {
            if(id == null || db.books == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = db.books
                .Include(b => b.venueModel)
                .FirstOrDefault(m => m.booking_id == id);

            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: adminBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookModel bookModel = db.books.Find(id);
            db.books.Remove(bookModel);
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
