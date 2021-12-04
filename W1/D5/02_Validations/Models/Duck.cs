using System.ComponentModel.DataAnnotations;

namespace _02_Validations.Models
{
    public class Duck 
    {
        [Display(Name = "Duck Name: ")]
        [Required(ErrorMessage = "Please provide a name for your feathery friend.")]
        [MinLength(2, ErrorMessage = "Your Duck's name must be at least 2 characters long.")]
        public string DuckName { get; set; }

        [Display(Name = "Quackifications: ")]
        public string Quackifications { get; set; }

        [Display(Name = "Bill Length (in centibeakers): ")]
        [Range(0, 15, ErrorMessage = "Bill Length must be between 0 and 15 centibeakers.")]
        [Required(ErrorMessage = "Please enter a Bill Length.")]
        public int? BillLength { get; set; }

        public Duck(){}
        public Duck(string name, string quacks, int bill)
        {
            DuckName = name;
            Quackifications = quacks;
            BillLength = bill;
        }

    }
}