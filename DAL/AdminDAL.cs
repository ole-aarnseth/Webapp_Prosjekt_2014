using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminDAL : DAL.AdminDALInterface
    {
        // Because DAL has no access to the original hash function in Prosjekt1/Models/DBCustomer, it needs its own implementation.
        public static byte[] GeneratePasswordHash(string Password)
        {
            var algorithm = System.Security.Cryptography.SHA512.Create();
            byte[] input = System.Text.Encoding.ASCII.GetBytes(Password);

            return algorithm.ComputeHash(input);
        }

        public Admin GetAdmin(string Email, string Password)
        {
            using (AdminDB adminDB = new AdminDB())
            {
                byte[] passwordhash = GeneratePasswordHash(Password);
                return adminDB.Admins.Where(a => a.Email == Email && a.LoginPassword == passwordhash).SingleOrDefault();
            }
        }

        public Admin GetAdmin(int AdminId)
        {
            using (AdminDB adminDB = new AdminDB())
            {
                return adminDB.Admins.Where(a => a.AdminId == AdminId).SingleOrDefault();
            }
        }
    }
}
