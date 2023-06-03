using System.ComponentModel.DataAnnotations;

namespace Projekt_Zespolowy.Models
{
    public class Localization
    {
        [Key]
        public int LocalizationId { get; set; }
        [Display(Name = "Ulica")]
        [Required(ErrorMessage = "Proszę podać nazwę ulicy")]
        public string Street { get; set; } = string.Empty;
        [Required(ErrorMessage = "Proszę podać nazwę miasta")]
        [Display(Name = "Miasto")]
        public string City { get; set; } = string.Empty;
        [Display(Name = "Kod pocztowy")]
        [Required(ErrorMessage = "Proszę podać kod pocztowy")]
        public string PostalCode { get; set; } = string.Empty;
        [Display(Name = "Numer domu")]
        [Required(ErrorMessage = "Proszę podać numer domu")]
        public string HouseNumber { get; set; } = string.Empty;
        [Display(Name = "Numer mieszkania")]
        public string HomeNumber { get; set; } = string.Empty;
        [Display(Name = "Szerokość geograficzna")]
        public double Latitude { get; set; }
        [Display(Name = "Wysokość geograficzna")]
        public double Longitude { get; set; }
    }

}
