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
            var mainPageVM = new MainPageVM();
            var tableWithOffersResult = _db.Offers
                .Include(o => o.Localization)
                .Include(o => o.OfferCreator)
                .ThenInclude(i=>i.Opinions)
                .Include(o => o.Category)
                .Include(o=> o.LevelClasses)
                .OrderByDescending(t => t.OfferId)
                .Take(5)
                .ToList();
            mainPageVM.NewOffers = tableWithOffersResult;

            var offerents = _db.Users.Where(x => x.Offers.Any()).ToList();
            mainPageVM.TopUsers = offerents.OrderByDescending(x => x.Score).Take(10).ToList();
            var categoriesCountList = new List<CategoryCount>();
            foreach (var category in _db.Categories)
            {
                if(string.IsNullOrEmpty(category.Name))
                    continue;
                var categoryList = new CategoryCount()
                {
                    Name = category.Name,
                    CategoryId = category.CategoryId,
                    Count = _db.Offers.Where(x => x.Category.CategoryId == category.CategoryId).Count(),
                };
                categoriesCountList.Add(categoryList);
            }
            mainPageVM.TopCategories = categoriesCountList.OrderByDescending(x => x.Count).Take(10).ToList();

            return View(mainPageVM);
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

        public async Task<IActionResult> SearchBar(string searchString)
        {
            var model = new SearchVM();
            if (!string.IsNullOrEmpty(searchString))
            {
                model.SearchString = searchString;
                model.SearchResult = await SearchInDbAsync(model.SearchString);
            }

            return View(model);
        }

        private async Task<List<Offer>> SearchInDbAsync(string SearchString)
        {
            var tableWithOffersResult = await _db.Offers
                .Include(o => o.Localization)
                .Include(o => o.OfferCreator)
                .ThenInclude(i => i.Opinions)
                .Include(o => o.Category)
                .Include(o => o.LevelClasses)
                .Where(t => t.OfferName.ToLower().Contains(SearchString.ToLower()) ||
                t.Localization.City.ToLower().Contains(SearchString.ToLower()) ||
                t.LevelClasses.Any(lc => lc.Name.ToLower().Contains(SearchString.ToLower())) ||
                t.Category.Name.ToLower().Contains(SearchString.ToLower()) ||
                    (t.OfferCreator.FirstName.ToLower().Contains(SearchString.ToLower()) ||
                    t.OfferCreator.LastName.ToLower().Contains(SearchString.ToLower()) ||
                    t.OfferCreator.Email.ToLower().Contains(SearchString.ToLower())) // etc. dla każdego pola w OfferCreator
                )
                .OrderByDescending(t => t.OfferId)
                .ToListAsync();

            return tableWithOffersResult;
        }
    }
}