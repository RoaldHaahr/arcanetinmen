namespace ArcaneTinmen.Migrations
{
    using Areas.Admin.Controllers;
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
                    Firstname = "Hermione",
                    Lastname = "Granger",
                    Address = "Bakers Street 133",
                    Zip = 5489,
                    Email = "hermionegranger@mail.com",
                },
                new Customer {
                    Firstname = "Harry",
                    Lastname = "Potter",
                    Address = "4 Privet Drive",
                    Zip = 7878,
                    Email = "harrypotter@mail.com",
                },
                new Customer {
                    Firstname = "Ronald",
                    Lastname = "Weasly",
                    Address = "The Buroow",
                    Zip = 3258,
                    Email = "ronaldweasley@mail.com",
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

            List<Game> games = new List<Game>
            {
                new Game
                {
                    GameId = 1,
                    Name = "Hero Quest"
                },
                new Game
                {
                    GameId = 2,
                    Name = "Scythe"
                },
                new Game
                {
                    GameId = 3,
                    Name = "Dominion"
                },
                new Game
                {
                    GameId = 4,
                    Name = "Falling Sky"
                },
                new Game
                {
                    GameId = 5,
                    Name = "Grand Austria Hotel",
                },
                new Game
                {
                    GameId = 6,
                    Name = "Dungeon and Dragons",
                },
                new Game
                {
                    GameId = 7,
                    Name = "Star Wars Rebellion",
                },
                new Game
                {
                    GameId = 8,
                    Name = "Settlers of Catan"
                },
                new Game
                {
                    GameId = 9,
                    Name = "Trivial Pursuit",
                },
                new Game
                {
                    GameId = 10,
                    Name = "Monopoly",
                },
                new Game
                {
                    GameId = 11,
                    Name = "Risk",
                },
                new Game
                {
                    GameId = 12,
                    Name = "Uno",
                },
                new Game
                {
                    GameId = 13,
                    Name = "Best Game",
                },
                new Game
                {
                    GameId = 14,
                    Name = "Thunder and Lightning",
                }
            };

            games.ForEach(a => context.Games.AddOrUpdate(a));
            context.SaveChanges();

            List<GameSleeve> gameSleeves = new List<GameSleeve>
            {
                new GameSleeve
                {
                    SleeveId = "AT-10405",
                    GameId = 8
                },
                new GameSleeve
                {
                    SleeveId = "AT-10407",
                    GameId = 9
                },
                new GameSleeve
                {
                    SleeveId = "AT-10406",
                    GameId = 9
                },
                new GameSleeve
                {
                    SleeveId = "AT-10407",
                    GameId = 10
                },
                new GameSleeve
                {
                    SleeveId = "AT-10406",
                    GameId = 10
                },
                new GameSleeve
                {
                    SleeveId = "AT-10408",
                    GameId = 13
                }
            };

            gameSleeves.ForEach(gs => context.GameSleeves.AddOrUpdate(gs));
            context.SaveChanges();

            List<Account> accounts = new List<Account>
            {
                new Account
                {
                    AccountId = 1,
                    Username = "MasterChef",
                    Password = "admin",
                    Email = "Admin@adminsen.dk"
                },
                new Account
                {
                    AccountId = 2,
                    Username = "MinorAdmin",
                    Password = "admin",
                    Email = "Admin@adminson.dk"
                }
            };
            accounts.ForEach(a => context.Accounts.AddOrUpdate(a));
            context.SaveChanges();
        }
    }
}
