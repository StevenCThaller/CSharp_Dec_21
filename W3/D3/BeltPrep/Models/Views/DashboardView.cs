using System.Collections.Generic;

namespace BeltPrep.Models
{
    public class DashboardView
    {
        public string UserName { get; set; }
        public List<TVShow> AllShows { get; set; }
    }
}