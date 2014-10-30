using Prosjekt1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Prosjekt1.Repositories
{
    public interface BookRepositoryInterface
    {
        Book GetBook(int BookId);
        bool EditBook(Book Book);
        SelectList AuthorList(Book Book);
        SelectList GenreList(Book Book);
    }
}
