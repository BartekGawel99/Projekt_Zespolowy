using System.ComponentModel.DataAnnotations;

namespace Projekt_Zespolowy.Models
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę oferty")]
        public string OfferName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Proszę podać opis oferty")]
        public string OfferDescription { get; set; } = string.Empty;
        [Required(ErrorMessage = "Proszę podać cenę oferty")]
        public double Price { get; set; } = 0;
        [Required]
        public bool IsOnline { get; set; } = false;
        public Localization Localization { get; set; } = new Localization();
        [Required]
        public Category Category { get; set; } = new Category();
        [Required]
        public User OfferCreator { get; set; } = new User();
        public List<LevelClass> LevelClasses { get; set; } = new List<LevelClass>();
    }
}
