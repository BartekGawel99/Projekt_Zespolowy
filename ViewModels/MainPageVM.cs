using Projekt_Zespolowy.Models;

namespace Projekt_Zespolowy.ViewModels
{
    public class MainPageVM
    {
        public List<Offer> NewOffers { get; set; } = new List<Offer>();
        public List<User> TopUsers { get; set; } = new List<User>();
        public List<CategoryCount> TopCategories { get; set; } = new List<CategoryCount>();
    }
}
