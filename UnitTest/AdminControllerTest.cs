using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using Prosjekt1.Controllers;
using DAL;
using Prosjekt1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Prosjekt1.Repositories;
using Prosjekt1.ViewModels;

namespace UnitTest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void SignIn()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());

            // Act
            var Result = (ViewResult) Controller.SignIn();

            // Assert
            Assert.AreEqual(Result.ViewName, "");
        }

        [TestMethod]
        public void SignInPostSuccessfulSignIn()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());

            // These are the credentials for the defaultadmin in Stub
            SignInCredentials creds = new SignInCredentials()
            {
                Email = "admin@admin.com",
                LoginPassword = "admin1234"
            };

            // Act
            var Result = (RedirectToRouteResult) Controller.SignIn(creds);

            // Assert
            Assert.AreEqual(Result.RouteName, "");
            Assert.IsTrue(Result.RouteValues.Count == 2);
            Assert.AreEqual(Result.RouteValues.Values.First(), "Index");
            Assert.AreEqual(Result.RouteValues.Values.Last(), "Store");
        }

        [TestMethod]
        public void SignInPostModelStateNotValid()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());
            Controller.ViewData.ModelState.AddModelError("Email", "Email is required");

            SignInCredentials creds = new SignInCredentials()
            {
                Email = "",
                LoginPassword = "admin1234"
            };

            // Act
            var Result = (ViewResult) Controller.SignIn(creds);

            // Assert
            Assert.IsTrue(Result.ViewData.ModelState.Count == 1);
            Assert.AreEqual(Result.ViewName, "");
        }

        [TestMethod]
        public void SignInPostBadCredentials()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());

            // AdminDALStub will only accept defaultadmin "admin@admin.com" with password "admin1234"
            SignInCredentials creds = new SignInCredentials()
            {
                Email = "wrongadmin@admin.com",
                LoginPassword = "thisisnottherightpassword"
            };

            // Act
            var Result = (ViewResult) Controller.SignIn(creds);

            // Assert
            Assert.AreEqual(Result.ViewName, "");
            Assert.AreEqual(Result.ViewBag.SignInFailed, "Invalid email or password");
        }

        [TestMethod]
        public void SignOut()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());

            // Act
            var Result = (ViewResult) Controller.SignOut();

            // Assert
            Assert.AreEqual(Result.ViewName, "");
            Assert.AreEqual(Result.ViewBag.SignedOutEmail, "admin@admin.com");
        }

        [TestMethod]
        public void AdminDetails()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());

            // Act
            var Result = (ViewResult) Controller.AdminDetails();

            // Assert
            Assert.AreEqual(Result.ViewName, "");
        }

        [TestMethod]
        public void EditBook()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());

            // Act
            var Result = (ViewResult) Controller.EditBook(1);

            // Assert
            Assert.AreEqual(Result.ViewName, "");
        }

        [TestMethod]
        public void EditBookPostSuccessful()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());
            var BookModel = new BookViewModel()
            {
                BookId = 1
            };

            // Act
            var Result = (RedirectToRouteResult) Controller.EditBook(BookModel);

            // Assert
            Assert.AreEqual(Result.RouteName, "");
            Assert.IsTrue(Result.RouteValues.Count == 2);
            Assert.AreEqual(Result.RouteValues.Values.First(), "Index");
            Assert.AreEqual(Result.RouteValues.Values.Last(), "Store");
        }

        [TestMethod]
        public void EditBookPostModelStateNotValid()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());
            Controller.ViewData.ModelState.AddModelError("Email", "Email is required");
            var BookModel = new BookViewModel()
            {
                BookId = 1
            };

            // Act
            var Result = (ViewResult) Controller.EditBook(BookModel);

            // Assert
            Assert.AreEqual(Result.ViewName, "");
            Assert.IsTrue(Result.ViewData.ModelState.Count == 1);
        }

        [TestMethod]
        public void EditBookPostDBError()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());
            var BookModel = new BookViewModel()
            {
                BookId = 0
            };

            // Act
            var Result = (ViewResult) Controller.EditBook(BookModel);

            // Assert
            Assert.AreEqual(Result.ViewName, "");
            Assert.AreEqual(Result.ViewBag.DBError, "Something went wrong when editing database.");
        }

        [TestMethod]
        public void DeleteBookSuccessful()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());

            // Act
            var Result = (RedirectToRouteResult) Controller.DeleteBook(1);

            // Assert
            Assert.AreEqual(Result.RouteName, "");
            Assert.IsTrue(Result.RouteValues.Count == 2);
            Assert.AreEqual(Result.RouteValues.Values.First(), "Index");
            Assert.AreEqual(Result.RouteValues.Values.Last(), "Store");
        }

        [TestMethod]
        public void DeleteBookDBError()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()), new BookRepositoryStub());

            // Act
            var Result = (ViewResult) Controller.DeleteBook(0);

            // Assert
            Assert.AreEqual(Result.ViewName, "");
        }
    }
}
