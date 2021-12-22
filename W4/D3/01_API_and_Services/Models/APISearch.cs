using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace _01_API_and_Services.Models
{
    public class APISearch
    {
        // The url has to be formatted in a way like this: apiurl.com/{Category}/{Searchid}
        [Required]
        public string Category  { get; set; }
        [Required]
        public int? SearchId { get; set; }

        public List<string> AvailableCategories { get; set; } = new List<string>
        {
            "people",
            "planets",
            "starships"
        };

    }
}