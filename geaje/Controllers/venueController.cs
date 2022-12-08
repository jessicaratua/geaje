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
    public class venueController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: venue
        public ActionResult Index()
        {
            var venues = db.venues.Include(v => v.desaModel).Include(v => v.kecModel).Include(v => v.kotaModel);
            return View(venues.ToList());
        }

        // GET: venue/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || db.venues == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var venue = db.venues
                .Include(v => v.desaModel)
                .Include(v => v.kecModel)
                .Include(v => v.kotaModel)
                .FirstOrDefault(m => m.venue_id == id);
            
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // GET: venue/Create
        public ActionResult Create()
        {
            ViewBag.id_desa = new SelectList(db.desas, "desa_id", "desa_name");
            ViewBag.id_kec = new SelectList(db.kecs, "kec_id", "kec_name");
            ViewBag.id_kota = new SelectList(db.kotas, "kota_id", "kota_name");
            return View();
        }

        // POST: venue/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "venue_id,venue_name,id_kota,id_kec,id_desa,alamat,deskripsi,harga")] venueModel venueModel)
        {
            if (ModelState.IsValid)
            {
                db.venues.Add(venueModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_desa = new SelectList(db.desas, "desa_id", "desa_name", venueModel.id_desa);
            ViewBag.id_kec = new SelectList(db.kecs, "kec_id", "kec_name", venueModel.id_kec);
            ViewBag.id_kota = new SelectList(db.kotas, "kota_id", "kota_name", venueModel.id_kota);
            return View(venueModel);
        }

        // GET: venue/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            venueModel venueModel = db.venues.Find(id);
            if (venueModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_desa = new SelectList(db.desas, "desa_id", "desa_name", venueModel.id_desa);
            ViewBag.id_kec = new SelectList(db.kecs, "kec_id", "kec_name", venueModel.id_kec);
            ViewBag.id_kota = new SelectList(db.kotas, "kota_id", "kota_name", venueModel.id_kota);
            return View(venueModel);
        }

        // POST: venue/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "venue_id,venue_name,id_kota,id_kec,id_desa,alamat,deskripsi,harga")] venueModel venueModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venueModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_desa = new SelectList(db.desas, "desa_id", "desa_name", venueModel.id_desa);
            ViewBag.id_kec = new SelectList(db.kecs, "kec_id", "kec_name", venueModel.id_kec);
            ViewBag.id_kota = new SelectList(db.kotas, "kota_id", "kota_name", venueModel.id_kota);
            return View(venueModel);
        }

        // GET: venue/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || db.venues == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var venue = db.venues
                .Include(v => v.desaModel)
                .Include(v => v.kecModel)
                .Include(v => v.kotaModel)
                .FirstOrDefault(m => m.venue_id == id);

            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        
        }

        // POST: venue/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            venueModel venueModel = db.venues.Find(id);
            db.venues.Remove(venueModel);
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
