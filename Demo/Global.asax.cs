using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Demo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Application_Start()
        {
            using (DB db = new DB())
            {
                if (db.Roles.Count() == 0)
                {
                    var role1 = new UserRole();
                    var role2 = new UserRole();
                    role1.RoleName = "User";
                    role2.RoleName = "Admin";
                    db.Roles.Add(role1);
                    db.Roles.Add(role2);    
                    db.SaveChanges();
                }
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
