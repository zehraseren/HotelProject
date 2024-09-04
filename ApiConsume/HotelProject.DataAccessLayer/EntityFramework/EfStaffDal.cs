using HotelProject.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Repositories;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context) { }

        public int GetStaffCount()
        {
            using var context = new Context();
            var value = context.Staffs.Count();
            return value;
        }

        public List<Staff> Last4Staffs()
        {
            using var context = new Context();
            var values = context.Staffs.OrderByDescending(x => x.StaffID).Take(4).ToList(); ;
            return values;
        }
    }
}
