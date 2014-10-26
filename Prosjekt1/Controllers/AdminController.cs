using BLL;
using Prosjekt1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prosjekt1.Controllers
{
    public class AdminController : Controller
    {
        private AdminBLL BLL;

        public AdminController()
        {
            BLL = new AdminBLL();
        }

        public AdminController(AdminBLL TestBLL)
        {
            BLL = TestBLL;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInCredentials creds)
        {
            if (ModelState.IsValid)
            {
                if (BLL.SignIn(this.HttpContext, creds.Email, creds.LoginPassword))
                {
                    return RedirectToAction("Index", "Store");
                }

                else
                {
                    ViewBag.SignInFailed = "Invalid email or password";
                }
            }

            return View();
        }
    }
}