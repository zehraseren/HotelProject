using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelProject.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginUserDto ludto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(ludto.Username, ludto.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Staff");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}
