/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Dette er kontrollobjektet for handlevognen vår, den legger til bøker og fjerner via kall til "ShoppingCart"-modellen,
 * i tilegg til en PartialView på navbaren som gir en oppsummering av handlevognens innhold.
 * 
 *    
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prosjekt1.Models;
using System.Web.Mvc;
using Prosjekt1.ViewModels;

namespace Prosjekt1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var shoppingCart = ShoppingCart.GetCart(this.HttpContext);

            var ViewModel = new ShoppingCartViewModel
            {
                CartTotal = shoppingCart.GetTotal(),
                CartItems = shoppingCart.GetItems()
            };

            return View(ViewModel);
        }

        public ActionResult AddToCart(int bookId)
        {
            var shoppingCart = ShoppingCart.GetCart(this.HttpContext);
            shoppingCart.AddItem(bookId);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveItemFromCart(int recordId)
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                Cart cart = bookDB.Carts.Include("Book").Where(c => c.RecordId == recordId).Single();
                string bookTitle = cart.Book.Title;

                var shoppingCart = ShoppingCart.GetCart(this.HttpContext);
                int itemCount = shoppingCart.RemoveItem(recordId);

                var postResults = new ShoppingCartRemoveViewModel
                {
                    Message = "1x " + Server.HtmlEncode(bookTitle) + " was removed from shopping cart.",
                    CartTotal = shoppingCart.GetTotal(),
                    CartCount = shoppingCart.GetCount(),
                    ItemCount = itemCount,
                    DeleteId = recordId
                };

                return Json(postResults);
            }
        }

        [ChildActionOnly]
        public ActionResult CartNavSummary()
        {
            var shoppingCart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["ItemCount"] = shoppingCart.GetCount();

            return PartialView("CartNavSummary");
        }
    }
}