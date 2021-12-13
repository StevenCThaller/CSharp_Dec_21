using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_Many_To_Many.Models
{
    public class PokemonHasMove 
    {
        [Key]
        public int PokemonHasMoveId { get; set; }

        // Foreign Key and Navigation Property for the Pokemon
        [Required]
        public int PokemonId { get; set; }
        public Pokemon PokemonWithMove { get; set; }

        // Foreign Key and Navigation Property for the Move
        [Required]
        public int MoveId { get; set; }
        public Move MoveKnownByPokemon { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;   
    }
}