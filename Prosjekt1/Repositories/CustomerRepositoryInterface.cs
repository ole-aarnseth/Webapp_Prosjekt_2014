using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prosjekt1.Models;

namespace Prosjekt1.Repositories
{
    public interface CustomerRepositoryInterface
    {
        DBCustomer GetCustomer(string Email);
        bool DeleteCustomer(string Email);
        List<DBCustomer> GetAllCustomers();
    }
}
