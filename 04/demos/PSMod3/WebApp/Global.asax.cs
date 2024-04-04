using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApp.Models;

namespace WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var db = new ApplicationDbContext())
            {
                if (!db.Tenants.Any())
                {
                    db.Tenants.AddRange(new List<Tenant>()
                    {
                        new Tenant()
                        {
                            Id = 1,
                            Name = "SVCC",
                            Default = true,
                            DomainName = "siliconvalley-codecamp.com",
                        },
                        new Tenant()
                        {
                            Id = 1,
                            Name = "ANGU",
                            Default = false,
                            DomainName = "angularu.com",
                        },
                    });
                    db.SaveChanges();
                }

                if (!db.Speakers.Any())
                {
                    db.Speakers.AddRange(new List<Speaker>()
                    {
                        new Speaker
                        {
                            Id = 1,
                            First = "Chris",
                            Last = "Love",
                            TenantId = 1
                        },
                        new Speaker
                        {
                            Id = 2,
                            First = "Daniel",
                            Last = "Egan",
                            TenantId = 1
                        },
                        new Speaker
                        {
                            Id = 3,
                            First = "Igor",
                            Last = "Minar",
                            TenantId = 2
                        },
                        new Speaker
                        {
                            Id = 4,
                            First = "Brad",
                            Last = "Green",
                            TenantId = 2
                        },
                        new Speaker
                        {
                            Id = 5,
                            First = "Misko",
                            Last = "Hevery",
                            TenantId = 2
                        }

                    });
                    db.SaveChanges();
                }
            }
        }
    }
}
