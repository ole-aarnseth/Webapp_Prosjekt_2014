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

namespace UnitTest
{
    [TestClass]
    public class AdminControllerTest
    {
        [TestMethod]
        public void SignIn()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()));

            // Act
            var Result = (ViewResult) Controller.SignIn();

            // Assert
            Assert.AreEqual(Result.ViewName, "");
        }

        [TestMethod]
        public void SignInPostSuccessfulSignIn()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()));

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
            Assert.AreEqual(Result.RouteValues.Count, 2);
            Assert.AreEqual(Result.RouteValues.Values.First(), "Index");
            Assert.AreEqual(Result.RouteValues.Values.Last(), "Store");
        }

        [TestMethod]
        public void SignInPostModelStateNotValid()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()));
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
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()));

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
    }
}
