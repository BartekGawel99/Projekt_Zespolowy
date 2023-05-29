using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Zespolowy.Models
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Pole Imię jest wymagane.")]
        [Display(Name = "Imię")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Pole Nazwisko jest wymagane.")]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; } = string.Empty;
        [Display(Name = "Średnia ocen korepetytora")]
        public double Rating { get; set; } = 0;
        public UserImage UserImage { get; set; } = new UserImage();
        public List<Offer> Offers { get; set; } = new List<Offer>();
        public List<Opinion> Opinions { get; set; } = new List<Opinion>();

        [NotMapped]
        public float? Score
        {
            get
            {
                float rateSum = 0;

                if (Opinions != null)
                {
                    foreach (var opinion in Opinions)
                        rateSum += opinion.Rate;

                    return rateSum / Opinions.Count();
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
