using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_Zespolowy.Data;
using Projekt_Zespolowy.Models;
using Projekt_Zespolowy.ViewModels;

namespace Projekt_Zespolowy.Controllers
{
	public class UserController : Controller
	{
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        public UserController(UserManager<User> userManager, ApplicationDbContext db, IHttpContextAccessor httpContextAccessor) 
		{ 
			_db = db;
			_httpContextAccessor = httpContextAccessor;
			_userManager = userManager;
		}

        public IActionResult UserPanel(string OfferCreatorId)
        {
            if (!string.IsNullOrEmpty(OfferCreatorId))
            {
                UserPanelVM vm = new UserPanelVM();
                vm.User = _db.Users
                    .Include(x => x.Offers)
                    .FirstOrDefault(i => i.Id == OfferCreatorId);

                vm.OpinionsList = _db.Opinions
                    .Where(i => i.UserId == OfferCreatorId)
                    .ToList();

                if (vm.User != null)
                {
                    return View(vm);
                }
                else
                {
                    return Redirect("~/"); 
                }
            }
            else
			{
               return Redirect("~/");
            }
        }
	}
}
