using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _01_Many_To_Many.Models
{
    public class Move 
    {
        [Key]
        public int MoveId { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }

        /* ***************************************************************************** */
        // Navigation Property for the Many To Many Relationship between Pokemon and Moves
        public List<PokemonHasMove> PokemonThatLearnMove { get; set; }
        /* ***************************************************************************** */

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}