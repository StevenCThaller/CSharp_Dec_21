using Microsoft.EntityFrameworkCore;

namespace _01_Many_To_Many.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}

        // MAKE SURE you are adding a DbSet for every single model
        // you wish to translate to the database
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<PokemonHasMove> PokemonHaveMoves { get; set; }
        public DbSet<Move> Moves { get; set; }
    }
}