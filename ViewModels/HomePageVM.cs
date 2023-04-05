using Projekt_Zespolowy.Models;

namespace Projekt_Zespolowy.ViewModels
{
    public class HomePageVM
    {
        public List<Category> categorieList = new();
        public List<Localization> localizationList = new();
        public List<Offer> offerList = new();
        public List<LevelClass> levelClassList = new();
    }
}
