using ArcaneTinmen.Models;
using System;
using System.Collections.Generic;

namespace ArcaneTinmen.DAL
{
    public class ArcaneTinmenInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ArcaneTinmenContext>
    {
        protected override void Seed(ArcaneTinmenContext context)
        { /*
            var customers = new List<Customer>
            {
                new Customer {
                    CustomerId = 1,
                    Title = "Miss",
                    FirstName = "Hermione",
                    LastName = "Granger",
                    Address = "Bakers Street 133",
                    Zip = 54895,
                    Phone = 66779922,
                    Email = "hermionegranger@mail.com",
                    Password = "123aB",
                    ConfirmPassword = "123aB"
                }
            };
            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges(); */
        }
    }
}