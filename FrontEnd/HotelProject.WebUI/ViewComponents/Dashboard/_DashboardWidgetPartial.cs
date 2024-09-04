using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5200/api/DashboardWidgets/StaffCount/");
            var jsonData = await response.Content.ReadAsStringAsync();
            ViewBag.staffCount = jsonData;

            var client2 = _httpClientFactory.CreateClient();
            var response2 = await client2.GetAsync("http://localhost:5200/api/DashboardWidgets/BookingCount/");
            var jsonData2 = await response2.Content.ReadAsStringAsync();
            ViewBag.bookingCount = jsonData2;

            var client3 = _httpClientFactory.CreateClient();
            var response3 = await client3.GetAsync("http://localhost:5200/api/DashboardWidgets/AppUserCount/");
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            ViewBag.appUserCount = jsonData3;

            var client4 = _httpClientFactory.CreateClient();
            var response4 = await client4.GetAsync("http://localhost:5200/api/DashboardWidgets/RoomCount/");
            var jsonData4 = await response4.Content.ReadAsStringAsync();
            ViewBag.roomCount = jsonData4;

            return View();
        }
    }
}
