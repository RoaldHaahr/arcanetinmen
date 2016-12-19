using System.ComponentModel.DataAnnotations;

namespace ArcaneTinmen.Models
{
    public class Account
    {
        // PROPERTIES
        [Key]
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Please enter a valid username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]{2,3}$", ErrorMessage = "Not a valid email")]
        public string Email { get; set; }

        // CONSTRUCTORS
        public Account() {}

        public Account(int accountId, string username, string password, string email)
        {
            AccountId = accountId;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}