using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class AdminBLL
    {
        public void SeedAdminDB()
        {
            AdminDBSeed seeder = new AdminDBSeed();
            seeder.SeedAdminDB();
        }
    }
}
