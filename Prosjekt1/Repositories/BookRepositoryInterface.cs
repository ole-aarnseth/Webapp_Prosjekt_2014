using Prosjekt1.Models;
using Prosjekt1.ViewModels;
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
        bool EditBook(BookViewModel Book);
        List<SelectListItem> AuthorList(Book Book);
        List<SelectListItem> GenreList(Book Book);
    }
}
