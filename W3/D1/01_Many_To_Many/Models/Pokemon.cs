using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _01_Many_To_Many.Models
{
    public class Pokemon 
    {
        [Key]
        public int PokemonId { get; set; }

        public string Name { get; set; }

        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        
        // Foreign Key for the trainer who caught any given pokemon
        [Display(Name = "Caught by: ")]
        public int TrainerId { get; set; }
        // Navigation Property for that actual trainer
        public Trainer CaughtBy { get; set; }

        /* ***************************************************************************** */
        // Navigation Property for the Many To Many Relationship between Pokemon and Moves (middle table)
        public List<PokemonHasMove> MovesKnown { get; set; }
        /* ***************************************************************************** */

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;        

        [NotMapped]
        // This property is exclusively for our form
        public List<Trainer> AvailableTrainers { get; set; }
    }
}