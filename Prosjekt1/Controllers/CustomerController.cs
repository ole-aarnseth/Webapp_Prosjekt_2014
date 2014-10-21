/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Dette er kontrolleren til all kundeinfo, innlogging og utlogging kan kun skje gjennom denne, i tillegg til kunderegistrering.
 * For å logge inn en kunde vil en session-variabel bli tilengnet kundeid-en fra databasen. Hvis denne variabelen er satt, er kunden
 * innlogget, hvis den er null er han ikke innlogget.
 * 
 * 
*/

using Prosjekt1.Models;
using Prosjekt1.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prosjekt1.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(SignInCredentials SignInCreds)
        {
            if (ModelState.IsValid)
            {
                using (BookStoreDB bookDB = new BookStoreDB())
                {
                    byte[] password = DBCustomer.GeneratePasswordHash(SignInCreds.LoginPassword);
                    DBCustomer check = bookDB.Customers.Where(c => c.Email == SignInCreds.Email && c.LoginPassword == password).SingleOrDefault();

                    if (check != null)
                    {
                        HttpContextBase Context = this.HttpContext;
                        Context.Session[SessionKeys.SignedInSessionKey] = check.DBCustomerId.ToString();

                        if (Context.Session[SessionKeys.ReDirectToOrderReviewAfterSignInKey] != null)
                        {
                            Context.Session[SessionKeys.ReDirectToOrderReviewAfterSignInKey] = null;
                            return RedirectToAction("ReviewOrder", "Order");
                        }

                        else
                        {
                            return RedirectToAction("CustomerDetails", "Customer");
                        }
                    }

                    else
                    {
                        ViewBag.SignInFailed = "Invalid email or password";
                    }

                }
            }

            return View();
        }

        public ActionResult SignOut()
        {
            HttpContextBase Context = this.HttpContext;

            if (Context.Session[SessionKeys.SignedInSessionKey] != null)
            {
                int CustomerId = Convert.ToInt32(Context.Session[SessionKeys.SignedInSessionKey]);
                Context.Session[SessionKeys.SignedInSessionKey] = null;
                
                using (BookStoreDB bookDB = new BookStoreDB())
                {
                    DBCustomer customer = bookDB.Customers.Where(c => c.DBCustomerId == CustomerId).Single();
                    ViewBag.Email = customer.Email;
                }
            }

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer Customer)
        {
            if (ModelState.IsValid)
            {
                if (!DBCustomer.CheckDuplicateEmail(Customer.Email))
                {
                    ViewBag.DuplicateEmail = "Another customer with the same email was found.";
                    return View();
                }

                using (BookStoreDB bookDB = new BookStoreDB())
                {
                    DBCustomer dbCustomer = new DBCustomer
                    {
                        Email = Customer.Email,
                        LoginPassword = DBCustomer.GeneratePasswordHash(Customer.LoginPassword),
                        FirstName = Customer.FirstName,
                        LastName = Customer.LastName,
                        Phone = Customer.Phone,
                        Address = Customer.Address,
                        PostalCode = Customer.PostalCode,
                        City = Customer.City
                    };

                    bookDB.Customers.Add(dbCustomer);
                    bookDB.SaveChanges();

                    dbCustomer = bookDB.Customers.Where(c => c.Email == Customer.Email).Single();

                    HttpContextBase Context = this.HttpContext;
                    Context.Session[SessionKeys.SignedInSessionKey] = dbCustomer.DBCustomerId.ToString();

                    if (Context.Session[SessionKeys.ReDirectToOrderReviewAfterSignInKey] != null)
                    {
                        Context.Session[SessionKeys.ReDirectToOrderReviewAfterSignInKey] = null;
                        return RedirectToAction("ReviewOrder", "Order");
                    }

                    else
                    {
                        return RedirectToAction("CustomerDetails", "Customer");
                    }
                }
            }

            return View();
        }

        [ChildActionOnly]
        public ActionResult CustomerMenu()
        {
            HttpContextBase Context = this.HttpContext;

            if (Context.Session[SessionKeys.SignedInSessionKey] != null)
            {
                ViewData["IsSignedIn"] = true;

                using (BookStoreDB bookDB = new BookStoreDB())
                {
                    int CustomerId = Convert.ToInt32(Context.Session[SessionKeys.SignedInSessionKey]);
                    var Customer = bookDB.Customers.Where(c => c.DBCustomerId == CustomerId).Single();

                    ViewData["Email"] = Customer.Email;
                }
            }

            else
            {
                ViewData["IsSignedIn"] = false;
            }

            return PartialView("CustomerMenu");
        }

        public ActionResult CustomerDetails()
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                HttpContextBase Context = this.HttpContext;
                int customerid = Convert.ToInt32(Context.Session[SessionKeys.SignedInSessionKey]);
                DBCustomer Customer = bookDB.Customers.Where(c => c.DBCustomerId == customerid).Single();

                return View(Customer);
            }
        }

        public ActionResult EditCustomer()
        {
            HttpContextBase Context = this.HttpContext;

            if (Context.Session[SessionKeys.SignedInSessionKey] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            using (BookStoreDB bookDB = new BookStoreDB())
            {
                int customerid = Convert.ToInt32(Context.Session[SessionKeys.SignedInSessionKey]);
                DBCustomer Customer = bookDB.Customers.Where(c => c.DBCustomerId == customerid).Single();

                Customer myCustomer = new Customer
                {
                    Email = Customer.Email,
                    FirstName = Customer.FirstName,
                    LastName = Customer.LastName,
                    Phone = Customer.Phone,
                    Address = Customer.Address,
                    PostalCode = Customer.PostalCode,
                    City = Customer.City
                };

                return View(myCustomer);
            }
        }

        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid || customer.LoginPassword == null)
            {
                HttpContextBase Context = this.HttpContext;
                int customerid = Convert.ToInt32(Context.Session[SessionKeys.SignedInSessionKey]);

                if (!DBCustomer.CheckDuplicateEmailIgnoreCustomer(customer.Email, customerid))
                {
                    ViewBag.DuplicateEmail = "Another customer with the same email was found.";
                    return View();
                }

                using (BookStoreDB bookDB = new BookStoreDB())
                {
                    DBCustomer original = bookDB.Customers.Find(customerid);

                    if (customer.Email != null && customer.Email != original.Email)
                    {
                        original.Email = customer.Email;
                    }

                    if (customer.LoginPassword != null)
                    {
                        byte[] password = DBCustomer.GeneratePasswordHash(customer.LoginPassword);

                        if (password != original.LoginPassword)
                        {
                            original.LoginPassword = DBCustomer.GeneratePasswordHash(customer.LoginPassword);
                        }
                    }

                    if (customer.FirstName != null && customer.FirstName != original.FirstName)
                    {
                        original.FirstName = customer.FirstName;
                    }

                    if (customer.LastName != null && customer.LastName != original.LastName)
                    {
                        original.LastName = customer.LastName;
                    }

                    if (customer.Phone != null && customer.Phone != original.Phone)
                    {
                        original.Phone = customer.Phone;
                    }

                    if (customer.Address != null && customer.Address != original.Address)
                    {
                        original.Address = customer.Address;
                    }

                    if (customer.PostalCode != null && customer.PostalCode != original.PostalCode)
                    {
                        original.PostalCode = customer.PostalCode;
                    }

                    if (customer.City != null && customer.City != original.City)
                    {
                        original.City = customer.City;
                    }

                    bookDB.SaveChanges();
                }

                return RedirectToAction("CustomerDetails");
            }

            ViewBag.DuplicateEmail = "Another customer ";
            return View();
        }
    }
}