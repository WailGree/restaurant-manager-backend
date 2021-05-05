using System.Collections.Generic;
using EFDataAccess.DataAccess;
using EFDataAccess.Models;

namespace RecipesAPI.Models
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly RestaurantContext _context;

        public SQLUserRepository(RestaurantContext context)
        {
            _context = context;
        }

        public User GetUser(string username)
        {
            return _context.Users.Find(username);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User updateUser(User userChanges)
        {
            var user = _context.Users.Attach(userChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return userChanges;
        }

        public User DeleteUser(string username)
        {
            User user = _context.Users.Find(username);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return user;
        }

        public string GenerateTokenForUser(string userName)
        {
            User user = _context.Users.Find(userName);
            if (user != null)
            {
                user.GenerateToken();
                _context.Users.Update(user);
                _context.SaveChanges();
            }

            return user.Token;
        }

        public string DeleteUserToken(string userName)
        {
            User user = _context.Users.Find(userName);
            if (user != null)
            {
                user.DeleteToken();
                _context.Users.Update(user);
                _context.SaveChanges();
            }

            return user.Token;
        }
    }
}