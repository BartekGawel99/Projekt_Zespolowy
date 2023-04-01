using System.ComponentModel.DataAnnotations;

namespace Projekt_Zespolowy.Models
{
    public class Localization
    {
        [Key]
        public int LocalizationId { get; set; }
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string HouseNumber { get; set; } = string.Empty;
        public string HomeNumber { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

}
