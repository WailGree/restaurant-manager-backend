namespace EFDataAccess.Models
{
    public class AuthenticationCredential
    {
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticationCredential(string username, string token)
        {
            Username = username;
            Token = token;
        }
    }
}