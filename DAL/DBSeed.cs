using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class DBSeed
    {
        public void SeedAdminDB()
        {
            using (DBContext adminDB = new DBContext())
            {
                int count = adminDB.Admins.Count();

                if (count != 0)
                {
                    return;
                }

                var defaultAdmin = new Admin()
                {
                    Email = "admin@admin.com",
                    LoginPassword = AdminDAL.GeneratePasswordHash("admin1234"),
                    FirstName = "Lars",
                    LastName = "Adminsson",
                    Phone = "ADMIN-2020202"
                };

                adminDB.Admins.Add(defaultAdmin);

                var categories = new List<FAQCategory>
                {
                    new FAQCategory() { Name = "About us" },
                    new FAQCategory() { Name = "Shopping cart" },
                    new FAQCategory() { Name = "Orders" },
                    new FAQCategory() { Name = "Shipping" },
                    new FAQCategory() { Name = "Customer details" },
                    new FAQCategory() { Name = "Discounts" }
                };

                new List<FAQQuestion>()
                {
                    new FAQQuestion()
                    {
                        QuestionText = "What kind of books do you sell in this store?",
                        Answer = "We have a wide selection of books ranging from timeless classics like Brave New World and 1984 to more modern educational masterpieces like Pro ASP.NET MVC 5.",
                        Category = categories.Single(c => c.Name == "About us")
                    },

                    new FAQQuestion()
                    {
                        QuestionText = "Where is your store located?",
                        Answer = "In Oslo, Norway - the land of mountains, trolls and vikings.",
                        Category = categories.Single(c => c.Name == "About us")
                    },

                    new FAQQuestion()
                    {
                        QuestionText = "Can you do international shipping?",
                        Answer = "Yes, through our freight company 'The Very Fine Postal Service' we can post orders to every corner of the globe.",
                        Category = categories.Single(c => c.Name == "Shipping")
                    },

                    new FAQQuestion()
                    {
                        QuestionText = "How long does shipping normally take?",
                        Answer = "This depends on how far away you live from Oslo, Norway. After the order is posted it usually takes between three or four working days to one week.",
                        Category = categories.Single(c => c.Name == "Shipping")
                    },

                    new FAQQuestion()
                    {
                        QuestionText = "How do I add books to the shopping cart?",
                        Answer = "Click on the book you desire, this will take you to the book details page. Click 'Add to cart' to add the book to the shopping cart.",
                        Category = categories.Single(c => c.Name == "Shopping cart")
                    },

                    new FAQQuestion()
                    {
                        QuestionText = "How do I remove books from the shopping cart?",
                        Answer = "Click 'Cart' on the menu at the top, this will take you to your shopping cart summary page. Click 'Remove' next to the book that you wish to remove, this will remove the book from your shopping cart.",
                        Category = categories.Single(c => c.Name == "Shopping cart")
                    },

                    new FAQQuestion()
                    {
                        QuestionText = "How do I place an order?",
                        Answer = "Click on the books you would like to order, and place them in the shopping cart. When all the books you desire are in the shopping cart, click 'Go to checkout' in your shopping cart summary page. If you are not signed in, you will be prompted to do so. If you are an existing customer, sign in with your Email and password, or register a new customer account if you are new here. Review your order and postage address and click 'Place order' to place your order.",
                        Category = categories.Single(c => c.Name == "Orders")
                    },

                    new FAQQuestion()
                    {
                        QuestionText = "Where can i review my customer details?",
                        Answer = "Click on your email address in the top-right corner, this will take you to your customer details page.",
                        Category = categories.Single(c => c.Name == "Customer details")
                    },

                    new FAQQuestion()
                    {
                        QuestionText = "Where can i review my order history?",
                        Answer = "Click on your email address in the top-right corner, this will take you to your customer details page. To view your order history, click 'Order history'.",
                        Category = categories.Single(c => c.Name == "Orders")
                    },

                    new FAQQuestion()
                    {
                        QuestionText = "Can I track my order?",
                        Answer = "At present 'The Very Fine Postal Service' does not offer any tracking services, but they are working on it and it should be ready by 2015.",
                        Category = categories.Single(c => c.Name == "Shipping")
                    },

                    new FAQQuestion()
                    {
                        QuestionText = "Do you offer any student discounts?",
                        Answer = "At present we do not, but a discount system for students is planned when we have expanded our 'Educational' section.",
                        Category = categories.Single(c => c.Name == "Discounts")
                    }
                }.ForEach(q => adminDB.FAQQuestions.Add(q));

                var EmailedQuestion = new EmailedFAQQuestion()
                {
                    ContactEmail = "john.doe@email.com",
                    QuestionText = "How can I edit my customer details and change my shipping address?"
                };

                adminDB.EmailedFAQQuestions.Add(EmailedQuestion);

                adminDB.SaveChanges();
            }
        }
    }
}
