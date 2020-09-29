using sevbesMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sevbesMVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return View(db.Users.ToList());
            }

        }

        public ActionResult AllRoles()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return View(db.Roles.ToList());
            }

        }

        public ActionResult YourRoles()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return View(db.Roles.ToList());
            }

        }
    }
}