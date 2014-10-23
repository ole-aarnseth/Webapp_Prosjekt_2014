using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminDAL
    {
        // Because DAL has no access to the original hash function in Prosjekt1/Models/DBCustomer, it needs its own implementation.
        public static byte[] GeneratePasswordHash(string Password)
        {
            var algorithm = System.Security.Cryptography.SHA512.Create();
            byte[] input = System.Text.Encoding.ASCII.GetBytes(Password);

            return algorithm.ComputeHash(input);
        }
    }
}
