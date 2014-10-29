using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prosjekt1.Models;
using BLL;

namespace Prosjekt1.Repositories
{
    public class CustomerRepository : CustomerRepositoryInterface
    {
        public DBCustomer GetCustomer(string Email)
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                return bookDB.Customers.Where(c => c.Email == Email).SingleOrDefault();
            }
        }

        public bool DeleteCustomer(string Email)
        {
            DBCustomer Customer = GetCustomer(Email);

            if (Customer == null)
            {
                return false;
            }

            var bookDB = new BookStoreDB();

            try
            {
                bookDB.Customers.Remove(Customer);
                bookDB.SaveChanges();
            }

            catch (Exception exc)
            {
                // Write exception details to error log
                ErrorLogBLL.WriteToErrorLogFile(exc.ToString());
                return false;
            }

            return true;
        }

        public List<DBCustomer> GetAllCustomers()
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                return bookDB.Customers.ToList();
            }
        }
    }
}