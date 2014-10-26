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
    /*
     * About AssertFailedException:
     * If an Assert fails, the AssertFailException is caught in the following catch-statement, which passes
     * the Exception details to TestLogWriter, and then throws the exception so Visual Studio will see it.
     */

    [TestClass]
    public class AdminControllerTest
    {
        private TestLogWriter LogWriter;

        public AdminControllerTest()
        {
            LogWriter = new TestLogWriter();
        }

        [TestMethod]
        public void SignIn()
        {
            // Arrange
            var Controller = new AdminController(new AdminBLL(new AdminDALStub()));

            // Act
            var Result = (ViewResult) Controller.SignIn();

            // Assert
            try
            {
                Assert.AreEqual(Result.ViewName, "");
            }

            catch (AssertFailedException Exception)
            {
                LogWriter.WriteToLogFile(Exception.ToString());
                throw Exception;
            }
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
            try
            {
                Assert.AreEqual(Result.RouteName, "");
                Assert.IsTrue(Result.RouteValues.Count == 2);
                Assert.AreEqual(Result.RouteValues.Values.First(), "Index");
                Assert.AreEqual(Result.RouteValues.Values.Last(), "Store");
            }

            catch (AssertFailedException Exception)
            {
                LogWriter.WriteToLogFile(Exception.ToString());
                throw Exception;
            }
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
            try
            {
                Assert.IsTrue(Result.ViewData.ModelState.Count == 1);
                Assert.AreEqual(Result.ViewName, "");
            }

            catch (AssertFailedException Exception)
            {
                LogWriter.WriteToLogFile(Exception.ToString());
                throw Exception;
            }
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
            try
            {
                Assert.AreEqual(Result.ViewName, "");
                Assert.AreEqual(Result.ViewBag.SignInFailed, "Invalid email or password");
            }

            catch (AssertFailedException Exception)
            {
                LogWriter.WriteToLogFile(Exception.ToString());
                throw Exception;
            }
        }
    }
}
