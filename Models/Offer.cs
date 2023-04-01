using System.ComponentModel.DataAnnotations;

namespace Projekt_Zespolowy.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        [Required(ErrorMessage = "Proszę podać nazwę oferty")]
        public string OfferName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Proszę podać opis oferty")]
        public string OfferDescription { get; set; } = string.Empty;
        [Required(ErrorMessage = "Proszę podać cenę oferty")]
        public double Price { get; set; }
        public string Localization { get; set; } = string.Empty;
        public Category Category { get; set; } = new Category();
    }
}
