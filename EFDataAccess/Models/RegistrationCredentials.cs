namespace EFDataAccess.Models
{
    public class RegistrationCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public RegistrationCredentials(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
}