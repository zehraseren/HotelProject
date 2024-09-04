using HotelProject.EntityLayer.Concrete;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;

namespace HotelProject.BusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _staffDal;

        public StaffManager(IStaffDal staffDal)
        {
            _staffDal = staffDal ?? throw new ArgumentNullException(nameof(staffDal));
        }

        public void TDelete(Staff t)
        {
            _staffDal.Delete(t);
        }

        public Staff TGetByID(int id)
        {
            return _staffDal.GetByID(id);
        }

        public List<Staff> TGetList()
        {
            return _staffDal.GetList();
        }

        public int TGetStaffCount()
        {
            return _staffDal.GetStaffCount();
        }

        public void TInsert(Staff t)
        {
            _staffDal.Insert(t);
        }

        public List<Staff> TLast4Staffs()
        {
            return _staffDal.Last4Staffs();
        }

        public void TUpdate(Staff t)
        {
            _staffDal.Update(t);
        }
    }
}
