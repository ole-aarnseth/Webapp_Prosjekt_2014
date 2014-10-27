/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Kontroller for startsiden til nettbutikken, returnerer en index-View for startsiden.
 * 
 * 
*/

using BLL;
using Prosjekt1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prosjekt1.Controllers
{
    public class HomeController : Controller
    {
        private AdminBLL BLL;

        public HomeController()
        {
            BLL = new AdminBLL();
        }

        public HomeController(AdminBLL ABLL)
        {
            BLL = ABLL;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var admin = BLL.GetSignedInAdmin(this.HttpContext);

            if (admin != null)
            {
                ViewData["AdminIsSignedIn"] = true;
                ViewData["AdminEmail"] = admin.Email;
            }

            else
            {
                ViewData["AdminIsSignedIn"] = false;
            }

            return PartialView("MainMenu");
        }
    }
}