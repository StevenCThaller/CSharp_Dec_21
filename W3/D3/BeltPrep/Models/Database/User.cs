using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltPrep.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        [Display(Name = "Name: ")]
        [RegularExpression("^[A-Za-z ]+$", ErrorMessage = "Name may only contain letters and spaces")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [DataType(DataType.Text)]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter a password")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters in length.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Your passwords must match.")]
        [DataType(DataType.Password)]
        public string ConfirmPw { get; set; }

        public List<TVShow> ShowsCreated { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}