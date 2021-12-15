
namespace BeltPrep.Models
{
    public class ShowInfoView
    {
        public int LoggedUserId { get; set; }
        public TVShow Show { get; set; }
        public Rating Form { get; set; }
    }
}