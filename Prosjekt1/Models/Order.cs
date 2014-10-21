/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Modellobjekt for en bestilling i databasen.
 * 
 * 
*/

using Prosjekt1.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prosjekt1.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public int DBCustomerId { get; set; }
        public DBCustomer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public static Order GetOrder(HttpContextBase Context)
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                var shoppingCart = ShoppingCart.GetCart(Context);
                int CustomerId = Convert.ToInt32(Context.Session[SessionKeys.SignedInSessionKey]);
                var customer = bookDB.Customers.Where(c => c.DBCustomerId == CustomerId).Single();
                var orderitems = new List<OrderItem>();
                var cartItems = shoppingCart.GetItems();

                foreach (var item in cartItems)
                {
                    var orderitem = new OrderItem
                    {
                        ItemQuantity = item.Count,
                        Book = item.Book
                    };

                    orderitems.Add(orderitem);
                }

                var order = new Order
                {
                    OrderDate = System.DateTime.Now,
                    OrderTotal = shoppingCart.GetTotal(),
                    Customer = customer,
                    OrderItems = orderitems
                };

                return order;
            }
        }
    }
}