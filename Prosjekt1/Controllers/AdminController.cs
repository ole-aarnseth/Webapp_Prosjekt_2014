using BLL;
using Prosjekt1.Models;
using Prosjekt1.Repositories;
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
        private BookRepositoryInterface BookRepo;

        public AdminController()
        {
            BLL = new AdminBLL();
            BookRepo = new BookRepository();
        }

        public AdminController(AdminBLL TestBLL, BookRepositoryInterface BookRepoStub)
        {
            BLL = TestBLL;
            BookRepo = BookRepoStub;
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

        public ActionResult SignOut()
        {
            string Email = BLL.SignOut(this.HttpContext);
            ViewBag.SignedOutEmail = Email;

            return View();
        }

        public ActionResult AdminDetails()
        {
            var SignedInAdmin = BLL.GetSignedInAdmin(this.HttpContext);

            return View(SignedInAdmin);
        }

        public ActionResult EditBook(int BookId)
        {
            var Book = BookRepo.GetBook(BookId);
            ViewBag.AuthorId = BookRepo.AuthorList(Book);

            return View(Book);
        }
    }
}