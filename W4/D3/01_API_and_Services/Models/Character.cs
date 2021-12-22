using System;

namespace _01_API_and_Services.Models
{
    public class Character
    {
        public int characterId { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public string url { get; set; }

        public static Character ConvertFromObjectToCharacter(object toConvert)
        {
            return (Character) toConvert;
        }
    }
}