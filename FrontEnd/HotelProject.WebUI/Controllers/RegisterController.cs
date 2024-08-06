using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDto;

namespace HotelProject.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto cnudto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var appUser = new AppUser()
            {
                Name = cnudto.Name,
                Surname = cnudto.Surname,
                Email = cnudto.Mail,
                UserName = cnudto.Username,
            };
            var result = await _userManager.CreateAsync(appUser, cnudto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
