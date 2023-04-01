using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Projekt_Zespolowy.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Pole Imię jest wymagane.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pole Nazwisko jest wymagane.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pole Ulica jest wymagane.")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pole Miasto jest wymagane.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pole Kod Pocztowy jest wymagane.")]
        public string PostalCode { get; set; } = string.Empty;

        public double Rating { get; set; } = 0;

        public UserImage UserImage { get; set; } = new UserImage();

    }
}
