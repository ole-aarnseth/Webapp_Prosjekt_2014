/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Modellobjekt for sjanger i databasen.
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Prosjekt1.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}