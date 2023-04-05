using Microsoft.AspNetCore.Mvc;
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
    }
}