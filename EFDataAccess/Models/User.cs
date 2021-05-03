using System.ComponentModel.DataAnnotations;

namespace EFDataAccess.Models
{
    public class User
    {
        [Key] [MaxLength(100)] public string UserName { get; set; }
        [Required] [MaxLength(200)] public string Email { get; set; }

        public User()
        {
        }

        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }
    }
}