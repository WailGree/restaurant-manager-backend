using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccess.DataAccess
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<MenuItem> Menu { get; set; }
    }
}