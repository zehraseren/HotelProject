using Microsoft.EntityFrameworkCore;
using HotelProject.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        public EfAppUserDal(Context context) : base(context)
        {
        }

        public List<AppUser> UserListWithWorkLocation()
        {
            var context = new Context();
            return context.Users.Include(x => x.WorkLocation).ToList();
        }
    }
}
