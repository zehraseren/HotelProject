using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IBookingService : IGenericService<Booking>
    {
        void TBookingStatusChangeApproved(int id);
        void TBookingStatusChangeCancelled(int id);
        void TBookingStatusChangeWaiting(int id);
        int TGetBookingCount();
        List<Booking> TLast6Bookings();
    }
}
