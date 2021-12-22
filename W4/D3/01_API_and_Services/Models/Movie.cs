namespace _01_API_and_Services.Models
{
    public class Movie
    {
        public int movieId { get; set; }
        public string title { get; set; }
        public string episode_id { get; set; }
        public string director { get; set; }
        public string url { get; set; }

        public static Movie ConvertFromObjectToMovie(object toConvert)
        {
            return (Movie) toConvert;
        }
    }
}