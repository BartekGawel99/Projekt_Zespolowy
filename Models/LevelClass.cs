using System.ComponentModel.DataAnnotations;

namespace Projekt_Zespolowy.Models
{
    public class LevelClass
    {
        [Key]
        public int LevelId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Offer> Offers { get; set; }
    }
}
