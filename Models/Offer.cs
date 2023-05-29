using System.ComponentModel.DataAnnotations;

namespace Projekt_Zespolowy.Models
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę oferty")]
        [Display(Name = "Nazwa oferty")]
        public string OfferName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Proszę podać opis oferty")]
        [Display(Name = "Opis oferty")]
        public string OfferDescription { get; set; } = string.Empty;
        [Required(ErrorMessage = "Proszę podać cenę oferty")]
        [Display(Name = "Oferowana cena [zł/h]")]
        public double Price { get; set; } = 0;
        [Required]
        [Display(Name = "Czy zajęcia są zdalne?")]
        public bool IsOnline { get; set; } = false;
        [Display(Name = "Lokalizacja zajęć")]
        public Localization Localization { get; set; } = new Localization();
        [Required]
        [Display(Name = "Kategoria zajęć")]
        public Category Category { get; set; } = new Category();
        [Required]
        public User OfferCreator { get; set; } = new User();
        [Display(Name = "Poziom zajęć")]
        public List<LevelClass> LevelClasses { get; set; } = new List<LevelClass>();
    }
}
