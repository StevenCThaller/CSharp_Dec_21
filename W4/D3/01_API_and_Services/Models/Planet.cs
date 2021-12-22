namespace _01_API_and_Services.Models
{
    public class Planet
    {
        public int planetId { get; set; }
        public string name { get; set; }
        public double diameter { get; set; }
        public double population { get; set; }
        public string url { get; set; }

        public static Planet ConvertFromObjectToPlanet(object toConvert)
        {
            return (Planet) toConvert;
        }
    }
}