using System.ComponentModel.DataAnnotations;

namespace ArcaneTinmen.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }

        public Admin() {}
        public Admin(int adminId, string username, string password, string email)
        {
            AdminId = adminId;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}