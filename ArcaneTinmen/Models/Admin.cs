namespace ArcaneTinmen.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
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