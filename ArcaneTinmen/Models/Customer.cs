using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArcaneTinmen.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        
        public string Title { get; set; }

        [RegularExpression(@"([a-zA-Z]+\s{0,1})*", ErrorMessage = "Your first name can only consist of letters and spaces")]
        [Required(ErrorMessage = "Please enter your name.")]
        public string FirstName { get; set; }

        [RegularExpression(@"([a-zA-Z]+\s{0,1})*", ErrorMessage = "Your last name can only consist of letters and spaces")]
        [Required]
        public string LastName { get; set; }

        [RegularExpression(@"([a-zA-Z]*\d*)*", ErrorMessage = "Your password must only consist of numbers and letters.")]
        [Required(ErrorMessage = "Please enter a password.")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Your password must be between 6 and 12 characters long")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The passwords does not match.")]
        [Required(ErrorMessage = "Please confirm your password.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Address { get; set; }

        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "The zip code must be either 3 or 4 digits")]
        [Required]
        public int Zip { get; set; }

        [RegularExpression(@"^(\d{2}\s?){4}$", ErrorMessage = "Nope")]
        public string Phone { get; set; }

        // Email must be able to handle period seperated values e.g. johndoe@students.baaa.dk
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]{2,3}$", ErrorMessage = "Not a valid email")]
        [Required]
        public string Email { get; set; }

        public virtual ICollection<OrderPlacement> OrderPlacements { get; set; }

        public Customer() {}

        public Customer(int customerId, string title, string firstName, string lastName, string address, int zip, string phone, string email)
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