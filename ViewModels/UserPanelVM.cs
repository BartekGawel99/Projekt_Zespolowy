using Projekt_Zespolowy.Models;

namespace Projekt_Zespolowy.ViewModels
{
	public class UserPanelVM
	{
		public User User { get; set; } = new User();
		public List<Offer> OffersList { get; set; } = new List<Offer>();
	}
}
