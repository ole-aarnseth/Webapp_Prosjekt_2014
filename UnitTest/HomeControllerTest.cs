using BLL;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prosjekt1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace UnitTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var Controller = new HomeController(new AdminBLL(new AdminDALStub()));

            // Act
            var Result = (ViewResult) Controller.Index();

            // Assert
            Assert.AreEqual(Result.ViewName, "");
        }
    }
}
