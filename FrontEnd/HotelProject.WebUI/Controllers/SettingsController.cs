using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Setting;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel uevm = new UserEditViewModel();
            uevm.Name = user.Name;
            uevm.Surname = user.Surname;
            uevm.Email = user.Email;
            uevm.Username = user.UserName;
            return View(uevm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel uevm)
        {
            if (uevm.Password == uevm.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = uevm.Name;
                user.Surname = uevm.Surname;
                user.Email = uevm.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, uevm.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
