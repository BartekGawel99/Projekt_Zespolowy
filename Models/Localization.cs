using System.ComponentModel.DataAnnotations;

namespace Projekt_Zespolowy.Models
{
    public class Localization
    {
        [Key]
        public int LocalizationId { get; set; }
        [Display(Name = "Ulica")]
        public string Street { get; set; } = string.Empty;
        [Display(Name = "Miasto")]
        public string City { get; set; } = string.Empty;
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; } = string.Empty;
        [Display(Name = "Numer domu")]
        public string HouseNumber { get; set; } = string.Empty;
        [Display(Name = "Numer mieszkania")]
        public string HomeNumber { get; set; } = string.Empty;
        [Display(Name = "Szerokość geograficzna")]
        public double Latitude { get; set; }
        [Display(Name = "Wysokość geograficzna")]
        public double Longitude { get; set; }
    }

}
