using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;



namespace _01_API_and_Services.Models
{
    public class StarWarsThing
    {
        [Key]
        public int StarWarsThingId { get; set; }

        public string Url { get; set; }

        public List<Favorite> FavoritedBy { get; set; }
    }
}