using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prosjekt1.Models;

namespace Prosjekt1.Repositories
{
    public class CustomerRepositoryStub : CustomerRepositoryInterface
    {
        public DBCustomer GetCustomer(string Email)
        {
            return new DBCustomer()
            {
                DBCustomerId = 1,
                Email = Email,
                LoginPassword = DBCustomer.GeneratePasswordHash("customer1234"),
                FirstName = "John",
                LastName = "Doe",
                Phone = "1212121221",
                Address = "Customer Street 20",
                PostalCode = "400000",
                City = "Customer City"
            };
        }

        public bool DeleteCustomer(string Email)
        {
            return Email != "UnitTestDeleteShouldFail";
        }

        public List<DBCustomer> GetAllCustomers()
        {
            return new List<DBCustomer>()
            {
                GetCustomer("customer1@customer.com"),
                GetCustomer("customer2@customer.com"),
                GetCustomer("customer3@customer.com")
            };
        }
    }
}