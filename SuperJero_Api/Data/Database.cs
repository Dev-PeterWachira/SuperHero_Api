using Entities;
using Microsoft.EntityFrameworkCore;
namespace SuperJero_Api.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
            
        }

        public DbSet<SuperHero> SuperHeroes {get; set;}

        public DbSet<User> Users {get; set;}
    }
}