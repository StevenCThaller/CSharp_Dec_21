using System.ComponentModel.DataAnnotations;

namespace _01_API_and_Services.Models
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public int StarWarsThingId { get; set; }
        public StarWarsThing StarWarsThing { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}