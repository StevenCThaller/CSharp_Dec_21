using System.Collections.Generic;

namespace _01_Many_To_Many.Models
{
    public class IndexView 
    {
        public List<Pokemon> AllPokemon { get; set; }
        public List<Trainer> AllTrainers { get; set; }
        public List<Move> AllMoves { get; set; }
    }
}