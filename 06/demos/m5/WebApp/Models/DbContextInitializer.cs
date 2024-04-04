using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Configuration;
using Newtonsoft.Json.Linq;

namespace WebApp.Models
{


    //public class DbContextInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    public class DbContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {


        protected override void Seed(ApplicationDbContext context)
        {
            var customers = new List<Customer>
            {
                new Customer {FirstName = "George", LastName = "Washington"},
                new Customer {FirstName = "Ronald", LastName = "Reagan"},
                new Customer {FirstName = "William", LastName = "Clinton"}
            };
            context.Customers.AddRange(customers);

            context.Tenants.AddRange(new List<Tenant>()
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

            context.Speakers.AddRange(new List<Speaker>()
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

            context.SaveChanges();

        }

    }
}
