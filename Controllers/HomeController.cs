﻿using Microsoft.AspNetCore.Mvc;
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
        private async Task<List<Offer>> SearchInDbAsync(string SearchString)
        {
 

            var tableWithOffersResult = await _db.Offers
                .Include(o => o.Localization)
                .Include(o => o.LevelClasses)
                .Include(o => o.Category)
                .Where(t => t.OfferName.ToLower().Contains(SearchString.ToLower()) ||
                t.Localization.City.ToLower().Contains(SearchString.ToLower()) ||
                t.LevelClasses.Any(lc => lc.Name.ToLower().Contains(SearchString.ToLower())) ||
                t.Category.Name.ToLower().Contains(SearchString.ToLower()))
    .ToListAsync();
           

            return tableWithOffersResult;
        }
    }
}