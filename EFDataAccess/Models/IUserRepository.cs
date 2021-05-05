using System.Collections.Generic;
using EFDataAccess.Models;

namespace RecipesAPI.Models
{
    public interface IUserRepository
    {
        User GetUser(string username);
        IEnumerable<User> GetUsers();
        User AddUser(User person);
        User updateUser(User personChanges);
        User DeleteUser(string username);
        string GenerateTokenForUser(string userName);
        string DeleteUserToken(string userName);
    }
}