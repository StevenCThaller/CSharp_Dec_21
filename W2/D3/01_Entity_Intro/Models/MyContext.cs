using Microsoft.EntityFrameworkCore;

namespace _01_Entity_Intro.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        // MAKE SURE you are adding a DbSet for every single model
        // you wish to translate to the database
        public DbSet<Duck> Ducks { get; set; }
    }
}