using Microsoft.AspNetCore.Mvc;
using HotelProject.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            _bookingService.TDelete(values);
            return Ok();
        }

        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            return Ok(values);
        }

        [HttpGet("Last6Bookings")]
        public IActionResult Last6Bookings()
        {
            var values = _bookingService.TLast6Bookings();
            return Ok(values);
        }

        [HttpGet("BookingApproved")]
        public IActionResult BookingApproved(int id)
        {
            _bookingService.TBookingStatusChangeApproved(id);
            return Ok();
        }

        [HttpGet("BookingCancelled")]
        public IActionResult BookingCancelled(int id)
        {
            _bookingService.TBookingStatusChangeCancelled(id);
            return Ok();
        }

        [HttpGet("BookingWaiting")]
        public IActionResult BookingWaiting(int id)
        {
            _bookingService.TBookingStatusChangeWaiting(id);
            return Ok();
        }
    }
}
