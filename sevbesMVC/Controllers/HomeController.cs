using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sevbesMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "google")]
        public ActionResult Google()
        {
            return View();
        }
        [Authorize(Roles = "yandex")]
        public ActionResult Yandex()
        {
            return View();
        }
        [Authorize(Roles ="gmail")]
        public ActionResult Gmail()
        {
            return View();
        }

        public ActionResult ErrorAllow()
        {
            ViewBag.Message = "Your aren't have allow to this page";

            return View();
        }
    }
}