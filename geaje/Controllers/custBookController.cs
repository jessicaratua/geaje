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
    public class custBookController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        

        // GET: custBook/Details/5
       
        

        // GET: custBook/Create
        public ActionResult Create()
        {
            ViewBag.id_venue = new SelectList(db.venues, "venue_id", "venue_name");
            return View();
        }

        // POST: custBook/Create
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
                return RedirectToAction("Index","customer");
            }

            ViewBag.id_venue = new SelectList(db.venues, "venue_id", "venue_name", bookModel.id_venue);
            return View(bookModel);
        }

        // GET: custBook/Edit/5
        
    }
}
