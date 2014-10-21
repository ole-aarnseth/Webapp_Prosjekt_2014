/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Butikk-kontrolleren har som hovedoppgave å vise fram alle Book-objekter som nettbutikken tilbyr.
 * Bøker kan sorteres etter sjanger eller forfatter.
 * 
 * 
*/

using Prosjekt1.Models;
using Prosjekt1.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Prosjekt1.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            using (var bookDB = new BookStoreDB())
            {
                var books = bookDB.Books.Include(b => b.Author).ToList();
                return View(books);
            }
        }

        public ActionResult BookDetails(int bookId, int fromContext)
        {
            using (var bookDB = new BookStoreDB())
            {
                ViewBag.FromContext = fromContext;

                if (fromContext == DetailsFromContext.FromBrowseAuthor)
                {
                    var author = (from b in bookDB.Books
                                  join a in bookDB.Authors
                                  on b.AuthorId equals a.AuthorId
                                  where b.BookId == bookId
                                  select new
                                  {
                                      FirstName = a.FirstName,
                                      LastName = a.LastName
                                  }).Single();

                    ViewBag.FirstName = author.FirstName;
                    ViewBag.LastName = author.LastName;
                }

                else if (fromContext == DetailsFromContext.FromBrowseGenre)
                {
                    var genre = (from b in bookDB.Books
                                 join g in bookDB.Genres
                                 on b.GenreId equals g.GenreId
                                 where b.BookId == bookId
                                 select new
                                 {
                                     Name = g.Name
                                 }).Single();

                    ViewBag.GenreName = genre.Name;
                }

                var book = bookDB.Books.Find(bookId);
                return View(book);
            }
        }

        [ChildActionOnly]
        public ActionResult AuthorMenu()
        {
            using (var bookDB = new BookStoreDB())
            {
                var authors = bookDB.Authors.ToList();
                return PartialView(authors);
            }
        }

        public ActionResult BrowseAuthor(string fname, string lname)
        {
            using (var bookDB = new BookStoreDB())
            {
                var authorBooks = bookDB.Authors.Include("Books").Single(a => a.FirstName == fname && a.LastName == lname);
                return View(authorBooks);
            }
        }

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            using (var bookDB = new BookStoreDB())
            {
                var genres = bookDB.Genres.ToList();
                return PartialView(genres);
            }
        }

        public ActionResult BrowseGenre(string name)
        {
            using (var bookDB = new BookStoreDB())
            {
                var genreBooks = bookDB.Genres.Include(g => g.Books.Select(b => b.Author)).Single(g => g.Name == name);
                return View(genreBooks);
            }
        }
    }
}