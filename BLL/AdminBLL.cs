using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using System.Web;

namespace BLL
{
    public class AdminBLL
    {
        public void SeedAdminDB()
        {
            AdminDBSeed seeder = new AdminDBSeed();
            seeder.SeedAdminDB();
        }

        public static byte[] GeneratePasswordHash(string Password)
        {
            return AdminDAL.GeneratePasswordHash(Password);
        }

        public bool SignIn(HttpContextBase Context, string Email, string Password)
        {
            AdminDAL dal = new AdminDAL();
            var admin = dal.GetAdmin(Email, Password);

            if (admin != null)
            {
                Context.Session[Constants.AdminSignedInSessionKey] = admin.AdminId.ToString();
                return true;
            }

            else
            {
                return false;
            }
        }

        public Admin GetAdmin(int AdminId)
        {
            AdminDAL dal = new AdminDAL();
            return dal.GetAdmin(AdminId);
        }

        public Admin GetSignedInAdmin(HttpContextBase Context)
        {
            if (Context.Session[Constants.AdminSignedInSessionKey] != null)
            {
                AdminDAL dal = new AdminDAL();
                int AdminId = Convert.ToInt32(Context.Session[Constants.AdminSignedInSessionKey]);

                return dal.GetAdmin(AdminId);
            }

            else
            {
                return null;
            }
        }
    }
}
