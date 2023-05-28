using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt_Zespolowy.Data;
using Projekt_Zespolowy.Models;
using Projekt_Zespolowy.ViewModels;
using System.Security.Claims;

namespace Projekt_Zespolowy.Controllers
{
    [Authorize]
    public class OffersController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public OffersVM OffertyVM { get; set; }

        public OffersController(UserManager<User> userManager, ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            var oferty = await _db.Offers
                .Include(o => o.OfferCreator)
                .Include(o => o.Localization)
                .ToListAsync();

            OffertyVM = new OffersVM {
                Oferty = oferty
            };

            return View(oferty);
        }

        public IActionResult Add()
        {
            AddOfferVM addOfferVM = new()
            {
                Category = _db.Categories.ToList(),
                LevelClass = _db.LevelClasses.ToList(),

            };
            return View(addOfferVM);
        }
        public async Task<IActionResult> AddOffer(AddOfferVM AddOfferVM)
        {

            var Offer = new Offer()
            {
                OfferName = AddOfferVM.Offer.OfferName,
                OfferDescription = AddOfferVM.Offer.OfferDescription,
                OfferCreator = _userManager.FindByNameAsync(_httpContextAccessor.HttpContext?.User.Identity?.Name).Result,
                Price = AddOfferVM.Offer.Price,
                IsOnline = AddOfferVM.Offer.IsOnline,
                Category = AddOfferVM.Offer.Category,
                LevelClasses = AddOfferVM.Offer.LevelClasses,
                Localization = AddOfferVM.Localization,
            };

            _db.Add(Offer);
            await _db.SaveChangesAsync();
            return Redirect("Add");
        }

        public async Task<IActionResult> ShowOffers()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var offers = await _db.Offers
                .Include(o => o.OfferCreator)
                .Include(o => o.Localization)
                .Where(o => o.OfferCreator.Id == userId)
                .ToListAsync();

            return View(offers);
        }

        public async Task<IActionResult> Delete(int OfferID)
        {
            var oferta = await _db.Offers.FindAsync(OfferID);

            if (oferta == null)
                return NotFound();

            _db.Offers.Remove(oferta);
            await _db.SaveChangesAsync();

            return Redirect("ShowOffers");
        }

        public async Task<IActionResult> OfferDetails(int OfferID)
        {
            var Offer = await _db.Offers
                .Include(o => o.OfferCreator)
                .Include(o => o.Localization)
                .Where(x => x.OfferId == OfferID)
                .FirstOrDefaultAsync();
            return View(Offer);
        }
    }
}
