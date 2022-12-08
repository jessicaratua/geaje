using geaje.DataContext;
using geaje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace geaje.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(adminModel adminM)
        {
            using (ApplicationDBContext db = new ApplicationDBContext())
            {
                var admin = db.admins.Where(a => a.username.Equals(adminM.username) && a.password.Equals(adminM.password)).FirstOrDefault();
                if (admin != null)
                {
                    Session["admin_id"] = admin.admin_id;
                    return RedirectToAction("Index", "adminBook");


                }
                else
                {

                    return View("Index");
                }
                return View();
            }

        }
    }
}