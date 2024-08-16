using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
