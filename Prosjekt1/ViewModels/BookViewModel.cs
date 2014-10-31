using Prosjekt1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prosjekt1.ViewModels
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BookImageURL { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public List<SelectListItem> AuthorList { get; set; }
        public int GenreId { get; set; }
        public List<SelectListItem> GenreList { get; set; }
    }
}