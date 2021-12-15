using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BeltPrep.Models
{
    public class TVShow
    {
        [Key]
        public int TVShowId { get; set; }
        [Required(ErrorMessage = "You must enter a title")]
        [Display(Name = "Title: ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must enter a network")]
        [Display(Name = "Network: ")]
        public string Network { get; set; }
        public int UserId { get; set; }
        public User PostedBy { get; set; }

        public List<Rating> Ratings { get; set; } = new List<Rating>();

        [NotMapped]
        public double AverageRating 
        {
            get
            {
                System.Console.WriteLine("Did this do a thing?");
                if(Ratings.Count == 0)
                {
                    return 0;
                }
                else 
                {
                    return (double)Ratings.Sum(r => r.StarRating) / (double)Ratings.Count;
                }
            }
        }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}