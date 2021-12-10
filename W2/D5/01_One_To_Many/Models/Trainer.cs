using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01_One_To_Many.Models
{
    public class Trainer 
    {
        [Key]
        public int TrainerId { get; set; }
        public string Name { get; set; }
        public string NumberOfBadges { get; set; }

        // Navigation Property for the pokmeon caught by this trainer
        public List<Pokemon> PokemonCaught { get; set; }
    }
}