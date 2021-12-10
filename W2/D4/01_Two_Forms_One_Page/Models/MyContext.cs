using Microsoft.EntityFrameworkCore;

namespace _01_Two_Forms_One_Page.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        // MAKE SURE you are adding a DbSet for every single model
        // you wish to translate to the database
        public DbSet<Duck> Ducks { get; set; }
        public DbSet<Goose> Geese { get; set; }
    }
}