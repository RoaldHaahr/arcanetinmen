using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ArcaneTinmen.DAL;

namespace ArcaneTinmen.Models
{
    public class Customer
    {
        // PROPTERTIES
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        //[Required(ErrorMessage = "Enter a name Between 2 and 50 characters")]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        //[Required(ErrorMessage = "Please enter a Valid Zip Code")]
        public int Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        //[Required(ErrorMessage = "please enter a valid Email")]
        public string Email { get; set; }

        // NAVIGATION
        public virtual ICollection<Order> Orders { get; set; }

        // CONSTRUCTORS
        public Customer() { }

        public Customer(int customerId, string firstnavn, string lastnavn, string address, int zip, string city)
        {
            CustomerId = customerId;
            Firstname = firstnavn;
            Lastname = lastnavn;
            Address = address;
            Zip = zip;
            City = city;
        }
    }
}