using Microsoft.EntityFrameworkCore;

namespace _01_One_To_Many.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        // MAKE SURE you are adding a DbSet for every single model
        // you wish to translate to the database
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
    }
}