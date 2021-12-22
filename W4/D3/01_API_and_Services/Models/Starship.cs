namespace _01_API_and_Services.Models
{
    public class Starship
    {
        public int starshipId { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public string url { get; set; }

        public static Starship ConvertFromObjectToStarship(object toConvert)
        {
            return (Starship) toConvert;
        }
    }
}