
namespace _01_Models_Intro.Models
{
    public class Duck 
    {
        public string DuckName { get; set; }
        public string Quackifications { get; set; }
        public int BillLength { get; set; }

        public Duck(){}
        public Duck(string name, string quacks, int bill)
        {
            DuckName = name;
            Quackifications = quacks;
            BillLength = bill;
        }

    }
}