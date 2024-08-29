using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using HotelProject.WebUI.Dtos.AppUserDto;

namespace HotelProject.WebUI.Controllers
{
    public class AdminUsersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> UserList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5200/api/AppUser/");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAppUserListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
