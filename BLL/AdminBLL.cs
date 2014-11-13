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
        private AdminDALInterface DAL;

        public AdminBLL()
        {
            DAL = new AdminDAL();
        }

        public AdminBLL(AdminDALInterface stub)
        {
            DAL = stub;
        }

        public void SeedAdminDB()
        {
            DBSeed seeder = new DBSeed();
            seeder.SeedAdminDB();
        }

        public bool SignIn(HttpContextBase Context, string Email, string Password)
        {
            var admin = DAL.GetAdmin(Email, Password);

            if (admin != null)
            {
                // If UnitTest is running, Context will be null
                if (Context != null)
                {
                    Context.Session[Constants.AdminSignedInSessionKey] = admin.AdminId.ToString();
                }

                return true;
            }

            else
            {
                return false;
            }
        }

        public Admin GetAdmin(int AdminId)
        {
            return DAL.GetAdmin(AdminId);
        }

        public Admin GetSignedInAdmin(HttpContextBase Context)
        {
            // HttpContext is null during unit testing
            if (Context == null)
            {
                return DAL.GetAdmin(1);
            }

            else if (Context.Session[Constants.AdminSignedInSessionKey] != null)
            {
                int AdminId = Convert.ToInt32(Context.Session[Constants.AdminSignedInSessionKey]);

                return DAL.GetAdmin(AdminId);
            }

            else
            {
                return null;
            }
        }

        public string SignOut(HttpContextBase Context)
        {
            // HttpContext is null during unit testing
            if (Context == null)
            {
                return DAL.GetAdmin(1).Email;
            }

            int AdminId = Convert.ToInt32(Context.Session[Constants.AdminSignedInSessionKey]);
            Context.Session[Constants.AdminSignedInSessionKey] = null;

            return DAL.GetAdmin(AdminId).Email;
        }
    }
}
