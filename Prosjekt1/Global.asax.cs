using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BLL;

namespace Prosjekt1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Seed BookStoreDB
            System.Data.Entity.Database.SetInitializer(new Prosjekt1.Models.DBSeed());

            // Seed AdminDB
            AdminBLL AdminBLL = new AdminBLL();
            AdminBLL.SeedAdminDB();

            // Add bug workaround
            ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
