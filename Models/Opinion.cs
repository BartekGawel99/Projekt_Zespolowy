using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Zespolowy.Models
{
    public class Opinion
    {
        public int OpinionId { get; set; }
        [Required(ErrorMessage = "Komentarz nie może być pusty")]
        public string Comment { get; set; }
        [Required(ErrorMessage = "Ocena nie może być pusta")]
        [Range(1, 5)]
        public int Rate { get; set; }
        public string RewiewerId { get; set; }
        [NotMapped]
        public string RewiewerName { get; set; }
    }
}
