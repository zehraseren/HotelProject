﻿using HotelProject.EntityLayer.Concrete;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Repositories;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfRoomDal : GenericRepository<Room>, IRoomDal
    {
        public EfRoomDal(Context context) : base(context) { }
    }
}
