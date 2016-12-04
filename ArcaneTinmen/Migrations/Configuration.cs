namespace ArcaneTinmen.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ArcaneTinmen.DAL.ArcaneTinmenContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ArcaneTinmen.DAL.ArcaneTinmenContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var customers = new List<Customer>
            {
                new Customer {
                    CustomerId = 1,
                    Title = "Miss",
                    FirstName = "Hermione",
                    LastName = "Granger",
                    Address = "Bakers Street 133",
                    Zip = 5489,
                    Phone = 66779922,
                    Email = "hermionegranger@mail.com",
                    Password = "123aBc",
                    ConfirmPassword = "123aBc"
                }
            };
            customers.ForEach(c => context.Customers.AddOrUpdate(c));
            context.SaveChanges();
        }
    }
}
