using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
	public class ConfirmController : Controller
	{
	    UserManager<AppUser> _userManager;

        public ConfirmController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index()
		{
			var value = TempData["Mail"];
			ViewBag.mail = value;
			//confirmMailViewModel.Mail = value.ToString();
			return View();
		}


		[HttpPost]
		public async Task <IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
		{
            
			var user = await _userManager.FindByEmailAsync(confirmMailViewModel.Mail);
			if (user.ConfirmCode==confirmMailViewModel.ConfirmCode) {
				user.EmailConfirmed = true;
				await _userManager.UpdateAsync(user);
				return RedirectToAction("Index","MyProfile");
			
			}
            return View();
        }
	}
}
