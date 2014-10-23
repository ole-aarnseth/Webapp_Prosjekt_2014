using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class AdminDBSeed
    {
        public void SeedAdminDB()
        {
            using (AdminDB adminDB = new AdminDB())
            {
                int count = adminDB.Admins.Count();

                if (count != 0)
                {
                    return;
                }

                var defaultAdmin = new Admin
                {
                    Email = "admin@admin.com",
                    LoginPassword = AdminDAL.GeneratePasswordHash("admin1234"),
                    FirstName = "Lars",
                    LastName = "Adminsson",
                    Phone = "ADMIN-2020202"
                };

                adminDB.Admins.Add(defaultAdmin);
                adminDB.SaveChanges();
            }
        }
    }
}
