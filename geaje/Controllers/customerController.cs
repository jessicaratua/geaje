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
    public class customerController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: customer
        public ActionResult Index()
        {
            var venues = db.venues.Include(v => v.desaModel).Include(v => v.kecModel).Include(v => v.kotaModel);
            return View(venues.ToList());
        }

        // GET: customer/Details/5
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

    }
}
