using System.Collections.Generic;

namespace ArcaneTinmen.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<OrderPlacement> OrderPlacements { get; set; }

        public Customer() {}

        public Customer(int customerId, string title, string firstName, string lastName, string address, int zip, int phone, string email)
        {
            CustomerId = customerId;
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Zip = zip;
            Phone = phone;
            Email = email;
        }
    }
}