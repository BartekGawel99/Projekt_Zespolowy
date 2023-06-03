using Projekt_Zespolowy.Models;

namespace Projekt_Zespolowy.ViewModels
{
    public class AddOfferVM
    {
        public Offer Offer { get; set; } = new Offer();
        public Localization Localization { get; set; } = new Localization();
        public List<Category> CategoriesList { get; set; } = new List<Category>();
        public List<LevelClass> LevelClassesList { get; set; } = new List<LevelClass>();
    }
}
