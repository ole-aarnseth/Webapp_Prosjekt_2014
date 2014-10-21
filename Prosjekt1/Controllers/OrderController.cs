/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Kontroller for alle bestillinger (Order-objekter), den lager alle bestillingene og viser dem gjennom views
 * i forskjellige kontekster.
 * 
 * 
*/

using Prosjekt1.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prosjekt1.Models;
using System.Data.Entity;

namespace Prosjekt1.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult ReviewOrder()
        {
            HttpContextBase Context = this.HttpContext;

            if (Context.Session[SessionKeys.SignedInSessionKey] == null)
            {
                Context.Session[SessionKeys.ReDirectToOrderReviewAfterSignInKey] = "true";
                return RedirectToAction("SignIn", "Customer");
            }

            var order = Order.GetOrder(Context);

            return View(order);
        }

        public ActionResult PlaceOrder()
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                var order = Order.GetOrder(this.HttpContext);

                var shoppingCart = ShoppingCart.GetCart(this.HttpContext);
                shoppingCart.EmptyShoppingCart();

                bookDB.Orders.Add(order);

                // Setting state to Unchanged on customer and books so the entries aren't added a second time by Entity Framework
                bookDB.Entry(order.Customer).State = EntityState.Unchanged;

                foreach (var item in order.OrderItems)
                {
                    bookDB.Entry(item.Book).State = EntityState.Unchanged;
                }

                bookDB.SaveChanges();
                
                return View(order);
            }
        }

        public ActionResult ListOrders()
        {
            HttpContextBase Context = this.HttpContext;

            if (Context.Session[SessionKeys.SignedInSessionKey] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            int customerid = Convert.ToInt32(Context.Session[SessionKeys.SignedInSessionKey]);

            using (BookStoreDB bookDB = new BookStoreDB())
            {
                var orders = bookDB.Orders.Where(o => o.DBCustomerId == customerid).ToList();

                return View(orders);
            }
        }

        public ActionResult OrderDetails(int OrderId)
        {
            HttpContextBase Context = this.HttpContext;

            if (Context.Session[SessionKeys.SignedInSessionKey] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            using (BookStoreDB bookDB = new BookStoreDB())
            {
                var order = bookDB.Orders.Include(o => o.Customer).Include(o => o.OrderItems.Select(b => b.Book)).Where(o => o.OrderId == OrderId).Single();

                return View(order);
            }
        }
    }
}