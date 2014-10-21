/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Modellobjekt som brukes til lagring av Kundeinfo. Grunnen til at vi har to kundemodeller er at datafeltet "LoginPassord" til databasemodellen
 * ikke kan mappes til HTML-form inputten siden den lagres i databasen som en hash. To klasser ble en enkel workaround for det.
 * 
 * I tillegg inneholder den statiske funksjoner for å generere passordhash, samt sjekke om en epostadresse finnes fra før av i databasen.
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prosjekt1.Models
{
    public class DBCustomer
    {
        public int DBCustomerId { get; set; }
        public string Email { get; set; }
        public byte[] LoginPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public static byte[] GeneratePasswordHash(string Password)
        {
            var algorithm = System.Security.Cryptography.SHA512.Create();
            byte[] input = System.Text.Encoding.ASCII.GetBytes(Password);

            return algorithm.ComputeHash(input);
        }

        public static bool CheckDuplicateEmail(string checkEmail)
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                var check = (from c in bookDB.Customers
                             where String.Compare(c.Email, checkEmail, StringComparison.InvariantCultureIgnoreCase) == 0
                             select new
                             {
                                 Email = c.Email
                             }).SingleOrDefault();

                return check == null;
            }
        }

        public static bool CheckDuplicateEmailIgnoreCustomer(string checkEmail, int customerId)
        {
            using (BookStoreDB bookDB = new BookStoreDB())
            {
                var check = (from c in bookDB.Customers
                             where c.DBCustomerId != customerId
                             && String.Compare(c.Email, checkEmail, StringComparison.InvariantCultureIgnoreCase) == 0
                             select new
                             {
                                 Email = c.Email
                             }).SingleOrDefault();

                return check == null;
            }
        }
    }
}