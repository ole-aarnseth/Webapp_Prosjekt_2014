using BLL;
using Prosjekt1.Models;
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
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                return bookDB.Books.Include("Author").Include("Genre").Where(b => b.BookId == BookId).SingleOrDefault();
            }
        }

        public bool EditBook(Book Book)
        {
            BookStoreDB bookDB = new BookStoreDB();

            try
            {
                var BookEdit = GetBook(Book.BookId);

                BookEdit = new Book()
                {
                    BookId = Book.BookId,
                    Title = Book.Title,
                    Description = Book.Description,
                    BookImageURL = Book.BookImageURL,
                    Price = Book.Price,
                    AuthorId = Book.AuthorId,
                    GenreId = Book.GenreId
                };

                bookDB.SaveChanges();
            }

            catch (Exception exc)
            {
                ErrorLogBLL.WriteToErrorLogFile(exc.ToString());
                return false;
            }

            return true;
        }

        public SelectList AuthorList(Book Book)
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                return new SelectList(bookDB.Authors, "AuthorId", "Name", Book.AuthorId);
            }
        }

        public SelectList GenreList(Book Book)
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                return new SelectList(bookDB.Genres, "GenreId", "Name", Book.GenreId);
            }
        }
    }
}