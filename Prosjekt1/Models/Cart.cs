/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Modellobjekt for em bok i handlevognen.
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prosjekt1.Models
{
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }

        public string CartId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateOrder { get; set;}
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}