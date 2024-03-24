using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //only register user access this --------------------------------------
        [Authorize (Roles ="User")]
        public ActionResult UserArea()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //only Admin Access only ---------------------------------------------
        //this will redireact the user to login page if it is not Authorize
        [Authorize(Roles = "Admin")]
        public ActionResult AdminArea()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}