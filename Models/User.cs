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
        public double Rating { get; set; } = 0;
        public UserImage UserImage { get; set; } = new UserImage();
        public List<Offer> Offers { get; set; } = new List<Offer>();

    }
}
