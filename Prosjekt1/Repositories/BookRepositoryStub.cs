﻿using Prosjekt1.Models;
using Prosjekt1.ViewModels;
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

        public bool EditBook(BookViewModel Book)
        {
            if (Book.BookId == 0)
            {
                return false;
            }

            return true;
        }

        public List<SelectListItem> AuthorList(Book Book)
        {
            return null;
        }

        public List<SelectListItem> GenreList(Book Book)
        {
            return null;
        }

        public bool DeleteBook(int BookId)
        {
            return BookId == 1;
        }
    }
}