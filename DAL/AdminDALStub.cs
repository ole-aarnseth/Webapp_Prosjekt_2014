using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminDALStub : DAL.AdminDALInterface
    {
        public Admin GetAdmin(string Email, string Password)
        {
            if (Email != "admin@admin.com")
            {
                return null;
            }

            var defaultAdmin = new Admin()
            {
                AdminId = 1,
                Email = "admin@admin.com",
                LoginPassword = AdminDAL.GeneratePasswordHash("admin1234"),
                FirstName = "Lars",
                LastName = "Adminsson",
                Phone = "ADMIN-2020202"
            };

            return defaultAdmin;
        }

        public Admin GetAdmin(int AdminId)
        {
            var defaultAdmin = new Admin()
            {
                AdminId = AdminId,
                Email = "admin@admin.com",
                LoginPassword = AdminDAL.GeneratePasswordHash("admin1234"),
                FirstName = "Lars",
                LastName = "Adminsson",
                Phone = "ADMIN-2020202"
            };

            return defaultAdmin;
        }
    }
}
