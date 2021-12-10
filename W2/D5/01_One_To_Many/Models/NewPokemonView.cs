using System.Collections.Generic;

namespace _01_One_To_Many.Models
{
    public class NewPokemonView
    {
        public Pokemon Form { get; set; }
        public List<Trainer> AvailableTrainers { get; set; }
    }
}