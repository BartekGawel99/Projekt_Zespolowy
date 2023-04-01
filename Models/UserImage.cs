using System.ComponentModel.DataAnnotations;

namespace Projekt_Zespolowy.Models
{
    public class UserImage
    {
        [Key]
        public int UserImageId { get; set; }
        public string UserImageURl { get; set; } = string.Empty;
    }
}
