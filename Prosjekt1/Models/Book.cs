/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Modellobjekt for bøker i databasen.
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
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BookImageURL { get; set; }
        public decimal Price { get; set; }

        // Table connection to Author with foreign key
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        // Table connection to Genre with foreign key
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}