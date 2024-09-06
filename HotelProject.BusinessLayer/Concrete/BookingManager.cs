using HotelProject.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;

namespace HotelProject.BusinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal ?? throw new ArgumentNullException(nameof(bookingDal));
        }

        public void TBookingStatusChangeApproved(int id)
        {
            _bookingDal.BookingStatusChangeApproved(id);
        }

        public void TBookingStatusChangeCancelled(int id)
        {
            _bookingDal.BookingStatusChangeCancelled(id);
        }

        public void TBookingStatusChangeWaiting(int id)
        {
            _bookingDal.BookingStatusChangeWaiting(id);
        }

        public void TDelete(Booking t)
        {
            _bookingDal.Delete(t);
        }

        public int TGetBookingCount()
        {
            return _bookingDal.GetBookingCount();
        }

        public Booking TGetByID(int id)
        {
            return _bookingDal.GetByID(id);
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public void TInsert(Booking t)
        {
            _bookingDal.Insert(t);
        }

        public List<Booking> TLast6Bookings()
        {
            return _bookingDal.Last6Bookings();
        }

        public void TUpdate(Booking t)
        {
            _bookingDal.Update(t);
        }
    }
}
