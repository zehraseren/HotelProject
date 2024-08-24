using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<(int, int)> GetCount()
        {
            var client = _httpClientFactory.CreateClient();
            var response2 = await client.GetAsync("http://localhost:5200/api/Contact/GetContactCount/");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            var contactCount = int.Parse(jsonData2);

            var response3 = await client.GetAsync("http://localhost:5200/api/SendMessage/GetSendMessageCount/");
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            var sendMessageCount = int.Parse(jsonData3);

            return (contactCount, sendMessageCount);
        }

        public async Task<IActionResult> Inbox()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5200/api/Contact/");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                var (contactCount, sendMessageCount) = await GetCount();
                ViewBag.contactCount = contactCount;
                ViewBag.sendMessageCount = sendMessageCount;
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5200/api/SendMessage/");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendboxDto>>(jsonData);
                var (contactCount, sendMessageCount) = await GetCount();
                ViewBag.contactCount = contactCount;
                ViewBag.sendMessageCount = sendMessageCount;
                return View(values);
            }
            return View();
        }

        public PartialViewResult SidebarAdminContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto csmdto)
        {
            csmdto.SenderMail = "admin@gmail.com";
            csmdto.SenderName = "Admin";
            csmdto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(csmdto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5200/api/SendMessage/", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();
        }

        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5200/api/Contact/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(jsonData);
                var (contactCount, sendMessageCount) = await GetCount();
                ViewBag.contactCount = contactCount;
                ViewBag.sendMessageCount = sendMessageCount;
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> MessageDetailsBySendbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5200/api/SendMessage/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData);
                var (contactCount, sendMessageCount) = await GetCount();
                ViewBag.contactCount = contactCount;
                ViewBag.sendMessageCount = sendMessageCount;
                return View(values);
            }
            return View();
        }
    }
}
