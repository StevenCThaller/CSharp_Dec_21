using System;
using System.ComponentModel.DataAnnotations;

namespace _01_Entity_Intro.Models
{
    public class Duck 
    {
        // Anything that goes into our database should have a primary key for easy 
        // data access
        [Key]
        public int DuckId { get; set; }

        [Display(Name = "Duck Name: ")]
        [Required(ErrorMessage = "Please provide a name for your feathery friend.")]
        [MinLength(2, ErrorMessage = "Your Duck's name must be at least 2 characters long.")]
        public string DuckName { get; set; }

        [Display(Name = "Quackifications: ")]
        public string Quackifications { get; set; }

        [Display(Name = "Bill Length (in centibeakers): ")]
        [Range(0, 15, ErrorMessage = "Bill Length must be between 0 and 15 centibeakers.")]
        [Required(ErrorMessage = "Please enter a Bill Length.")]
        public int? BillLength { get; set; }

        // public int NumberOfTimesMigrated { get; set; } = 0; // how many times has a duck migrated south for winter

        // We also need our timestamps
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Duck(){}
        public Duck(string name, string quacks, int bill)
        {
            DuckName = name;
            Quackifications = quacks;
            BillLength = bill;
        }

    }
}