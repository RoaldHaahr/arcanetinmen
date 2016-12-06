using System.ComponentModel.DataAnnotations;

namespace ArcaneTinmen.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "Please enter a valid username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]{2,3}$", ErrorMessage = "Not a valid email")]
        public string Email { get; set; }
        public Admin() { }
        public Admin(int adminId, string username, string password, string email)
        {
            AdminId = adminId;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}