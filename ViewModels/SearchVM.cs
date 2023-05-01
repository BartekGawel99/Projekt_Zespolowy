using Projekt_Zespolowy.Models;

namespace Projekt_Zespolowy.ViewModels
{
    public class SearchVM
    {
        public string SearchString { get; set; }
        public List<Offer> SearchResult { get; set; } = new List<Offer>();
    }
}
