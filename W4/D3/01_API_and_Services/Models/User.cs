using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace _01_API_and_Services.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Favorite> Favorites { get; set; }
    }
}