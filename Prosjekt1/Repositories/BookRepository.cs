using BLL;
using Prosjekt1.Models;
using Prosjekt1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prosjekt1.Repositories
{
    public class BookRepository : BookRepositoryInterface
    {
        public Book GetBook(int BookId)
        {
            BookStoreDB bookDB = new BookStoreDB();
            return bookDB.Books.Where(b => b.BookId == BookId).SingleOrDefault();
        }

        public bool EditBook(BookViewModel Book)
        {
            BookStoreDB bookDB = new BookStoreDB();

            try
            {
                var BookEdit = bookDB.Books.Where(b => b.BookId == Book.BookId).SingleOrDefault();

                BookEdit.Title = Book.Title;
                BookEdit.Description = Book.Description;
                BookEdit.Price = Book.Price;
                BookEdit.AuthorId = Book.AuthorId;
                BookEdit.GenreId = Book.GenreId;

                bookDB.SaveChanges();
            }

            catch (Exception exc)
            {
                ErrorLogBLL.WriteToErrorLogFile(exc.ToString());
                return false;
            }

            return true;
        }

        public List<SelectListItem> AuthorList(Book Book)
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                List<Author> DBAuthors = bookDB.Authors.ToList();
                List<SelectListItem> AuthorList = new List<SelectListItem>();

                foreach (var Author in DBAuthors)
                {
                    AuthorList.Add(new SelectListItem()
                    {
                        Text = Author.FirstName + " " + Author.LastName,
                        Value = Author.AuthorId.ToString()
                    });
                }

                return AuthorList;
            }
        }

        public List<SelectListItem> GenreList(Book Book)
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                List<Genre> DBGenres = bookDB.Genres.ToList();
                List<SelectListItem> GenreList = new List<SelectListItem>();

                foreach (var Genre in DBGenres)
                {
                    GenreList.Add(new SelectListItem()
                    {
                        Text = Genre.Name,
                        Value = Genre.GenreId.ToString()
                    });
                }

                return GenreList;
            }
        }
    }
}