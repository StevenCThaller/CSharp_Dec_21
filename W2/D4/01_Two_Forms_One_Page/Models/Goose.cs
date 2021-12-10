using System;
using System.ComponentModel.DataAnnotations;

namespace _01_Two_Forms_One_Page.Models
{
    public class Goose
    {
        [Key]
        public int GooseId { get; set; }

        [Required]
        public string GooseName { get; set;}
        [Required]
        public string GooseFrabba { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}