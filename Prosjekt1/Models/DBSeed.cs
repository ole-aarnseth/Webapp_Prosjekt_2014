/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Dette er "seeder"-klassen til databasen vår, den seeder databasen med "dummy"-data så nettbutikken kan testes med bøker i databasen.
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Prosjekt1.Models
{
    public class DBSeed : DropCreateDatabaseIfModelChanges<BookStoreDB>
    {
        protected override void Seed(BookStoreDB context)
        {
            var genres = new List<Genre>
            {
                new Genre { Name = "Educational"},
                new Genre { Name = "Cookbooks"},
                new Genre { Name = "Humour"},
                new Genre { Name = "Classics"},
                new Genre { Name = "Philosophy"}
            };

            var authors = new List<Author>
            {
                new Author { FirstName = "Adam", LastName = "Freeman"},
                new Author { FirstName = "Gina", LastName = "Homolka"},
                new Author { FirstName = "Maria", LastName = "Semple"},
                new Author { FirstName = "Aldous", LastName = "Huxley"},
                new Author { FirstName = "George", LastName = "Orwell"},
                new Author { FirstName = "Ayn", LastName = "Rand"},
                new Author { FirstName = "Fredrich", LastName = "Nietzsche"},
                new Author { FirstName = "Niccolo", LastName = "Machiavelli"},
                new Author { FirstName = "Fyodor", LastName = "Dostoyevsky"}
            };

            new List<Book>
            {
                new Book { Title = "Pro ASP.NET MVC 5", Genre = genres.Single(g => g.Name == "Educational"),
                    Author = authors.Single(a => a.FirstName == "Adam" && a.LastName == "Freeman"), Price= 550.00M, BookImageURL = ("/Content/Images/Book-icon.png"),
                    Description = "The ASP.NET MVC 5 Framework is the latest evolution of Microsoft’s ASP.NET web platform. It provides a high-productivity programming model that promotes cleaner code architecture, test-driven development, and powerful extensibility, combined with all the benefits of ASP.NET."},
                new Book { Title = "The Skinnytaste Cookbook: Light on Calories, Big on Flavor", Genre = genres.Single(g => g.Name == "Cookbooks"), Author = authors.Single(a => a.FirstName == "Gina" && a.LastName == "Homolka"),
                    Price = 600.00M, BookImageURL = ("/Content/Images/Book-icon.png"),
                    Description = "Get the recipes everyone is talking about in the debut cookbook from the wildly popular blog Skinnytaste."},
                new Book { Title = "Where'd You Go, Bernadette: A Novel", Genre = genres.Single(g => g.Name == "Humour"), Author = authors.Single(a => a.FirstName == "Maria" && a.LastName == "Semple"),
                    Price = 600.00M, BookImageURL = ("/Content/Images/Book-icon.png"),
                    Description = "Bernadette Fox is notorious. To her Microsoft-guru husband, she's a fearlessly opinionated partner; to fellow private-school mothers in Seattle, she's a disgrace; to design mavens, she's a revolutionary architect, and to 15-year-old Bee, she is a best friend and, simply, Mom."},
                new Book { Title = "Brave New World", Genre = genres.Single(g => g.Name == "Classics"), Author = authors.Single(a => a.FirstName == "Aldous" && a.LastName == "Huxley"),
                    Price = 600.00M, BookImageURL = ("/Content/Images/Book-icon.png"),
                    Description = "Aldous Huxley is rightly considered a prophetic genius and one of the most important literary and philosophical voices of the 20th Century, and Brave New World is his masterpiece. This powerful work remains absolutely relevant to this day as both a cautionary dystopian tale in the vein of the George Orwell classic 1984, and as thought-provoking, thoroughly satisfying entertainment."},
                new Book { Title = "Nineteen Eighty-Four", Genre = genres.Single(g => g.Name == "Classics"), Author = authors.Single(a => a.FirstName == "George" && a.LastName == "Orwell"),
                    Price = 600.00M, BookImageURL = ("/Content/Images/Book-icon.png"),
                    Description = "Nineteen Eighty-Four revealed George Orwell as one of the twentieth century’s greatest mythmakers. His harrowing cautionary tale of a man trapped in a political nightmare has with its relevance and power disturbed our complacency decade by decade. In Winston Smith’s desperate struggle to free himself from an all-encompassing, malevolent state, Orwell zeroed in on tendencies apparent in every modern society, and made vivid the universal predicament of the individual."},
                new Book { Title = "Animal Farm", Genre = genres.Single(g => g.Name == "Classics"), Author = authors.Single(a => a.FirstName == "George" && a.LastName == "Orwell"),
                    Price = 600.00M, BookImageURL = ("/Content/Images/Book-icon.png"),
                    Description = "As ferociously fresh as it was more than a half century ago, this remarkable allegory of a downtrodden society of overworked, mistreated animals and their quest to create a paradise of progress, justice, and equality is one of the most scathing satires ever published. As readers witness the rise and bloody fall of the revolutionary animals, they begin to recognize the seeds of totalitarianism in the most idealistic organization—and in the most charismatic leaders, the souls of the cruelest oppressors."},
                new Book { Title = "Atlas Shrugged", Genre = genres.Single(g => g.Name == "Philosophy"), Author = authors.Single(a => a.FirstName == "Ayn" && a.LastName == "Rand"),
                    Price = 500.00M, BookImageURL = ("/Content/Images/Book-icon.png"),
                    Description = "Atlas Shrugged is the astounding story of a man who said that he would stop the motor of the world--and did. Tremendous in scope, breathtaking in its suspense, Atlas Shrugged stretches the boundaries further than any book you have ever read. It is a mystery, not about the murder of a man's body, but about the murder--and rebirth--of man's spirit."},
                new Book { Title = "Beyond Good and Evil", Genre = genres.Single(g => g.Name == "Philosophy"), Author = authors.Single(a => a.FirstName == "Fredrich" && a.LastName == "Nietzsche"),
                    Price = 550.00M, BookImageURL = ("/Content/Images/Book-icon.png"),
                    Description = "In Beyond Good and Evil, Nietzsche accuses past philosophers of lacking critical sense and blindly accepting dogmatic premises in their consideration of morality. Specifically, he accuses them of founding grand metaphysical systems upon the faith that the good man is the opposite of the evil man, rather than just a different expression of the same basic impulses that find more direct expression in the evil man."},
                new Book { Title = "The Prince", Genre = genres.Single(g => g.Name == "Philosophy"), Author = authors.Single(a => a.FirstName == "Niccolo" && a.LastName == "Machiavelli"),
                    Price = 600.00M, BookImageURL = ("/Content/Images/Book-icon.png"),
                    Description = "Niccolò Machiavelli's (1469-1527) intense desire to see the Medici family assume power in Italy provided the foundation for his primer for princes. In this classic guide to acquiring and maintaining political power, Machiavelli used a rational approach to advise prospective rulers, developing logical arguments and alternatives for a number of potential problems, among them governing hereditary monarchies, dealing with colonies and the treatment of conquered peoples."},
                new Book { Title = "Crime and Punishment", Genre = genres.Single(g => g.Name == "Classics"), Author = authors.Single(a => a.FirstName == "Fyodor" && a.LastName == "Dostoyevsky"),
                    Price = 600.00M, BookImageURL = ("/Content/Images/Book-icon.png"),
                    Description = "Crime and Punishment focuses on the mental anguish and moral dilemmas of Rodion Romanovich Raskolnikov, an impoverished man who formulates and executes a plan to kill an unscrupulous pawnbroker seemingly for her money, thereby solving his financial problems and at the same time, ridding the world of an evil parasite. Raskolnikov also strives to be an extraordinary being, believing that murder is permissible in pursuit of a higher purpose."}
            }.ForEach(b => context.Books.Add(b));

            context.SaveChanges();
        }
    }
}