/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * ViewModel som overfører handlevongsdataene til Cartcontroller sin Index-View.
 * 
 * 
*/

using Prosjekt1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prosjekt1.ViewModels
{
    public class ShoppingCartViewModel
    {
        public decimal CartTotal { get; set; }
        public List<Cart> CartItems { get; set;}
    }
}