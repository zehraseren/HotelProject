using HotelProject.EntityLayer.Concrete;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IBookingDal : IGenericDal<Booking>
    {
        void BookingStatusChangeApproved(int id);
        void BookingStatusChangeCancelled(int id);
        void BookingStatusChangeWaiting(int id);
        int GetBookingCount();
        List<Booking> Last6Bookings();
    }
}
