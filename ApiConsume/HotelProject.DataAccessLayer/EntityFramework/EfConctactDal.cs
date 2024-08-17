using HotelProject.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Repositories;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfConctactDal : GenericRepository<Contact>, IContactDal
    {
        public EfConctactDal(Context context) : base(context)
        {

        }
    }
}
