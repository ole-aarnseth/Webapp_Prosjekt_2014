/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * ViewModel som overfører data tilbake til ajax-skriptet i Cart/Index etter at et item er blitt fjernet fra
 * handlevogna.
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prosjekt1.ViewModels
{
    public class ShoppingCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }
}