using AutoMapper;
using HotelProject.EntityLayer.Concrete;
using HotelProject.DTOLayer.Dtos.RoomDto;

namespace HotelProject.WebAPI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>();
            CreateMap<Room, RoomAddDto>();

            CreateMap<UpdateRoomDto, Room>().ReverseMap();
        }
    }
}
