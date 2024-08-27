using HotelProject.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfMessageCategoryDal : GenericRepository<MessageCategory>, IMessageCategoryDal
    {
        public EfMessageCategoryDal(Context context) : base(context)
        {

        }
    }
}
