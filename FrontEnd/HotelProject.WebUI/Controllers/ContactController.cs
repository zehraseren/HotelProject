using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using HotelProject.WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelProject.WebUI.Dtos.MessageCategoryDto;

namespace HotelProject.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5200/api/MessageCategory/");

            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.MessageCategoryName,
                                                Value = x.MessageCategoryID.ToString()
                                            }).ToList();
            ViewBag.v = values2;
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto ccdto)
        {
            ccdto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(ccdto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5200/api/Contact/ ", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}
