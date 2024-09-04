using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using HotelProject.WebUI.Dtos.BookingDto;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5200/api/Booking/");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> ApprovedReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5200/api/Booking/UpdateReservationStatus?id={id}");
            if (response.IsSuccessStatusCode)
            {
                var bookingJsonData = await response.Content.ReadAsStringAsync();
                var booking = JsonConvert.DeserializeObject<UpdateBookingDto>(bookingJsonData);
                booking.Status = "Onaylandı";
                bookingJsonData = JsonConvert.SerializeObject(booking);
                StringContent stringContent = new StringContent(bookingJsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5200/api/Booking/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
