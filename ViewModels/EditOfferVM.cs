using Projekt_Zespolowy.Models;

namespace Projekt_Zespolowy.ViewModels
{
    public class EditOfferVM
    {
        public Offer Offer { get; set; }
		public Localization Localization { get; set; } = new Localization();
		public List<Category> CategoriesList { get; set; } = new List<Category>();
		public List<LevelClass> LevelClassesList { get; set; } = new List<LevelClass>();
        public LevelClass ChosenLevelClass { get; set; } = new LevelClass();
    }
}
