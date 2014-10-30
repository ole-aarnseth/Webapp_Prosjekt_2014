using Prosjekt1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prosjekt1.Repositories
{
    public class BookRepositoryStub : BookRepositoryInterface
    {
        public Book GetBook(int BookId)
        {
            return new Book()
            {
                BookId = 1,
                Title = "TestBook",
                Description = "Testbook is the magnum opus of our test author.",
                BookImageURL = "URLURLURL",
                Price = 400.00M,
                AuthorId = 1,
                GenreId = 1
            };
        }

        public bool EditBook(Book Book)
        {
            if (Book.BookId == 0)
            {
                return false;
            }

            return true;
        }

        public SelectList AuthorList(Book Book)
        {
            return null;
        }

        public SelectList GenreList(Book Book)
        {
            return null;
        }
    }
}