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
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ArcaneTinmen.DAL.ArcaneTinmenContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //List<Customer> customers = new List<Customer>
            //{
            //    new Customer {
            //        Title = "Miss",
            //        FirstName = "Hermione",
            //        LastName = "Granger",
            //        Address = "Bakers Street 133",
            //        Zip = 5489,
            //        Phone = 66779922,
            //        Email = "hermionegranger@mail.com",
            //        Password = "123aBc",
            //        ConfirmPassword = "123aBc"
            //    },
            //    new Customer {
            //        Title = "Mr.",
            //        FirstName = "Harry",
            //        LastName = "Potter",
            //        Address = "4 Privet Drive",
            //        Zip = 7878,
            //        Phone = 11668579,
            //        Email = "harrypotter@mail.com",
            //        Password = "456dEf",
            //        ConfirmPassword = "456dEf"
            //    },
            //    new Customer {
            //        Title = "Mr.",
            //        FirstName = "Ronald",
            //        LastName = "Weasly",
            //        Address = "The Buroow",
            //        Zip = 9638,
            //        Phone = 78549316,
            //        Email = "ronaldweasley@mail.com",
            //        Password = "789gHi",
            //        ConfirmPassword = "789gHi"
            //    }

            //};
            //customers.ForEach(c => context.Customers.AddOrUpdate(c));
            //context.SaveChanges();

            List<Sleeve> sleeves = new List<Sleeve>
            {
                new Sleeve
                {
                    SleeveId = "AT-10402",
                    Name = "Large",
                    Description = "Euro-games: Large cards",
                    Height = 92,
                    Width = 59,
                    SalePrice = 100,
                    StockAmount = 130
                },
                new Sleeve
                {
                    SleeveId = "AT-10403",
                    Name = "Medium",
                    Description = "American games: Large cards",
                    Height = 89,
                    Width = 57,
                    SalePrice = 100.12,
                    StockAmount = 140
                }
            };
            sleeves.ForEach(s => context.Sleeves.AddOrUpdate(s));
            context.SaveChanges();

            List<Admin> admins = new List<Admin>
            {
                new Admin
                {
                    AdminId = 1,
                    Username = "MasterChef",
                    Password = "admin",
                    Email = "Admin@adminsen.dk"
                },
                new Admin
                {
                    AdminId = 2,
                    Username = "MinorAdmin",
                    Password = "admin",
                    Email = "Admin@adminson.dk"
                }
            };
            admins.ForEach(a => context.Admins.AddOrUpdate(a));
            context.SaveChanges();
        }
    }
}
