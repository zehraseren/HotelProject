using HotelProject.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfWorkLocationDal : GenericRepository<WorkLocation>, IWorkLocationDal
    {
        public EfWorkLocationDal(Context context) : base(context)
        {
        }
    }
}
