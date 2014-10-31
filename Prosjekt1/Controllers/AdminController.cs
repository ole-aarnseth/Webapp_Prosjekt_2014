using BLL;
using Prosjekt1.Models;
using Prosjekt1.Repositories;
using Prosjekt1.ViewModels;
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

            var BookView = new BookViewModel()
            {
                BookId = Book.BookId,
                Title = Book.Title,
                Description = Book.Description,
                BookImageURL = Book.BookImageURL,
                Price = Book.Price,
                AuthorId = Book.AuthorId,
                AuthorList = BookRepo.AuthorList(Book),
                GenreId = Book.GenreId,
                GenreList = BookRepo.GenreList(Book)
            };

            return View(BookView);
        }

        [HttpPost]
        public ActionResult EditBook(BookViewModel BookModel)
        {
            if (ModelState.IsValid)
            {
                bool EditOK = BookRepo.EditBook(BookModel);

                if (EditOK)
                {
                    return RedirectToAction("Index", "Store");
                }

                else
                {
                    ViewBag.DBError = "Something went wrong when editing database.";
                }
            }

            return View();
        }
    }
}