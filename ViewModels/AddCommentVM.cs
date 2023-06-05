using Microsoft.Extensions.Options;
using Projekt_Zespolowy.Models;

namespace Projekt_Zespolowy.ViewModels
{
	public class AddCommentVM 
	{
		public Opinion Opinion { get; set; } = new Opinion();
		public Offer Offer { get; set; } = new Offer();
		public User User { get; set; } = new User();
	}
}
