/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Modellobjekt for en item i en bestilling, tilsvarer et Cart-objekt i ShoppingCart.
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prosjekt1.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ItemQuantity { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}