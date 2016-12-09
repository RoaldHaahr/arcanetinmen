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

            List<Customer> customers = new List<Customer>
            {
                new Customer
                {
                    Title = "Miss",
                    FirstName = "Hermione",
                    LastName = "Granger",
                    Address = "Bakers Street 133",
                    Zip = 5489,
                    Phone = 66779922,
                    Email = "hermionegranger@mail.com",
                    Password = "123aBc",
                    ConfirmPassword = "123aBc"
                },
                new Customer {
                    Title = "Mr.",
                    FirstName = "Harry",
                    LastName = "Potter",
                    Address = "4 Privet Drive",
                    Zip = 7878,
                    Phone = 11668579,
                    Email = "harrypotter@mail.com",
                    Password = "456dEf",
                    ConfirmPassword = "456dEf"
                },
                new Customer {

                    Title = "Mr.",
                    FirstName = "Ronald",
                    LastName = "Weasly",
                    Address = "The Buroow",
                    Zip = 9638,
                    Phone = 78549316,
                    Email = "ronaldweasley@mail.com",
                    Password = "789gHi",
                    ConfirmPassword = "789gHi"
                }
            };
            customers.ForEach(c => context.Customers.AddOrUpdate(c));
            context.SaveChanges();

            List<Sleeve> sleeves = new List<Sleeve>
            {
                new Sleeve
                {
                    SleeveId = "AT-10402",
                    Name = "Large",
                    Description = "Euro-games: Large cards (fit cards of 59 x 92 mm or smaller)",
                    Height = 92,
                    Width = 59,
                    SalePrice = 100,
                    StockAmount = 130,
                    CardImageFileName = "l_card.svg",
                    BadgeImageFileName = "l_badge.svg"
                },
                new Sleeve
                {
                    SleeveId = "AT-10403",
                    Name = "Medium",
                    Description = "American games: Large cards (fit cards of 57 x 89 mm or smaller)",
                    Height = 89,
                    Width = 57,
                    SalePrice = 100,
                    StockAmount = 140,
                    CardImageFileName = "m_card.svg",
                    BadgeImageFileName = "m_badge.svg"
                },
                new Sleeve
                {
                    SleeveId = "AT-10404",
                    Name = "Small",
                    Description = "Euro-games: Small cards (fit cards of 44 x 68 mm or smaller)",
                    Height = 68,
                    Width = 44,
                    SalePrice = 100,
                    StockAmount = 130,
                    CardImageFileName = "s_card.svg",
                    BadgeImageFileName = "s_badge.svg"
                },
                new Sleeve
                {
                    SleeveId = "AT-10405",
                    Name = "Mini",
                    Description = "American games: Small cards (fit cards of 41 x 63 mm or smaller)",
                    Height = 63,
                    Width = 41,
                    SalePrice = 100,
                    StockAmount = 130,
                    CardImageFileName = "mini_card.svg",
                    BadgeImageFileName = "mini_badge.svg"
                },
                new Sleeve
                {
                    SleeveId = "AT-10406",
                    Name = "Standard",
                    Description = "CCG-size (most of them) (fit cards of 63 x 88 or smaller)",
                    Height = 88,
                    Width = 63,
                    SalePrice = 100,
                    StockAmount = 130,
                    CardImageFileName = "standard_card.svg",
                    BadgeImageFileName = "standard_badge.svg"
                },
                new Sleeve
                {
                    SleeveId = "AT-10407",
                    Name = "Extra Large",
                    Description = "Slightly larger than CCG (fit cards of 65 x 100 mm or smaller)",
                    Height = 100,
                    Width = 65,
                    SalePrice = 100,
                    StockAmount = 130,
                    CardImageFileName = "xl_card.svg",
                    BadgeImageFileName = "xl_badge.svg"
                },
                new Sleeve
                {
                    SleeveId = "AT-10408",
                    Name = "Oversize",
                    Description = "Oversized cards / Tarot-size (fit cards of 82 x 124 mm or smaller)",
                    Height = 124,
                    Width = 82,
                    SalePrice = 100,
                    StockAmount = 130,
                    CardImageFileName = "oversize_card.svg",
                    BadgeImageFileName = "oversize_badge.svg"
                },
                new Sleeve
                {
                    SleeveId = "AT-10409",
                    Name = "Square",
                    Description = "Square cards (fit cards of 69 x 69 mm or smaller)",
                    Height = 69,
                    Width = 69,
                    SalePrice = 100,
                    StockAmount = 130,
                    CardImageFileName = "square_card.svg",
                    BadgeImageFileName = "square_badge.svg"
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
