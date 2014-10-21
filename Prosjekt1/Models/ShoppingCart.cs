/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Modellobjekt for handlevognen til nettbutikken. Den bruker EF-databasen og identifiseres for hver session gjennom en GUID i en Session-varibel.
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Prosjekt1.Constants;

namespace Prosjekt1.Models
{
    public partial class ShoppingCart
    {
        BookStoreDB bookDB = new BookStoreDB();

        string ShoppingCartId { get; set; }

        public static ShoppingCart GetCart(HttpContextBase Context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(Context);
            return cart;
        }

        public string GetCartId(HttpContextBase Context)
        {
            if (Context.Session[SessionKeys.CartSessionKey] == null)
            {
                Context.Session[SessionKeys.CartSessionKey] = Guid.NewGuid().ToString();
            }

            return Context.Session[SessionKeys.CartSessionKey].ToString();
        }

        public void AddItem(int bookId)
        {
            var cartItem = bookDB.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.BookId == bookId);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateOrder = DateTime.Now,
                    BookId = bookId
                };

                bookDB.Carts.Add(cartItem);
            }

            else
            {
                cartItem.Count++;
            }

            bookDB.SaveChanges();
        }

        public int RemoveItem(int id)
        {
            var item = bookDB.Carts.Single(c => c.CartId == ShoppingCartId
                                               && c.RecordId == id);

            if (item != null)
            {
                if (item.Count == 1)
                {
                    bookDB.Carts.Remove(item);
                    bookDB.SaveChanges();
                    return 0;
                }

                else
                {
                    item.Count--;
                }
            }

            bookDB.SaveChanges();
            return item.Count;
        }

        public decimal GetTotal()
        {
            decimal? sum = (from items in bookDB.Carts
                            where items.CartId == ShoppingCartId
                            select (int?)items.Count * items.Book.Price).Sum();

            decimal total = sum ?? decimal.Zero;
            return total;
        }

        public int GetCount()
        {
            int? count = (from items in bookDB.Carts
                          where items.CartId == ShoppingCartId
                          select (int?)items.Count).Sum();

            return count ?? 0;
        }

        public List<Cart> GetItems()
        {
            var items = bookDB.Carts.Include("Book").Where(c => c.CartId == ShoppingCartId).ToList();
            return items;
        }

        public void EmptyShoppingCart()
        {
            var items = bookDB.Carts.Where(c => c.CartId == ShoppingCartId).ToList();

            foreach (var item in items)
            {
                bookDB.Carts.Remove(item);
            }

            bookDB.SaveChanges();
        }
    }
}