using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Zespolowy.Data;
using Projekt_Zespolowy.Models;
using Projekt_Zespolowy.ViewModels;
using System.Diagnostics;

namespace Projekt_Zespolowy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            HomePageVM homePageVM = new HomePageVM
            {
                categorieList = _db.Categories.ToList(),
                localizationList = _db.Localizations.ToList(),
                levelClassList = _db.LevelClasses.ToList(),
                offerList = _db.Offers.ToList(),
            };

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> SearchBar(SearchVM model)
        {
            if (!string.IsNullOrEmpty(model.SearchString))
            {
                model.SearchResult = await SearchInDbAsync(model.SearchString);
            }

            return View(model);
        }
        private async Task<List<string>> SearchInDbAsync(string SearchString)
        {
            List<string> wyniki = new List<string>();


            var tableWithOffersResult = await _db.Offers
                .Where(t => t.OfferName.ToLower().Contains(SearchString.ToLower()))
                .Select(t => t.OfferName)
                .ToListAsync();
            wyniki.AddRange(tableWithOffersResult);

            var tableWithLocalizationsResult = await _db.Localizations
                .Where(t => t.City.ToLower().Contains(SearchString.ToLower()))
                .Select(t => t.City)
                .ToListAsync();
            wyniki.AddRange(tableWithLocalizationsResult);

            var tableWithLevelClassesResult = await _db.LevelClasses
                .Where(t => t.Name.ToLower().Contains(SearchString.ToLower()))
                .Select(t => t.Name)
                .ToListAsync();
            wyniki.AddRange(tableWithLevelClassesResult);

            var tableWithCategoriesResult = await _db.Categories
                .Where(t => t.Name.ToLower().Contains(SearchString.ToLower()))
                .Select(t => t.Name)
                .ToListAsync();
            wyniki.AddRange(tableWithCategoriesResult);


            return wyniki;
        }

    }
}