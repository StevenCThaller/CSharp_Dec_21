using System.Collections.Generic;

namespace _01_One_To_Many.Models
{
    public class IndexView 
    {
        public List<Pokemon> AllPokemon { get; set; }
        public List<Trainer> AllTrainers { get; set; }
    }
}