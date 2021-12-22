using Microsoft.EntityFrameworkCore;

namespace _01_API_and_Services.Models
{
    public class MyContext : DbContext 
    {
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<StarWarsThing> StarWarsThings { get; set; }
    }
}